using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sys_Prog
{
    public partial class SyncForm : Form
    {
        private Random rnd = new();


        public SyncForm()
        {
            InitializeComponent();
            Log = new Action<string>(log);

        }
        #region Threads
        private void buttonStart_Click(object sender, EventArgs e)
        {
            result = 100;
            ConsoleLog.Items.Add("Start...");
            for (int i = 1; i <= 12; i++)
            {
                new Thread(AddPercent).Start(i);
            }


        }
        double result;
        int Index = 0;
        object reslocker = new ();
        Action<String> Log;
        private void AddPercent(object month)
        {
            List<TextBox> tbxs = this.Controls.OfType<TextBox>()
                .Where(x => x.Name.Contains("textBox")).ToList();
            tbxs.Reverse();
            lock (reslocker)
            {

                double tmp = result;
                //Thread.Sleep(rnd.Next(100, 200));
                tmp *= 1.1;
                result = tmp;

                Invoke(new Action(
                    () => ConsoleLog.Items.Add(
                        String.Format(
                            "{0} - {1}",
                            Convert.ToInt32(month),
                            result))));

                if (Controls[Index] is TextBox)
                {
                    TextBox t = tbxs.First();
                    tbxs[Index].Text = Convert.ToString(result);
                    Index++;
                }
            }
        }


        private void log(String str)
        {
            ConsoleLog.Items.Add(str);
        }

        Thread t1;
        private void Proc1()
        {
            this.Invoke(Log, new object[] { "Proc1 start" });
            //ConsoleLog.Items.Add("Proc1 Start");
            Thread.Sleep(rnd.Next(100, 200));
            //ConsoleLog.Items.Add("Proc1 end");
            Invoke(Log, new object[] { "Proc1 end" });
        }

        private void Proc2()
        {
            Invoke(Log, new object[] { "Proc2 start" });
            Thread.Sleep(rnd.Next(100, 200));
            Invoke(Log, new object[] { "Proc2 end" });
        }

        private void Proc3()
        {
            t1.Join();//await t1 аналог
            Invoke(Log, new object[] { "Proc3 start" });

            Thread.Sleep(rnd.Next(100, 200));

            Invoke(Log, new object[] { "Proc3 end" });
        }
        private void buttonSchemel1_Click(object sender, EventArgs e)
        {
            new Thread(Proc1).Start();
            new Thread(Proc2).Start();
        }

        private void buttonScheme2_Click(object sender, EventArgs e)
        {
            t1 = new Thread(Proc1);
            t1.Start();
            new Thread(Proc3).Start();
        }

        delegate void callback();
        private int cnt;
        

        private void Proc4(object obj)
        {

            var cb = (callback)obj;
                Invoke(Log, new object[] { "Proc4 start" });

                Thread.Sleep(rnd.Next(100, 200));

                Invoke(Log, new object[] { "Proc4 end" });
                cnt--;
                if (cnt == 0) cb();

        }

       
        private void Proc5(object obj)
        {

                var cb = (callback)obj;
                Invoke(Log, new object[] { "Proc5 start" });

                Thread.Sleep(rnd.Next(100, 200));

                Invoke(Log, new object[] { "Proc5 end" });
                cnt--;
                if (cnt == 0) cb();

        }
        private void fin()
        {
            Invoke(Log, new object[] { "Callback - fin" });
        }

        int tmp;
        private void buttonScheme3_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBoxThreads.Text, out tmp))
            {
                cnt = tmp;
            }
            callback f = fin;
           for (int i = cnt; i > 0; i--)
            {
                new Thread(Proc4).Start(f);

            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ConsoleLog.Items.Clear();
        }

        char[] digits = new char[10];

        private void AddDigit(object? d)
        {
            //d->int
            int digit = 0;
            String str = String.Empty;
            try
            {
                digit = Convert.ToInt32(d);
            }
            catch
            {
                Invoke(new Action(() => ConsoleLog.Items.Add("Parse exception")));
                return;
            }
            if (digit < 0 || digit > 9)
            {
                Invoke(new Action(() => ConsoleLog.Items.Add("Digit invalid")));
                return;
            }
            lock (reslocker)
            {
                //int -> char;
                char symbol = (char)(digit + '0');
                //place in array
                digits[digit] = symbol;
                //form string(---3---6-----)
                foreach (var item in digits)
                {
                    if (item == '\0')
                        str += "-";
                    else
                        str += item;
                }     
            //display string (consoleLog)
            }
            Invoke(new Action(() => ConsoleLog.Items.Add(str)));

            


        }
        private void buttonDigits_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                digits[i] = '\0';
            }
            for (int i = 0; i < 10; i++)
            {
                new Thread(AddDigit).Start(i);

            }
        }

        /*Задача сформировать массив символов (char) цифр 0123...9
         * после каждого добавления цифры выводить результат
         * (___3_______)
         * (1__3_______)
         * */
        #endregion

        #region Thread Pool
        String str = String.Empty;
        private readonly object strlocker = new();
        private void Logs()
        {
            ConsoleLog.Items.Add(str);
        }
        private void PoolProc1(object? param)
        {
            if (param == null) return;
            lock (strlocker)
            {
                str = param.ToString()!;
                Invoke((Action)Logs);
            }
        }
        private void buttonPool1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(PoolProc1, i);
            }
        }

        private CancellationTokenSource cts = new CancellationTokenSource();
        private void PoolProc2(object? param)
        {
            if (param == null) return;
            var threadData = param as ThreadData;
            str = "Start " + threadData.id;
            Invoke((Action)Logs);
        }

        private void buttonPool2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(PoolProc2, new ThreadData { id = i, Token = cts.Token });
            }
        }

        private void buttonPool2Stop_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
        #endregion

        class ThreadData
        {
            public int id { get; set; }

            public CancellationToken Token { get; set; }

        
        }
    }
}
