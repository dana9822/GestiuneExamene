
namespace GestiuneExameneWindowsForms
{
    partial class ModificaProfesorExaminator
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
            this.dataGridViewUpdateProf = new System.Windows.Forms.DataGridView();
            this.comboBoxUpdateProf = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_UpdateProfSuprav = new System.Windows.Forms.Button();
            this.buttonScheduleExamBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUpdateProf)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUpdateProf
            // 
            this.dataGridViewUpdateProf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUpdateProf.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewUpdateProf.Name = "dataGridViewUpdateProf";
            this.dataGridViewUpdateProf.Size = new System.Drawing.Size(950, 423);
            this.dataGridViewUpdateProf.TabIndex = 0;
            this.dataGridViewUpdateProf.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellRowClick_selectedIndexChanged);
            // 
            // comboBoxUpdateProf
            // 
            this.comboBoxUpdateProf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUpdateProf.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUpdateProf.FormattingEnabled = true;
            this.comboBoxUpdateProf.Location = new System.Drawing.Point(278, 441);
            this.comboBoxUpdateProf.Name = "comboBoxUpdateProf";
            this.comboBoxUpdateProf.Size = new System.Drawing.Size(427, 39);
            this.comboBoxUpdateProf.Sorted = true;
            this.comboBoxUpdateProf.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 444);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(260, 31);
            this.label7.TabIndex = 21;
            this.label7.Text = "Asistent examinator:";
            // 
            // button_UpdateProfSuprav
            // 
            this.button_UpdateProfSuprav.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_UpdateProfSuprav.Location = new System.Drawing.Point(711, 440);
            this.button_UpdateProfSuprav.Name = "button_UpdateProfSuprav";
            this.button_UpdateProfSuprav.Size = new System.Drawing.Size(251, 40);
            this.button_UpdateProfSuprav.TabIndex = 29;
            this.button_UpdateProfSuprav.Text = "Modifica asistent";
            this.button_UpdateProfSuprav.UseVisualStyleBackColor = true;
            this.button_UpdateProfSuprav.Click += new System.EventHandler(this.button_UpdateProfSuprav_Click);
            // 
            // buttonScheduleExamBack
            // 
            this.buttonScheduleExamBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScheduleExamBack.Location = new System.Drawing.Point(848, 509);
            this.buttonScheduleExamBack.Name = "buttonScheduleExamBack";
            this.buttonScheduleExamBack.Size = new System.Drawing.Size(114, 51);
            this.buttonScheduleExamBack.TabIndex = 30;
            this.buttonScheduleExamBack.Text = "Inapoi";
            this.buttonScheduleExamBack.UseVisualStyleBackColor = true;
            this.buttonScheduleExamBack.Click += new System.EventHandler(this.buttonScheduleExamBack_Click);
            // 
            // ModificaProfesorExaminator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 572);
            this.Controls.Add(this.buttonScheduleExamBack);
            this.Controls.Add(this.button_UpdateProfSuprav);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxUpdateProf);
            this.Controls.Add(this.dataGridViewUpdateProf);
            this.Name = "ModificaProfesorExaminator";
            this.Text = "ModificaProfesorExaminator";
            this.Load += new System.EventHandler(this.ModificaProfesorExaminator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUpdateProf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUpdateProf;
        private System.Windows.Forms.ComboBox comboBoxUpdateProf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_UpdateProfSuprav;
        private System.Windows.Forms.Button buttonScheduleExamBack;
    }
}