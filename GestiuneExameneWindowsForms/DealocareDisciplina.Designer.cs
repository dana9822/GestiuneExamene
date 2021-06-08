
namespace GestiuneExameneWindowsForms
{
    partial class DealocareDisciplina
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
            this.comboBoxDropDownListDealocareDiscList = new System.Windows.Forms.ComboBox();
            this.comboBoxDropDownListDealocareSpecList = new System.Windows.Forms.ComboBox();
            this.labelSpec = new System.Windows.Forms.Label();
            this.buttonDealocDisciplina = new System.Windows.Forms.Button();
            this.groupBoxDealocDiscTipEvaluare = new System.Windows.Forms.GroupBox();
            this.radioButtonExamen = new System.Windows.Forms.RadioButton();
            this.radioButtonVerificare = new System.Windows.Forms.RadioButton();
            this.groupBoxDealocDiscSemestru = new System.Windows.Forms.GroupBox();
            this.radioButtonSem2 = new System.Windows.Forms.RadioButton();
            this.radioButtonSem1 = new System.Windows.Forms.RadioButton();
            this.comboBoxDropDownListDealocareAnStudiuList = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button_backToAddData = new System.Windows.Forms.Button();
            this.button_Iesire = new System.Windows.Forms.Button();
            this.groupBoxDealocDiscTipEvaluare.SuspendLayout();
            this.groupBoxDealocDiscSemestru.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxDropDownListDealocareDiscList
            // 
            this.comboBoxDropDownListDealocareDiscList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDropDownListDealocareDiscList.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDropDownListDealocareDiscList.FormattingEnabled = true;
            this.comboBoxDropDownListDealocareDiscList.Location = new System.Drawing.Point(233, 76);
            this.comboBoxDropDownListDealocareDiscList.Name = "comboBoxDropDownListDealocareDiscList";
            this.comboBoxDropDownListDealocareDiscList.Size = new System.Drawing.Size(423, 39);
            this.comboBoxDropDownListDealocareDiscList.Sorted = true;
            this.comboBoxDropDownListDealocareDiscList.TabIndex = 40;
            this.comboBoxDropDownListDealocareDiscList.SelectedIndexChanged += new System.EventHandler(this.disciplina_selectedIndexChanged);
            // 
            // comboBoxDropDownListDealocareSpecList
            // 
            this.comboBoxDropDownListDealocareSpecList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDropDownListDealocareSpecList.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDropDownListDealocareSpecList.FormattingEnabled = true;
            this.comboBoxDropDownListDealocareSpecList.Location = new System.Drawing.Point(233, 25);
            this.comboBoxDropDownListDealocareSpecList.Name = "comboBoxDropDownListDealocareSpecList";
            this.comboBoxDropDownListDealocareSpecList.Size = new System.Drawing.Size(423, 39);
            this.comboBoxDropDownListDealocareSpecList.Sorted = true;
            this.comboBoxDropDownListDealocareSpecList.TabIndex = 39;
            this.comboBoxDropDownListDealocareSpecList.SelectedIndexChanged += new System.EventHandler(this.specializare_selectedIndexChanged);
            // 
            // labelSpec
            // 
            this.labelSpec.AutoSize = true;
            this.labelSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpec.Location = new System.Drawing.Point(57, 33);
            this.labelSpec.Name = "labelSpec";
            this.labelSpec.Size = new System.Drawing.Size(170, 31);
            this.labelSpec.TabIndex = 38;
            this.labelSpec.Text = "Specializare:";
            // 
            // buttonDealocDisciplina
            // 
            this.buttonDealocDisciplina.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDealocDisciplina.Location = new System.Drawing.Point(319, 362);
            this.buttonDealocDisciplina.Name = "buttonDealocDisciplina";
            this.buttonDealocDisciplina.Size = new System.Drawing.Size(274, 51);
            this.buttonDealocDisciplina.TabIndex = 37;
            this.buttonDealocDisciplina.Text = "Dealoca disciplina";
            this.buttonDealocDisciplina.UseVisualStyleBackColor = true;
            this.buttonDealocDisciplina.Click += new System.EventHandler(this.buttonDealocDisciplina_Click);
            // 
            // groupBoxDealocDiscTipEvaluare
            // 
            this.groupBoxDealocDiscTipEvaluare.Controls.Add(this.radioButtonExamen);
            this.groupBoxDealocDiscTipEvaluare.Controls.Add(this.radioButtonVerificare);
            this.groupBoxDealocDiscTipEvaluare.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDealocDiscTipEvaluare.Location = new System.Drawing.Point(233, 268);
            this.groupBoxDealocDiscTipEvaluare.Name = "groupBoxDealocDiscTipEvaluare";
            this.groupBoxDealocDiscTipEvaluare.Size = new System.Drawing.Size(423, 88);
            this.groupBoxDealocDiscTipEvaluare.TabIndex = 36;
            this.groupBoxDealocDiscTipEvaluare.TabStop = false;
            this.groupBoxDealocDiscTipEvaluare.Text = "Tip evaluare";
            // 
            // radioButtonExamen
            // 
            this.radioButtonExamen.AutoSize = true;
            this.radioButtonExamen.Location = new System.Drawing.Point(230, 37);
            this.radioButtonExamen.Name = "radioButtonExamen";
            this.radioButtonExamen.Size = new System.Drawing.Size(130, 35);
            this.radioButtonExamen.TabIndex = 1;
            this.radioButtonExamen.Text = "Examen";
            this.radioButtonExamen.UseVisualStyleBackColor = true;
            // 
            // radioButtonVerificare
            // 
            this.radioButtonVerificare.AutoSize = true;
            this.radioButtonVerificare.Checked = true;
            this.radioButtonVerificare.Location = new System.Drawing.Point(28, 37);
            this.radioButtonVerificare.Name = "radioButtonVerificare";
            this.radioButtonVerificare.Size = new System.Drawing.Size(147, 35);
            this.radioButtonVerificare.TabIndex = 0;
            this.radioButtonVerificare.TabStop = true;
            this.radioButtonVerificare.Text = "Verificare";
            this.radioButtonVerificare.UseVisualStyleBackColor = true;
            // 
            // groupBoxDealocDiscSemestru
            // 
            this.groupBoxDealocDiscSemestru.Controls.Add(this.radioButtonSem2);
            this.groupBoxDealocDiscSemestru.Controls.Add(this.radioButtonSem1);
            this.groupBoxDealocDiscSemestru.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDealocDiscSemestru.Location = new System.Drawing.Point(233, 176);
            this.groupBoxDealocDiscSemestru.Name = "groupBoxDealocDiscSemestru";
            this.groupBoxDealocDiscSemestru.Size = new System.Drawing.Size(423, 86);
            this.groupBoxDealocDiscSemestru.TabIndex = 35;
            this.groupBoxDealocDiscSemestru.TabStop = false;
            this.groupBoxDealocDiscSemestru.Text = "Semestru";
            // 
            // radioButtonSem2
            // 
            this.radioButtonSem2.AutoSize = true;
            this.radioButtonSem2.Location = new System.Drawing.Point(230, 37);
            this.radioButtonSem2.Name = "radioButtonSem2";
            this.radioButtonSem2.Size = new System.Drawing.Size(177, 35);
            this.radioButtonSem2.TabIndex = 1;
            this.radioButtonSem2.Text = "Semestrul II";
            this.radioButtonSem2.UseVisualStyleBackColor = true;
            this.radioButtonSem2.CheckedChanged += new System.EventHandler(this.specializare_selectedIndexChanged);
            // 
            // radioButtonSem1
            // 
            this.radioButtonSem1.AutoSize = true;
            this.radioButtonSem1.Checked = true;
            this.radioButtonSem1.Location = new System.Drawing.Point(28, 37);
            this.radioButtonSem1.Name = "radioButtonSem1";
            this.radioButtonSem1.Size = new System.Drawing.Size(169, 35);
            this.radioButtonSem1.TabIndex = 0;
            this.radioButtonSem1.TabStop = true;
            this.radioButtonSem1.Text = "Semestrul I";
            this.radioButtonSem1.UseVisualStyleBackColor = true;
            this.radioButtonSem1.CheckedChanged += new System.EventHandler(this.specializare_selectedIndexChanged);
            // 
            // comboBoxDropDownListDealocareAnStudiuList
            // 
            this.comboBoxDropDownListDealocareAnStudiuList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDropDownListDealocareAnStudiuList.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDropDownListDealocareAnStudiuList.FormattingEnabled = true;
            this.comboBoxDropDownListDealocareAnStudiuList.Location = new System.Drawing.Point(233, 125);
            this.comboBoxDropDownListDealocareAnStudiuList.Name = "comboBoxDropDownListDealocareAnStudiuList";
            this.comboBoxDropDownListDealocareAnStudiuList.Size = new System.Drawing.Size(423, 39);
            this.comboBoxDropDownListDealocareAnStudiuList.TabIndex = 34;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(88, 128);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(135, 31);
            this.label21.TabIndex = 33;
            this.label21.Text = "An studiu:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(88, 79);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(139, 31);
            this.label20.TabIndex = 32;
            this.label20.Text = "Disciplina:";
            // 
            // button_backToAddData
            // 
            this.button_backToAddData.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_backToAddData.Location = new System.Drawing.Point(601, 430);
            this.button_backToAddData.Name = "button_backToAddData";
            this.button_backToAddData.Size = new System.Drawing.Size(100, 34);
            this.button_backToAddData.TabIndex = 41;
            this.button_backToAddData.Text = "Inapoi";
            this.button_backToAddData.UseVisualStyleBackColor = true;
            this.button_backToAddData.Click += new System.EventHandler(this.button_backToAddData_Click);
            // 
            // button_Iesire
            // 
            this.button_Iesire.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Iesire.Location = new System.Drawing.Point(707, 430);
            this.button_Iesire.Name = "button_Iesire";
            this.button_Iesire.Size = new System.Drawing.Size(90, 34);
            this.button_Iesire.TabIndex = 42;
            this.button_Iesire.Text = "Iesire";
            this.button_Iesire.UseVisualStyleBackColor = true;
            this.button_Iesire.Click += new System.EventHandler(this.button_Iesire_Click);
            // 
            // DealocareDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 476);
            this.Controls.Add(this.button_Iesire);
            this.Controls.Add(this.button_backToAddData);
            this.Controls.Add(this.comboBoxDropDownListDealocareDiscList);
            this.Controls.Add(this.comboBoxDropDownListDealocareSpecList);
            this.Controls.Add(this.labelSpec);
            this.Controls.Add(this.buttonDealocDisciplina);
            this.Controls.Add(this.groupBoxDealocDiscTipEvaluare);
            this.Controls.Add(this.groupBoxDealocDiscSemestru);
            this.Controls.Add(this.comboBoxDropDownListDealocareAnStudiuList);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Name = "DealocareDisciplina";
            this.Text = "DealocareDisciplina";
            this.Load += new System.EventHandler(this.DealocareDisciplina_Load);
            this.groupBoxDealocDiscTipEvaluare.ResumeLayout(false);
            this.groupBoxDealocDiscTipEvaluare.PerformLayout();
            this.groupBoxDealocDiscSemestru.ResumeLayout(false);
            this.groupBoxDealocDiscSemestru.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDropDownListDealocareDiscList;
        private System.Windows.Forms.ComboBox comboBoxDropDownListDealocareSpecList;
        private System.Windows.Forms.Label labelSpec;
        private System.Windows.Forms.Button buttonDealocDisciplina;
        private System.Windows.Forms.GroupBox groupBoxDealocDiscTipEvaluare;
        private System.Windows.Forms.RadioButton radioButtonExamen;
        private System.Windows.Forms.RadioButton radioButtonVerificare;
        private System.Windows.Forms.GroupBox groupBoxDealocDiscSemestru;
        private System.Windows.Forms.RadioButton radioButtonSem2;
        private System.Windows.Forms.RadioButton radioButtonSem1;
        private System.Windows.Forms.ComboBox comboBoxDropDownListDealocareAnStudiuList;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button_backToAddData;
        private System.Windows.Forms.Button button_Iesire;
    }
}