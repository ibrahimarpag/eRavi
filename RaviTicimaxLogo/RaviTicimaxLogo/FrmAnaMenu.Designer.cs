namespace RaviTicimaxLogo
{
    partial class FrmAnaMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnaMenu));
            this.imageLogo = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnDokulenUrunKontrol = new DevExpress.XtraEditors.SimpleButton();
            this.btnMenuKapat = new DevExpress.XtraEditors.SimpleButton();
            this.panelCenter = new DevExpress.XtraEditors.PanelControl();
            this.btnMaximized = new DevExpress.XtraEditors.SimpleButton();
            this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnMinimized = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCenter)).BeginInit();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
            this.stackPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageLogo
            // 
            this.imageLogo.EditValue = ((object)(resources.GetObject("imageLogo.EditValue")));
            this.imageLogo.Location = new System.Drawing.Point(22, 20);
            this.imageLogo.Name = "imageLogo";
            this.imageLogo.Properties.AllowFocused = false;
            this.imageLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.imageLogo.Properties.Appearance.Options.UseBackColor = true;
            this.imageLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.imageLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.imageLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.imageLogo.Size = new System.Drawing.Size(302, 90);
            this.imageLogo.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(5, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(208, 60);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Yapmak İstediğiniz İşlemi Seçiniz";
            // 
            // btnDokulenUrunKontrol
            // 
            this.btnDokulenUrunKontrol.AllowFocus = false;
            this.btnDokulenUrunKontrol.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnDokulenUrunKontrol.Appearance.Options.UseFont = true;
            this.btnDokulenUrunKontrol.Location = new System.Drawing.Point(286, 3);
            this.btnDokulenUrunKontrol.Name = "btnDokulenUrunKontrol";
            this.btnDokulenUrunKontrol.Size = new System.Drawing.Size(194, 88);
            this.btnDokulenUrunKontrol.TabIndex = 2;
            this.btnDokulenUrunKontrol.Text = "Sipariş Liste";
            // 
            // btnMenuKapat
            // 
            this.btnMenuKapat.AllowFocus = false;
            this.btnMenuKapat.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnMenuKapat.Appearance.Options.UseFont = true;
            this.btnMenuKapat.Appearance.Options.UseTextOptions = true;
            this.btnMenuKapat.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnMenuKapat.Location = new System.Drawing.Point(286, 97);
            this.btnMenuKapat.Name = "btnMenuKapat";
            this.btnMenuKapat.Size = new System.Drawing.Size(194, 88);
            this.btnMenuKapat.TabIndex = 2;
            this.btnMenuKapat.Text = "Uygulamadan Çık";
            // 
            // panelCenter
            // 
            this.panelCenter.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelCenter.Appearance.Options.UseBackColor = true;
            this.panelCenter.AutoSize = true;
            this.panelCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelCenter.Controls.Add(this.labelControl1);
            this.panelCenter.Controls.Add(this.btnMenuKapat);
            this.panelCenter.Controls.Add(this.btnDokulenUrunKontrol);
            this.panelCenter.Location = new System.Drawing.Point(334, 273);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(483, 189);
            this.panelCenter.TabIndex = 3;
            // 
            // btnMaximized
            // 
            this.btnMaximized.AllowFocus = false;
            this.btnMaximized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximized.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximized.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.btnMaximized.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnMaximized.Appearance.Options.UseBackColor = true;
            this.btnMaximized.Appearance.Options.UseFont = true;
            this.btnMaximized.Appearance.Options.UseForeColor = true;
            this.btnMaximized.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMaximized.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMaximized.ImageOptions.SvgImage")));
            this.btnMaximized.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnMaximized.Location = new System.Drawing.Point(53, 6);
            this.btnMaximized.Name = "btnMaximized";
            this.btnMaximized.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnMaximized.Size = new System.Drawing.Size(40, 40);
            this.btnMaximized.TabIndex = 4;
            // 
            // stackPanel1
            // 
            this.stackPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stackPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.stackPanel1.Appearance.Options.UseBackColor = true;
            this.stackPanel1.Controls.Add(this.btnKapat);
            this.stackPanel1.Controls.Add(this.btnMaximized);
            this.stackPanel1.Controls.Add(this.btnMinimized);
            this.stackPanel1.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.RightToLeft;
            this.stackPanel1.Location = new System.Drawing.Point(1003, 0);
            this.stackPanel1.Name = "stackPanel1";
            this.stackPanel1.Size = new System.Drawing.Size(150, 53);
            this.stackPanel1.TabIndex = 5;
            this.stackPanel1.UseSkinIndents = true;
            // 
            // btnKapat
            // 
            this.btnKapat.AllowFocus = false;
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnKapat.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.btnKapat.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnKapat.Appearance.Options.UseBackColor = true;
            this.btnKapat.Appearance.Options.UseFont = true;
            this.btnKapat.Appearance.Options.UseForeColor = true;
            this.btnKapat.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnKapat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnKapat.ImageOptions.SvgImage")));
            this.btnKapat.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnKapat.Location = new System.Drawing.Point(97, 6);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnKapat.Size = new System.Drawing.Size(40, 40);
            this.btnKapat.TabIndex = 4;
            // 
            // btnMinimized
            // 
            this.btnMinimized.AllowFocus = false;
            this.btnMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimized.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimized.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.btnMinimized.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnMinimized.Appearance.Options.UseBackColor = true;
            this.btnMinimized.Appearance.Options.UseFont = true;
            this.btnMinimized.Appearance.Options.UseForeColor = true;
            this.btnMinimized.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnMinimized.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMinimized.ImageOptions.SvgImage")));
            this.btnMinimized.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnMinimized.Location = new System.Drawing.Point(9, 6);
            this.btnMinimized.Name = "btnMinimized";
            this.btnMinimized.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnMinimized.Size = new System.Drawing.Size(40, 40);
            this.btnMinimized.TabIndex = 4;
            // 
            // FrmAnaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(1151, 734);
            this.Controls.Add(this.stackPanel1);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.imageLogo);
            this.DoubleBuffered = true;
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAnaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.imageLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCenter)).EndInit();
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
            this.stackPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit imageLogo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnDokulenUrunKontrol;
        private DevExpress.XtraEditors.SimpleButton btnMenuKapat;
        private DevExpress.XtraEditors.PanelControl panelCenter;
        private DevExpress.XtraEditors.SimpleButton btnMaximized;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.SimpleButton btnMinimized;
    }
}

