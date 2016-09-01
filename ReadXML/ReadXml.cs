///////////////////////////////////////////////////////////////
// ReadXml.cs - Test Requirements for Project #2            //
// Ver 1.0                                                    //
// Application: Demonstration for CSE681-SMA, Project#2      //
// Language:    C#, ver 5.0, Visual Studio 2015              //
// Platform:    Dell inspiron 1545 , Core-2 duo, Windows 8   //
// Author:      Varun Jindal, Student, Syracuse University  //
//              (315) 412-8139, vjindal@syr.edu             //
///////////////////////////////////////////////////////////////
/*
 * Package Operations:
 * -------------------
 * This package helps demonstration of meeting requirements.
 * Augmentation and Restoration of the data dictionary
   from a XML file will be performed in this package
 */
/*
 * Maintenance:
 * ------------
 * Required Files: 
 * DBElement.cs, DBEngine.cs, Display.cs, 
 * DBExtensions.cs, UtilityExtensions.cs
 *
 * Build Process:  devenv Project2Starter.sln /Rebuild debug
 *                 Run from Developer Command Prompt
 *                 To find: search for developer
 *
 * Maintenance History:
 * --------------------
 * ver 1.0 : 7 Oct 15
 * - first release
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using static System.Console;
using System.IO;

namespace Project2Starter
{
#if (TEST_READ_XML)
    class TestReadXml
    {
        static void Main(string[] args)
        {
            DBEngine<string, DBElement<string, List<string>>> dbRead = new DBEngine<string, DBElement<string, List<string>>>();
            ReadXml<string> test = new ReadXml<string>();
            DBEngine<string, DBElement<string, List<string>>> dbPay = new DBEngine<string, DBElement<string, List<string>>>();
            DBEngine<int, DBElement<int, List<string>>> db = new DBEngine<int, DBElement<int, List<string>>>();
            ReadXml<string> test2 = new ReadXml<string>();
            ReadXml<int> test1 = new ReadXml<int>();
            test1.readXml(db);
            Console.WriteLine(); Console.WriteLine();
            db.showEnumerableDB();
            dbPay.showEnumerableDB();
            WriteLine();
        }
    }
#endif

    public class ReadXml<Key>
    {
        private string nameRead = "";
        private string descrRead = "";
        private string tsread = "";
        private Key keyParent,keyChild;
        private int first = 0;

        public void readXml(DBEngine<Key, DBElement<Key, List<string>>> dbRead)
        {
            XmlDocument doc = new XmlDocument();                //creating object of XmlDocument Class

            if (File.Exists("yyy.xml"))
            {
                try
                { doc.Load("yyy.xml"); }
                catch (Exception e)
                {
                    WriteLine("\n Wrong Input file. Error Message : {0}\n", e.Message);
                }
            }
            else
            {
                WriteLine("\n  File \" yyy.xml \" does not exist.");
                return ;
            }
            doc.Save(Console.Out);                                 //Printing XML file on the console
            foreach (XmlNode node in doc.GetElementsByTagName("noSqlDb"))
            {   DBElement<Key, List<string>> elemRead = null;
                foreach (XmlNode node2 in node.ChildNodes)
                {
                    if (node2.Name == "key")                        // Capturing the Parent key
                    {   first += 1;
                        if(first>0 && first%2==1)
                            elemRead = new DBElement<Key, List<string>>();
                        keyParent= (Key)Convert.ChangeType(node2.InnerText, typeof(Key));
                    }
                    else if (node2.Name == "element")               //Capturing Element Tag
                    {   first += 1;
                        foreach (XmlNode node3 in node2.ChildNodes)
                        {
                            if (node3.Name == "name")                   // Capturing Metadata "Name"
                                elemRead.name = node3.InnerText;
                            else if (node3.Name == "descr")             // Capturing Metadata "description"
                                elemRead.descr = node3.InnerText;
                            else if (node3.Name == "timeStamp")         // Capturing Metadata "Time Stamp"
                               elemRead.timeStamp = DateTime.Parse(node3.InnerText);
                            else if (node3.Name == "children")              // Capturing childen of the Parent Key
                            {
                                List<Key> childRead = new List<Key>();                               
                                foreach (XmlNode node4 in node3.ChildNodes)
                                    if (node4.Name == "key")
                                        childRead.Add((Key)Convert.ChangeType(node4.InnerText, typeof(Key)));
                                elemRead.children = childRead;
                            }
                            else if (node3.Name == "payload")                   // Capturing Value/Payload
                            {
                                List<string> payloadRead = new List<string>();
                                foreach (XmlNode node5 in node3.ChildNodes)
                                if (node5.Name == "item")
                                        payloadRead.Add(node5.InnerText);
                                elemRead.payload = payloadRead;
                            }
                        }
                    }
                    if(first>0 && first%2==0)
                    {   dbRead.insert(keyParent, elemRead);             // Inserting captured records into the database
                        first = 0;
                    }
                }
            }
        }

       

    }
}
