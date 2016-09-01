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
 *  creation of a new immutable database constructed from the
 * result of any query that returns a collection of keys
 */
/*
 * Maintenance:
 * ------------
 * Required Files: 
 * DBElement.cs, DBEngine
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
#if (TEST_DB_FACTORY)
    class TestDBFactory
    {
        static void Main(string[] args)
        {
            
            DBEngine<int, DBElement<int, string>> db = new DBEngine<int, DBElement<int, string>>();
            DBElement<int, string> elem = new DBElement<int, string>();                               //Populating DBEngine
            elem.name = "Element2";                                                                  //object db
            elem.descr = "test element2";                                                            //for testing data int and string type.
            elem.timeStamp = DateTime.Now;
            elem.children.AddRange(new List<int> { });
            elem.payload = "Varun";
            db.insert(1, elem);
            DBElement<int, string> elem1 = new DBElement<int, string>();                            //Populating DBEngine
            elem1.name = "Key/Value pair to be edited";                                             //object db
            elem1.descr = "test element3";                                                          //for testing data int and string type.
            elem1.timeStamp = DateTime.Now;
            elem1.children.AddRange(new List<int> { 4, 5, 6 });
            elem1.payload = "EDIT !";
            db.insert(2, elem1);
            DBFactory<int, DBElement<int, string>> dff = new DBFactory<int, DBElement<int, string>>(db);

            dff.getValue(1, out elem1);
            Console.WriteLine(elem1.name);

        }
    }
#endif

    public class DBFactory<Key,Value>
    {
        private Dictionary<Key, Value> dbStore;
        public DBFactory(DBEngine<Key, Value> dbImmut)
        {
            dbStore = new Dictionary<Key, Value>();
            Value value;
            foreach (Key key in dbImmut.Keys()) {
                dbImmut.getValue(key, out value);
                if (!dbStore.Keys.Contains(key))
                    dbStore[key] = value;
            }

        }
        
        public bool getValue(Key key, out Value val)
        {
            if (dbStore.Keys.Contains(key))
            {
                val = dbStore[key];
                return true;
            }
            val = default(Value);
            return false;
        }
        public IEnumerable<Key> Keys()
        {
            return dbStore.Keys;
        }
    }
}
