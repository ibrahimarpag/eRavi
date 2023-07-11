using Dapper;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using PetekKernel;
using RaviDataManager.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace RaviMalzeme.Manager
{
    public class GridManager
    {
        private SqlConnection dbCon { get; set; }
        private Sirket sirket { get; set; }
        public GridManager(Sirket sirket)
        {
            this.sirket = sirket;
            dbCon = new SqlConnection(this.sirket.Baglanti);
        }
        public void SaveGridColumns(GridView grdv)
        {
            List<IRGridSet> ColumnList = new List<IRGridSet>();
            foreach (GridColumn item in grdv.Columns)
            {
                if (item.Tag is IRGridSet set)
                {
                    set.jFiltre = "";
                    if (!string.IsNullOrEmpty(item.FilterInfo.FilterString)) set.jFiltre = GetFilterValue(item.FilterInfo.FilterString);
                    if (item.VisibleIndex > 0 && set.jOrder != item.VisibleIndex) set.jOrder = item.VisibleIndex;
                    if (set.jWidth != item.Width) set.jWidth = item.Width;
                    set.jValue = item.Visible ? "1" : "0";
                    ColumnList.Add(set);
                }
            }
            var grid_cols = JsonConvert.SerializeObject(ColumnList);
            dbCon.Execute("update sistem..tb_grid_set set grid_cols=@grid_cols where kullanicino=1 and firmano=1 and grid_ftip=3 and grid_ekey=31", new { grid_cols });
        }
        private string GetFilterValue(string filterString)
        {
            string filterValue = "";

            if (!string.IsNullOrEmpty(filterString))
            {
                int index = filterString.IndexOf("'");
                if (index >= 0)
                {
                    int lastIndex = filterString.LastIndexOf("'");
                    if (lastIndex > index)
                    {
                        filterValue = filterString.Substring(index + 1, lastIndex - index - 1);
                    }
                }
            }

            return filterValue;
        }
        public void FillGridColumns(GridView grdv)
        {
            grdv.OptionsBehavior.Editable = false;
            grdv.OptionsView.ShowGroupPanel = false;
            grdv.OptionsView.ColumnAutoWidth = false;
            grdv.OptionsFind.AlwaysVisible = false;
            grdv.OptionsView.ShowAutoFilterRow = true;
            grdv.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            grdv.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.SmartTag;

            grdv.OptionsView.ShowFooter = true;

            grdv.Columns.Clear();
            var ColumnRow = dbCon.Query<dynamic>("select * from sistem..tb_grid_set where kullanicino=1 and firmano=1 and grid_ftip=3 and grid_ekey=31").FirstOrDefault();
            if (ColumnRow != null)
            {
                if (ColumnRow.grid_cols is string cols)
                {
                    List<IRGridSet> ColumnList = JsonConvert.DeserializeObject<List<IRGridSet>>(cols);
                    if (ColumnList.Count > 0)
                    {
                        foreach (var item in ColumnList.OrderBy(x => x.jOrder))
                        {
                            GridColumn col = new GridColumn();
                            col.Tag = item;
                            col.Caption = item.jText;
                            col.FieldName = item.jKey;
                            col.Visible = item.jValue == "1";
                            col.Width = item.jWidth;
                            col.CustomizationCaption = item.jText;
                            col.OptionsColumn.ShowInCustomizationForm = true;
                            col.OptionsFilter.AllowFilter = false;
                            grdv.Columns.Add(col);
                            if (!string.IsNullOrEmpty(item.jFiltre))
                            {
                                grdv.ActiveFilter.Add(grdv.Columns[col.FieldName], new ColumnFilterInfo($"Contains([{item.jKey}], '{item.jFiltre}') ", $""));
                                col.SearchText = item.jFiltre;
                            }
                        }
                    }
                }
            }
            grdv.ApplyColumnsFilter();
        }
    }
}
