using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] person = new Person[3];

            #region
            //try
            ////{
            ////    for (int i = 0; i < person.Length; i++)
            ////    {
            ////        Person pers = new Person();
            ////        pers.Input();
            ////        person[i] = pers;
            ////    }
            //}
            //catch (FormatException a)
            //{
            //    Console.WriteLine(a.Message);
            //}

            //foreach (var pers in person)
            //{
            //    if (pers.Age() < 16)
            //    {
            //        pers.ChangeName("Very Young");
            //    }
            //    pers.Output();
            //}


            //for (int i = 0; i < person.Length; i++)
            //{
            //    for (int a = 0; a < person.Length; a++)
            //    {
            //        if (a == i) continue;
            //        if (person[i].Name == person[a].Name)
            //        {                        
            //            Console.Write($"The persons with the same names :");                        
            //            person[i].Output();
            //        }


            //    }

            //}
            #endregion
            Person persi = new Person("Olena", DateTime.ParseExact("1994", "yyyy", null));
         
            persi.SaveInXmlFormat("person.xml");

            persi.SaveInJsonFormat("Person.json");


            Console.ReadKey();
        }
    }
}
