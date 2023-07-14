using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ButtonsPanelControl;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using PetekKernel.Fonksiyon;
using System.Windows.Forms;

namespace RaviMalzeme
{
    public class RaviGridControl : GridControl
    {
        private bool RBCF { get; set; }
        public bool RaviButtonCustomizationForm { get => RBCF; set => RBCF = value; }
        public RaviGridControl()
        {

        }

        protected override void OnLoaded()
        {
            base.OnLoaded();
            if (!DesignMode)
            {
                if (this.Parent != null)
                {
                    if (this.Parent.GetType() == typeof(GroupControl))
                    {
                        var grp = this.Parent as GroupControl;
                        grp.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
                        grp.Text = "";
                        if (grp.CustomHeaderButtons.Count == 0)
                        {
                            grp.CustomButtonClick += Grp_CustomButtonClick;
                            //if (RaviListele)
                            //{
                            //    var btnListele = new GroupBoxButton() { Caption = "Listele" };
                            //    //btnListele.ImageOptions.SvgImage = Ravi_Malzeme.Properties.Resources.btnGetir_ImageOptions_SvgImage;
                            //    //btnListele.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
                            //    btnListele.Tag = "listele";
                            //    btnListele.ToolTip = "Listele";
                            //    grp.CustomHeaderButtons.Add(btnListele);
                            //}
                            //if (RaviButtonSirala)
                            //{
                            //    var btnSirala = new GroupBoxButton() { Caption = "Sırala" };
                            //    //btnSirala.ImageOptions.SvgImage = Ravi_Malzeme.Properties.Resources.buttonImageOptions1_SvgImage;
                            //    //btnSirala.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
                            //    btnSirala.Tag = "sirala";
                            //    btnSirala.ToolTip = "Sırala";
                            //    grp.CustomHeaderButtons.Add(btnSirala);
                            //}
                            //if (RaviButtonFiltreTemizle)
                            //{
                            //    var btnFilter = new GroupBoxButton() { Caption = "" };
                            //    //btnFilter.ImageOptions.SvgImage = Ravi_Malzeme.Properties.Resources.filterClearSvgImage;
                            //    btnFilter.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
                            //    btnFilter.Tag = "filtretemizle";
                            //    btnFilter.ToolTip = "Tüm Filtrelemeyi Temizle";
                            //    grp.CustomHeaderButtons.Add(btnFilter);
                            //}
                            //if (RaviButtonFiltre)
                            //{
                            //    var btnFilter = new GroupBoxButton() { Caption = "" };
                            //    //btnFilter.ImageOptions.SvgImage = Ravi_Malzeme.Properties.Resources.btnFilterSvgImage;
                            //    btnFilter.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
                            //    btnFilter.Tag = "filtre";
                            //    btnFilter.ToolTip = "Satır Filtrele [F7]";
                            //    grp.CustomHeaderButtons.Add(btnFilter);
                            //}
                            //if (RaviButtonDelete)
                            //{
                            //    var btnDelete = new GroupBoxButton() { Caption = "" };
                            //    //btnDelete.ImageOptions.SvgImage = Ravi_Malzeme.Properties.Resources.btnCikis_ImageOptions_SvgImage;
                            //    btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
                            //    btnDelete.Tag = "sil";
                            //    btnDelete.ToolTip = "Sil";
                            //    grp.CustomHeaderButtons.Add(btnDelete);
                            //}
                            if (RaviButtonCustomizationForm)
                            {
                                var btnSetting = new GroupBoxButton() { Caption = "" };
                                btnSetting.ImageOptions.SetSvgImage("ayar", 16, 16);
                                //btnSetting.ImageOptions.SvgImage = Ravi_Malzeme.Properties.Resources.btnSettingSvgImage;
                                //btnSetting.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
                                btnSetting.Tag = "ayar";
                                btnSetting.ToolTip = "Satır Başlıkları Ayarla";
                                grp.CustomHeaderButtons.Add(btnSetting);
                                
                            }
                        }
                    }
                }
            }
        }
        private void Grp_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (this.DefaultView != null)
            {
                this.DefaultView.Focus();
                var grdv = this.DefaultView as GridView;
                var btn = e.Button as GroupBoxButton;
                if (btn.Tag.StrX() == "ayar")
                {
                    if (grdv.CustomizationForm == null)
                    {

                        grdv.ShowCustomization();
                        grdv.CustomizationForm.Text = "Satır Başlıkları";
                    }
                    else
                    {
                        grdv.HideCustomization();
                    }
                }
                else if (btn.Tag.StrX() == "sirala")
                {

                }
                else if (btn.Tag.StrX() == "sil")
                {
                    grdv.DeleteSelectedRows();
                }
                else if (btn.Tag.StrX() == "listele")
                {
                    //Listele.Invoke(sender, e);
                    //LoadData();
                }
                else if (btn.Tag.StrX() == "filtretemizle")
                {
                    //RunningFilterClear = true;
                    //grdv.ActiveFilterString = "";
                    //base.RefreshDataSource();
                    //grdv.SortInfo.ClearSorting();
                    //grdv.SortInfo.Clear();
                    //RunningFilterClear = false;
                    //LoadData();
                }
                else if (btn.Tag.StrX() == "filtre")
                {
                    SendKeys.Send("{F7}");
                }
            }
        }
    }
}
