using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.google.zxing;
using com.google.zxing.qrcode;
using com.google.zxing.common;
using ByteMatrix = com.google.zxing.common.ByteMatrix;
using EAN13Writer = com.google.zxing.oned.EAN13Writer;
using EAN8Writer = com.google.zxing.oned.EAN8Writer;
using MultiFormatWriter = com.google.zxing.MultiFormatWriter;

namespace qrcode
{
    public class QrcodeClass
    {

        //生成二维码  content二维码内容,filePath二维码保存路径
        public void WriteQrcodeToFile(string content, string filePath)
        {
            ByteMatrix byteMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, 200, 200);
            Bitmap bitmap = toBitmap(byteMatrix);
          //  pictureBox1.Image = bitmap;
            writeToFile(byteMatrix, ImageFormat.Jpeg, filePath);

        }


        //识别二维码
        public string recognitionQrcode(string filePath)
        {
            string qrcodeString = "";


            return qrcodeString;
        }




        #region 私有类
        private static void writeToFile(ByteMatrix matrix, System.Drawing.Imaging.ImageFormat format, string file)
        {
            Bitmap bmap = toBitmap(matrix);
            bmap.Save(file, format);
        }
        private static Bitmap toBitmap(ByteMatrix matrix)
        {
            int width = matrix.Width;
            int height = matrix.Height;
            Bitmap bmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    bmap.SetPixel(x, y, matrix.get_Renamed(x, y) != -1 ? ColorTranslator.FromHtml("0xFF000000") : ColorTranslator.FromHtml("0xFFFFFFFF"));
                }
            }
            return bmap;
        }

        #endregion

    }
}
