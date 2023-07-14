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
        public event EventHandler<USTMENUBUTTONTIP> ClickButton = delegate { };
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
            stack.Controls.Add(GetTopButton("Kapat", "skapat", USTMENUBUTTONTIP.KAPAT));
            switch (FormTip)
            {
                case FORMTIP.NONE:
                    break;
                case FORMTIP.SMS:
                    {
                        var drp = GetTopDropdown("Liste", "dikeyrapor", new[]
                           {
                                new { Caption = "Getir", resim = "getir" ,Tag = USTMENUBUTTONTIP.LGETIR},
                                new { Caption = "Göster", resim = "goster",Tag = USTMENUBUTTONTIP.LGOSTER},
                                new { Caption = "Rapor Seç", resim = "secyesil",Tag = USTMENUBUTTONTIP.LRAPORSEC},
                                new { Caption = "Sıralama", resim = "sirala",Tag = USTMENUBUTTONTIP.LSIRALAMA},
                                new { Caption = "Excel", resim = "excel",Tag = USTMENUBUTTONTIP.LEXCEL},
                                new { Caption = "Tasarla", resim = "tasarla",Tag = USTMENUBUTTONTIP.LTASARLA}
                            });
                        stack.Controls.Add(drp);
                        stack.Controls.Add(GetTopButton("Sms Gönder", "smsgonder", USTMENUBUTTONTIP.SMSGONDER));
                    }
                    break;
                case FORMTIP.MAIL:
                    {
                        var drp = GetTopDropdown("Liste", "dikeyrapor", new[]
                           {
                               new { Caption = "Getir", resim = "getir" ,Tag = USTMENUBUTTONTIP.LGETIR},
                                new { Caption = "Göster", resim = "goster",Tag = USTMENUBUTTONTIP.LGOSTER},
                                new { Caption = "Rapor Seç", resim = "secyesil",Tag = USTMENUBUTTONTIP.LRAPORSEC},
                                new { Caption = "Sıralama", resim = "sirala",Tag = USTMENUBUTTONTIP.LSIRALAMA},
                                new { Caption = "Excel", resim = "excel",Tag = USTMENUBUTTONTIP.LEXCEL},
                                new { Caption = "Tasarla", resim = "tasarla",Tag = USTMENUBUTTONTIP.LTASARLA}
                            });
                        stack.Controls.Add(drp);
                        stack.Controls.Add(GetTopButton("Mail Gönder", "mailgonder", USTMENUBUTTONTIP.MAILGONDER));
                    }
                    break;
                case FORMTIP.TAKVIM:
                    {
                        stack.Controls.Add(GetTopButton("Bugün", "takvimgun", USTMENUBUTTONTIP.BUGUN));
                        stack.Controls.Add(GetTopButton("3 Günlük", "takvimgun", USTMENUBUTTONTIP.GUNLUK3));
                    }
                    break;
                case FORMTIP.STOKLISTE:
                case FORMTIP.CARILISTE:
                case FORMTIP.TANIM:
                    {
                        stack.Controls.Add(GetTopButton("Seç", "secyesil", USTMENUBUTTONTIP.SEC));
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
        private SimpleButton GetTopButton(string text, string resim, object tag)
        {
            SimpleButton btn = new SimpleButton()
            {
                Text = text,
                Tag = tag,
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
                var dx = new DXMenuItem() { Caption = item.Caption, Tag = item.Tag };
                dx.Click += Btn_Click;
                dx.ImageOptions.SetSvgImage((string)item.resim, 24, 24);
                popupMenu.Items.Add(dx);
            }
            return popupMenu;
        }
        private void Btn_Click(object sender, EventArgs e)
        {

            if (sender is DXMenuItem dbtn)
            {
                lock (dbtn) if (dbtn.Tag is USTMENUBUTTONTIP t) this.ClickButton.Invoke(sender, t);
            }
            else if (sender is DXPopupMenu dxbtn)
            {
                lock (dxbtn) if (dxbtn.Tag is USTMENUBUTTONTIP t) this.ClickButton.Invoke(sender, t);
            }
            else if (sender is SimpleButton btn)
            {
                lock (btn) if (btn.Tag is USTMENUBUTTONTIP t) this.ClickButton.Invoke(sender, t);
            }
        }
    }
}
