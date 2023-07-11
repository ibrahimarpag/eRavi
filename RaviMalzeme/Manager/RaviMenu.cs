using DevExpress.Utils.CodedUISupport;
using DevExpress.Utils.Layout;
using DevExpress.XtraBars;
using DevExpress.XtraBars.FluentDesignSystem;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using PetekKernel;
using RaviDataManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaviMalzeme.Manager
{
    public class RaviMenu
    {
        #region Event
        public event EventHandler<RAVIUSTMENU> ClickUstMenu = delegate { };
        #endregion
        #region Property
        //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SanalMarket.Properties.Resources));
        public GridLookUpEdit lookOpenForms { get; set; }
        public Sirket sirket { get; set; }
        AccordionControl solMenu { get; set; }
        RibbonPageGroup ustMenu { get; set; }
        RibbonStatusBar footerPanel { get; set; }
        #endregion
        public RaviMenu(Sirket sirket, AccordionControl solMenu, RibbonPageGroup ustMenu, RibbonStatusBar footerPanel, GridLookUpEdit lookOpenForms)
        {
            this.sirket = sirket;
            this.solMenu = solMenu;
            this.ustMenu = ustMenu;
            this.footerPanel = footerPanel;
            this.lookOpenForms = lookOpenForms;
            this.solMenu.Elements.Clear();
            solMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            footerPanel.Cursor = System.Windows.Forms.Cursors.Hand;





            //LoadUstMenu();
            //LoadSolMenu();
            LoadOpenForms();
        }
        public void LoadAltMenu(KullaniciRw kullanici)
        {
            footerPanel.ItemLinks.Clear();
            footerPanel.ItemLinks.Add(GetFooterLabel("www.petekyazilim.com.tr"));
            footerPanel.ItemLinks.Add(GetFooterLabel(" | "));
            footerPanel.ItemLinks.Add(GetFooterLabel("Firma: " + P.RaviFirma, "firma"));
            footerPanel.ItemLinks.Add(GetFooterLabel(" | "));
            footerPanel.ItemLinks.Add(GetFooterLabel("Kullanıcı: " + kullanici.Adi + " " + kullanici.Soyadi, "kullanici"));
            footerPanel.ItemLinks.Add(GetFooterLabel(" | "));
            footerPanel.ItemLinks.Add(GetFooterLabel("Pos: " + P.AktifPos, "pos"));
            footerPanel.ItemLinks.Add(GetFooterLabel(" | "));
            footerPanel.ItemLinks.Add(GetFooterLabel("Depo: " + P.ADepoKodu, "depo"));
            footerPanel.ItemLinks.Add(GetFooterLabel(" | "));
            footerPanel.ItemLinks.Add(GetFooterLabel("Kasa: " + P.AKasaKodu, "kasa"));
            footerPanel.ItemLinks.Add(GetFooterLabel(" | "));
            footerPanel.ItemLinks.Add(GetFooterLabel(DateTime.Today.ToString("dddd, dd MMMM yyyy"), "tarih"));
        }
        private BarStaticItem GetFooterLabel(string text, string tag = "")
        {
            var lbl = new BarStaticItem() { Caption = text, AutoSize = BarStaticItemSize.Spring, Tag = tag };
            lbl.ItemAppearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            return lbl;
        }
        #region Kullanımda Olan Formlar
        private void LoadOpenForms()
        {
            //lookOpenForms.Properties.Buttons[0].ImageOptions.SetImage("pencereler", 24, 24);
            var btnFrmKapat = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
            {
                AutoHeight = true,
                TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor,
                AllowFocused = false
            };
            btnFrmKapat.AllowMouseWheel = false;
            btnFrmKapat.Buttons.Clear();
            var cbtn = new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close);
            cbtn.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            cbtn.Appearance.ForeColor = Color.Red;
            btnFrmKapat.Buttons.Add(cbtn);
            var col = new DevExpress.XtraGrid.Columns.GridColumn()
            {
                FieldName = "Text",
                Caption = "Açık Pencereler",
                Visible = true,
                VisibleIndex = 0
            };
            var colKapat = new DevExpress.XtraGrid.Columns.GridColumn()
            {
                FieldName = "close",
                Caption = "Kapat",
                Visible = true,
                VisibleIndex = 2,
                ColumnEdit = btnFrmKapat,
                Width = 20
            };
            colKapat.AppearanceCell.ForeColor = Color.Red;
            colKapat.AppearanceCell.Options.UseForeColor = false;
            col.OptionsFilter.AllowFilter = false;
            lookOpenForms.Properties.PopupView.Columns.Add(col);
            lookOpenForms.Properties.PopupView.Columns.Add(colKapat);
            lookOpenForms.Properties.View.RowCellClick += (sender, e) =>
            {
                if (e.Column.FieldName == "close")
                {
                    if (lookOpenForms.Properties.View.GetRow(e.RowHandle) is Form f) f.Close();
                }
                else
                {
                    if (lookOpenForms.Properties.View.GetRow(e.RowHandle) is Form f)
                    {
                        f.Visible = true;
                        f.WindowState = FormWindowState.Normal;
                        f.Activate();
                    }
                }
            };
            //lookOpenForms.ButtonClick += (sender, e) =>
            //{
            //    lookOpenForms.DataSource = null;
            //    var cc = Application.OpenForms.Cast<Form>().ToList().Where<Form>(x => x.Name != "FrmAnaMenu").ToList();
            //    lookOpenForms.DataSource = cc;
            //};

            lookOpenForms.QueryPopUp += (sender, e) =>
            {
                lookOpenForms.Properties.DataSource = null;
                var cc = Application.OpenForms.Cast<Form>().ToList().Where<Form>(x => x.Name != "FrmAnaMenu" && x.Name != "FrmGiris" && x.Name != "FrmBildirim").ToList();
                lookOpenForms.Properties.DataSource = cc;
            };
            //lookOpenForms.QueryPopUp += (sender, e) =>
            //{
            //    lookOpenForms.DataSource = null;
            //    var cc = Application.OpenForms.Cast<Form>().ToList().Where<Form>(x => x.Name != "FrmAnaMenu").ToList();
            //    lookOpenForms.DataSource = cc;
            //};
        }
        #endregion 
        #region Üst Menü
        public void LoadUstMenu()
        {
            ustMenu.ItemLinks.Clear();
            UstMenuAdd(new CustomBarButtonItem(), "SMS", "sms", RAVIUSTMENU.SMS);
            UstMenuAdd(new CustomBarButtonItem(), "MAİL", "mail", RAVIUSTMENU.MAIL);
            UstMenuAdd(new CustomBarButtonItem(), "DESTEK", "destek", RAVIUSTMENU.DESTEK);
            UstMenuAdd(new CustomBarButtonItem(), "TAKVİM", "takvim", RAVIUSTMENU.TAKVIM);
            UstMenuAdd(new CustomBarButtonItem(), "HESAPLA", "hesapla", RAVIUSTMENU.HESAP);
            UstMenuAdd(new CustomBarButtonItem(), "KISAYOL", "kisayol", RAVIUSTMENU.MASAUSTU);
            UstMenuAdd(new CustomBarButtonItem(), "SİSTEM", "sistem", RAVIUSTMENU.SISTEM);
            UstMenuAdd(new CustomBarButtonItem(), "RAPOR", "rapor", RAVIUSTMENU.RAPOR);
            UstMenuAdd(new CustomBarButtonItem(), "YEDEKLE", "yedekle", RAVIUSTMENU.YEDEKLE);
            UstMenuAdd(new CustomBarButtonItem(), "HAKKINDA", "hakkinda", RAVIUSTMENU.HAKKINDA);
            UstMenuAdd(new CustomBarButtonItem(), "FİRMA", "firma", RAVIUSTMENU.FIRMA);
            UstMenuAdd(new CustomBarButtonItem(), "KAPAT", "close", RAVIUSTMENU.KAPAT);
        }
        private void UstMenuAdd(CustomBarButtonItem btn, string text, string resim, RAVIUSTMENU UstMenuTip, int w = 16, int h = 16)
        {
            btn.UstMenuTip = UstMenuTip;
            btn.ImageOptions.SetSvgImage(resim, w, h);
            btn.LargeWidth = 62;
            btn.Caption = text;
            btn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            btn.ItemClick += UstMenu_Click;
            ustMenu.ItemLinks.Add(btn);
        }

        private void UstMenu_Click(object sender, ItemClickEventArgs e)
        {
            if (e.Item is CustomBarButtonItem sb) ClickUstMenu.Invoke(sender, sb.UstMenuTip);
        }
        #endregion
        #region Sol Menü
        public void LoadSolMenu()
        {

            this.solMenu.Elements.Clear();
            DataTableM dt = new DataTableM(sirket);
            dt.cmdSQL = $"select * from sistem..tb_menu where kullanicino={P.AktifKullanici} and firmano={P.AktifFirma} order by sira asc";
            dt.GetirDt();
            if (dt.KayitVar)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (item["seviye"].ToString() == "0" && item["goster"].ToString() == "1")
                    {
                        var tr = GetTreeNode(dt.Select("seviye<>0"), item);
                        tr.Appearance.Default.Font = new System.Drawing.Font("Nina", 11F);
                        this.solMenu.Elements.Add(tr);
                    }
                }
            }
        }
        private DevExpress.XtraBars.Navigation.AccordionControlElement GetTreeNode(DataRow[] dt, DataRow dr)
        {
            var accordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            accordionControlElement.Tag = dr;
            accordionControlElement.Expanded = false;
            accordionControlElement.Text = dr["adi"].ToString();
            var altMenu = dt.ToList().Where<DataRow>(x => x["mno_ana"].ToString() == dr["mno"].ToString()).ToArray();
            if (altMenu.Length > 0)
            {
                foreach (DataRow item in altMenu)
                {
                    var tr = GetTreeNode(dt, item);
                    accordionControlElement.Elements.Add(tr);
                }
            }
            else if (dr["seviye"].ToString() != "0")
                accordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            return accordionControlElement;
        }
        #endregion
    }
}
