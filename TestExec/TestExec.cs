///////////////////////////////////////////////////////////////
// TestExec.cs - Test Requirements for Project #2            //
// Ver 1.2                                                   //
// Application: Demonstration for CSE687-OOD, Project#2      //
// Language:    C#, ver 6.0, Visual Studio 2015              //
// Platform:    Dell XPS2700, Core-i7, Windows 10            //
// Source:      Jim Fawcett, CST 4-187, Syracuse University  //
//              (315) 443-3948, jfawcett@twcny.rr.com        //
// Author:      Varun Jindal, Student, Syracuse University   //
//              (315) 412-8139, vjindal@syr.edu              //
///////////////////////////////////////////////////////////////
/*
 * Package Operations:
 * -------------------
 * This package begins the demonstration of meeting requirements.
 * All other packages are called from here.
 */
/*
 * Maintenance:
 * ------------
 * Required Files: 
 *   Bonus.cs, DBElement.cs, DBFactory.cs, DBEngine.cs, DBExtensions.cs
 *   Display.cs, ItemEditor.cs, PersistEngine.cs, QueryEngine.cs, ReadXML.cs
 *   Scheduler.cs, UtilityExtensions.cs
 * Build Process:  devenv Project2Starter.sln /Rebuild debug
 *                 Run from Developer Command Prompt
 *                 To find: search for developer
 *
 * Maintenance History:
 * --------------------
 * ver 1.2 : 7  oct 15
 * ver 1.1 : 24 Sep 15
 * ver 1.0 : 18 Sep 15
 * - first release
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Project2Starter
{
  class TestExec
  {
        private DBEngine<int, DBElement<int, string>> db = new DBEngine<int, DBElement<int, string>>();
        private DBEngine<int, DBElement<int, List<string>>> dbPay = new DBEngine<int, DBElement<int, List<string>>>();
        private DBEngine<string ,DBElement<string, List<string>>> dbRead = new DBEngine<string, DBElement<string, List<string>>>();
        private DBEngine<string, DBElement<string, List<string>>> dbString = new DBEngine<string, DBElement<string, List<string>>>();
        private ItemEditor<int,string> itemEdit = new ItemEditor<int,string>();
        private ItemEditor<string, string> itemEdit2 = new ItemEditor<string, string>();
        private QueryEngine<int, string> QE = new QueryEngine<int, string>();
        private QueryEngine<string, string> QE1 = new QueryEngine<string, string>();

        public TestExec()
        {
            DBElement<string, List<String>> elemString = new DBElement<string, List<String>>();   //Populating DBEngine 
            elemString.name = "Element2";                                                         //object dbString
            elemString.descr = "testelement2";                                                    //for testing data string and list of string type.
            elemString.timeStamp = DateTime.Now;
            elemString.children.AddRange(new List<string> { "SMA1", "Syracuse2", "NY3" });
            elemString.payload = new List<string>();
            elemString.payload.AddRange(new List<string> { "we", "rock", "the ", "world" });
            dbString.insert("Prohject2", elemString);
            DBElement<string, List<String>> elemString2 = new DBElement<string, List<String>>();    //Populating DBEngine 
            elemString2.name = "Element3";                                                          //object dbString
            elemString2.descr = "test element3";                                                    //for testing data string and list of string type.
            elemString2.timeStamp = DateTime.Now;
            elemString2.children.AddRange(new List<string> { "SMA2", "Syracuse22", "NY33" });
            elemString2.payload = new List<string>();
            elemString2.payload.AddRange(new List<string> { "Thug", "Life" });
            dbString.insert("Thug3", elemString2);
            DBElement<int, List<string>> elemPayload = new DBElement<int, List<string>>();          //Populating DBEngine
            elemPayload.name = "Element4";                                                          //object dbPay
            elemPayload.descr = "test element4";                                                    //for testing data int and list of string type.
            elemPayload.timeStamp = DateTime.Now;
            elemPayload.children.AddRange(new List<int> { 1, 2, 3 });
            elemPayload.payload = new List<string>();
            elemPayload.payload.AddRange(new List<string> { "Project 2", "Demo", "start" });
            dbPay.insert(1, elemPayload);
            DBElement<int, List<string>> elemPayload2 = new DBElement<int, List<string>>();         //Populating DBEngine
            elemPayload2.name = "Element5";                                                         //object dbPay
            elemPayload2.descr = "test element5";                                                   //for testing data int and list of string type.
            elemPayload2.timeStamp = DateTime.Now;
            elemPayload2.children.AddRange(new List<int> { 98, 22, 35 });
            elemPayload2.payload = new List<string>();
            elemPayload2.payload.AddRange(new List<string> { "we", "rock", "the", "world" });
            dbPay.insert(2, elemPayload2);
            DBElement<int, string> elem = new DBElement<int, string>();                               //Populating DBEngine
            elem.name = "Element2";                                                                  //object db
            elem.descr = "test element2";                                                            //for testing data int and string type.
            elem.timeStamp = DateTime.Now;
            elem.children.AddRange(new List<int> {});
            elem.payload = "Varun";
            db.insert(1, elem);
            DBElement<int, string> elem1 = new DBElement<int, string>();                            //Populating DBEngine
            elem1.name = "Key/Value pair to be edited";                                             //object db
            elem1.descr = "test element3";                                                          //for testing data int and string type.
            elem1.timeStamp = DateTime.Now;
            elem1.children.AddRange(new List<int> { 4, 5, 6 });
            elem1.payload = "EDIT !";
            db.insert(2, elem1);
        }

    void TestR1()
     {
            "Demonstrating Requirement #1".title();
            WriteLine("\nProject #2 is being implemented in C# using the facilities of the .Net Framework Class Library and Visual Studio 2015, as provided in the ECS clusters\n");
     }
    void TestR2()
    {
      "Demonstrating Requirement #2".title();
            WriteLine("\nKey/Value database with key of type 'int' and data of type 'string'");
            db.showDB();
            WriteLine("\n\nKey/Value database with key of type 'int' and data of type 'list of string'");
            dbPay.showEnumerableDB();
            WriteLine("\n\nKey/Value database with key of type 'string' and data of type 'list of string'");
            dbString.showEnumerableDB();
            WriteLine();
    }
    void TestR3()
    {
      "Demonstrating Requirement #3 - Adding & Removing new key/value pair".title();
            
            //db.showDB();
            WriteLine("\n");
            WriteLine("Demonstrating Requirement #3 - removing a key/value pair [Removing Key 1]");
            db.remove(1);                                                         //removing the element
            db.showDB();
            WriteLine("\n\nDemonstrating Requirement #3 - removing a key/value pair [Removing Key 2]");
            dbPay.remove(2);                                                     //removing the element
            dbPay.showEnumerableDB();

            WriteLine("\n");
            WriteLine("Demonstrating Requirement #3 - adding a key/value pair [adding Key 3]");
            DBElement<int, string> elem = new DBElement<int, string>();                            
            elem.name = "Key/Value pair";                                             
            elem.descr = "test element";                                                          
            elem.timeStamp = DateTime.Now;
            elem.children.AddRange(new List<int> { 4, 5, 6 });
            elem.payload = "Dude !";
            db.insert(3,elem);                                                  //adding new element
            db.showDB();
            WriteLine("\n\nDemonstrating Requirement #3 - adding a key/value pair [adding Key 3]");
            DBElement<int, List<string>> elem1 = new DBElement<int, List<string>>();          
            elem1.name = "Element";
            elem1.descr = "test element";
            elem1.timeStamp = DateTime.Now;
            elem1.children.AddRange(new List<int> { 99,43,21});
            elem1.payload = new List<string>();
            elem1.payload.AddRange(new List<string> { "SMA","project 2" });
            dbPay.insert(3, elem1);                                                 //adding new element
            dbPay.showEnumerableDB();

        }
    void TestR4()
    {
            WriteLine();
            "Demonstrating Requirement #4".title();

            DBElement<int, string> elem = new DBElement<int, string>();                               //Populating DBEngine
            elem.name = "Element2";                                                                  //object db
            elem.descr = "test element2";                                                            //for testing data int and string type.
            elem.timeStamp = DateTime.Now;
            elem.children.AddRange(new List<int> { });
            elem.payload = "Varun";
            db.insert(1, elem);

            DBElement<int, List<string>> elemPayload2 = new DBElement<int, List<string>>();         //Populating DBEngine
            elemPayload2.name = "Element5";                                                         //object dbPay
            elemPayload2.descr = "test element5";                                                   //for testing data int and list of string type.
            elemPayload2.timeStamp = DateTime.Now;
            elemPayload2.children.AddRange(new List<int> { 98, 22, 35 });
            elemPayload2.payload = new List<string>();
            elemPayload2.payload.AddRange(new List<string> { "we", "rock", "the", "world" });
            dbPay.insert(2, elemPayload2);

            WriteLine();
            WriteLine("\nUpdating Name of Key 1");
            itemEdit.edit(1,"name","updated",db);           // editing name
            db.showDB();

            WriteLine();
            WriteLine("\nUpdating description of Key 1");
            itemEdit.edit(1, "descr", "updated", dbPay);        // editing description
            dbPay.showEnumerableDB();

            WriteLine();
            WriteLine("\nUpdating childern of Key 1");
            List<int> child = new List<int> { 3, 2, 1 };
            itemEdit.editChildern(1, "childern", child, db);    // editing children
            db.showDB();
            WriteLine();

            WriteLine();
            WriteLine("\nUpdating Payload of Key 'Thug3'");
            List<string> payEdit = new List<string> { "Updated", "the", "payload !" };
            itemEdit2.editPayload("Thug3", "payload", payEdit, dbString);               // editing payload
            dbString.showEnumerableDB();
            WriteLine();
        }
    void TestR5()
        {
             "Demonstrating Requirement #5".title();
             WriteLine();
            WriteLine("Persisting Database in to the XML\n");
            PersistEngine<string> test = new PersistEngine<string>();       // persisting XML
            test.createXML(dbString);

            "Demonstrating Augmenting back from XML #5".title();

            ReadXml<string> testRead = new ReadXml<string>();
            Console.WriteLine("\nReading the XML\n");                       // reading xml
            testRead.readXml(dbRead);
            WriteLine();
            WriteLine("Displaying DB contents after reading the XML");
            dbRead.showEnumerableDB();
            WriteLine();
        }
    void TestR6()
    {
      "Demonstrating Requirement #6 - Scheduled Save".title();
            Scheduler<string> sch = new Scheduler<string>();            // Scheduled Save starts here
            sch.scheduledSave(dbString);
            WriteLine();
        }
    void TestR7()
    {
        "Demonstrating Requirement #7".title();
          
            QE.valueByKey(1, dbPay);                        // Return value by key
            WriteLine();

            QE.childrenByKey(1, dbPay);                     // return children by key

            //QE1.keyPattern(".*h.*", dbString);
            WriteLine();
            QE1.keyPattern(".*hjbbj.*", dbString);          // search by pattern in key name
            WriteLine();
            QE.metaDataPattern("t2", dbString);             // search by string in metadata

            //DateTime toDate = new DateTime(2015, 10, 7);
            DateTime toDate = new DateTime();                   //Please pass the custom toTime like DateTime toDate = new DateTime(2015, 10, 7); 
            DateTime fromDate = new DateTime(2015, 10, 1);
            //System.Threading.Thread.Sleep(500);

            QE.dateTimeSearch(fromDate,toDate,dbString);


        }
    void TestR8()
    {
      "Demonstrating Requirement #8".title();

            DBFactory<string, DBElement<string, List<string>>> dbFac;           // immutable db object
            DBEngine<string, DBElement<string, List<string>>> dbImmut= new DBEngine<string, DBElement<string, List<string>>>();
            List<string> fetchedKeys = new List<string>();

            fetchedKeys = QE1.keyPattern(".*hu.*", dbString);
            

            foreach(string key in fetchedKeys)
            {
                DBElement<string, List<String>> elem = new DBElement<string, List<String>>();
                dbString.getValue(key, out elem);
                dbImmut.insert(key, elem);
                
            }
            //dbImmut.showEnumerableDB();
            dbFac = new DBFactory<string, DBElement<string, List<string>>>(dbImmut);    // populating immutable db

            WriteLine("\nDisplaying the contents of the immutable database");
            dbFac.showEnumerableDB();

            WriteLine();
    }
    void TestR9()
        {
            "Demonstrating Requirement #9".title();
            WriteLine("Loading project 2 package structure XML in the DB");
            ReadXml<string> testRead = new ReadXml<string>();                   // loading project structure xml in db
            testRead.readXml(dbRead);
            WriteLine();
            WriteLine("Displaying DB contents after reading the XML");          
            dbRead.showEnumerableDB();
            WriteLine();

        }
    void TestR10()
        {
            "Demonstrating Requirement #10".title();
            Console.WriteLine("\nAll the functional requirements #2-#9 demonstrated\n");
        }
        void TestR11()
        {
            "Demonstrating Requirement #11".title();
            WriteLine();
            Console.WriteLine("Comparison Document is submitted in zip file");
        }
        void TestR12()
        {
            "Demonstrating Requirement #12".title();
            WriteLine();
            Bonus b = new Bonus();                          // calling bonus class contructor
        }
        static void Main(string[] args)
    {
      TestExec exec = new TestExec();
      "Demonstrating Project#2 Requirements".title('=');
      WriteLine();
            exec.TestR1();
            exec.TestR2();
            exec.TestR3();
            exec.TestR4();
            exec.TestR5();
            exec.TestR6();
            exec.TestR7();
            exec.TestR8();
            exec.TestR9();
            exec.TestR10();
            exec.TestR11();
            exec.TestR12();
            Write("\n\n");
        }
  }
}
