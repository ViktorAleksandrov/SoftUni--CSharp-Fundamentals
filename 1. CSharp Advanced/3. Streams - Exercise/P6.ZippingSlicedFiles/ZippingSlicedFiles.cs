namespace P6.ZippingSlicedFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;

    public class ZippingSlicedFiles
    {
        public static void Main()
        {
            var sourceFile = "sliceMe.mp4";
            var destination = string.Empty;

            var parts = int.Parse(Console.ReadLine());

            var files = SliceAndZip(sourceFile, destination, parts);

            Assemble(files, destination);
        }

        private static List<string> SliceAndZip(string sourceFile, string destinationDirectory, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                var files = new List<string>();

                var partSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int index = 0; index < parts; index++)
                {
                    var filePartName = $"Part-{index}.{extension}.gz";

                    files.Add(filePartName);

                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    var filePath = destinationDirectory + filePartName;

                    using (var writer = new GZipStream(new FileStream(filePath, FileMode.Create), CompressionMode.Compress))
                    {
                        var currentBytes = 0;

                        var buffer = new byte[4096];

                        while (currentBytes < partSize)
                        {
                            var readBytes = reader.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            writer.Write(buffer, 0, readBytes);

                            currentBytes += readBytes;
                        }
                    }
                }

                return files;
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            if (destinationDirectory.EndsWith('/') == false)
            {
                destinationDirectory += "/";
            }

            var assembledFile = $"{destinationDirectory}sliceMe-ASSEMBLED.mp4";

            using (var writer = new FileStream(assembledFile, FileMode.Create))
            {
                var buffer = new byte[4096];

                foreach (var file in files)
                {
                    using (var reader = new GZipStream(new FileStream(file, FileMode.Open), CompressionMode.Decompress))
                    {
                        while (true)
                        {
                            var readBytes = reader.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            writer.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }
    }
}