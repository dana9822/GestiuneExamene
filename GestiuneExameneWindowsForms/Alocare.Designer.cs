
namespace GestiuneExameneWindowsForms
{
    partial class Alocare
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
            this.buttonAlocaDisciplina = new System.Windows.Forms.Button();
            this.groupBoxAlocareDiscStatus = new System.Windows.Forms.GroupBox();
            this.radioButtonInactiv = new System.Windows.Forms.RadioButton();
            this.radioButtonActiv = new System.Windows.Forms.RadioButton();
            this.groupBoxAlocDiscTipEvaluare = new System.Windows.Forms.GroupBox();
            this.radioButtonExamen = new System.Windows.Forms.RadioButton();
            this.radioButtonVerificare = new System.Windows.Forms.RadioButton();
            this.groupBoxAlocDiscSemestru = new System.Windows.Forms.GroupBox();
            this.radioButtonSem2 = new System.Windows.Forms.RadioButton();
            this.radioButtonSem1 = new System.Windows.Forms.RadioButton();
            this.comboBoxDropDownListAlocareDiscAnStudiuList = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBoxDropDownListAlocareDisSpecList = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label_DisciplinaAdaugata = new System.Windows.Forms.Label();
            this.groupBoxAlocareDiscStatus.SuspendLayout();
            this.groupBoxAlocDiscTipEvaluare.SuspendLayout();
            this.groupBoxAlocDiscSemestru.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAlocaDisciplina
            // 
            this.buttonAlocaDisciplina.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlocaDisciplina.Location = new System.Drawing.Point(290, 340);
            this.buttonAlocaDisciplina.Name = "buttonAlocaDisciplina";
            this.buttonAlocaDisciplina.Size = new System.Drawing.Size(195, 32);
            this.buttonAlocaDisciplina.TabIndex = 20;
            this.buttonAlocaDisciplina.Text = "Aloca disciplina";
            this.buttonAlocaDisciplina.UseVisualStyleBackColor = true;
            this.buttonAlocaDisciplina.Click += new System.EventHandler(this.buttonAlocaDisciplina_Click);
            // 
            // groupBoxAlocareDiscStatus
            // 
            this.groupBoxAlocareDiscStatus.Controls.Add(this.radioButtonInactiv);
            this.groupBoxAlocareDiscStatus.Controls.Add(this.radioButtonActiv);
            this.groupBoxAlocareDiscStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAlocareDiscStatus.Location = new System.Drawing.Point(252, 284);
            this.groupBoxAlocareDiscStatus.Name = "groupBoxAlocareDiscStatus";
            this.groupBoxAlocareDiscStatus.Size = new System.Drawing.Size(265, 50);
            this.groupBoxAlocareDiscStatus.TabIndex = 19;
            this.groupBoxAlocareDiscStatus.TabStop = false;
            this.groupBoxAlocareDiscStatus.Text = "Status";
            // 
            // radioButtonInactiv
            // 
            this.radioButtonInactiv.AutoSize = true;
            this.radioButtonInactiv.Location = new System.Drawing.Point(134, 18);
            this.radioButtonInactiv.Name = "radioButtonInactiv";
            this.radioButtonInactiv.Size = new System.Drawing.Size(80, 28);
            this.radioButtonInactiv.TabIndex = 1;
            this.radioButtonInactiv.Text = "Inactiv";
            this.radioButtonInactiv.UseVisualStyleBackColor = true;
            // 
            // radioButtonActiv
            // 
            this.radioButtonActiv.AutoSize = true;
            this.radioButtonActiv.Checked = true;
            this.radioButtonActiv.Location = new System.Drawing.Point(7, 18);
            this.radioButtonActiv.Name = "radioButtonActiv";
            this.radioButtonActiv.Size = new System.Drawing.Size(68, 28);
            this.radioButtonActiv.TabIndex = 0;
            this.radioButtonActiv.TabStop = true;
            this.radioButtonActiv.Text = "Activ";
            this.radioButtonActiv.UseVisualStyleBackColor = true;
            // 
            // groupBoxAlocDiscTipEvaluare
            // 
            this.groupBoxAlocDiscTipEvaluare.Controls.Add(this.radioButtonExamen);
            this.groupBoxAlocDiscTipEvaluare.Controls.Add(this.radioButtonVerificare);
            this.groupBoxAlocDiscTipEvaluare.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAlocDiscTipEvaluare.Location = new System.Drawing.Point(252, 222);
            this.groupBoxAlocDiscTipEvaluare.Name = "groupBoxAlocDiscTipEvaluare";
            this.groupBoxAlocDiscTipEvaluare.Size = new System.Drawing.Size(265, 58);
            this.groupBoxAlocDiscTipEvaluare.TabIndex = 18;
            this.groupBoxAlocDiscTipEvaluare.TabStop = false;
            this.groupBoxAlocDiscTipEvaluare.Text = "Tip evaluare";
            // 
            // radioButtonExamen
            // 
            this.radioButtonExamen.AutoSize = true;
            this.radioButtonExamen.Location = new System.Drawing.Point(134, 28);
            this.radioButtonExamen.Name = "radioButtonExamen";
            this.radioButtonExamen.Size = new System.Drawing.Size(99, 28);
            this.radioButtonExamen.TabIndex = 1;
            this.radioButtonExamen.Text = "Examen";
            this.radioButtonExamen.UseVisualStyleBackColor = true;
            // 
            // radioButtonVerificare
            // 
            this.radioButtonVerificare.AutoSize = true;
            this.radioButtonVerificare.Checked = true;
            this.radioButtonVerificare.Location = new System.Drawing.Point(7, 28);
            this.radioButtonVerificare.Name = "radioButtonVerificare";
            this.radioButtonVerificare.Size = new System.Drawing.Size(107, 28);
            this.radioButtonVerificare.TabIndex = 0;
            this.radioButtonVerificare.TabStop = true;
            this.radioButtonVerificare.Text = "Verificare";
            this.radioButtonVerificare.UseVisualStyleBackColor = true;
            // 
            // groupBoxAlocDiscSemestru
            // 
            this.groupBoxAlocDiscSemestru.Controls.Add(this.radioButtonSem2);
            this.groupBoxAlocDiscSemestru.Controls.Add(this.radioButtonSem1);
            this.groupBoxAlocDiscSemestru.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAlocDiscSemestru.Location = new System.Drawing.Point(252, 158);
            this.groupBoxAlocDiscSemestru.Name = "groupBoxAlocDiscSemestru";
            this.groupBoxAlocDiscSemestru.Size = new System.Drawing.Size(265, 58);
            this.groupBoxAlocDiscSemestru.TabIndex = 17;
            this.groupBoxAlocDiscSemestru.TabStop = false;
            this.groupBoxAlocDiscSemestru.Text = "Semestru";
            // 
            // radioButtonSem2
            // 
            this.radioButtonSem2.AutoSize = true;
            this.radioButtonSem2.Location = new System.Drawing.Point(134, 29);
            this.radioButtonSem2.Name = "radioButtonSem2";
            this.radioButtonSem2.Size = new System.Drawing.Size(125, 28);
            this.radioButtonSem2.TabIndex = 1;
            this.radioButtonSem2.Text = "Semestrul II";
            this.radioButtonSem2.UseVisualStyleBackColor = true;
            // 
            // radioButtonSem1
            // 
            this.radioButtonSem1.AutoSize = true;
            this.radioButtonSem1.Checked = true;
            this.radioButtonSem1.Location = new System.Drawing.Point(7, 29);
            this.radioButtonSem1.Name = "radioButtonSem1";
            this.radioButtonSem1.Size = new System.Drawing.Size(121, 28);
            this.radioButtonSem1.TabIndex = 0;
            this.radioButtonSem1.TabStop = true;
            this.radioButtonSem1.Text = "Semestrul I";
            this.radioButtonSem1.UseVisualStyleBackColor = true;
            // 
            // comboBoxDropDownListAlocareDiscAnStudiuList
            // 
            this.comboBoxDropDownListAlocareDiscAnStudiuList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDropDownListAlocareDiscAnStudiuList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDropDownListAlocareDiscAnStudiuList.FormattingEnabled = true;
            this.comboBoxDropDownListAlocareDiscAnStudiuList.Location = new System.Drawing.Point(252, 120);
            this.comboBoxDropDownListAlocareDiscAnStudiuList.Name = "comboBoxDropDownListAlocareDiscAnStudiuList";
            this.comboBoxDropDownListAlocareDiscAnStudiuList.Size = new System.Drawing.Size(265, 32);
            this.comboBoxDropDownListAlocareDiscAnStudiuList.TabIndex = 16;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(152, 120);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 24);
            this.label21.TabIndex = 15;
            this.label21.Text = "An studiu:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(151, 82);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 24);
            this.label20.TabIndex = 13;
            this.label20.Text = "Disciplina:";
            // 
            // comboBoxDropDownListAlocareDisSpecList
            // 
            this.comboBoxDropDownListAlocareDisSpecList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDropDownListAlocareDisSpecList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDropDownListAlocareDisSpecList.FormattingEnabled = true;
            this.comboBoxDropDownListAlocareDisSpecList.Location = new System.Drawing.Point(252, 44);
            this.comboBoxDropDownListAlocareDisSpecList.Name = "comboBoxDropDownListAlocareDisSpecList";
            this.comboBoxDropDownListAlocareDisSpecList.Size = new System.Drawing.Size(265, 32);
            this.comboBoxDropDownListAlocareDisSpecList.TabIndex = 12;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(129, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(117, 24);
            this.label19.TabIndex = 11;
            this.label19.Text = "Specializare:";
            // 
            // label_DisciplinaAdaugata
            // 
            this.label_DisciplinaAdaugata.AutoSize = true;
            this.label_DisciplinaAdaugata.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DisciplinaAdaugata.Location = new System.Drawing.Point(332, 82);
            this.label_DisciplinaAdaugata.Name = "label_DisciplinaAdaugata";
            this.label_DisciplinaAdaugata.Size = new System.Drawing.Size(111, 24);
            this.label_DisciplinaAdaugata.TabIndex = 21;
            this.label_DisciplinaAdaugata.Text = "Placeholder";
            // 
            // Alocare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_DisciplinaAdaugata);
            this.Controls.Add(this.buttonAlocaDisciplina);
            this.Controls.Add(this.groupBoxAlocareDiscStatus);
            this.Controls.Add(this.groupBoxAlocDiscTipEvaluare);
            this.Controls.Add(this.groupBoxAlocDiscSemestru);
            this.Controls.Add(this.comboBoxDropDownListAlocareDiscAnStudiuList);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.comboBoxDropDownListAlocareDisSpecList);
            this.Controls.Add(this.label19);
            this.Name = "Alocare";
            this.Text = "Alocare";
            this.Load += new System.EventHandler(this.Alocare_Load);
            this.groupBoxAlocareDiscStatus.ResumeLayout(false);
            this.groupBoxAlocareDiscStatus.PerformLayout();
            this.groupBoxAlocDiscTipEvaluare.ResumeLayout(false);
            this.groupBoxAlocDiscTipEvaluare.PerformLayout();
            this.groupBoxAlocDiscSemestru.ResumeLayout(false);
            this.groupBoxAlocDiscSemestru.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAlocaDisciplina;
        private System.Windows.Forms.GroupBox groupBoxAlocareDiscStatus;
        private System.Windows.Forms.RadioButton radioButtonInactiv;
        private System.Windows.Forms.RadioButton radioButtonActiv;
        private System.Windows.Forms.GroupBox groupBoxAlocDiscTipEvaluare;
        private System.Windows.Forms.RadioButton radioButtonExamen;
        private System.Windows.Forms.RadioButton radioButtonVerificare;
        private System.Windows.Forms.GroupBox groupBoxAlocDiscSemestru;
        private System.Windows.Forms.RadioButton radioButtonSem2;
        private System.Windows.Forms.RadioButton radioButtonSem1;
        private System.Windows.Forms.ComboBox comboBoxDropDownListAlocareDiscAnStudiuList;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboBoxDropDownListAlocareDisSpecList;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label_DisciplinaAdaugata;
    }
}