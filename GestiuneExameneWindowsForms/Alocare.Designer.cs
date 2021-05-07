
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
            this.label19 = new System.Windows.Forms.Label();
            this.label_DisciplinaAdaugata = new System.Windows.Forms.Label();
            this.panel_CheckList_Alocare_Disciplina_Spec = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonIesire = new System.Windows.Forms.Button();
            this.button_back_AddDataForm = new System.Windows.Forms.Button();
            this.button_toAcoperireForm = new System.Windows.Forms.Button();
            this.groupBoxAlocareDiscStatus.SuspendLayout();
            this.groupBoxAlocDiscTipEvaluare.SuspendLayout();
            this.groupBoxAlocDiscSemestru.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAlocaDisciplina
            // 
            this.buttonAlocaDisciplina.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlocaDisciplina.Location = new System.Drawing.Point(183, 321);
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
            this.groupBoxAlocareDiscStatus.Location = new System.Drawing.Point(145, 265);
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
            this.groupBoxAlocDiscTipEvaluare.Location = new System.Drawing.Point(145, 203);
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
            this.groupBoxAlocDiscSemestru.Location = new System.Drawing.Point(145, 139);
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
            this.comboBoxDropDownListAlocareDiscAnStudiuList.Location = new System.Drawing.Point(145, 101);
            this.comboBoxDropDownListAlocareDiscAnStudiuList.Name = "comboBoxDropDownListAlocareDiscAnStudiuList";
            this.comboBoxDropDownListAlocareDiscAnStudiuList.Size = new System.Drawing.Size(265, 32);
            this.comboBoxDropDownListAlocareDiscAnStudiuList.TabIndex = 16;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(45, 101);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 24);
            this.label21.TabIndex = 15;
            this.label21.Text = "An studiu:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(44, 63);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 24);
            this.label20.TabIndex = 13;
            this.label20.Text = "Disciplina:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(310, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(158, 24);
            this.label19.TabIndex = 11;
            this.label19.Text = "Alocare disciplina";
            // 
            // label_DisciplinaAdaugata
            // 
            this.label_DisciplinaAdaugata.AutoSize = true;
            this.label_DisciplinaAdaugata.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DisciplinaAdaugata.Location = new System.Drawing.Point(225, 63);
            this.label_DisciplinaAdaugata.Name = "label_DisciplinaAdaugata";
            this.label_DisciplinaAdaugata.Size = new System.Drawing.Size(111, 24);
            this.label_DisciplinaAdaugata.TabIndex = 21;
            this.label_DisciplinaAdaugata.Text = "Placeholder";
            // 
            // panel_CheckList_Alocare_Disciplina_Spec
            // 
            this.panel_CheckList_Alocare_Disciplina_Spec.Location = new System.Drawing.Point(488, 90);
            this.panel_CheckList_Alocare_Disciplina_Spec.Name = "panel_CheckList_Alocare_Disciplina_Spec";
            this.panel_CheckList_Alocare_Disciplina_Spec.Size = new System.Drawing.Size(235, 263);
            this.panel_CheckList_Alocare_Disciplina_Spec.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(547, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 23;
            this.label1.Text = "Specializari:";
            // 
            // buttonIesire
            // 
            this.buttonIesire.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIesire.Location = new System.Drawing.Point(704, 406);
            this.buttonIesire.Name = "buttonIesire";
            this.buttonIesire.Size = new System.Drawing.Size(84, 32);
            this.buttonIesire.TabIndex = 24;
            this.buttonIesire.Text = "Iesire";
            this.buttonIesire.UseVisualStyleBackColor = true;
            this.buttonIesire.Click += new System.EventHandler(this.buttonIesire_Click);
            // 
            // button_back_AddDataForm
            // 
            this.button_back_AddDataForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back_AddDataForm.Location = new System.Drawing.Point(471, 406);
            this.button_back_AddDataForm.Name = "button_back_AddDataForm";
            this.button_back_AddDataForm.Size = new System.Drawing.Size(227, 32);
            this.button_back_AddDataForm.TabIndex = 25;
            this.button_back_AddDataForm.Text = "Inapoi la adaugare date";
            this.button_back_AddDataForm.UseVisualStyleBackColor = true;
            this.button_back_AddDataForm.Click += new System.EventHandler(this.button_back_AddDataForm_Click);
            // 
            // button_toAcoperireForm
            // 
            this.button_toAcoperireForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_toAcoperireForm.Location = new System.Drawing.Point(270, 406);
            this.button_toAcoperireForm.Name = "button_toAcoperireForm";
            this.button_toAcoperireForm.Size = new System.Drawing.Size(195, 32);
            this.button_toAcoperireForm.TabIndex = 26;
            this.button_toAcoperireForm.Text = "Acoperire disciplina";
            this.button_toAcoperireForm.UseVisualStyleBackColor = true;
            this.button_toAcoperireForm.Click += new System.EventHandler(this.button_toAcoperireForm_Click);
            // 
            // Alocare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_toAcoperireForm);
            this.Controls.Add(this.button_back_AddDataForm);
            this.Controls.Add(this.buttonIesire);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_CheckList_Alocare_Disciplina_Spec);
            this.Controls.Add(this.label_DisciplinaAdaugata);
            this.Controls.Add(this.buttonAlocaDisciplina);
            this.Controls.Add(this.groupBoxAlocareDiscStatus);
            this.Controls.Add(this.groupBoxAlocDiscTipEvaluare);
            this.Controls.Add(this.groupBoxAlocDiscSemestru);
            this.Controls.Add(this.comboBoxDropDownListAlocareDiscAnStudiuList);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
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
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label_DisciplinaAdaugata;
        private System.Windows.Forms.Panel panel_CheckList_Alocare_Disciplina_Spec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonIesire;
        private System.Windows.Forms.Button button_back_AddDataForm;
        private System.Windows.Forms.Button button_toAcoperireForm;
    }
}