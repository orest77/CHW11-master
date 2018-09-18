using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;


namespace HW4
{
    [Serializable]
    [DataContract]
    public class Person
    {
        private string name;
        private DateTime birthYear;

        //[XmlAttribute]
        [DataMember]
        public string Name { get { return name; } set { } }

        //[XmlAttribute]
        [DataMember]
        public DateTime BirthYear { get { return birthYear; } set { } }

        public Person()
        {
        }
        
        public Person(string _name, DateTime _birthyear)
        {
            this.name = _name;
            this.birthYear = _birthyear;
        }

        public int Age()
        {
            return DateTime.Now.Year - BirthYear.Year;
        }

        public void Input()
        {
            Console.Write("Input person name: ");
            name = Console.ReadLine();
            Console.Write("Input person birthday (YYYY) : ");
            birthYear = DateTime.ParseExact(Console.ReadLine(), "yyyy",null);

        }

        public void ChangeName(string n)
        {
            this.name = n;
        }

        public override string ToString()
        {
            return $"{name} + {Age()}".ToString();
        }

        public void Output()
        {
            Console.WriteLine(ToString());
        }

        public static bool operator ==(Person first, Person second)
        {
            return (first.name == second.name);
        }

        public static bool operator !=(Person first, Person second)
        {
            return !(first == second);
        }

        public void SaveInXmlFormat(string fileName)
        {          
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Person),
                new Type[] { typeof(Person) });
            using (FileStream fStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, this);
            }
            Console.WriteLine("--> Save object in XML-format");
        }
        public void SaveInJsonFormat(string jsfileName)
        {
            DataContractJsonSerializer JsonFormat = new DataContractJsonSerializer(typeof(Person),
                new Type[] { typeof(Person) });
            using (FileStream fStream = new FileStream(jsfileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                JsonFormat.WriteObject(fStream, this);
            }
            Console.WriteLine("--> Save object in JSON-format");
        }
    }
}