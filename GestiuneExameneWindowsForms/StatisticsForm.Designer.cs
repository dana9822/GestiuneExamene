
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.buttonStatisticsBack = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ExamenAnUniv = new GestiuneExameneWindowsForms.ExamenAnUniv();
            this.ExamenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ExamenAnUniv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExamenBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStatisticsBack
            // 
            this.buttonStatisticsBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStatisticsBack.Location = new System.Drawing.Point(737, 592);
            this.buttonStatisticsBack.Name = "buttonStatisticsBack";
            this.buttonStatisticsBack.Size = new System.Drawing.Size(63, 28);
            this.buttonStatisticsBack.TabIndex = 0;
            this.buttonStatisticsBack.Text = "Inapoi";
            this.buttonStatisticsBack.UseVisualStyleBackColor = true;
            this.buttonStatisticsBack.Click += new System.EventHandler(this.buttonStatisticsBack_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet_ExamenAnUniv";
            reportDataSource1.Value = this.ExamenBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GestiuneExameneWindowsForms.ReportExamenAnUniv.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(816, 586);
            this.reportViewer1.TabIndex = 1;
            // 
            // ExamenAnUniv
            // 
            this.ExamenAnUniv.DataSetName = "ExamenAnUniv";
            this.ExamenAnUniv.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ExamenBindingSource
            // 
            this.ExamenBindingSource.DataMember = "Examen";
            this.ExamenBindingSource.DataSource = this.ExamenAnUniv;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 632);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.buttonStatisticsBack);
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ExamenAnUniv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExamenBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStatisticsBack;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ExamenBindingSource;
        private ExamenAnUniv ExamenAnUniv;
    }
}