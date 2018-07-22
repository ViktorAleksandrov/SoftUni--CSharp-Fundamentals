namespace P4.CopyBinaryFile
{
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            using (var source = new FileStream("copyMe.png", FileMode.Open))
            {
                using (var destination = new FileStream("copyMe-COPY.png", FileMode.Create))
                {
                    var buffer = new byte[4096];

                    while (true)
                    {
                        var readBytes = source.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}