namespace P9.HTTPServer
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class HTTPServer
    {
        public static void Main()
        {
            const int Port = 8181;
            const string HtmlFilesPath = "./";

            var localAddress = IPAddress.Parse("127.0.0.1");

            var server = new TcpListener(localAddress, Port);

            server.Start();

            Console.WriteLine($"Waiting for a connection on {localAddress}:{Port}...");

            while (true)
            {
                using (var stream = server.AcceptTcpClient().GetStream())
                {
                    var request = new byte[4096];

                    var readBytes = stream.Read(request, 0, request.Length);

                    var requestDetails = Encoding.UTF8.GetString(request, 0, readBytes);

                    Console.WriteLine(requestDetails);

                    var requestFirstLine = requestDetails
                        .Substring(0, requestDetails.IndexOf(Environment.NewLine))
                        .Split();

                    var url = requestFirstLine[1];

                    var headerStatusLine = $"{requestFirstLine[2]} 200 OK";

                    var requestedPage = string.Empty;

                    if (url.Equals("/"))
                    {
                        requestedPage = $"{HtmlFilesPath}/index.html";
                    }
                    else
                    {
                        requestedPage = $"{HtmlFilesPath}{url.Substring(url.IndexOf('/'))}";

                        if (requestedPage.EndsWith(".html") == false)
                        {
                            requestedPage += ".html";
                        }

                        if (File.Exists(requestedPage) == false)
                        {
                            requestedPage = $"{HtmlFilesPath}/error.html";
                        }
                    }

                    var responseHeader = new StringBuilder();

                    responseHeader.AppendLine(headerStatusLine);
                    responseHeader.AppendLine("Accept-Ranges: bytes");

                    var responseMessage = new StringBuilder();

                    using (var reader = new StreamReader(requestedPage))
                    {
                        while (true)
                        {
                            var line = reader.ReadLine();

                            if (line == null)
                            {
                                break;
                            }

                            responseMessage.Append(line);
                        }
                    }

                    if (requestedPage.EndsWith("info.html"))
                    {
                        responseMessage
                            .Replace("{0}", DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"))
                            .Replace("{1}", Environment.ProcessorCount.ToString());
                    }

                    var contentLength = Encoding.UTF8.GetBytes(responseMessage.ToString()).Length;

                    responseHeader.AppendLine($"ContentLength: {contentLength}");
                    responseHeader.AppendLine("Connection: close");
                    responseHeader.AppendLine("Content-Type: text/html");
                    responseHeader.AppendLine();

                    responseMessage.Insert(0, responseHeader);

                    var responseBytes = Encoding.UTF8.GetBytes(responseMessage.ToString());

                    stream.Write(responseBytes, 0, responseBytes.Length);
                }
            }
        }
    }
}