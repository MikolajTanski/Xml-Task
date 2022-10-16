using Microsoft.AspNetCore.Http;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Xml_Task.Models;

namespace Xml_Task.Services
{
    public class XMLService
    {
        public void Save(string filePath)
        {
            User user = GetUserFromXML(filePath);
            string name = user.Name;

            //File.Delete(filePath);
        }
        internal User GetUserFromXML(string filePath)
        {
            User objectToDeserialize = new User();
            XmlSerializer xmlserializer = new System.Xml.Serialization.XmlSerializer(objectToDeserialize.GetType());

            //Use using so that streamReader object will be cleaned up properly after use. 
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                return (User)xmlserializer.Deserialize(streamReader);
            }
        }
    }
}
