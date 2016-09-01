///////////////////////////////////////////////////////////////
// ItemEditor.cs - Test Requirements for Project #2            //
// Ver 1.0                                                    //
// Application: Demonstration for CSE681-smA, Project#2      //
// Language:    C#, ver 5.0, Visual Studio 2015              //
// Platform:    Dell inspiron 1545 , Core-2 duo, Windows 8   //
// Author:      Varun Jindal, Student, Syracuse University  //
//              (315) 412-8139, vjindal@syr.edu             //
///////////////////////////////////////////////////////////////
/*
 * Package Operations:
 * -------------------
 * This package helps demonstration of meeting requirements.
 * Editing the Metadata and Value of a specified key will be handled here.
 * 
 */
/*
 * Maintenance:
 * ------------
 * Required Files: 
 * DBElement.cs,DBElementTest.cs, DBEngine.cs, Display.cs, 
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


namespace Project2Starter
{

#if(TEST_ITEMEDITOR)
    public class TestItemEditor
    {
        public static void Main(string[] args)
        {
            "Testing Item Editor Package".title('=');
            Console.WriteLine();
            DBEngine<int, DBElement<int, List<string>>> dbPay = new DBEngine<int, DBElement<int, List<string>>>();

            DBElement<int, List<string>> elemPayload = new DBElement<int, List<string>>();
            elemPayload.name = "Element4";
            elemPayload.descr = "test element4";
            elemPayload.timeStamp = DateTime.Now;
            elemPayload.children.AddRange(new List<int> { 1, 2, 3 });
            elemPayload.payload = new List<string>();
            elemPayload.payload.AddRange(new List<string> { "Project 2", " ", "demo", " ", "starts" });
            //elem.showElement();
            dbPay.insert(4, elemPayload);

            DBElement<int, List<string>> elemPayload2 = new DBElement<int, List<string>>();
            elemPayload2.name = "Element5";
            elemPayload2.descr = "test element5";
            elemPayload2.timeStamp = DateTime.Now;
            elemPayload2.children.AddRange(new List<int> { 98, 22, 35 });
            elemPayload2.payload = new List<string>();
            elemPayload2.payload.AddRange(new List<string> { "we", "rock", "the", "world" });
            //elem.showElement();
            dbPay.insert(5, elemPayload2);

            dbPay.showEnumerableDB();
            Console.WriteLine();

            ItemEditor<int,string> itemEdit = new ItemEditor<int,string>();
            itemEdit.edit(4, "name", "updated", dbPay);
            itemEdit.edit(4, "descr", "updated", dbPay);
            List<int> child = new List<int> { 3, 2, 1 };
            itemEdit.editChildern(4, "childern", child, dbPay);

            List<string> payLoad = new List<string> { "Update", " ", "demo", " ", "starts" };
            itemEdit.editPayload(4, "pay-load", payLoad, dbPay);

            dbPay.showEnumerableDB();

        }
    }

#endif

    public class ItemEditor<Key,Value>
    {
        
        DBElement<Key, string> elem = new DBElement<Key, string>();
        DBElement<Key, List<string>> elemPay = new DBElement<Key, List<string>>();

        public bool edit(Key key, string attribute, string newValue, DBEngine<Key, DBElement<Key, List<string>>> db)
        {
           bool test =  db.getValue(key, out elemPay);

            if (!test) {  return false; }

            else
            {
                if (attribute == "name")
                {
                    elemPay.name = newValue;
                    db.insert(key, elemPay);

                }

                else if (attribute == "descr")
                {
                    elemPay.descr = newValue;
                    db.insert(key, elemPay);
                }
                return true;
            }
        }

        public bool edit(Key key, string attribute, string newValue, DBEngine<Key, DBElement<Key, string>> db)
        {

            bool test = db.getValue(key, out elem);

            if (!test) {  return false; }
            
            else
            {

                if (attribute == "name")
                {
                    elem.name = newValue;
                    db.insert(key, elem);

                }

                else if (attribute == "descr")
                {
                    elem.descr = newValue;
                    db.insert(key, elem);
                }
                return true;
            }
        }

        public bool editChildern(Key key, string attribute, List<Key> newValue, DBEngine<Key, DBElement<Key, string>> db)
        {
            bool test = db.getValue(key, out elem);

            if (!test) { return false; }

            else
            {

                elem.children = newValue;
                db.insert(key, elem);
            }
            return true;
        }

        public bool editChildern(Key key, string attribute, List<Key> newValue, DBEngine<Key, DBElement<Key, List<string>>> db)
        {
            bool test = db.getValue(key, out elemPay);

            if (!test) { return false; }

            else
            {
                elemPay.children = newValue;
                db.insert(key, elemPay);
            }
            return true;
        }

        public bool editPayload(Key key, string attribute, List<string> newValue, DBEngine<Key, DBElement<Key, List<string>>> db)
        {
            bool test = db.getValue(key, out elemPay);

            if (!test) { return false; }

            else
            {

                elemPay.payload = newValue;
                db.insert(key, elemPay);
            }
            return true;
        }
    }

}
