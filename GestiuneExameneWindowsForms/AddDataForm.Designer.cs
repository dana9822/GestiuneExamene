
namespace GestiuneExameneWindowsForms
{
    partial class AddDataForm
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
            this.buttonAddDataBack = new System.Windows.Forms.Button();
            this.labelAddDataConnectionStatus = new System.Windows.Forms.Label();
            this.labelAnUniversitarCurent = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFacultate = new System.Windows.Forms.TabPage();
            this.tabPageSpecializare = new System.Windows.Forms.TabPage();
            this.tabPageGrupa = new System.Windows.Forms.TabPage();
            this.tabPageProfesor = new System.Windows.Forms.TabPage();
            this.tabPageDisciplina = new System.Windows.Forms.TabPage();
            this.tabPageSesiune = new System.Windows.Forms.TabPage();
            this.tabPageCorp = new System.Windows.Forms.TabPage();
            this.tabPageSala = new System.Windows.Forms.TabPage();
            this.tabPageAlocareDisciplina = new System.Windows.Forms.TabPage();
            this.tabPageAcoperireDisciplina = new System.Windows.Forms.TabPage();
            this.labelDenFac = new System.Windows.Forms.Label();
            this.labelAdresaFac = new System.Windows.Forms.Label();
            this.textBoxDenumireFacultate = new System.Windows.Forms.TextBox();
            this.textBoxAdresaFacultate = new System.Windows.Forms.TextBox();
            this.buttonAdaugaFacultate = new System.Windows.Forms.Button();
            this.labelDenSpec = new System.Windows.Forms.Label();
            this.groupBoxFormaInv = new System.Windows.Forms.GroupBox();
            this.radioButtonLicenta = new System.Windows.Forms.RadioButton();
            this.radioButtonMaster = new System.Windows.Forms.RadioButton();
            this.labelFacultateSpec = new System.Windows.Forms.Label();
            this.textBoxDenumireSpecializare = new System.Windows.Forms.TextBox();
            this.comboBoxDropDownListFacultate = new System.Windows.Forms.ComboBox();
            this.buttonAdaugaSpecializare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDropDownListSpecializareGrupa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownNrGrupa = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDropDownListAnStudiuGrupa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAnUniversitarGrupa = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownNrStudentiGrupa = new System.Windows.Forms.NumericUpDown();
            this.buttonAdaugaGrupa = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageFacultate.SuspendLayout();
            this.tabPageSpecializare.SuspendLayout();
            this.tabPageGrupa.SuspendLayout();
            this.groupBoxFormaInv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNrGrupa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNrStudentiGrupa)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddDataBack
            // 
            this.buttonAddDataBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddDataBack.Location = new System.Drawing.Point(670, 395);
            this.buttonAddDataBack.Name = "buttonAddDataBack";
            this.buttonAddDataBack.Size = new System.Drawing.Size(104, 43);
            this.buttonAddDataBack.TabIndex = 0;
            this.buttonAddDataBack.Text = "Inapoi";
            this.buttonAddDataBack.UseVisualStyleBackColor = true;
            this.buttonAddDataBack.Click += new System.EventHandler(this.buttonAddDataBack_Click);
            // 
            // labelAddDataConnectionStatus
            // 
            this.labelAddDataConnectionStatus.AutoSize = true;
            this.labelAddDataConnectionStatus.Location = new System.Drawing.Point(27, 411);
            this.labelAddDataConnectionStatus.Name = "labelAddDataConnectionStatus";
            this.labelAddDataConnectionStatus.Size = new System.Drawing.Size(0, 13);
            this.labelAddDataConnectionStatus.TabIndex = 1;
            this.labelAddDataConnectionStatus.Visible = false;
            // 
            // labelAnUniversitarCurent
            // 
            this.labelAnUniversitarCurent.AutoSize = true;
            this.labelAnUniversitarCurent.Location = new System.Drawing.Point(27, 381);
            this.labelAnUniversitarCurent.Name = "labelAnUniversitarCurent";
            this.labelAnUniversitarCurent.Size = new System.Drawing.Size(0, 13);
            this.labelAnUniversitarCurent.TabIndex = 2;
            this.labelAnUniversitarCurent.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageFacultate);
            this.tabControl1.Controls.Add(this.tabPageSpecializare);
            this.tabControl1.Controls.Add(this.tabPageGrupa);
            this.tabControl1.Controls.Add(this.tabPageProfesor);
            this.tabControl1.Controls.Add(this.tabPageDisciplina);
            this.tabControl1.Controls.Add(this.tabPageSesiune);
            this.tabControl1.Controls.Add(this.tabPageCorp);
            this.tabControl1.Controls.Add(this.tabPageSala);
            this.tabControl1.Controls.Add(this.tabPageAlocareDisciplina);
            this.tabControl1.Controls.Add(this.tabPageAcoperireDisciplina);
            this.tabControl1.Location = new System.Drawing.Point(30, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(744, 348);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageFacultate
            // 
            this.tabPageFacultate.Controls.Add(this.buttonAdaugaFacultate);
            this.tabPageFacultate.Controls.Add(this.textBoxAdresaFacultate);
            this.tabPageFacultate.Controls.Add(this.textBoxDenumireFacultate);
            this.tabPageFacultate.Controls.Add(this.labelAdresaFac);
            this.tabPageFacultate.Controls.Add(this.labelDenFac);
            this.tabPageFacultate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageFacultate.Location = new System.Drawing.Point(4, 22);
            this.tabPageFacultate.Name = "tabPageFacultate";
            this.tabPageFacultate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFacultate.Size = new System.Drawing.Size(736, 322);
            this.tabPageFacultate.TabIndex = 0;
            this.tabPageFacultate.Text = "Facultate";
            this.tabPageFacultate.UseVisualStyleBackColor = true;
            // 
            // tabPageSpecializare
            // 
            this.tabPageSpecializare.Controls.Add(this.buttonAdaugaSpecializare);
            this.tabPageSpecializare.Controls.Add(this.comboBoxDropDownListFacultate);
            this.tabPageSpecializare.Controls.Add(this.textBoxDenumireSpecializare);
            this.tabPageSpecializare.Controls.Add(this.labelFacultateSpec);
            this.tabPageSpecializare.Controls.Add(this.groupBoxFormaInv);
            this.tabPageSpecializare.Controls.Add(this.labelDenSpec);
            this.tabPageSpecializare.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageSpecializare.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpecializare.Name = "tabPageSpecializare";
            this.tabPageSpecializare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpecializare.Size = new System.Drawing.Size(736, 322);
            this.tabPageSpecializare.TabIndex = 1;
            this.tabPageSpecializare.Text = "Specializare";
            this.tabPageSpecializare.UseVisualStyleBackColor = true;
            // 
            // tabPageGrupa
            // 
            this.tabPageGrupa.Controls.Add(this.buttonAdaugaGrupa);
            this.tabPageGrupa.Controls.Add(this.numericUpDownNrStudentiGrupa);
            this.tabPageGrupa.Controls.Add(this.label5);
            this.tabPageGrupa.Controls.Add(this.labelAnUniversitarGrupa);
            this.tabPageGrupa.Controls.Add(this.label4);
            this.tabPageGrupa.Controls.Add(this.comboBoxDropDownListAnStudiuGrupa);
            this.tabPageGrupa.Controls.Add(this.label3);
            this.tabPageGrupa.Controls.Add(this.numericUpDownNrGrupa);
            this.tabPageGrupa.Controls.Add(this.label2);
            this.tabPageGrupa.Controls.Add(this.comboBoxDropDownListSpecializareGrupa);
            this.tabPageGrupa.Controls.Add(this.label1);
            this.tabPageGrupa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageGrupa.Location = new System.Drawing.Point(4, 22);
            this.tabPageGrupa.Name = "tabPageGrupa";
            this.tabPageGrupa.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGrupa.Size = new System.Drawing.Size(736, 322);
            this.tabPageGrupa.TabIndex = 2;
            this.tabPageGrupa.Text = "Grupa";
            this.tabPageGrupa.UseVisualStyleBackColor = true;
            // 
            // tabPageProfesor
            // 
            this.tabPageProfesor.Location = new System.Drawing.Point(4, 22);
            this.tabPageProfesor.Name = "tabPageProfesor";
            this.tabPageProfesor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProfesor.Size = new System.Drawing.Size(736, 322);
            this.tabPageProfesor.TabIndex = 3;
            this.tabPageProfesor.Text = "Profesor";
            this.tabPageProfesor.UseVisualStyleBackColor = true;
            // 
            // tabPageDisciplina
            // 
            this.tabPageDisciplina.Location = new System.Drawing.Point(4, 22);
            this.tabPageDisciplina.Name = "tabPageDisciplina";
            this.tabPageDisciplina.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDisciplina.Size = new System.Drawing.Size(736, 322);
            this.tabPageDisciplina.TabIndex = 4;
            this.tabPageDisciplina.Text = "Disciplina";
            this.tabPageDisciplina.UseVisualStyleBackColor = true;
            // 
            // tabPageSesiune
            // 
            this.tabPageSesiune.Location = new System.Drawing.Point(4, 22);
            this.tabPageSesiune.Name = "tabPageSesiune";
            this.tabPageSesiune.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSesiune.Size = new System.Drawing.Size(736, 322);
            this.tabPageSesiune.TabIndex = 5;
            this.tabPageSesiune.Text = "Sesiune";
            this.tabPageSesiune.UseVisualStyleBackColor = true;
            // 
            // tabPageCorp
            // 
            this.tabPageCorp.Location = new System.Drawing.Point(4, 22);
            this.tabPageCorp.Name = "tabPageCorp";
            this.tabPageCorp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCorp.Size = new System.Drawing.Size(736, 322);
            this.tabPageCorp.TabIndex = 6;
            this.tabPageCorp.Text = "Corp";
            this.tabPageCorp.UseVisualStyleBackColor = true;
            // 
            // tabPageSala
            // 
            this.tabPageSala.Location = new System.Drawing.Point(4, 22);
            this.tabPageSala.Name = "tabPageSala";
            this.tabPageSala.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSala.Size = new System.Drawing.Size(736, 322);
            this.tabPageSala.TabIndex = 7;
            this.tabPageSala.Text = "Sala";
            this.tabPageSala.UseVisualStyleBackColor = true;
            // 
            // tabPageAlocareDisciplina
            // 
            this.tabPageAlocareDisciplina.Location = new System.Drawing.Point(4, 22);
            this.tabPageAlocareDisciplina.Name = "tabPageAlocareDisciplina";
            this.tabPageAlocareDisciplina.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlocareDisciplina.Size = new System.Drawing.Size(736, 322);
            this.tabPageAlocareDisciplina.TabIndex = 8;
            this.tabPageAlocareDisciplina.Text = "Alocare Disciplina";
            this.tabPageAlocareDisciplina.UseVisualStyleBackColor = true;
            // 
            // tabPageAcoperireDisciplina
            // 
            this.tabPageAcoperireDisciplina.Location = new System.Drawing.Point(4, 22);
            this.tabPageAcoperireDisciplina.Name = "tabPageAcoperireDisciplina";
            this.tabPageAcoperireDisciplina.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAcoperireDisciplina.Size = new System.Drawing.Size(736, 322);
            this.tabPageAcoperireDisciplina.TabIndex = 9;
            this.tabPageAcoperireDisciplina.Text = "Acoperire Disciplina";
            this.tabPageAcoperireDisciplina.UseVisualStyleBackColor = true;
            // 
            // labelDenFac
            // 
            this.labelDenFac.AutoSize = true;
            this.labelDenFac.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDenFac.Location = new System.Drawing.Point(6, 30);
            this.labelDenFac.Name = "labelDenFac";
            this.labelDenFac.Size = new System.Drawing.Size(98, 24);
            this.labelDenFac.TabIndex = 0;
            this.labelDenFac.Text = "Denumire:";
            // 
            // labelAdresaFac
            // 
            this.labelAdresaFac.AutoSize = true;
            this.labelAdresaFac.Location = new System.Drawing.Point(29, 71);
            this.labelAdresaFac.Name = "labelAdresaFac";
            this.labelAdresaFac.Size = new System.Drawing.Size(75, 24);
            this.labelAdresaFac.TabIndex = 1;
            this.labelAdresaFac.Text = "Adresa:";
            // 
            // textBoxDenumireFacultate
            // 
            this.textBoxDenumireFacultate.Location = new System.Drawing.Point(110, 25);
            this.textBoxDenumireFacultate.Name = "textBoxDenumireFacultate";
            this.textBoxDenumireFacultate.Size = new System.Drawing.Size(322, 29);
            this.textBoxDenumireFacultate.TabIndex = 2;
            // 
            // textBoxAdresaFacultate
            // 
            this.textBoxAdresaFacultate.Location = new System.Drawing.Point(111, 71);
            this.textBoxAdresaFacultate.Name = "textBoxAdresaFacultate";
            this.textBoxAdresaFacultate.Size = new System.Drawing.Size(321, 29);
            this.textBoxAdresaFacultate.TabIndex = 3;
            // 
            // buttonAdaugaFacultate
            // 
            this.buttonAdaugaFacultate.Location = new System.Drawing.Point(144, 116);
            this.buttonAdaugaFacultate.Name = "buttonAdaugaFacultate";
            this.buttonAdaugaFacultate.Size = new System.Drawing.Size(258, 44);
            this.buttonAdaugaFacultate.TabIndex = 4;
            this.buttonAdaugaFacultate.Text = "Adauga facultate";
            this.buttonAdaugaFacultate.UseVisualStyleBackColor = true;
            this.buttonAdaugaFacultate.Click += new System.EventHandler(this.buttonAdaugaFacultate_Click);
            // 
            // labelDenSpec
            // 
            this.labelDenSpec.AutoSize = true;
            this.labelDenSpec.Location = new System.Drawing.Point(6, 29);
            this.labelDenSpec.Name = "labelDenSpec";
            this.labelDenSpec.Size = new System.Drawing.Size(98, 24);
            this.labelDenSpec.TabIndex = 0;
            this.labelDenSpec.Text = "Denumire:";
            // 
            // groupBoxFormaInv
            // 
            this.groupBoxFormaInv.Controls.Add(this.radioButtonMaster);
            this.groupBoxFormaInv.Controls.Add(this.radioButtonLicenta);
            this.groupBoxFormaInv.Location = new System.Drawing.Point(111, 125);
            this.groupBoxFormaInv.Name = "groupBoxFormaInv";
            this.groupBoxFormaInv.Size = new System.Drawing.Size(179, 100);
            this.groupBoxFormaInv.TabIndex = 1;
            this.groupBoxFormaInv.TabStop = false;
            this.groupBoxFormaInv.Text = "Forma invatamant";
            // 
            // radioButtonLicenta
            // 
            this.radioButtonLicenta.AutoSize = true;
            this.radioButtonLicenta.Checked = true;
            this.radioButtonLicenta.Location = new System.Drawing.Point(17, 29);
            this.radioButtonLicenta.Name = "radioButtonLicenta";
            this.radioButtonLicenta.Size = new System.Drawing.Size(88, 28);
            this.radioButtonLicenta.TabIndex = 0;
            this.radioButtonLicenta.TabStop = true;
            this.radioButtonLicenta.Text = "Licenta";
            this.radioButtonLicenta.UseVisualStyleBackColor = true;
            // 
            // radioButtonMaster
            // 
            this.radioButtonMaster.AutoSize = true;
            this.radioButtonMaster.Location = new System.Drawing.Point(17, 63);
            this.radioButtonMaster.Name = "radioButtonMaster";
            this.radioButtonMaster.Size = new System.Drawing.Size(84, 28);
            this.radioButtonMaster.TabIndex = 1;
            this.radioButtonMaster.Text = "Master";
            this.radioButtonMaster.UseVisualStyleBackColor = true;
            // 
            // labelFacultateSpec
            // 
            this.labelFacultateSpec.AutoSize = true;
            this.labelFacultateSpec.Location = new System.Drawing.Point(13, 76);
            this.labelFacultateSpec.Name = "labelFacultateSpec";
            this.labelFacultateSpec.Size = new System.Drawing.Size(91, 24);
            this.labelFacultateSpec.TabIndex = 2;
            this.labelFacultateSpec.Text = "Facultate:";
            // 
            // textBoxDenumireSpecializare
            // 
            this.textBoxDenumireSpecializare.Location = new System.Drawing.Point(110, 24);
            this.textBoxDenumireSpecializare.Name = "textBoxDenumireSpecializare";
            this.textBoxDenumireSpecializare.Size = new System.Drawing.Size(238, 29);
            this.textBoxDenumireSpecializare.TabIndex = 3;
            // 
            // comboBoxDropDownListFacultate
            // 
            this.comboBoxDropDownListFacultate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDropDownListFacultate.FormattingEnabled = true;
            this.comboBoxDropDownListFacultate.Location = new System.Drawing.Point(111, 68);
            this.comboBoxDropDownListFacultate.Name = "comboBoxDropDownListFacultate";
            this.comboBoxDropDownListFacultate.Size = new System.Drawing.Size(237, 32);
            this.comboBoxDropDownListFacultate.TabIndex = 4;
            // 
            // buttonAdaugaSpecializare
            // 
            this.buttonAdaugaSpecializare.Location = new System.Drawing.Point(128, 241);
            this.buttonAdaugaSpecializare.Name = "buttonAdaugaSpecializare";
            this.buttonAdaugaSpecializare.Size = new System.Drawing.Size(207, 38);
            this.buttonAdaugaSpecializare.TabIndex = 5;
            this.buttonAdaugaSpecializare.Text = "Adauga Specializare";
            this.buttonAdaugaSpecializare.UseVisualStyleBackColor = true;
            this.buttonAdaugaSpecializare.Click += new System.EventHandler(this.buttonAdaugaSpecializare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Specializare:";
            // 
            // comboBoxDropDownListSpecializareGrupa
            // 
            this.comboBoxDropDownListSpecializareGrupa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDropDownListSpecializareGrupa.FormattingEnabled = true;
            this.comboBoxDropDownListSpecializareGrupa.Location = new System.Drawing.Point(143, 20);
            this.comboBoxDropDownListSpecializareGrupa.Name = "comboBoxDropDownListSpecializareGrupa";
            this.comboBoxDropDownListSpecializareGrupa.Size = new System.Drawing.Size(239, 32);
            this.comboBoxDropDownListSpecializareGrupa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numar grupa:";
            // 
            // numericUpDownNrGrupa
            // 
            this.numericUpDownNrGrupa.Location = new System.Drawing.Point(143, 71);
            this.numericUpDownNrGrupa.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNrGrupa.Name = "numericUpDownNrGrupa";
            this.numericUpDownNrGrupa.Size = new System.Drawing.Size(239, 29);
            this.numericUpDownNrGrupa.TabIndex = 3;
            this.numericUpDownNrGrupa.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "An studiu:";
            // 
            // comboBoxDropDownListAnStudiuGrupa
            // 
            this.comboBoxDropDownListAnStudiuGrupa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDropDownListAnStudiuGrupa.FormattingEnabled = true;
            this.comboBoxDropDownListAnStudiuGrupa.Location = new System.Drawing.Point(143, 113);
            this.comboBoxDropDownListAnStudiuGrupa.Name = "comboBoxDropDownListAnStudiuGrupa";
            this.comboBoxDropDownListAnStudiuGrupa.Size = new System.Drawing.Size(239, 32);
            this.comboBoxDropDownListAnStudiuGrupa.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "An universitar:";
            // 
            // labelAnUniversitarGrupa
            // 
            this.labelAnUniversitarGrupa.AutoSize = true;
            this.labelAnUniversitarGrupa.Location = new System.Drawing.Point(196, 166);
            this.labelAnUniversitarGrupa.Name = "labelAnUniversitarGrupa";
            this.labelAnUniversitarGrupa.Size = new System.Drawing.Size(0, 24);
            this.labelAnUniversitarGrupa.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Numar studenti:";
            // 
            // numericUpDownNrStudentiGrupa
            // 
            this.numericUpDownNrStudentiGrupa.Location = new System.Drawing.Point(143, 204);
            this.numericUpDownNrStudentiGrupa.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownNrStudentiGrupa.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNrStudentiGrupa.Name = "numericUpDownNrStudentiGrupa";
            this.numericUpDownNrStudentiGrupa.Size = new System.Drawing.Size(239, 29);
            this.numericUpDownNrStudentiGrupa.TabIndex = 9;
            this.numericUpDownNrStudentiGrupa.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonAdaugaGrupa
            // 
            this.buttonAdaugaGrupa.Location = new System.Drawing.Point(168, 250);
            this.buttonAdaugaGrupa.Name = "buttonAdaugaGrupa";
            this.buttonAdaugaGrupa.Size = new System.Drawing.Size(185, 44);
            this.buttonAdaugaGrupa.TabIndex = 10;
            this.buttonAdaugaGrupa.Text = "Adauga Grupa";
            this.buttonAdaugaGrupa.UseVisualStyleBackColor = true;
            this.buttonAdaugaGrupa.Click += new System.EventHandler(this.buttonAdaugaGrupa_Click);
            // 
            // AddDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 464);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelAnUniversitarCurent);
            this.Controls.Add(this.labelAddDataConnectionStatus);
            this.Controls.Add(this.buttonAddDataBack);
            this.Name = "AddDataForm";
            this.Text = "AddDataForm";
            this.Load += new System.EventHandler(this.AddDataForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageFacultate.ResumeLayout(false);
            this.tabPageFacultate.PerformLayout();
            this.tabPageSpecializare.ResumeLayout(false);
            this.tabPageSpecializare.PerformLayout();
            this.tabPageGrupa.ResumeLayout(false);
            this.tabPageGrupa.PerformLayout();
            this.groupBoxFormaInv.ResumeLayout(false);
            this.groupBoxFormaInv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNrGrupa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNrStudentiGrupa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddDataBack;
        private System.Windows.Forms.Label labelAddDataConnectionStatus;
        private System.Windows.Forms.Label labelAnUniversitarCurent;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageFacultate;
        private System.Windows.Forms.TabPage tabPageSpecializare;
        private System.Windows.Forms.TextBox textBoxAdresaFacultate;
        private System.Windows.Forms.TextBox textBoxDenumireFacultate;
        private System.Windows.Forms.Label labelAdresaFac;
        private System.Windows.Forms.Label labelDenFac;
        private System.Windows.Forms.TabPage tabPageGrupa;
        private System.Windows.Forms.TabPage tabPageProfesor;
        private System.Windows.Forms.TabPage tabPageDisciplina;
        private System.Windows.Forms.TabPage tabPageSesiune;
        private System.Windows.Forms.TabPage tabPageCorp;
        private System.Windows.Forms.TabPage tabPageSala;
        private System.Windows.Forms.TabPage tabPageAlocareDisciplina;
        private System.Windows.Forms.TabPage tabPageAcoperireDisciplina;
        private System.Windows.Forms.Button buttonAdaugaFacultate;
        private System.Windows.Forms.Button buttonAdaugaSpecializare;
        private System.Windows.Forms.ComboBox comboBoxDropDownListFacultate;
        private System.Windows.Forms.TextBox textBoxDenumireSpecializare;
        private System.Windows.Forms.Label labelFacultateSpec;
        private System.Windows.Forms.GroupBox groupBoxFormaInv;
        private System.Windows.Forms.RadioButton radioButtonMaster;
        private System.Windows.Forms.RadioButton radioButtonLicenta;
        private System.Windows.Forms.Label labelDenSpec;
        private System.Windows.Forms.Button buttonAdaugaGrupa;
        private System.Windows.Forms.NumericUpDown numericUpDownNrStudentiGrupa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelAnUniversitarGrupa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDropDownListAnStudiuGrupa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownNrGrupa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDropDownListSpecializareGrupa;
        private System.Windows.Forms.Label label1;
    }
}