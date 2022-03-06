﻿using System;
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
        private void AddPercent(object month)
        {
            List<TextBox> tbxs = this.Controls.OfType<TextBox>()
                .Where(x => x.Name.Contains("textBox")).ToList();
            tbxs.Reverse();
            lock (reslocker)
            {

                double tmp = result;
                Thread.Sleep(rnd.Next(100, 200));
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
    }
}
