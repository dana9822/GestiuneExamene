
namespace GestiuneExameneWindowsForms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonAdaugaDate = new System.Windows.Forms.Button();
            this.buttonProgramareExamene = new System.Windows.Forms.Button();
            this.buttonStatistici = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAdaugaDate
            // 
            this.buttonAdaugaDate.Location = new System.Drawing.Point(42, 102);
            this.buttonAdaugaDate.Name = "buttonAdaugaDate";
            this.buttonAdaugaDate.Size = new System.Drawing.Size(126, 45);
            this.buttonAdaugaDate.TabIndex = 0;
            this.buttonAdaugaDate.Text = "Adauga Date";
            this.buttonAdaugaDate.UseVisualStyleBackColor = true;
            this.buttonAdaugaDate.Click += new System.EventHandler(this.buttonAdaugaDate_Click);
            // 
            // buttonProgramareExamene
            // 
            this.buttonProgramareExamene.Location = new System.Drawing.Point(174, 102);
            this.buttonProgramareExamene.Name = "buttonProgramareExamene";
            this.buttonProgramareExamene.Size = new System.Drawing.Size(128, 45);
            this.buttonProgramareExamene.TabIndex = 1;
            this.buttonProgramareExamene.Text = "Programare Examene";
            this.buttonProgramareExamene.UseVisualStyleBackColor = true;
            this.buttonProgramareExamene.Click += new System.EventHandler(this.buttonProgramareExamene_Click);
            // 
            // buttonStatistici
            // 
            this.buttonStatistici.Location = new System.Drawing.Point(309, 102);
            this.buttonStatistici.Name = "buttonStatistici";
            this.buttonStatistici.Size = new System.Drawing.Size(128, 45);
            this.buttonStatistici.TabIndex = 2;
            this.buttonStatistici.Text = "Statistici si rapoarte";
            this.buttonStatistici.UseVisualStyleBackColor = true;
            this.buttonStatistici.Click += new System.EventHandler(this.buttonStatistici_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(392, 224);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Iesire";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(479, 259);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonStatistici);
            this.Controls.Add(this.buttonProgramareExamene);
            this.Controls.Add(this.buttonAdaugaDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Gestiune Examene";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAdaugaDate;
        private System.Windows.Forms.Button buttonProgramareExamene;
        private System.Windows.Forms.Button buttonStatistici;
        private System.Windows.Forms.Button buttonExit;
    }
}

