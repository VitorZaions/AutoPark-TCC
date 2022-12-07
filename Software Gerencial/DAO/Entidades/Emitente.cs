using AutoDAO.Atributos;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace AutoDAO.Entidades
{
    public class Emitente
    {
        [CampoTabela("IDEMITENTE")]

        public decimal IDEmitente { get; set; } = -1;

        [CampoTabela("IDENDERECO")]

        public decimal IDEndereco { get; set; } = -1;

        [CampoTabela("IDCONTATO")]

        public decimal IDContato { get; set; } = -1;

        [CampoTabela("CNPJ")]

        public string CNPJ { get; set; }

        [CampoTabela("RAZAOSOCIAL")]

        public string RazaoSocial { get; set; }

        [CampoTabela("NOMEFANTASIA")]

        public string NomeFantasia { get; set; }

        [CampoTabela("EMAIL")]

        public string Email { get; set; }

        [CampoTabela("LOGOMARCA")]
        public byte[] Logomarca { get; set; }

        [CampoTabela("NOMELOGOMARCA")]

        public string NomeLogomarca { get; set; }

        [CampoTabela("SITE")]
        public string Site { get; set; }

        [CampoTabela("FACEBOOK")]
        public string Facebook { get; set; }

        [CampoTabela("INSTAGRAM")]
        public string Instagram { get; set; }

        // Fiscal

        public string LogoTipoIMG   // property
        {
            get { return ConvertImageToBase64(GetLogoInImage(), ImageFormat.Png); }   // get method
        }

        private Image GetLogoInImage()
        {
            Image ToReturn = null;
            using (var ms = new MemoryStream(this.Logomarca))
                ToReturn = Image.FromStream(ms);

            if(ToReturn == null)
            {
                using (var ms = new MemoryStream(ImageToByteArray(AutoDAO.Properties.Resources.logotipo_sync)))
                    ToReturn = Image.FromStream(ms);
            }

            return ToReturn;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        private static string ConvertImageToBase64(Image image, ImageFormat format)
        {
            byte[] imageArray;

            using (System.IO.MemoryStream imageStream = new System.IO.MemoryStream())
            {
                image.Save(imageStream, format);
                imageArray = new byte[imageStream.Length];
                imageStream.Seek(0, System.IO.SeekOrigin.Begin);
                imageStream.Read(imageArray, 0, Convert.ToInt32(imageStream.Length));
            }

            return Convert.ToBase64String(imageArray);
        }


        public Emitente()
        {
        }
    }
}
