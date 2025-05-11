namespace Simple.Coinos.Helpers;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class LogDecoder
{
    private LogDecoder() { }

    public static LogData[] DecodeFile(string filePath)
    {
        LogDecoder decoder = new LogDecoder();

        string fileContent = File.ReadAllText(filePath);
        // Fix Object concat
        fileContent = "[" + fileContent + "]";
        fileContent = fileContent.Replace("}\n{", "},{");

        var data = Newtonsoft.Json.JsonConvert.DeserializeObject<LogData[]>(fileContent);
        if (data is null) throw new InvalidOperationException("Null Deserialization");

        return data.OrderBy(o => o.ts).ToArray();
    }

    public record LogData
    {
        public string level { get; set; }
        public double ts { get; set; }
        public DateTime DateTime => DateTime.UnixEpoch.AddSeconds(ts);

        public string logger { get; set; }
        public string msg { get; set; }
        public Request request { get; set; }
        public string user_id { get; set; }
        public float duration { get; set; }
        public TimeSpan sDuration => TimeSpan.FromSeconds(duration);

        public int size { get; set; }
        public int status { get; set; }
        public Dictionary<string, string[]> resp_headers { get; set; }

        public class Request
        {
            public string remote_ip { get; set; }
            public string remote_port { get; set; }
            public string proto { get; set; }
            public string method { get; set; }
            public string host { get; set; }
            public string uri { get; set; }
            public Dictionary<string, string[]> headers { get; set; }
            public Tls tls { get; set; }

            public string OriginalIP => string.Join(' ', headers["X-Forwarded-For"]);
        }
        public class Tls
        {
            public bool resumed { get; set; }
            public int version { get; set; }
            public int cipher_suite { get; set; }
            public string proto { get; set; }
            public string server_name { get; set; }
        }

        public override string ToString()
        {
            return $"{DateTime:dd/MM HHmmss} {request.OriginalIP} [{request.method}] {request.uri} {string.Join(" ", request.headers["User-Agent"])}";
        }
    }
}
