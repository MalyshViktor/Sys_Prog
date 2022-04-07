namespace Sys_Prog
{
    partial class DllForm
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
            this.buttonAlert = new System.Windows.Forms.Button();
            this.buttonError = new System.Windows.Forms.Button();
            this.buttonWarning = new System.Windows.Forms.Button();
            this.buttonQuestion = new System.Windows.Forms.Button();
            this.buttonReverse = new System.Windows.Forms.Button();
            this.buttonSingleSpace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAlert
            // 
            this.buttonAlert.Location = new System.Drawing.Point(27, 49);
            this.buttonAlert.Name = "buttonAlert";
            this.buttonAlert.Size = new System.Drawing.Size(75, 23);
            this.buttonAlert.TabIndex = 0;
            this.buttonAlert.Text = "Alert";
            this.buttonAlert.UseVisualStyleBackColor = true;
            this.buttonAlert.Click += new System.EventHandler(this.buttonAlert_Click);
            // 
            // buttonError
            // 
            this.buttonError.Location = new System.Drawing.Point(27, 104);
            this.buttonError.Name = "buttonError";
            this.buttonError.Size = new System.Drawing.Size(75, 23);
            this.buttonError.TabIndex = 1;
            this.buttonError.Text = "Error";
            this.buttonError.UseVisualStyleBackColor = true;
            this.buttonError.Click += new System.EventHandler(this.buttonError_Click);
            // 
            // buttonWarning
            // 
            this.buttonWarning.Location = new System.Drawing.Point(27, 155);
            this.buttonWarning.Name = "buttonWarning";
            this.buttonWarning.Size = new System.Drawing.Size(75, 23);
            this.buttonWarning.TabIndex = 2;
            this.buttonWarning.Text = "Warning";
            this.buttonWarning.UseVisualStyleBackColor = true;
            this.buttonWarning.Click += new System.EventHandler(this.buttonWarning_Click);
            // 
            // buttonQuestion
            // 
            this.buttonQuestion.Location = new System.Drawing.Point(27, 212);
            this.buttonQuestion.Name = "buttonQuestion";
            this.buttonQuestion.Size = new System.Drawing.Size(75, 23);
            this.buttonQuestion.TabIndex = 3;
            this.buttonQuestion.Text = "Question";
            this.buttonQuestion.UseVisualStyleBackColor = true;
            this.buttonQuestion.Click += new System.EventHandler(this.buttonQuestion_Click);
            // 
            // buttonReverse
            // 
            this.buttonReverse.Location = new System.Drawing.Point(154, 49);
            this.buttonReverse.Name = "buttonReverse";
            this.buttonReverse.Size = new System.Drawing.Size(110, 23);
            this.buttonReverse.TabIndex = 4;
            this.buttonReverse.Text = "Reverse";
            this.buttonReverse.UseVisualStyleBackColor = true;
            this.buttonReverse.Click += new System.EventHandler(this.buttonReverse_Click_1);
            // 
            // buttonSingleSpace
            // 
            this.buttonSingleSpace.Location = new System.Drawing.Point(154, 104);
            this.buttonSingleSpace.Name = "buttonSingleSpace";
            this.buttonSingleSpace.Size = new System.Drawing.Size(110, 23);
            this.buttonSingleSpace.TabIndex = 5;
            this.buttonSingleSpace.Text = "SingleSpace";
            this.buttonSingleSpace.UseVisualStyleBackColor = true;
            this.buttonSingleSpace.Click += new System.EventHandler(this.buttonSingleSpace_Click_1);
            // 
            // DllForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSingleSpace);
            this.Controls.Add(this.buttonReverse);
            this.Controls.Add(this.buttonQuestion);
            this.Controls.Add(this.buttonWarning);
            this.Controls.Add(this.buttonError);
            this.Controls.Add(this.buttonAlert);
            this.Name = "DllForm";
            this.Text = "DllForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAlert;
        private System.Windows.Forms.Button buttonError;
        private System.Windows.Forms.Button buttonWarning;
        private System.Windows.Forms.Button buttonQuestion;
        private System.Windows.Forms.Button buttonReverse;
        private System.Windows.Forms.Button buttonSingleSpace;
    }
}