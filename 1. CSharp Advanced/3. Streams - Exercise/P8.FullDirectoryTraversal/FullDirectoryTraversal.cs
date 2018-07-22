namespace P8.FullDirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            var filesData = new SortedDictionary<string, List<FileInfo>>();

            CollectDataForFiles(filesData);

            WriteReportFile(filesData);
        }

        private static void CollectDataForFiles(SortedDictionary<string, List<FileInfo>> filesData)
        {
            var path = Console.ReadLine();

            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var extension = fileInfo.Extension;

                if (filesData.ContainsKey(extension) == false)
                {
                    filesData[extension] = new List<FileInfo>();
                }

                filesData[extension].Add(fileInfo);
            }
        }

        private static void WriteReportFile(SortedDictionary<string, List<FileInfo>> filesData)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var reportFilePath = desktopPath + "\\report.txt";

            using (var writer = new StreamWriter(reportFilePath))
            {
                foreach (var pair in filesData.OrderByDescending(kvp => kvp.Value.Count))
                {
                    var extension = pair.Key;

                    writer.WriteLine(extension);

                    var orderedFileInfos = pair.Value.OrderBy(p => p.Length);

                    foreach (var fileInfo in orderedFileInfos)
                    {
                        var fileSize = fileInfo.Length / 1024.0;

                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:F3}kb");
                    }
                }
            }
        }
    }
}