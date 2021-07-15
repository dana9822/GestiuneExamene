
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
            this.dataGridViewOrarExamen = new System.Windows.Forms.DataGridView();
            this.button_descarcaOrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrarExamen)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStatisticsBack
            // 
            this.buttonStatisticsBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStatisticsBack.Location = new System.Drawing.Point(1122, 592);
            this.buttonStatisticsBack.Name = "buttonStatisticsBack";
            this.buttonStatisticsBack.Size = new System.Drawing.Size(125, 61);
            this.buttonStatisticsBack.TabIndex = 0;
            this.buttonStatisticsBack.Text = "Inapoi";
            this.buttonStatisticsBack.UseVisualStyleBackColor = true;
            this.buttonStatisticsBack.Click += new System.EventHandler(this.buttonStatisticsBack_Click);
            // 
            // dataGridViewOrarExamen
            // 
            this.dataGridViewOrarExamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrarExamen.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewOrarExamen.Name = "dataGridViewOrarExamen";
            this.dataGridViewOrarExamen.Size = new System.Drawing.Size(1235, 574);
            this.dataGridViewOrarExamen.TabIndex = 1;
            // 
            // button_descarcaOrar
            // 
            this.button_descarcaOrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_descarcaOrar.Location = new System.Drawing.Point(499, 592);
            this.button_descarcaOrar.Name = "button_descarcaOrar";
            this.button_descarcaOrar.Size = new System.Drawing.Size(300, 61);
            this.button_descarcaOrar.TabIndex = 2;
            this.button_descarcaOrar.Text = "Descarca Orar";
            this.button_descarcaOrar.UseVisualStyleBackColor = true;
            this.button_descarcaOrar.Click += new System.EventHandler(this.button_descarcaOrar_Click);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 665);
            this.Controls.Add(this.button_descarcaOrar);
            this.Controls.Add(this.dataGridViewOrarExamen);
            this.Controls.Add(this.buttonStatisticsBack);
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrarExamen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStatisticsBack;
        private System.Windows.Forms.DataGridView dataGridViewOrarExamen;
        private System.Windows.Forms.Button button_descarcaOrar;
    }
}