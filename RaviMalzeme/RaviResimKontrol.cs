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

namespace RaviMalzeme
{
    public static class RaviResimKontrol
    {
        private static string KlasorYolu { get => @"F:\2023-01-21\Masaüstü\Firmalar\yeni ravi\"; }
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
