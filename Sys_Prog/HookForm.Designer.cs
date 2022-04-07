namespace Sys_Prog
{
    partial class HookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonStartKB = new System.Windows.Forms.Button();
            this.buttonStopKB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(253, 21);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(232, 379);
            this.listBox1.TabIndex = 0;
            // 
            // buttonStartKB
            // 
            this.buttonStartKB.Location = new System.Drawing.Point(60, 21);
            this.buttonStartKB.Name = "buttonStartKB";
            this.buttonStartKB.Size = new System.Drawing.Size(99, 23);
            this.buttonStartKB.TabIndex = 1;
            this.buttonStartKB.Text = "Start Keyboard";
            this.buttonStartKB.UseVisualStyleBackColor = true;
            this.buttonStartKB.Click += new System.EventHandler(this.buttonStartKB_Click);
            // 
            // buttonStopKB
            // 
            this.buttonStopKB.Location = new System.Drawing.Point(60, 66);
            this.buttonStopKB.Name = "buttonStopKB";
            this.buttonStopKB.Size = new System.Drawing.Size(99, 23);
            this.buttonStopKB.TabIndex = 2;
            this.buttonStopKB.Text = "Stop Keyboard";
            this.buttonStopKB.UseVisualStyleBackColor = true;
            this.buttonStopKB.Click += new System.EventHandler(this.buttonStopKB_Click);
            // 
            // HookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStopKB);
            this.Controls.Add(this.buttonStartKB);
            this.Controls.Add(this.listBox1);
            this.Name = "HookForm";
            this.Text = "HookForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonStartKB;
        private System.Windows.Forms.Button buttonStopKB;
    }
}