using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("usage: xml2json <input_filename> [<output_filename]");
            return;
        }
        
        var inputXml = args[0];
        var outputJson = args.Length > 1 ? args[1] : "";

        string xml;

        using (var inputFileStream = File.OpenRead(inputXml))
        {
            using (var inputStreamReader = new StreamReader(inputFileStream))
            {
                xml = inputStreamReader.ReadToEnd();
            }
        }

        var doc = new XmlDocument();
        doc.LoadXml(xml);

        foreach (XmlNode node in doc)
        {
            if (node.NodeType == XmlNodeType.XmlDeclaration)
                doc.RemoveChild(node);
        }

        var json = JsonConvert.SerializeXmlNode(doc);

        //save out
        if (!string.IsNullOrEmpty(outputJson))
        {
            using (var outputFileStream = File.Open(outputJson, FileMode.Create, FileAccess.Write))
            {
                using (var outputStreamWriter = new StreamWriter(outputFileStream))
                {
                    outputStreamWriter.Write(json);
                    outputStreamWriter.Flush();
                    outputStreamWriter.Close();
                }
            }
        }
        Console.WriteLine(json);
    }
}