using DevExpress.Utils.Layout;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviMalzeme.Manager
{
    public class RaviBildirimRow : StackPanel
    {
        //private PanelControl panelControl3 { get; set; }
        //private SeparatorControl separatorControl1 { get; set; }
        //private LabelControl labelControl1 { get; set; }
        public RaviBildirimRow(string Baslik = "") : base()
        {
            
            base.AutoScroll = true;
            base.Dock = System.Windows.Forms.DockStyle.Fill;
            base.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
            base.Location = new System.Drawing.Point(2, 2);
            base.Padding = new System.Windows.Forms.Padding(0,10,10,10);
            base.TabIndex = 0;
            
        }
        public void LoadData(List<dynamic> Data)
        {
            int sayi = 0;
            foreach (var item in Data)
            {
                var pc3 = new PanelControl();
                
                var lbl = new LabelControl();
                lbl.Appearance.Font = new System.Drawing.Font("Nina", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                lbl.Appearance.Options.UseFont = true;
                lbl.Dock = System.Windows.Forms.DockStyle.Left;
                lbl.Location = new System.Drawing.Point(0, 0);
                lbl.TabIndex = 0;
                lbl.Text = item.aciklama;
                lbl.Size = new Size(20, 16);

                var spc = new SeparatorControl();
                spc.Dock = System.Windows.Forms.DockStyle.Fill;
                spc.LineThickness = 1;
                spc.TabIndex = 1;




                pc3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                pc3.Controls.Add(spc);
                pc3.Controls.Add(lbl);
                pc3.Dock = System.Windows.Forms.DockStyle.Top;
                pc3.Location = new System.Drawing.Point(2, 2);
                pc3.Name = "panelControl3";
                pc3.Size = new System.Drawing.Size(275, sayi == 0 ? 20 : 30);
                pc3.TabIndex = 1;
                pc3.Margin = new System.Windows.Forms.Padding(0);
                pc3.Padding = new System.Windows.Forms.Padding(0, sayi == 0 ? 0 : 10, 0, 0);
                sayi++;
                base.Controls.Add(pc3);
                foreach (var detay in item.detay)
                {
                    var ldb = new LabelControl();
                    var lda = new LabelControl();
                    ldb.Appearance.Font = new System.Drawing.Font("Nina", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    ldb.Appearance.Options.UseFont = true;
                    ldb.Dock = System.Windows.Forms.DockStyle.Top;
                    ldb.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
                    ldb.Name = "lblDetayBaslik";
                    ldb.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
                    ldb.Size = new System.Drawing.Size(275, 28);
                    ldb.AutoSizeMode = LabelAutoSizeMode.Vertical;
                    ldb.TabIndex = 2;
                    ldb.Text = detay.baslik;
                    ldb.Margin = new System.Windows.Forms.Padding(0);

                    lda.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
                    lda.Appearance.Font = new System.Drawing.Font("Nina", 9F);
                    lda.Appearance.Options.UseFont = true;
                    lda.Dock = System.Windows.Forms.DockStyle.Top;
                    lda.Name = "lblDetayAciklama";
                    lda.Size = new System.Drawing.Size(275, 0);
                    lda.AutoSizeMode = LabelAutoSizeMode.Vertical;
                    lda.TabIndex = 2;
                    lda.Text = "E-Adisyon Entegrasyonu ile ilgili çalışgili çalışmalara başlandı.malara başlandı.";
                    lda.Margin = new System.Windows.Forms.Padding(0);
                    lda.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);


                    var spc1 = new SeparatorControl();
                    spc1.Dock = System.Windows.Forms.DockStyle.Top;
                    spc1.LineAlignment = Alignment.Default;
                    spc1.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
                    spc1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    spc1.LineThickness = 1;
                    spc1.Size = new Size(275, 5);

                    base.Controls.Add(ldb);
                    base.Controls.Add(lda);
                    if (item.detay.IndexOf(detay) != item.detay.Count-1)
                        base.Controls.Add(spc1);
                }
            }
        }
    }
}
