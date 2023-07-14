

using DevExpress.XtraEditors.Controls;
using PetekKernel.Fonksiyon;
using System;
using System.Drawing;
using System.Linq;

namespace RaviMalzeme
{
    public class RaviButtonEdit : DevExpress.XtraEditors.ButtonEdit
    {
        public event EventHandler ListeClick = delegate { };
        private bool LB { get; set; }
        private bool GLB { get; set; }
        public bool RaviListButton { get => LB; set { LB = value; if (value) AddListButton("liste"); } }
        public bool RaviGrupListButton { get => GLB; set { GLB = value; if (value) AddListButton("listgrup"); } }
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
            if (RaviListButton)
                AddListButton("liste");
            if (RaviGrupListButton)
                AddListButton("listgrup");
        }
        private void AddListButton(string tag)
        {
            if (!DesignMode)
            {
                var btn = new DevExpress.XtraEditors.Controls.EditorButton();
                btn.Tag = tag;
                btn.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
                btn.ImageOptions.SetSvgImage(tag, 16, 16);
                //btn.Click += Btn_Click;
                var deleteBtn = new DevExpress.XtraEditors.Controls.EditorButton()
                {
                    Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete,
                    Visible = false
                };
                deleteBtn.Click += Delete_Click;
                btn.Click += Liste_Click;
                this.TextChanged += (sender, e) =>
                {
                    if (string.IsNullOrEmpty(base.Text)) deleteBtn.Visible = false;
                    else deleteBtn.Visible = true;
                };
                base.Properties.Buttons.Add(deleteBtn);
                base.Properties.Buttons.Add(btn);
            }
        }
        public void Delete_Click(object sender,EventArgs e)
        {
            base.Text = string.Empty;
        }
        public void Liste_Click(object sender,EventArgs e)
        {
            ListeClick.Invoke(sender, e);
        }
    }
}
