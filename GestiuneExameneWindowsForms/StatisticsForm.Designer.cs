
namespace GestiuneExameneWindowsForms
{
    partial class StatisticsForm
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
            this.buttonStatisticsBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStatisticsBack
            // 
            this.buttonStatisticsBack.Location = new System.Drawing.Point(682, 394);
            this.buttonStatisticsBack.Name = "buttonStatisticsBack";
            this.buttonStatisticsBack.Size = new System.Drawing.Size(106, 44);
            this.buttonStatisticsBack.TabIndex = 0;
            this.buttonStatisticsBack.Text = "Inapoi";
            this.buttonStatisticsBack.UseVisualStyleBackColor = true;
            this.buttonStatisticsBack.Click += new System.EventHandler(this.buttonStatisticsBack_Click);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStatisticsBack);
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStatisticsBack;
    }
}