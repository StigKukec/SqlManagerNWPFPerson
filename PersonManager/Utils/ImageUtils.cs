using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PersonManager.Utils
{
    public static class ImageUtils
    {
        public static BitmapImage? ByteArrayToBitmapImage(byte[] picture)
        {
            using var memoryStream = new MemoryStream(picture);
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = memoryStream;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();

            image.Freeze();
            return image;
        }
        public static byte[]? BitmapImageToByteArray(BitmapImage image)
        {
            var jpegEncoder = new JpegBitmapEncoder();
            jpegEncoder.Frames.Add(BitmapFrame.Create(image));
            using var memoryStream = new MemoryStream();
            jpegEncoder.Save(memoryStream);
            return memoryStream.ToArray();
        }

        public static byte[] ByteArrayFromReader(SqlDataReader reader, string column)
        {
            using var memoryStream = new MemoryStream();
            using var binaryWriter = new BinaryWriter(memoryStream);

            int bufferSize = 1024;
            byte[] buffer = new byte[bufferSize];

            int cursor = 0;
            int readBytes;
            do
            {
                readBytes = (int)reader.GetBytes(reader.GetOrdinal(column), cursor, buffer, 0, bufferSize);
                cursor += readBytes;
                binaryWriter.Write(buffer, 0, readBytes);
            } while (readBytes == bufferSize);

            return memoryStream.ToArray();
        }
    }
}
