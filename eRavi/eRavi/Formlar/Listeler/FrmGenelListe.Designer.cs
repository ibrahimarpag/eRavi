namespace eRavi.Formlar.Listeler
{
    partial class FrmTanimListe
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
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            this.progressLoader = new DevExpress.XtraWaitForm.ProgressPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new RaviMalzeme.RaviGridControl();
            this.gridView1 = new RaviMalzeme.RaviGridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressLoader
            // 
            this.progressLoader.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressLoader.Appearance.Options.UseBackColor = true;
            this.progressLoader.Caption = "Liste Yükleniyor";
            this.progressLoader.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressLoader.Description = "Lütfen Bekleyiniz ...";
            this.progressLoader.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressLoader.Location = new System.Drawing.Point(0, 0);
            this.progressLoader.Name = "progressLoader";
            this.progressLoader.Size = new System.Drawing.Size(673, 71);
            this.progressLoader.TabIndex = 4;
            this.progressLoader.Text = "progressPanel1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 71);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(673, 497);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "groupControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 23);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RaviButtonCustomizationForm = false;
            this.gridControl1.Size = new System.Drawing.Size(669, 472);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Data = null;
            this.gridView1.DetailHeight = 377;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GridEKey = RaviDataManager.GRIDEKEY.NONE;
            this.gridView1.GridFTip = RaviDataManager.GRIDFTIP.NONE;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.tokenSource = cancellationTokenSource1;
            // 
            // FrmGenelListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 568);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.progressLoader);
            this.Name = "FrmGenelListe";
            this.Text = "FrmGenelListe";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressLoader;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private RaviMalzeme.RaviGridControl gridControl1;
        private RaviMalzeme.RaviGridView gridView1;
    }
}