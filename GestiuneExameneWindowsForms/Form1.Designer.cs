
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
            this.buttonAdaugaDate = new System.Windows.Forms.Button();
            this.buttonProgramareExamene = new System.Windows.Forms.Button();
            this.buttonStatistici = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.comboBoxListaFacultati = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelFacultateCurentSelectata = new System.Windows.Forms.Label();
            this.label_IDFacultateCurentSelectata = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAdaugaDate
            // 
            this.buttonAdaugaDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdaugaDate.Location = new System.Drawing.Point(58, 207);
            this.buttonAdaugaDate.Name = "buttonAdaugaDate";
            this.buttonAdaugaDate.Size = new System.Drawing.Size(178, 45);
            this.buttonAdaugaDate.TabIndex = 0;
            this.buttonAdaugaDate.Text = "Adauga Date";
            this.buttonAdaugaDate.UseVisualStyleBackColor = true;
            this.buttonAdaugaDate.Click += new System.EventHandler(this.buttonAdaugaDate_Click);
            // 
            // buttonProgramareExamene
            // 
            this.buttonProgramareExamene.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProgramareExamene.Location = new System.Drawing.Point(242, 207);
            this.buttonProgramareExamene.Name = "buttonProgramareExamene";
            this.buttonProgramareExamene.Size = new System.Drawing.Size(232, 45);
            this.buttonProgramareExamene.TabIndex = 1;
            this.buttonProgramareExamene.Text = "Programare Examene";
            this.buttonProgramareExamene.UseVisualStyleBackColor = true;
            this.buttonProgramareExamene.Click += new System.EventHandler(this.buttonProgramareExamene_Click);
            // 
            // buttonStatistici
            // 
            this.buttonStatistici.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStatistici.Location = new System.Drawing.Point(480, 207);
            this.buttonStatistici.Name = "buttonStatistici";
            this.buttonStatistici.Size = new System.Drawing.Size(206, 45);
            this.buttonStatistici.TabIndex = 2;
            this.buttonStatistici.Text = "Statistici si rapoarte";
            this.buttonStatistici.UseVisualStyleBackColor = true;
            this.buttonStatistici.Click += new System.EventHandler(this.buttonStatistici_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(627, 439);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(101, 43);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Iesire";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // comboBoxListaFacultati
            // 
            this.comboBoxListaFacultati.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListaFacultati.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxListaFacultati.FormattingEnabled = true;
            this.comboBoxListaFacultati.Location = new System.Drawing.Point(58, 127);
            this.comboBoxListaFacultati.Name = "comboBoxListaFacultati";
            this.comboBoxListaFacultati.Size = new System.Drawing.Size(628, 32);
            this.comboBoxListaFacultati.TabIndex = 4;
            this.comboBoxListaFacultati.SelectedIndexChanged += new System.EventHandler(this.facultateForm1_selectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(281, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Alegeti facultatea:";
            // 
            // labelFacultateCurentSelectata
            // 
            this.labelFacultateCurentSelectata.AutoSize = true;
            this.labelFacultateCurentSelectata.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFacultateCurentSelectata.Location = new System.Drawing.Point(54, 368);
            this.labelFacultateCurentSelectata.Name = "labelFacultateCurentSelectata";
            this.labelFacultateCurentSelectata.Size = new System.Drawing.Size(24, 24);
            this.labelFacultateCurentSelectata.TabIndex = 6;
            this.labelFacultateCurentSelectata.Text = "X";
            this.labelFacultateCurentSelectata.Visible = false;
            // 
            // label_IDFacultateCurentSelectata
            // 
            this.label_IDFacultateCurentSelectata.AutoSize = true;
            this.label_IDFacultateCurentSelectata.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IDFacultateCurentSelectata.Location = new System.Drawing.Point(54, 413);
            this.label_IDFacultateCurentSelectata.Name = "label_IDFacultateCurentSelectata";
            this.label_IDFacultateCurentSelectata.Size = new System.Drawing.Size(24, 24);
            this.label_IDFacultateCurentSelectata.TabIndex = 7;
            this.label_IDFacultateCurentSelectata.Text = "X";
            this.label_IDFacultateCurentSelectata.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 494);
            this.Controls.Add(this.label_IDFacultateCurentSelectata);
            this.Controls.Add(this.labelFacultateCurentSelectata);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxListaFacultati);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonStatistici);
            this.Controls.Add(this.buttonProgramareExamene);
            this.Controls.Add(this.buttonAdaugaDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Gestiune Examene";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdaugaDate;
        private System.Windows.Forms.Button buttonProgramareExamene;
        private System.Windows.Forms.Button buttonStatistici;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ComboBox comboBoxListaFacultati;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFacultateCurentSelectata;
        private System.Windows.Forms.Label label_IDFacultateCurentSelectata;
    }
}

