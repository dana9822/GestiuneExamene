
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
            this.SuspendLayout();
            // 
            // buttonAddDataBack
            // 
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
            this.labelAddDataConnectionStatus.Location = new System.Drawing.Point(24, 410);
            this.labelAddDataConnectionStatus.Name = "labelAddDataConnectionStatus";
            this.labelAddDataConnectionStatus.Size = new System.Drawing.Size(0, 13);
            this.labelAddDataConnectionStatus.TabIndex = 1;
            this.labelAddDataConnectionStatus.Visible = false;
            // 
            // AddDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelAddDataConnectionStatus);
            this.Controls.Add(this.buttonAddDataBack);
            this.Name = "AddDataForm";
            this.Text = "AddDataForm";
            this.Load += new System.EventHandler(this.AddDataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddDataBack;
        private System.Windows.Forms.Label labelAddDataConnectionStatus;
    }
}