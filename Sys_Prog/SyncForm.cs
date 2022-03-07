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
        object reslocker = new();
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
            }
                if (Controls[Index] is TextBox)
                {
                    TextBox t = tbxs.First();
                    tbxs[Index].Text = Convert.ToString(result);
                    Index++;
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
            //ConsoleLog.Items.Add("Proc2 Start");
            Thread.Sleep(rnd.Next(100, 200));
            //ConsoleLog.Items.Add("Proc2 end");
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
    }
}
