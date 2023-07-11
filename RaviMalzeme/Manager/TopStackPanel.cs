using DevExpress.Utils.Layout;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using RaviDataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaviMalzeme.Manager
{
    public class TopStackPanel : PanelControl
    {
        FORMTIP FormTip { get; set; }
        public TopStackPanel(string Baslik, FORMTIP formTip)
        {
            this.FormTip = formTip;
            var lblBaslik = new LabelControl()
            {
                Text = Baslik,
                AutoSizeMode = LabelAutoSizeMode.None,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Width = 200,
                Margin = new System.Windows.Forms.Padding(20, 0, 0, 0),
                Font = new System.Drawing.Font("Nina", 14, System.Drawing.FontStyle.Bold)
            };
            lblBaslik.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            lblBaslik.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            base.Dock = System.Windows.Forms.DockStyle.Top;
            base.Height = 65;

            var stack = GetStack();
            FillStack(stack);

            base.Controls.Add(lblBaslik);
            base.Controls.Add(stack);
        }
        private void FillStack(StackPanel stack)
        {
            stack.Controls.Add(GetTopButton("Kapat", "skapat"));
            switch (FormTip)
            {
                case FORMTIP.NONE:
                    break;
                case FORMTIP.SMS:
                    {
                        var drp = GetTopDropdown("Liste", "dikeyrapor", new[]
                           {
                                new { Caption = "Getir", resim = "getir"},
                                new { Caption = "Göster", resim = "goster"},
                                new { Caption = "Rapor Seç", resim = "sec"},
                                new { Caption = "Sıralama", resim = "sirala"},
                                new { Caption = "Excel", resim = "excel"},
                                new { Caption = "Tasarla", resim = "tasarla"}
                            });
                        stack.Controls.Add(drp);
                        stack.Controls.Add(GetTopButton("Sms Gönder", "smsgonder"));
                    }
                    break;
                case FORMTIP.MAIL:
                    {
                        var drp = GetTopDropdown("Liste", "dikeyrapor", new[]
                           {
                                new { Caption = "Getir", resim = "getir"},
                                new { Caption = "Göster", resim = "goster"},
                                new { Caption = "Rapor Seç", resim = "sec"},
                                new { Caption = "Sıralama", resim = "sirala"},
                                new { Caption = "Excel", resim = "excel"},
                                new { Caption = "Tasarla", resim = "tasarla"}
                            });
                        stack.Controls.Add(drp);
                        stack.Controls.Add(GetTopButton("Mail Gönder", "mailgonder"));
                    }
                    break;
                case FORMTIP.TAKVIM:
                    {
                        stack.Controls.Add(GetTopButton("Bugün", "takvimgun"));
                        stack.Controls.Add(GetTopButton("3 Günlük", "takvimgun"));
                    }
                    break;
                default:
                    break;
            }
        }
        private StackPanel GetStack()
        {
            var stack = new StackPanel();
            stack.Dock = System.Windows.Forms.DockStyle.Right;
            stack.AutoSize = true;
            stack.LayoutDirection = StackPanelLayoutDirection.RightToLeft;
            return stack;
        }
        private SimpleButton GetTopButton(string text, string resim)
        {
            SimpleButton btn = new SimpleButton()
            {
                Text = text,
                Width = 50,
                Height = 60,
                Cursor = DevExpress.Utils.Controls.DXCursors.Hand,
                PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light,
                AllowFocus = false,
            };
            btn.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            btn.ImageOptions.SetSvgImage(resim, 24, 24);
            btn.ImageOptions.ImageToTextAlignment = ImageAlignToText.TopCenter;

            btn.Click += Btn_Click;
            return btn;
        }
        private DropDownButton GetTopDropdown(string text, string resim, dynamic[] values)
        {
            DropDownButton btn = new DropDownButton()
            {
                Text = text,
                Width = 50,
                Height = 60,
                Cursor = DevExpress.Utils.Controls.DXCursors.Hand,
                PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light,
                AllowFocus = false,
            };
            btn.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            btn.DropDownArrowStyle = DropDownArrowStyle.Hide;
            btn.ImageOptions.SetSvgImage(resim, 24, 24);
            btn.ImageOptions.ImageToTextAlignment = ImageAlignToText.TopCenter;
            DXPopupMenu popupMenu = GetPopupMenu(values);
            btn.DropDownControl = popupMenu;
            btn.Click += Btn_Click;
            return btn;
        }

        private DXPopupMenu GetPopupMenu(dynamic[] values)
        {
            DXPopupMenu popupMenu = new DXPopupMenu();
            foreach (var item in values)
            {
                var dx = new DXMenuItem() { Caption = item.Caption };
                dx.ImageOptions.SetSvgImage((string)item.resim, 24, 24);
                popupMenu.Items.Add(dx);
            }
            return popupMenu;
        }
        private void Btn_Click(object sender, EventArgs e)
        {

        }
    }
}
