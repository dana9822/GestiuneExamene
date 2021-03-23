
namespace GestiuneExameneWindowsForms
{
    partial class ScheduleExamForm
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
            this.buttonScheduleExamBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonScheduleExamBack
            // 
            this.buttonScheduleExamBack.Location = new System.Drawing.Point(683, 400);
            this.buttonScheduleExamBack.Name = "buttonScheduleExamBack";
            this.buttonScheduleExamBack.Size = new System.Drawing.Size(105, 38);
            this.buttonScheduleExamBack.TabIndex = 0;
            this.buttonScheduleExamBack.Text = "Inapoi";
            this.buttonScheduleExamBack.UseVisualStyleBackColor = true;
            this.buttonScheduleExamBack.Click += new System.EventHandler(this.buttonScheduleExamBack_Click);
            // 
            // ScheduleExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonScheduleExamBack);
            this.Name = "ScheduleExamForm";
            this.Text = "ScheduleExamForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonScheduleExamBack;
    }
}