

using DevExpress.XtraEditors.Controls;
using PetekKernel.Fonksiyon;
using System.Drawing;
using System.Linq;

namespace RaviMalzeme
{
    public class RaviButtonEdit : DevExpress.XtraEditors.ButtonEdit
    {
        private bool LB { get; set; }
        private bool GLB { get; set; }
        public bool RaviListButton { get => LB; set { LB = value; AddListButton(); } }
        public bool RaviGrupListButton { get => GLB; set { GLB = value; AddGrupListButton(); } }
        public RaviButtonEdit() : base()
        {
            LB = false;
            GLB = false;
            Default();
        }
        protected override void OnLoaded()
        {
            base.OnLoaded();
            Default();
        }
        private void Default()
        {
            base.Properties.AutoHeight = false;
            base.Height = 22;
            base.Properties.Buttons.Clear();
            AddListButton();
            AddGrupListButton();
            base.LostFocus += (sender, e) =>
            {
                base.Properties.AppearanceFocused.BorderColor = Color.Red;
                base.Properties.AppearanceFocused.Options.UseBorderColor = false;
            };
        }
        private void AddListButton()
        {
            if (!DesignMode)
            {
                if (RaviListButton)
                {
                    if (base.Properties.Buttons.Count > 0)
                    {
                        if (base.Properties.Buttons.ToList().Where<EditorButton>(x => x.Tag.StrX() == "liste") is EditorButton b)
                            base.Properties.Buttons.Remove(b);
                    }
                    var btn = new DevExpress.XtraEditors.Controls.EditorButton();
                    btn.Tag = "liste";
                    btn.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                    btn.ImageOptions.SetSvgImage("liste", 16, 16);
                    //btn.Click += Btn_Click;

                    base.Properties.Buttons.Add(btn);
                }
                else
                {
                    if (base.Properties.Buttons.Where<EditorButton>(x => x.Tag.StrX() == "liste") is EditorButton b)
                        base.Properties.Buttons.Remove(b);
                }
            }
        }
        private void AddGrupListButton()
        {
            if (!DesignMode)
            {
                if (RaviGrupListButton)
                {
                    if (base.Properties.Buttons.Count > 0)
                    {
                        if (base.Properties.Buttons.ToList().Where<EditorButton>(x => x.Tag.StrX() == "listgrup") is EditorButton b)
                            base.Properties.Buttons.Remove(b);
                    }
                    var btn = new DevExpress.XtraEditors.Controls.EditorButton();
                    btn.Tag = "listgrup";
                    btn.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                    btn.ImageOptions.SetSvgImage("listgrup", 16, 16);
                    //btn.Click += Btn_Click;

                    base.Properties.Buttons.Add(btn);
                }
                else
                {
                    if (base.Properties.Buttons.Where<EditorButton>(x => x.Tag.StrX() == "listgrup") is EditorButton b)
                        base.Properties.Buttons.Remove(b);
                }
            }
        }
    }
}
