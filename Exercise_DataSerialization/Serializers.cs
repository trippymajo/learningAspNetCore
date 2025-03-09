using Exercise_DataSerialization.Models;
using System.Xml; // XmlWriter
using System.Text.Json; // Utf8JsonWriter, JsonWriterOptions

namespace Exercise_DataSerialization;
public class Serializer
{
    public void XmlSerilizer(IQueryable<Category> cat, bool useAttributes = false)
    {
        string xmlFile = $"xml-useAttribues-{useAttributes.ToString()}.xml";

        
    }
}

