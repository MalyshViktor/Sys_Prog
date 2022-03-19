namespace Sys_Prog
{
    partial class Sync_Async
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonTask = new System.Windows.Forms.Button();
            this.buttonTaskResult = new System.Windows.Forms.Button();
            this.buttonAsyncAwait = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(364, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(210, 304);
            this.listBox1.TabIndex = 0;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(34, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(89, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Invoke";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonTask
            // 
            this.buttonTask.Location = new System.Drawing.Point(34, 53);
            this.buttonTask.Name = "buttonTask";
            this.buttonTask.Size = new System.Drawing.Size(89, 23);
            this.buttonTask.TabIndex = 2;
            this.buttonTask.Text = "Task";
            this.buttonTask.UseVisualStyleBackColor = true;
            this.buttonTask.Click += new System.EventHandler(this.buttonTask_Click);
            // 
            // buttonTaskResult
            // 
            this.buttonTaskResult.Location = new System.Drawing.Point(34, 95);
            this.buttonTaskResult.Name = "buttonTaskResult";
            this.buttonTaskResult.Size = new System.Drawing.Size(89, 23);
            this.buttonTaskResult.TabIndex = 3;
            this.buttonTaskResult.Text = "Task Result";
            this.buttonTaskResult.UseVisualStyleBackColor = true;
            this.buttonTaskResult.Click += new System.EventHandler(this.buttonTaskResult_Click);
            // 
            // buttonAsyncAwait
            // 
            this.buttonAsyncAwait.Location = new System.Drawing.Point(34, 138);
            this.buttonAsyncAwait.Name = "buttonAsyncAwait";
            this.buttonAsyncAwait.Size = new System.Drawing.Size(89, 23);
            this.buttonAsyncAwait.TabIndex = 4;
            this.buttonAsyncAwait.Text = "Async Await";
            this.buttonAsyncAwait.UseVisualStyleBackColor = true;
            this.buttonAsyncAwait.Click += new System.EventHandler(this.buttonAsyncAwait_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Sync_Async
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAsyncAwait);
            this.Controls.Add(this.buttonTaskResult);
            this.Controls.Add(this.buttonTask);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listBox1);
            this.Name = "Sync_Async";
            this.Text = "Sync_Async";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonTask;
        private System.Windows.Forms.Button buttonTaskResult;
        private System.Windows.Forms.Button buttonAsyncAwait;
        private System.Windows.Forms.Button button1;
    }
}