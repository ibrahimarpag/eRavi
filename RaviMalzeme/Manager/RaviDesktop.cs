using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using PetekKernel;
using RaviDataManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaviMalzeme.Manager
{
    public class RaviDesktop
    {
        //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SanalMarket.Properties.Resources));
        #region Event
        public event EventHandler<IMenuRw> ClickDesktopButton = delegate { };
        #endregion
        #region Property
        Point DestkopLocation;
        Point p = Point.Empty;
        int btnDragOver = 0;
        private SimpleButton ActiveButton { get; set; }
        AccordionControl solMenu { get; set; }
        PanelControl panelDesktop { get; set; }
        PanelControl panelTrash { get; set; }
        Form form { get; set; }
        #endregion
        public RaviDesktop(Form form, AccordionControl solMenu, PanelControl panelDesktop, PanelControl panelTrash)
        {
            this.solMenu = solMenu;
            this.panelDesktop = panelDesktop;
            this.panelTrash = panelTrash;
            this.form = form;


            panelDesktop.AllowDrop = true;
            panelDesktop.Padding = new Padding(15);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += (sender, e) =>
            {
                var lx = Cursor.Position.X - panelDesktop.Parent.Parent.Location.X - form.Location.X;
                var ly = Cursor.Position.Y - panelDesktop.Parent.Parent.Location.Y - form.Location.Y;
                DestkopLocation = new Point(lx < 0 ? 0 : lx, ly < 0 ? 0 : ly);
                //f.Text = $"{DestkopLocation.X}:{DestkopLocation.Y}";
            };
            timer.Start();
        }
        public void StardDragDrop()
        {
            PanelTrashEvent();
            PanelDesktopEvent();
            SolMenuEvent();
        }
        #region Json
        public void LoadDesktop()
        {
            panelDesktop.Controls.Clear();
            if (System.IO.File.Exists($"{Application.StartupPath}\\desktop.js"))
            {
                var json = System.IO.File.ReadAllText($"{Application.StartupPath}\\desktop.js");
                var data = JsonConvert.DeserializeObject<List<dynamic>>(json);
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        var btn = GetKisayolButton((int)item.LX, (int)item.LY, item.Text.ToString(), JsonConvert.DeserializeObject<IMenuRw>(Convert.ToString(item.Menu)));

                        panelDesktop.Controls.Add(btn);
                    }
                }
                p = Cursor.Position;
            }
        }
        private void SaveDesktop()
        {
            var Liste = new List<object>();
            foreach (var item in panelDesktop.Controls) if (item is CustomSimpleButton b) Liste.Add(new { LX = b.Location.X, LY = b.Location.Y, b.Text, b.Menu });
            var json = JsonConvert.SerializeObject(Liste);
            string fileName = $"{Application.StartupPath}\\desktop.js";
            FileInfo fi = new FileInfo(fileName);
            if (fi.Exists) fi.Delete();
            using (FileStream fs = fi.Create())
            {
                Byte[] author = new UTF8Encoding(true).GetBytes(json);
                fs.Write(author, 0, author.Length);
            }
        }
        #endregion
        #region Sol Menü
        private void SolMenuEvent()
        {
            this.solMenu.MouseMove += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    if ((p != Point.Empty) && ((Math.Abs(e.X - p.X) > 5) || (Math.Abs(e.Y - p.Y) > 5)))
                    {
                        AccordionControlHitInfo hitInfo = solMenu.CalcHitInfo(e.Location);
                        if (hitInfo.HitTest == AccordionControlHitTest.Item)
                        {
                            var viewInfo = (AccordionItemViewInfo)hitInfo.ItemInfo;
                            if (!viewInfo.Element.Expanded)
                                viewInfo.Element.Expanded = true;

                            solMenu.DoDragDrop(viewInfo.Element, DragDropEffects.Move);
                        }
                        else solMenu.DoDragDrop(sender, DragDropEffects.Move);
                    }
            };
            this.solMenu.MouseDown += (sender, e) => { p = new Point(e.X, e.Y); };
        }
        #endregion
        #region Orta Menü
        private void PanelDesktopEvent()
        {
            panelDesktop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelDesktop_MouseMove);
            //panelDesktop.DragLeave += (sender, e) =>
            //{
            //    if (btnDragOver < 5)
            //        Btn_Click(ActiveButton, e);
            //};
            panelDesktop.DragOver += (sender, e) =>
            {
                if (e.Data.GetDataPresent(typeof(AccordionControlElement))) e.Effect = DragDropEffects.Move;
                else if (e.Data.GetDataPresent(typeof(CustomSimpleButton)))
                {
                    btnDragOver++;
                    if (form.Focused || btnDragOver >= 5)
                    {
                        e.Effect = DragDropEffects.Move;
                        panelTrash.Visible = true;
                    }
                    else form.Focus();
                }
            };
            panelDesktop.DragDrop += (sender, e) =>
            {
                if (e.Data.GetDataPresent(typeof(AccordionControlElement)))
                {
                    if (e.Data.GetData(typeof(AccordionControlElement)) is AccordionControlElement c)
                    {
                        var cntrl = panelDesktop.Controls.Cast<Control>().ToList().Where<Control>(x => x?.Text == c.Text).FirstOrDefault();
                        if (cntrl == null)
                        {
                            var lc = GetButtonPoint("");
                            var btn = GetKisayolButton(lc.X, lc.Y, c.Text, (DataRow)c.Tag);
                            panelDesktop.Controls.Add(btn);

                            SaveDesktop();
                        }
                        else cntrl.Focus();
                    }
                }
                else if (e.Data.GetDataPresent(typeof(CustomSimpleButton)))
                {
                    if (e.Data.GetData(typeof(CustomSimpleButton)) is CustomSimpleButton c)
                    {
                        c.Location = GetButtonPoint(c.Tag.ToString());
                    }
                    panelTrash.Visible = false;
                    SaveDesktop();
                }
            };
        }
        private void PanelTrashEvent()
        {
            panelTrash.AllowDrop = true;
            panelTrash.DragOver += (sender, e) =>
            {
                if (e.Data.GetDataPresent(typeof(CustomSimpleButton)))
                {
                    e.Effect = DragDropEffects.Move;
                    panelTrash.BackColor = Color.IndianRed;
                }
            };
            panelTrash.DragLeave += (sender, e) => { panelTrash.BackColor = Color.Transparent; };
            panelTrash.DragDrop += (sender, e) =>
            {
                if (e.Data.GetDataPresent(typeof(CustomSimpleButton)))
                {
                    if (e.Data.GetData(typeof(CustomSimpleButton)) is CustomSimpleButton c)
                    {
                        panelDesktop.Controls.Remove(c);
                        SaveDesktop();
                    }
                    panelTrash.Visible = false;
                }
            };
        }
        private void PanelDesktop_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((p != Point.Empty) && ((Math.Abs(e.X - p.X) > 5) || (Math.Abs(e.Y - p.Y) > 5)))
                {
                    if (sender is SimpleButton sb)
                    {
                        btnDragOver = 0;
                        panelTrash.Visible = false;
                        ActiveButton = sb;
                        sb.DoDragDrop(sender, DragDropEffects.Move);
                    }
                }
            }
        }
        private Point GetButtonPoint(string ettn)
        {
            var sx = DestkopLocation.X - 50;
            var sy = DestkopLocation.Y - 35;
            if (sx + 100 > panelDesktop.Width)
            {
                sx = 0;
                sy += 70;
            }
            var ModY = sy % 70;
            var ModX = sx % 100;
            sy = sy - ModY;
            if (ModX >= 50) sx = sx + (100 - ModX);
            else sx = sx - ModX;
            sx += 10;
            sy += 10;
            if (sx + 100 > panelDesktop.Width)
            {
                sx = 10;
                sy += 80;
            }
            LocationControl(sx, sy, ettn);
            return new Point(sx, sy);
        }
        private bool LocationControl(int sx, int sy, string ettn)
        {
            List<Control> l = new List<Control>();
            while (true)
            {
                if (panelDesktop.Controls.Cast<Control>().ToList().Where<Control>(x => x.Location == new Point(sx, sy)).FirstOrDefault() is Control b)
                {
                    l.Add(b);
                    sx += 100;
                }
                else break;
            }
            if (l.Count > 0)
                if (l.Where<Control>(x => x.Tag.ToString() == ettn).FirstOrDefault() is Control c)
                {
                    var index = l.IndexOf(c);
                    l.RemoveRange(index, l.Count - index);
                }
            l.ForEach(b => b.Location = new Point(b.Location.X + 100, b.Location.Y));
            return true;
        }
        private SimpleButton GetKisayolButton(int LX, int LY, string Text, DataRow Menu)
        {
            var m = new IMenuRw();
            m.adi = (string)Menu["adi"]?.ToString();
            m.adi_eng = (string)Menu["adi_eng"]?.ToString();
            m.adi_rus = (string)Menu["adi_rus"]?.ToString();
            m.resim = (string)Menu["resim"]?.ToString();
            m.duzelt = Convert.ToInt32(Menu["duzelt"] ?? 0);
            m.ekle = Convert.ToInt32(Menu["ekle"] ?? 0);
            m.firmano = Convert.ToInt32(Menu["firmano"] ?? 0);
            m.goster = Convert.ToInt32(Menu["goster"] ?? 0);
            m.islem = Convert.ToInt32(Menu["islem"] ?? 0);
            m.kullanicino = Convert.ToInt32(Menu["kullanicino"] ?? 0);
            m.mkey = Convert.ToInt32(Menu["mkey"] ?? 0);
            m.mno = Convert.ToInt32(Menu["mno"] ?? 0);
            m.mno_ana = Convert.ToInt32(Menu["mno_ana"] ?? 0);
            m.ozel = Convert.ToInt32(Menu["ozel"] ?? 0);
            m.seviye = Convert.ToInt32(Menu["seviye"] ?? 0);
            m.sil = Convert.ToInt32(Menu["sil"] ?? 0);
            m.sira = Convert.ToInt32(Menu["sira"] ?? 0);
            m.tipi = Convert.ToInt32(Menu["tipi"] ?? 0);
            return GetKisayolButton(LX, LY, Text, m);
        }
        private SimpleButton GetKisayolButton(int LX, int LY, string Text, IMenuRw Menu)
        {
            var btn = new CustomSimpleButton()
            {
                Text = Text,
                Menu = Menu,
                Width = 100,
                Height = 70,
                PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light,
                Tag = (Guid.NewGuid()).ToString().ToUpper(),
                AllowFocus = false,
                Cursor = DevExpress.Utils.Controls.DXCursors.Hand,
                Location = new Point(LX, LY),
                AutoSize = false
            };
            btn.ImageOptions.SetSvgImage("kisayoldesktop", 24, 24);
            btn.ImageOptions.ImageToTextAlignment = ImageAlignToText.TopCenter;
            btn.Click += Btn_Click;
            btn.MouseDown += PanelDesktop_MouseMove;
            return btn;
        }
        #endregion
        private void Btn_Click(object sender, EventArgs e)
        {
            if (sender is CustomSimpleButton sb) ClickDesktopButton.Invoke(sb, sb.Menu);
        }
    }
}
