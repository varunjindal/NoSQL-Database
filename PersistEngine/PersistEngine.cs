///////////////////////////////////////////////////////////////
// PersistEngine.cs - Test Requirements for Project #2        //
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
 * Persisting the contents of the data dictionary into a XML
   file is done here 
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

namespace Project2Starter
{
    
    class TestPersistEngine
    {
#if (PERSIST_ENGINE)
        static void Main(string[] args)
        {
            "Testing persist engine package".title();

            DBEngine<string, DBElement<string, List<string>>> dbString = new DBEngine<string, DBElement<string, List<string>>>();
            DBElement<string, List<String>> elemString = new DBElement<string, List<String>>();
            elemString.name = "Element2";
            elemString.descr = "testelement2";
            elemString.timeStamp = DateTime.Now;
            elemString.children.AddRange(new List<string> { "SMA1", "Syracuse2", "NY3" });
            elemString.payload = new List<string>();
            elemString.payload.AddRange(new List<string> { "we", "rock", "the ", "world" });

            //elem.showElement();
            dbString.insert("Prohject2", elemString);

            DBElement<string, List<String>> elemString2 = new DBElement<string, List<String>>();
            elemString2.name = "Element3";
            elemString2.descr = "test element3";
            elemString2.timeStamp = DateTime.Now;
            elemString2.children.AddRange(new List<string> { "SMA2", "Syracuse22", "NY33" });
            elemString2.payload = new List<string>();
            elemString2.payload.AddRange(new List<string> { "Thug", "Life" });

            //elem.showElement();
            dbString.insert("Thug3", elemString2);

            PersistEngine<string> test = new PersistEngine<string>();
            test.createXML(dbString);

        }
    }
#endif

        public class PersistEngine<Key>
        {
        public void createXML(DBEngine<Key, DBElement<Key, List<string>>> db)
        {
            XmlDocument doc = new XmlDocument();

            
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            
            XmlElement element1 = doc.CreateElement(string.Empty, "noSqlDb", string.Empty);
            doc.AppendChild(element1);

            XmlElement element2 = doc.CreateElement(string.Empty, "keytype", string.Empty);
            element1.AppendChild(element2);

            XmlText text2 = doc.CreateTextNode("string");
            element2.AppendChild(text2);

            XmlElement element3 = doc.CreateElement(string.Empty, "payloadtype", string.Empty);
            element1.AppendChild(element3);

            XmlText text3 = doc.CreateTextNode("ListOfStrings");
            element3.AppendChild(text3);

            foreach (Key key in db.Keys())
            {
                
                DBElement<Key, List<string>> elem = new DBElement<Key, List<string>>();
                db.getValue(key, out elem);

                XmlElement element4 = doc.CreateElement(string.Empty, "key", string.Empty);
                element1.AppendChild(element4);

                string xmlNode = key.ToString();
                XmlText text4 = doc.CreateTextNode(xmlNode);
                element4.AppendChild(text4);

                XmlElement element5 = doc.CreateElement(string.Empty, "element", string.Empty);
                element1.AppendChild(element5);

                XmlElement element6 = doc.CreateElement(string.Empty, "name", string.Empty);
                element5.AppendChild(element6);

                string nodeText = elem.name;
                XmlText text6 = doc.CreateTextNode(nodeText);
                element6.AppendChild(text6);

                XmlElement element7 = doc.CreateElement(string.Empty, "descr", string.Empty);
                element5.AppendChild(element7);

                nodeText = elem.descr;
                XmlText text7 = doc.CreateTextNode(nodeText);
                element7.AppendChild(text7);

                XmlElement element8 = doc.CreateElement(string.Empty, "timeStamp", string.Empty);
                element5.AppendChild(element8);

                nodeText = elem.timeStamp.ToString();
                XmlText text8 = doc.CreateTextNode(nodeText);
                element8.AppendChild(text8);

                XmlElement element9 = doc.CreateElement(string.Empty, "children", string.Empty);
                element5.AppendChild(element9);
                foreach (Key child in elem.children)
                {
                    XmlElement element10 = doc.CreateElement(string.Empty, "key", string.Empty);
                    element9.AppendChild(element10);
                    xmlNode = "key" + child;
                    XmlText text10 = doc.CreateTextNode(xmlNode);
                    element10.AppendChild(text10);
                }

                XmlElement element11 = doc.CreateElement(string.Empty, "payload", string.Empty);
                element5.AppendChild(element11);

                foreach (String pay in elem.payload)
                {
                    XmlElement element12 = doc.CreateElement(string.Empty, "item", string.Empty);
                    element11.AppendChild(element12);
                    nodeText = pay;
                    XmlText text12 = doc.CreateTextNode(nodeText);
                    element12.AppendChild(text12);
                }
            }


            doc.Save("xxx.xml");
        
        Console.WriteLine("\nXML Saved @/bin/Debug");
            Console.WriteLine("\nPlease open the XML file in the specified path to see the contents");
        }
    }

}
