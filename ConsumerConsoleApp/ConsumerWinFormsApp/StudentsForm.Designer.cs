namespace ConsumerWinFormsApp
{
    partial class StudentsForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.studentEntryTabPage = new System.Windows.Forms.TabPage();
            this.studentListTabPage = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.studentEntryTabPage);
            this.tabControl1.Controls.Add(this.studentListTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(75, 40);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 553);
            this.tabControl1.TabIndex = 0;
            // 
            // studentEntryTabPage
            // 
            this.studentEntryTabPage.Location = new System.Drawing.Point(4, 44);
            this.studentEntryTabPage.Name = "studentEntryTabPage";
            this.studentEntryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.studentEntryTabPage.Size = new System.Drawing.Size(614, 505);
            this.studentEntryTabPage.TabIndex = 0;
            this.studentEntryTabPage.Text = "New Student";
            this.studentEntryTabPage.UseVisualStyleBackColor = true;
            // 
            // studentListTabPage
            // 
            this.studentListTabPage.Location = new System.Drawing.Point(4, 44);
            this.studentListTabPage.Name = "studentListTabPage";
            this.studentListTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.studentListTabPage.Size = new System.Drawing.Size(614, 505);
            this.studentListTabPage.TabIndex = 1;
            this.studentListTabPage.Text = "Students List";
            this.studentListTabPage.UseVisualStyleBackColor = true;
            // 
            // StudentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 553);
            this.Controls.Add(this.tabControl1);
            this.Name = "StudentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StudentsForm";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage studentEntryTabPage;
        private System.Windows.Forms.TabPage studentListTabPage;
    }
}