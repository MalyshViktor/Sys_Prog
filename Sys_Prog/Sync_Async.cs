using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sys_Prog
{
    public partial class Sync_Async : Form
    {
        public Sync_Async()
        {
            InitializeComponent();
        }
        #region SyncMethod
        private String SyncMethod(String name)
        {
            Invoke(new Action(
                () => { listBox1.Items.Add($"Hello, { name}"); }));
            return "Hello";
        }
        private delegate String SyncInvoker(String name);
        private void buttonStart_Click(object sender, EventArgs e)
        {
            var syncInvoker = new SyncInvoker(SyncMethod);
            var act = syncInvoker.BeginInvoke("User", null, null);
            //произвольный код, выполняющийся параллельно с SyncMethod

            String res = syncInvoker.EndInvoke(null);//в этом месте ожидается окончание SyncMethod
        }

        private void buttonTask_Click(object sender, EventArgs e)
        {
            var act = Task.Run(() => SyncMethod("User"));
            //act.Wait(); зависание - SyncMethod через Invoke обращается к форме
            //, заблокированной командой act.Wait(), то есть зависает
            act.ContinueWith(                       //назначение callback-a
                task =>                             //в него будет передан отработавший Task
                MessageBox.Show(task.Result));      //task.Result - результат возврата SyncMethod
        }                                           //
        #endregion
        private Task<String> taskResult(String name)
        {
            return Task.Run(() => $"Hello, {name}");
        }
        private void buttonTaskResult_Click(object sender, EventArgs e)
        {
            //Stopwatch stopwatch = Stopwatch.StartNew();//секундомер
            var trU = taskResult("User");
            listBox1.Items.Add(trU.Result);

            
            //var trA = taskResult("Admin");

            //listBox1.Items.Add(trU.Result);
            //listBox1.Items.Add(trA.Result);
            //stopwatch.Stop();
        }

        private async Task<String> HelloAsync(String name)
        {
            await Task.Delay(500);
            return $"Hello, {name}";
        }
        private async void buttonAsyncAwait_Click(object sender, EventArgs e)
        {
            var greeting = HelloAsync("Admin");
            await (greeting);
        }
    }
}
