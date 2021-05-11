
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageExamen = new System.Windows.Forms.TabPage();
            this.groupBoxDiscSemestru = new System.Windows.Forms.GroupBox();
            this.radioButtonSem2 = new System.Windows.Forms.RadioButton();
            this.radioButtonSem1 = new System.Windows.Forms.RadioButton();
            this.buttonProgrameazaExamen = new System.Windows.Forms.Button();
            this.dateTimePickerDataExamen = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownExamenDurata = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownExamenOra = new System.Windows.Forms.NumericUpDown();
            this.labelSesiuneCurentaExamen = new System.Windows.Forms.Label();
            this.comboBoxExamenProfSuprav = new System.Windows.Forms.ComboBox();
            this.comboBoxExamenProfTitular = new System.Windows.Forms.ComboBox();
            this.comboBoxExamenSala = new System.Windows.Forms.ComboBox();
            this.comboBoxExmenGrupa = new System.Windows.Forms.ComboBox();
            this.comboBoxExamenSpecializare = new System.Windows.Forms.ComboBox();
            this.comboBoxExamenDisciplina = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBoxModEvaluare = new System.Windows.Forms.GroupBox();
            this.radioButtonOral = new System.Windows.Forms.RadioButton();
            this.radioButtonScris = new System.Windows.Forms.RadioButton();
            this.labelExamenTipEvaluare = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelExamenAnUniversitarCurent = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageRestanta = new System.Windows.Forms.TabPage();
            this.tabPageArhivaExamene = new System.Windows.Forms.TabPage();
            this.tabPageArhivaRestante = new System.Windows.Forms.TabPage();
            this.labelScheduleExamServerStatus = new System.Windows.Forms.Label();
            this.labelScheduleExamCurrentAcademicalYear = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageExamen.SuspendLayout();
            this.groupBoxDiscSemestru.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExamenDurata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExamenOra)).BeginInit();
            this.groupBoxModEvaluare.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonScheduleExamBack
            // 
            this.buttonScheduleExamBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScheduleExamBack.Location = new System.Drawing.Point(1130, 605);
            this.buttonScheduleExamBack.Name = "buttonScheduleExamBack";
            this.buttonScheduleExamBack.Size = new System.Drawing.Size(114, 51);
            this.buttonScheduleExamBack.TabIndex = 0;
            this.buttonScheduleExamBack.Text = "Inapoi";
            this.buttonScheduleExamBack.UseVisualStyleBackColor = true;
            this.buttonScheduleExamBack.Click += new System.EventHandler(this.buttonScheduleExamBack_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageExamen);
            this.tabControl1.Controls.Add(this.tabPageRestanta);
            this.tabControl1.Controls.Add(this.tabPageArhivaExamene);
            this.tabControl1.Controls.Add(this.tabPageArhivaRestante);
            this.tabControl1.Location = new System.Drawing.Point(12, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1232, 570);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageExamen
            // 
            this.tabPageExamen.Controls.Add(this.groupBoxDiscSemestru);
            this.tabPageExamen.Controls.Add(this.buttonProgrameazaExamen);
            this.tabPageExamen.Controls.Add(this.dateTimePickerDataExamen);
            this.tabPageExamen.Controls.Add(this.numericUpDownExamenDurata);
            this.tabPageExamen.Controls.Add(this.numericUpDownExamenOra);
            this.tabPageExamen.Controls.Add(this.labelSesiuneCurentaExamen);
            this.tabPageExamen.Controls.Add(this.comboBoxExamenProfSuprav);
            this.tabPageExamen.Controls.Add(this.comboBoxExamenProfTitular);
            this.tabPageExamen.Controls.Add(this.comboBoxExamenSala);
            this.tabPageExamen.Controls.Add(this.comboBoxExmenGrupa);
            this.tabPageExamen.Controls.Add(this.comboBoxExamenSpecializare);
            this.tabPageExamen.Controls.Add(this.comboBoxExamenDisciplina);
            this.tabPageExamen.Controls.Add(this.label12);
            this.tabPageExamen.Controls.Add(this.label11);
            this.tabPageExamen.Controls.Add(this.groupBoxModEvaluare);
            this.tabPageExamen.Controls.Add(this.labelExamenTipEvaluare);
            this.tabPageExamen.Controls.Add(this.label10);
            this.tabPageExamen.Controls.Add(this.label9);
            this.tabPageExamen.Controls.Add(this.label8);
            this.tabPageExamen.Controls.Add(this.label7);
            this.tabPageExamen.Controls.Add(this.label6);
            this.tabPageExamen.Controls.Add(this.label5);
            this.tabPageExamen.Controls.Add(this.labelExamenAnUniversitarCurent);
            this.tabPageExamen.Controls.Add(this.label4);
            this.tabPageExamen.Controls.Add(this.label3);
            this.tabPageExamen.Controls.Add(this.label2);
            this.tabPageExamen.Controls.Add(this.label1);
            this.tabPageExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageExamen.Location = new System.Drawing.Point(4, 22);
            this.tabPageExamen.Name = "tabPageExamen";
            this.tabPageExamen.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageExamen.Size = new System.Drawing.Size(1224, 544);
            this.tabPageExamen.TabIndex = 0;
            this.tabPageExamen.Text = "Programare Examen";
            this.tabPageExamen.UseVisualStyleBackColor = true;
            // 
            // groupBoxDiscSemestru
            // 
            this.groupBoxDiscSemestru.Controls.Add(this.radioButtonSem2);
            this.groupBoxDiscSemestru.Controls.Add(this.radioButtonSem1);
            this.groupBoxDiscSemestru.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDiscSemestru.Location = new System.Drawing.Point(214, 204);
            this.groupBoxDiscSemestru.Name = "groupBoxDiscSemestru";
            this.groupBoxDiscSemestru.Size = new System.Drawing.Size(383, 79);
            this.groupBoxDiscSemestru.TabIndex = 26;
            this.groupBoxDiscSemestru.TabStop = false;
            this.groupBoxDiscSemestru.Text = "Semestru";
            // 
            // radioButtonSem2
            // 
            this.radioButtonSem2.AutoSize = true;
            this.radioButtonSem2.Location = new System.Drawing.Point(182, 29);
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
            this.radioButtonSem1.Location = new System.Drawing.Point(7, 29);
            this.radioButtonSem1.Name = "radioButtonSem1";
            this.radioButtonSem1.Size = new System.Drawing.Size(169, 35);
            this.radioButtonSem1.TabIndex = 0;
            this.radioButtonSem1.TabStop = true;
            this.radioButtonSem1.Text = "Semestrul I";
            this.radioButtonSem1.UseVisualStyleBackColor = true;
            this.radioButtonSem1.CheckedChanged += new System.EventHandler(this.specializare_selectedIndexChanged);
            // 
            // buttonProgrameazaExamen
            // 
            this.buttonProgrameazaExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProgrameazaExamen.Location = new System.Drawing.Point(448, 464);
            this.buttonProgrameazaExamen.Name = "buttonProgrameazaExamen";
            this.buttonProgrameazaExamen.Size = new System.Drawing.Size(368, 50);
            this.buttonProgrameazaExamen.TabIndex = 25;
            this.buttonProgrameazaExamen.Text = "Programeaza Examen";
            this.buttonProgrameazaExamen.UseVisualStyleBackColor = true;
            this.buttonProgrameazaExamen.Click += new System.EventHandler(this.buttonProgrameazaExamen_Click);
            // 
            // dateTimePickerDataExamen
            // 
            this.dateTimePickerDataExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDataExamen.Location = new System.Drawing.Point(214, 384);
            this.dateTimePickerDataExamen.Name = "dateTimePickerDataExamen";
            this.dateTimePickerDataExamen.Size = new System.Drawing.Size(383, 38);
            this.dateTimePickerDataExamen.TabIndex = 24;
            // 
            // numericUpDownExamenDurata
            // 
            this.numericUpDownExamenDurata.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownExamenDurata.Location = new System.Drawing.Point(1086, 250);
            this.numericUpDownExamenDurata.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownExamenDurata.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownExamenDurata.Name = "numericUpDownExamenDurata";
            this.numericUpDownExamenDurata.Size = new System.Drawing.Size(70, 38);
            this.numericUpDownExamenDurata.TabIndex = 23;
            this.numericUpDownExamenDurata.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownExamenOra
            // 
            this.numericUpDownExamenOra.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownExamenOra.Location = new System.Drawing.Point(796, 250);
            this.numericUpDownExamenOra.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownExamenOra.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownExamenOra.Name = "numericUpDownExamenOra";
            this.numericUpDownExamenOra.Size = new System.Drawing.Size(81, 38);
            this.numericUpDownExamenOra.TabIndex = 22;
            this.numericUpDownExamenOra.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // labelSesiuneCurentaExamen
            // 
            this.labelSesiuneCurentaExamen.AutoSize = true;
            this.labelSesiuneCurentaExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSesiuneCurentaExamen.Location = new System.Drawing.Point(840, 25);
            this.labelSesiuneCurentaExamen.Name = "labelSesiuneCurentaExamen";
            this.labelSesiuneCurentaExamen.Size = new System.Drawing.Size(157, 31);
            this.labelSesiuneCurentaExamen.TabIndex = 21;
            this.labelSesiuneCurentaExamen.Text = "Placeholder";
            this.labelSesiuneCurentaExamen.Visible = false;
            // 
            // comboBoxExamenProfSuprav
            // 
            this.comboBoxExamenProfSuprav.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExamenProfSuprav.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxExamenProfSuprav.FormattingEnabled = true;
            this.comboBoxExamenProfSuprav.Location = new System.Drawing.Point(729, 183);
            this.comboBoxExamenProfSuprav.Name = "comboBoxExamenProfSuprav";
            this.comboBoxExamenProfSuprav.Size = new System.Drawing.Size(427, 39);
            this.comboBoxExamenProfSuprav.TabIndex = 20;
            // 
            // comboBoxExamenProfTitular
            // 
            this.comboBoxExamenProfTitular.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExamenProfTitular.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxExamenProfTitular.FormattingEnabled = true;
            this.comboBoxExamenProfTitular.Location = new System.Drawing.Point(729, 107);
            this.comboBoxExamenProfTitular.Name = "comboBoxExamenProfTitular";
            this.comboBoxExamenProfTitular.Size = new System.Drawing.Size(427, 39);
            this.comboBoxExamenProfTitular.TabIndex = 19;
            // 
            // comboBoxExamenSala
            // 
            this.comboBoxExamenSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExamenSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxExamenSala.FormattingEnabled = true;
            this.comboBoxExamenSala.Location = new System.Drawing.Point(214, 337);
            this.comboBoxExamenSala.Name = "comboBoxExamenSala";
            this.comboBoxExamenSala.Size = new System.Drawing.Size(383, 39);
            this.comboBoxExamenSala.TabIndex = 18;
            // 
            // comboBoxExmenGrupa
            // 
            this.comboBoxExmenGrupa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExmenGrupa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxExmenGrupa.FormattingEnabled = true;
            this.comboBoxExmenGrupa.Location = new System.Drawing.Point(214, 67);
            this.comboBoxExmenGrupa.Name = "comboBoxExmenGrupa";
            this.comboBoxExmenGrupa.Size = new System.Drawing.Size(383, 39);
            this.comboBoxExmenGrupa.TabIndex = 17;
            this.comboBoxExmenGrupa.SelectedIndexChanged += new System.EventHandler(this.grupa_selectedIndexChanged);
            // 
            // comboBoxExamenSpecializare
            // 
            this.comboBoxExamenSpecializare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExamenSpecializare.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxExamenSpecializare.FormattingEnabled = true;
            this.comboBoxExamenSpecializare.Location = new System.Drawing.Point(214, 22);
            this.comboBoxExamenSpecializare.Name = "comboBoxExamenSpecializare";
            this.comboBoxExamenSpecializare.Size = new System.Drawing.Size(383, 39);
            this.comboBoxExamenSpecializare.TabIndex = 16;
            this.comboBoxExamenSpecializare.SelectedIndexChanged += new System.EventHandler(this.specializare_selectedIndexChanged);
            // 
            // comboBoxExamenDisciplina
            // 
            this.comboBoxExamenDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExamenDisciplina.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxExamenDisciplina.FormattingEnabled = true;
            this.comboBoxExamenDisciplina.Location = new System.Drawing.Point(214, 112);
            this.comboBoxExamenDisciplina.Name = "comboBoxExamenDisciplina";
            this.comboBoxExamenDisciplina.Size = new System.Drawing.Size(383, 39);
            this.comboBoxExamenDisciplina.TabIndex = 15;
            this.comboBoxExamenDisciplina.SelectedIndexChanged += new System.EventHandler(this.disciplina_selectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(717, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 31);
            this.label12.TabIndex = 14;
            this.label12.Text = "Sesiune:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(958, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 31);
            this.label11.TabIndex = 13;
            this.label11.Text = "Durata:";
            // 
            // groupBoxModEvaluare
            // 
            this.groupBoxModEvaluare.Controls.Add(this.radioButtonOral);
            this.groupBoxModEvaluare.Controls.Add(this.radioButtonScris);
            this.groupBoxModEvaluare.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxModEvaluare.Location = new System.Drawing.Point(846, 294);
            this.groupBoxModEvaluare.Name = "groupBoxModEvaluare";
            this.groupBoxModEvaluare.Size = new System.Drawing.Size(216, 133);
            this.groupBoxModEvaluare.TabIndex = 12;
            this.groupBoxModEvaluare.TabStop = false;
            this.groupBoxModEvaluare.Text = "Mod evaluare";
            // 
            // radioButtonOral
            // 
            this.radioButtonOral.AutoSize = true;
            this.radioButtonOral.Location = new System.Drawing.Point(68, 81);
            this.radioButtonOral.Name = "radioButtonOral";
            this.radioButtonOral.Size = new System.Drawing.Size(83, 35);
            this.radioButtonOral.TabIndex = 1;
            this.radioButtonOral.Text = "Oral";
            this.radioButtonOral.UseVisualStyleBackColor = true;
            // 
            // radioButtonScris
            // 
            this.radioButtonScris.AutoSize = true;
            this.radioButtonScris.Checked = true;
            this.radioButtonScris.Location = new System.Drawing.Point(68, 40);
            this.radioButtonScris.Name = "radioButtonScris";
            this.radioButtonScris.Size = new System.Drawing.Size(93, 35);
            this.radioButtonScris.TabIndex = 0;
            this.radioButtonScris.TabStop = true;
            this.radioButtonScris.Text = "Scris";
            this.radioButtonScris.UseVisualStyleBackColor = true;
            // 
            // labelExamenTipEvaluare
            // 
            this.labelExamenTipEvaluare.AutoSize = true;
            this.labelExamenTipEvaluare.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExamenTipEvaluare.Location = new System.Drawing.Point(350, 167);
            this.labelExamenTipEvaluare.Name = "labelExamenTipEvaluare";
            this.labelExamenTipEvaluare.Size = new System.Drawing.Size(112, 31);
            this.labelExamenTipEvaluare.TabIndex = 11;
            this.labelExamenTipEvaluare.Text = "Examen";
            this.labelExamenTipEvaluare.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(37, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 31);
            this.label10.TabIndex = 10;
            this.label10.Text = "Tip evaluare:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(723, 252);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 31);
            this.label9.TabIndex = 9;
            this.label9.Text = "Ora:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(128, 384);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 31);
            this.label8.TabIndex = 8;
            this.label8.Text = "Data:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(806, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(306, 31);
            this.label7.TabIndex = 7;
            this.label7.Text = "Profesor supraveghetor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(840, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 31);
            this.label6.TabIndex = 6;
            this.label6.Text = "Profesor titular:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(132, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 31);
            this.label5.TabIndex = 5;
            this.label5.Text = "Sala:";
            // 
            // labelExamenAnUniversitarCurent
            // 
            this.labelExamenAnUniversitarCurent.AutoSize = true;
            this.labelExamenAnUniversitarCurent.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExamenAnUniversitarCurent.Location = new System.Drawing.Point(337, 290);
            this.labelExamenAnUniversitarCurent.Name = "labelExamenAnUniversitarCurent";
            this.labelExamenAnUniversitarCurent.Size = new System.Drawing.Size(143, 31);
            this.labelExamenAnUniversitarCurent.TabIndex = 4;
            this.labelExamenAnUniversitarCurent.Text = "2000-2001";
            this.labelExamenAnUniversitarCurent.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "An universitar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(111, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Grupa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Specializare:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disciplina:";
            // 
            // tabPageRestanta
            // 
            this.tabPageRestanta.Location = new System.Drawing.Point(4, 22);
            this.tabPageRestanta.Name = "tabPageRestanta";
            this.tabPageRestanta.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageRestanta.Size = new System.Drawing.Size(1224, 544);
            this.tabPageRestanta.TabIndex = 1;
            this.tabPageRestanta.Text = "Programare Restanta";
            this.tabPageRestanta.UseVisualStyleBackColor = true;
            // 
            // tabPageArhivaExamene
            // 
            this.tabPageArhivaExamene.Location = new System.Drawing.Point(4, 22);
            this.tabPageArhivaExamene.Name = "tabPageArhivaExamene";
            this.tabPageArhivaExamene.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageArhivaExamene.Size = new System.Drawing.Size(1224, 544);
            this.tabPageArhivaExamene.TabIndex = 2;
            this.tabPageArhivaExamene.Text = "Arhiva Examene";
            this.tabPageArhivaExamene.UseVisualStyleBackColor = true;
            // 
            // tabPageArhivaRestante
            // 
            this.tabPageArhivaRestante.Location = new System.Drawing.Point(4, 22);
            this.tabPageArhivaRestante.Name = "tabPageArhivaRestante";
            this.tabPageArhivaRestante.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageArhivaRestante.Size = new System.Drawing.Size(1224, 544);
            this.tabPageArhivaRestante.TabIndex = 3;
            this.tabPageArhivaRestante.Text = "Arhiva Restante";
            this.tabPageArhivaRestante.UseVisualStyleBackColor = true;
            // 
            // labelScheduleExamServerStatus
            // 
            this.labelScheduleExamServerStatus.AutoSize = true;
            this.labelScheduleExamServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScheduleExamServerStatus.Location = new System.Drawing.Point(24, 615);
            this.labelScheduleExamServerStatus.Name = "labelScheduleExamServerStatus";
            this.labelScheduleExamServerStatus.Size = new System.Drawing.Size(322, 31);
            this.labelScheduleExamServerStatus.TabIndex = 2;
            this.labelScheduleExamServerStatus.Text = "Server StatusPlaceholder";
            this.labelScheduleExamServerStatus.Visible = false;
            // 
            // labelScheduleExamCurrentAcademicalYear
            // 
            this.labelScheduleExamCurrentAcademicalYear.AutoSize = true;
            this.labelScheduleExamCurrentAcademicalYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScheduleExamCurrentAcademicalYear.Location = new System.Drawing.Point(24, 581);
            this.labelScheduleExamCurrentAcademicalYear.Name = "labelScheduleExamCurrentAcademicalYear";
            this.labelScheduleExamCurrentAcademicalYear.Size = new System.Drawing.Size(347, 31);
            this.labelScheduleExamCurrentAcademicalYear.TabIndex = 3;
            this.labelScheduleExamCurrentAcademicalYear.Text = "Academic Year Placeholder";
            this.labelScheduleExamCurrentAcademicalYear.Visible = false;
            // 
            // ScheduleExamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 668);
            this.Controls.Add(this.labelScheduleExamCurrentAcademicalYear);
            this.Controls.Add(this.labelScheduleExamServerStatus);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonScheduleExamBack);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ScheduleExamForm";
            this.Text = "ScheduleExamForm";
            this.Load += new System.EventHandler(this.ScheduleExamForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageExamen.ResumeLayout(false);
            this.tabPageExamen.PerformLayout();
            this.groupBoxDiscSemestru.ResumeLayout(false);
            this.groupBoxDiscSemestru.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExamenDurata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExamenOra)).EndInit();
            this.groupBoxModEvaluare.ResumeLayout(false);
            this.groupBoxModEvaluare.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonScheduleExamBack;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageExamen;
        private System.Windows.Forms.TabPage tabPageRestanta;
        private System.Windows.Forms.TabPage tabPageArhivaExamene;
        private System.Windows.Forms.TabPage tabPageArhivaRestante;
        private System.Windows.Forms.Label labelScheduleExamServerStatus;
        private System.Windows.Forms.Label labelScheduleExamCurrentAcademicalYear;
        private System.Windows.Forms.Label labelExamenAnUniversitarCurent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBoxModEvaluare;
        private System.Windows.Forms.RadioButton radioButtonOral;
        private System.Windows.Forms.RadioButton radioButtonScris;
        private System.Windows.Forms.Label labelExamenTipEvaluare;
        private System.Windows.Forms.ComboBox comboBoxExamenSala;
        private System.Windows.Forms.ComboBox comboBoxExmenGrupa;
        private System.Windows.Forms.ComboBox comboBoxExamenSpecializare;
        private System.Windows.Forms.ComboBox comboBoxExamenDisciplina;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxExamenProfTitular;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataExamen;
        private System.Windows.Forms.NumericUpDown numericUpDownExamenDurata;
        private System.Windows.Forms.NumericUpDown numericUpDownExamenOra;
        private System.Windows.Forms.Label labelSesiuneCurentaExamen;
        private System.Windows.Forms.ComboBox comboBoxExamenProfSuprav;
        private System.Windows.Forms.Button buttonProgrameazaExamen;
        private System.Windows.Forms.GroupBox groupBoxDiscSemestru;
        private System.Windows.Forms.RadioButton radioButtonSem2;
        private System.Windows.Forms.RadioButton radioButtonSem1;
    }
}