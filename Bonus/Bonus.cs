///////////////////////////////////////////////////////////////
// Bonus.cs - Test Requirements for Project #2               //
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
 * Implement categories by using a Dictionary<key,value> where 
 * each key is the name of a category and each value is a list 
 * of keys for db items in that category
 */
/*
 * Maintenance:
 * ------------
 * Required Files: 
 * 
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
using static System.Console;

namespace Project2Starter
{
#if (TEST_BONUS)
    class TestBonus
    {
        static void Main(string[] args)
        {
            Bonus b = new Bonus();
        }

    }
#endif
    public class Bonus
    {
        public Bonus()
        {

            DBEngine1<DBElement1<int, string>> db = new DBEngine1<DBElement1<int, string>>();
            DBElement1<int, string> elem = new DBElement1<int, string>();                               //Populating DBEngine1
            elem.name = "Element2";                                                                  //object db
            elem.descr = "test element2";                                                            //for testing data int and string type.
            elem.timeStamp = DateTime.Now;
            elem.children.AddRange(new List<int> { });
            elem.payload = "Varun";
            elem.category.AddRange(new List<int> { 1, 2, 3 });
            db.insert(1, elem);
            DBElement1<int, string> elem1 = new DBElement1<int, string>();                            //Populating DBEngine1
            elem1.name = "Key/Value pair to be edited";                                             //object db
            elem1.descr = "test element3";                                                          //for testing data int and string type.
            elem1.timeStamp = DateTime.Now;
            elem1.children.AddRange(new List<int> { 4, 5, 6 });
            elem1.payload = "EDIT !";
            elem1.category.AddRange(new List<int> { 1, 2, 5 });
            db.insert(2, elem1);
            DBElement1<int, string> elem2 = new DBElement1<int, string>();                            //Populating DBEngine1
            elem2.name = "Key/Value pair to be edited";                                             //object db
            elem2.descr = "test element3";                                                          //for testing data int and string type.
            elem2.timeStamp = DateTime.Now;
            elem2.children.AddRange(new List<int> { 4, 5, 6 });
            elem2.payload = "EDIT !";
            elem2.category.AddRange(new List<int> { });
            db.insert(3, elem2);


            Console.WriteLine("DATABASE CONTENTS");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ ");
            db.show(db);
            WriteLine("\n");

            //db.queryByCategory(1,db);
            Console.WriteLine("DATABASE BY CATEGORY");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _");
            db.showDBbyCategory(db);                        // Publishing DB
        }
    }

    public class DBEngine1<Value>
    {
        private Dictionary<int, Value> dbStore;
        public DBEngine1()
        {
            dbStore = new Dictionary<int, Value>();
        }

        public bool insert(int key, Value val)
        {
            if (dbStore.Keys.Contains(key))
                return false;
            dbStore[key] = val;
            return true;
        }

        public bool getValue(int key, out Value val)
        {
            if (dbStore.Keys.Contains(key))
            {
                val = dbStore[key];
                return true;
            }
            else
            {
                WriteLine("Key is not present in the DB");
                val = default(Value);
                return false;
            }

        }

        public void show(DBEngine1<Value> db)
        {
            foreach (int key in db.Keys())
            {
                Value value;
                db.getValue(key, out value);
                DBElement1<int, string> elem = value as DBElement1<int, string>;
                Write("\n\n  -- key = {0} --", key);
                Write(showElement(elem));
            }
        }

        public string showElement(DBElement1<int, string> elem)
        {
            StringBuilder accum = new StringBuilder();
            accum.Append(showMetaData(elem));
            if (elem.payload != null)
            {
                accum.Append(String.Format("\n  payload: {0}", elem.payload.ToString()));
            }
            return accum.ToString();
        }

        public string showMetaData(DBElement1<int, string> elem)
        {
            StringBuilder accum = new StringBuilder();
            accum.Append(String.Format("\n  name: {0}", elem.name));
            accum.Append(String.Format("\n  desc: {0}", elem.descr));
            accum.Append(String.Format("\n  time: {0}", elem.timeStamp));
            if (elem.children.Count() > 0)
            {
                accum.Append(String.Format("\n  Children: "));
                bool first = true;
                foreach (int key in elem.children)
                {
                    if (first)
                    {
                        accum.Append(String.Format("{0}", key.ToString()));
                        first = false;
                    }
                    else
                        accum.Append(String.Format(", {0}", key.ToString()));
                }
            }
            if (elem.category.Count() > 0)
            {
                accum.Append(String.Format("\n  Category: "));
                bool first = true;
                foreach (int key in elem.category)
                {
                    if (first)
                    {
                        accum.Append(String.Format("{0}", key.ToString()));
                        first = false;
                    }
                    else
                        accum.Append(String.Format(", {0}", key.ToString()));
                }
            }
            return accum.ToString();
        }

        public IEnumerable<int> Keys()
        {
            return dbStore.Keys;
        }

        //helper function for showDBbyCategory
        public void queryByCategory(int category, DBEngine1<DBElement1<int, string>> db)
        {
            List<int> foundKeys = new List<int>();
            IEnumerable<int> keys = db.Keys();
            foreach (int key in keys)
            {
                DBElement1<int, string> elem = new DBElement1<int, string>();

                db.getValue(key, out elem);

                if (elem.category.Contains(category))
                {
                    foundKeys.Add(key);
                }
            }
            foreach (int key1 in foundKeys)
            {
                Console.WriteLine("Key={0}", key1);
                DBElement1<int, string> elem = new DBElement1<int, string>();
                db.getValue(key1, out elem);
                Console.WriteLine("Name: {0}", elem.name);                      // Printing DB contents grouped by category
                Console.WriteLine("Description ={0}", elem.descr);
                Console.WriteLine("timeStamp : {0}", elem.timeStamp);
                Console.Write("Children:");
                foreach (int child in elem.children)
                    Console.Write("{0} ", child);
                //WriteLine();
                Console.WriteLine("Payload : {0}", elem.payload);
                WriteLine();

            }
        }

        public void showDBbyCategory(DBEngine1<DBElement1<int, string>> db)
        {
            List<int> cats = new List<int>();
            List<int> foundKeys = new List<int>();
            IEnumerable<int> keys = db.Keys();
            foreach (int key in keys)
            {
                DBElement1<int, string> elem = new DBElement1<int, string>();

                db.getValue(key, out elem);

                foreach (int cat in elem.category)
                {
                    if (cats.Contains(cat))                             // Skip for repeated categories
                    { continue; }
                    WriteLine("\nCategory = {0}", cat);
                    WriteLine("- - - - - - ");
                    queryByCategory(cat, db);                       // Querying DB by category
                    cats.Add(cat);

                }

            }

        }

    }

    public class DBElement1<Key, Data>
    {
        public string name { get; set; }          // metadata    |
        public string descr { get; set; }         // metadata    |
        public DateTime timeStamp { get; set; }   // metadata   value
        public List<Key> children { get; set; }   // metadata    |
        public Data payload { get; set; }         // data        |
        public List<int> category { get; set; }

        public DBElement1(string Name = "unnamed", string Descr = "undescribed")
        {
            name = Name;
            descr = Descr;
            timeStamp = DateTime.Now;
            children = new List<Key>();
            category = new List<int>();
        }
    }
}
