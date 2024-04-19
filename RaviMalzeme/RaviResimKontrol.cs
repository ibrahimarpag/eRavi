using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using PetekKernel.Properties;
using RaviDataManager;
using RaviMalzeme.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace RaviMalzeme
{
    public static class RaviResimKontrol
    {
        private static string KlasorYolu { get => $"{AppDomain.CurrentDomain.BaseDirectory}/Resimler/"; }
        public static string GetBildirimHtml()
        {
            return @"
<div class=""root"" id=""root"">
	<div class=""content"">
		<div class=""mail-content"">
			<div class=""from"" id=""from"">${aciklama}</div>
			<div class=""subject"" id=""subject"">${HtmlContent}</div>
			<div class=""tarih"">${eklemeTarihi}</div>
		</div>
	</div>
</div>";
        }
        public static string GetBildirimStyle()
        {
            return @"
.root {
	height: auto;
	font-family: ""Segoe UI"";
	font-size: 14px;
	background-color: @Window;
	border-style: solid;
	border-width: 0px;
	border-left-width: 0px;
	border-left-color: DarkGray;
    margin-bottom:10px;
}
.content {
	margin-top:18%;
	margin-bottom:18%;
	margin-Left:6px;
	margin-right:20px;
	display:flex;
	background-color:@Window;
}
.initials {
	color: @White;
	font-weight: bold;
	background-color: @Primary;
	border-radius: 100px;
	width: 32px;
	height: 32px;
	display: flex;
	align-items: center;
	justify-content: center;
}
.photo {
	width:32px;
	height:32px;
	border-radius:100px;
	border: solid 1px @Primary;
	object-fit:contain;
	background-color:white;
}
.mail-content {
	flex-grow: 1;
	margin-left: 8px;
}
.tarih {
	text-overflow:ellipsis;
	overflow:hidden;
	white-space:nowrap;
    font-size:11px;
}
.date {
	align-self:center;
	text-align:right;
}
.from {
	text-overflow:ellipsis;
	overflow:hidden;
	white-space:nowrap;
	margin-top:-4px;
	font-weight:bold;
}
.subject {
	text-overflow:ellipsis;
	overflow:hidden;
	white-space:wrap;
    max-height:28px;
    font-size:11px;
}
.buttons {
	margin-right:-6px;
	display:flex;
	flex-wrap:nowrap;
	justify-content:flex-end;
}

.btn {
	width:18px;
	height:18px;
	min-width:18px;
	object-fit:contain;
	opacity:0;
}

.root:hover .btn { opacity: 0.5; }
.root .btn:hover { opacity: 1; }

.btn-flag { opacity:<FlagDefaultOpacity>; }
.root:hover .btn-flag { opacity: <FlagHoverOpacity>; }
.root .btn-flag:hover { opacity: 1; }

.opaque { opacity:1; }
.root:hover .opaque { opacity: 1; }
.root .opaque:hover { opacity: 1; }";
        }
        public static void SetSvgImage(this ImageOptions io, string resim, int w = 0, int h = 0)
        {
            string dosyaYolu = Path.Combine(KlasorYolu, resim + ".svg");
            if (File.Exists(dosyaYolu))
            {
                if (SvgImage.FromFile(dosyaYolu) is SvgImage svgImage)
                {
                    io.SvgImage = svgImage;
                    if (w > 0 && h > 0) io.SvgImageSize = new Size(w, h);
                }
            }
        }
        public static void SetImage(this ImageOptions io, string resim)
        {
            string dosyaYolu = Path.Combine(KlasorYolu, resim);
            if (File.Exists(dosyaYolu)) if (Image.FromFile(dosyaYolu) is Image svgImage) io.Image = svgImage;
        }
        public static Image SetImage(this Image io, string resim)
        {
            string dosyaYolu = Path.Combine(KlasorYolu, resim);
            if (File.Exists(dosyaYolu)) if (Image.FromFile(dosyaYolu) is Image svgImage) return svgImage;
            return null;
        }
        public static Image GetImage(this string resim)
        {
            string dosyaYolu = Path.Combine(KlasorYolu, resim);
            if (File.Exists(dosyaYolu)) if (Image.FromFile(dosyaYolu) is Image svgImage) return svgImage;
            return null;
        }
        public static void SetSvgImage(this FormIconOptions io, string resim, int w = 0, int h = 0)
        {
            string dosyaYolu = Path.Combine(KlasorYolu, resim + ".svg");
            if (File.Exists(dosyaYolu))
            {
                if (SvgImage.FromFile(dosyaYolu) is SvgImage svgImage)
                {
                    io.SvgImage = svgImage;
                    if (w > 0 && h > 0) io.SvgImageSize = new Size(w, h);
                }
            }
        }
        public static void SetSvgImage(this PictureEdit io, string resim, int w = 0, int h = 0)
        {
            string dosyaYolu = Path.Combine(KlasorYolu, resim + ".svg");
            if (File.Exists(dosyaYolu))
            {
                if (SvgImage.FromFile(dosyaYolu) is SvgImage svgImage) io.SvgImage = svgImage;
            }
        }
        public static void SetImageFile(this ImageOptions io, string resimYol)
        {
            if (System.IO.File.Exists(resimYol)) if (Image.FromFile(resimYol) is System.Drawing.Image ir) io.Image = ir;
        }
        public static void SetFormIcon(this XtraForm frm, FORMTIP Tip, string text)
        {
            string resim = "";
            switch (Tip)
            {
                case FORMTIP.NONE:
                    break;
                case FORMTIP.SMS:
                    resim = "sms";
                    break;
                case FORMTIP.GIRIS:
                    resim = "raviikon";
                    break;
                case FORMTIP.MAIL:
                    resim = "mail";
                    break;
                case FORMTIP.FIRMA:
                    resim = "firma";
                    break;
                case FORMTIP.KULLANICI:
                    resim = "kullanici";
                    break;
                case FORMTIP.TAKVIM:
                    resim = "takvim";
                    break;
                case FORMTIP.STOK:
                    resim = "stok";
                    break;
                case FORMTIP.STOKLISTE:
                    resim = "stokliste";
                    break;
                case FORMTIP.CARI:
                    resim = "cari";
                    break;
                case FORMTIP.CARILISTE:
                    resim = "cariliste";
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(resim))
            {
                frm.IconOptions.SetSvgImage(resim);
            }
            else frm.IconOptions.ShowIcon = false;
            frm.Text = text;
        }
    }
}
