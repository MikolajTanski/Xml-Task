using System;
using System.Xml.Serialization;

namespace Xml_Task.Models
{

    [Serializable, XmlRoot("user")]
    public class User
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "age")]
        public int Age  { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\n Name: {Name}\n Email: {Email}\n Age: {Age}";
        }
    }
}
