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
    public partial class Form1 : Form
    {
        private bool stopPressed;
        private Thread progressThread;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            stopPressed = false;
            if (progressThread == null)
            {
                progressThread = new Thread(ShowProgress); //создание обьекта - потока
                progressThread.Start(); //начало выполнения потока
            }

        }

        private void ShowProgress()
        {

            for (int i = 0; i <= 10; i++)
            {
                this.Invoke(
                    new Action(
                        ()=> {
                            progressBar1.Value = i * 10; 
                }));
                Thread.Sleep(500);
                if (stopPressed)
                {
                    progressThread = null;
                    break;
                } 
            }
            progressThread = null;
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            stopPressed = true;
        }

        private Thread progressThread2 = null;
        private void ShowProgress2(object pauseTime)
        {
            int pTime = Convert.ToInt32(pauseTime);
            for (int i = 0; i <= 10; i++)
            {
                this.Invoke(
                    new Action(
                        () =>
                        {
                            progressBar1.Value = i * 10;
                        }));
                Thread.Sleep(pTime);
                if (stopPressed)
                {
                    progressThread = null;
                    break;
                }
            }
            progressThread2 = null;
        }
        private void buttonStart2_Click(object sender, EventArgs e)
        {
            stopPressed = false;
            if (progressThread2 == null && progressThread == null)
            {
                progressThread2 = new Thread(ShowProgress2);
                progressThread2.Start(300);
            }
            
            
        }

        private void buttonStop2_Click(object sender, EventArgs e)
        {
            stopPressed = true;
        }

        private CancellationTokenSource cts;

        private void buttonStart3_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            new Thread(ShowProgress4).Start(cts.Token);
        }
        
        private void buttonStop3_Click(object sender, EventArgs e)
        {
            cts?.Cancel();

        }

        private void ShowProgress3(object obj)
        {
            CancellationToken token = (CancellationToken)obj;
            for (int i = 0; i <= 10; i++)
            {
                this.Invoke(
                    new Action(
                        () => {
                            progressBar1.Value = i * 10;
                        }));
                Thread.Sleep(500);
                if (token.IsCancellationRequested)
                {
                    break;
                }
            }
        }
        private void ShowProgress4(object obj)
        {
            try
            {
                CancellationToken token = (CancellationToken)obj;
                for (int i = 0; i <= 10; i++)
                {
                    this.Invoke(
                        new Action(
                            () =>
                            {
                                progressBar1.Value = i * 10;
                            }));
                    Thread.Sleep(500);
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Test");
            }
        }

    }
}
