using AutoController.Funcoes;
using AutoDAO.Custom;
using AutoDAO.Enum;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AutoUTIL
{
    public partial class SyncUtil
    {
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string ConvertImageToBase64(Image image, ImageFormat format)
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
                
        public static string SaudacaoAgora()
        {
            int Hora = DateTime.Now.Hour;
            string Saudacao = string.Empty;
            if (Hora >= 0 && Hora <= 6)
                Saudacao = "Boa noite";

            if (Hora > 6 && Hora <= 13)
                Saudacao = "Bom dia";

            if (Hora > 13 && Hora <= 18)
                Saudacao = "Boa tarde";

            if (Hora > 18 && Hora <= 23)
                Saudacao = "Boa noite";

            return Saudacao;
        }
        public static Bitmap Transparent2Color(Bitmap bmp1, Color target)
        {
            Bitmap bmp2 = new Bitmap(bmp1.Width, bmp1.Height);
            Rectangle rect = new Rectangle(Point.Empty, bmp1.Size);
            using (Graphics G = Graphics.FromImage(bmp2))
            {
                G.Clear(target);
                G.DrawImageUnscaledAndClipped(bmp1, rect);
            }
            return bmp2;
        }

        public static byte[] StreamToBytes(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }


        static Image FixedSize(Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Red);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
               
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public static double Arredondar(double Valor, int Dec)
        {
            double Valor1 = 0;
            double Numero1 = 0;
            double Numero2 = 0;
            double Numero3 = 0;

            Valor1 = Math.Exp(Math.Log(10) * (Dec + 1));
            Numero1 = Convert.ToInt32(Valor * Valor1);
            Numero2 = (Numero1 / 10);
            Numero3 = Math.Round(Numero2);
            return (Numero3 / (Math.Exp(Math.Log(10) * Dec)));
        }

        public static string SomenteNumeros(string Value)
        {
            string resultString = string.Empty;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(Value, "");
            return resultString;
        }

        public static string FormatarCNAE(string Value)
        {
            string resultString = Value;
            resultString = resultString.Replace("-", "");
            resultString = resultString.Replace(".", "");
            resultString = resultString.Replace("/", "");           
            return resultString;
        }

        public static string FormatarCESTANDNCMANDANEXO(string Value)
        {
            string resultString = Value;
            resultString = resultString.Replace(".", "");
            return resultString;
        }

        public static object GetValueFieldDataRowView(DataRowView DataRow, string FieldName)
        {
            return DataRow[FieldName];
        }

        public static bool IsValidCNPJCPF(string cpfCnpj)
        {
            return (IsCpf(cpfCnpj) || IsCnpj(cpfCnpj));
        }

        public static bool IsValidEmail(string email)
        {
            return IsValidEmailGo(email);
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static string BitmapToBase64(Bitmap b)
        {
            ImageConverter ic = new ImageConverter();
            byte[] ba = (byte[])ic.ConvertTo(b, typeof(byte[]));
            return Convert.ToBase64String(ba, 0, ba.Length);
        }

        public static string RetornarMD5(string Senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return RetonarHash(md5Hash, Senha);
            }
        }

        public static bool ComparaMD5(string senhabanco, string Senha_MD5)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var senha = RetornarMD5(senhabanco);
                if (VerificarHash(md5Hash, Senha_MD5, senha))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static string RetonarHash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private static bool VerificarHash(MD5 md5Hash, string input, string hash)
        {
            StringComparer compara = StringComparer.OrdinalIgnoreCase;

            if (0 == compara.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Bitmap SetAlpha(Bitmap bmpIn, int alpha)
        {
            Bitmap bmpOut = new Bitmap(bmpIn.Width, bmpIn.Height);
            float a = alpha / 255f;
            Rectangle r = new Rectangle(0, 0, bmpIn.Width, bmpIn.Height);

            float[][] matrixItems = {
            new float[] {1, 0, 0, 0, 0},
            new float[] {0, 1, 0, 0, 0},
            new float[] {0, 0, 1, 0, 0},
            new float[] {0, 0, 0, a, 0},
            new float[] {0, 0, 0, 0, 1}};

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

            ImageAttributes imageAtt = new ImageAttributes();
            imageAtt.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            using (Graphics g = Graphics.FromImage(bmpOut))
                g.DrawImage(bmpIn, r, r.X, r.Y, r.Width, r.Height, GraphicsUnit.Pixel, imageAtt);

            return bmpOut;
        }

        private static bool IsValidEmailGo(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        private static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public static decimal ConvertStringToDecimal(string Version)
        {
            return VersionToDecimal(Version);
        }

        private static decimal VersionToDecimal(string Version)
        {
            Version = Version.Remove(1, 1);
            Version = Version.Remove(2, 1);
            Version = Version.Remove(3, 1);
            return Convert.ToDecimal(Version);
        }

        public static string ConvertDecimalToString(decimal version)
        {
            return ConvertVersionToString(version.ToString());
        }

        private static string ConvertVersionToString(string Version)
        {
            Version = Version.Insert(1, ".");
            Version = Version.Insert(3, ".");
            Version = Version.Insert(5, ".");
            return Version;
        }

        public static DataTable GetChanges(DataTable dt, TipoOperacao to)
        {
            if (dt == null)
                return null;

            switch (to)
            {
                case TipoOperacao.INSERT:
                    return dt.GetChanges(DataRowState.Added);
                case TipoOperacao.UPDATE:
                    return dt.GetChanges(DataRowState.Modified);
                case TipoOperacao.DELETE:
                    using (DataTable dtDel = dt.GetChanges(DataRowState.Deleted))
                    {
                        if (dtDel == null)
                            return null;
                        dtDel.RejectChanges();
                        return dtDel;
                    }
                default:
                    return null;
            }
        }

       
        public static void LembrarOption(string Usuario)
        {
            if (!FuncoesConfiguracao.Salvar(ChavesConfiguracao.CHAVE_LOGIN_USUARIO_LEMBRAR, Encoding.Default.GetBytes(Usuario)))
                throw new Exception("Não foi possível salvar a configuração de lembrar Login/Senha.");
        }         
    }

    public static class MaskUtil
    {
        public static string Mask(this string value, string mask, char substituteChar = '#')
        {
            int valueIndex = 0;
            try
            {
                return new string(mask.Select(maskChar => maskChar == substituteChar ? value[valueIndex++] : maskChar).ToArray());
            }
            catch (IndexOutOfRangeException e)
            {
                throw new Exception("Value too short to substitute all substitute characters in the mask", e);
            }
        }
    }


    public static class ImageExtensions
    {
        public static Image Resize(this Image image, int width, int height)
        {
            var scale = Math.Min(height / (float)image.Height, width / (float)image.Width);
            return image.GetThumbnailImage((int)(image.Width * scale), (int)(image.Height * scale), () => false, IntPtr.Zero);
        }

        public static Image ResizeImage(this Image image, int newWidth, int newHeight, InterpolationMode mode = InterpolationMode.Default, bool maintainAspectRatio = false)
        {
            Bitmap output = new Bitmap(newWidth, newHeight, image.PixelFormat);

            using (Graphics gfx = Graphics.FromImage(output))
            {
                gfx.Clear(Color.FromArgb(0, 0, 0, 0));
                gfx.InterpolationMode = mode;
                if (mode == InterpolationMode.NearestNeighbor)
                {
                    gfx.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gfx.SmoothingMode = SmoothingMode.HighQuality;
                }

                double ratioW = (double)newWidth / (double)image.Width;
                double ratioH = (double)newHeight / (double)image.Height;
                double ratio = ratioW < ratioH ? ratioW : ratioH;
                int insideWidth = (int)(image.Width * ratio);
                int insideHeight = (int)(image.Height * ratio);

                gfx.DrawImage(image, new Rectangle((newWidth / 2) - (insideWidth / 2), (newHeight / 2) - (insideHeight / 2), insideWidth, insideHeight));
            }

            return output;
        }

    }


}
