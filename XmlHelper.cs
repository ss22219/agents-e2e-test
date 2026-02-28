using System.IO;
using System.Xml.Serialization;

public static class XmlHelper
{
    public static string Serialize<T>(T obj)
    {
        if (obj == null) return null;
        var serializer = new XmlSerializer(typeof(T));
        using var writer = new StringWriter();
        serializer.Serialize(writer, obj);
        return writer.ToString();
    }

    public static T Deserialize<T>(string xml)
    {
        if (string.IsNullOrEmpty(xml)) return default(T);
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(xml);
        return (T)serializer.Deserialize(reader);
    }
}
