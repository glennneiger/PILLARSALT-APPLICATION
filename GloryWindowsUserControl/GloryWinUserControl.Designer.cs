namespace GloryWindowsUserControl
{
    partial class GloryWinUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GloryWinUserControl));
            this.axGloryCoCtrl2 = new AxGLORYCOCTRLLib.AxGloryCoCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.axGloryCoCtrl2)).BeginInit();
            this.SuspendLayout();
            // 
            // axGloryCoCtrl2
            // 
            this.axGloryCoCtrl2.Enabled = true;
            this.axGloryCoCtrl2.Location = new System.Drawing.Point(16, 15);
            this.axGloryCoCtrl2.Name = "axGloryCoCtrl2";
            this.axGloryCoCtrl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGloryCoCtrl2.OcxState")));
            this.axGloryCoCtrl2.Size = new System.Drawing.Size(161, 120);
            this.axGloryCoCtrl2.TabIndex = 0;
            // 
            // GloryWinUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axGloryCoCtrl2);
            this.Name = "GloryWinUserControl";
            this.Size = new System.Drawing.Size(269, 236);
            //this.Load += new System.EventHandler(this.GloryWinUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axGloryCoCtrl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxGLORYCOCTRLLib.AxGloryCoCtrl axGloryCoCtrl2;
    }
}
