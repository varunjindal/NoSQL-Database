///////////////////////////////////////////////////////////////
// Scheduler.cs - Test Requirements for Project #2            //
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
 * This package implements scheduled "save" process after every 1 second
 and will continue until cancelled
 */
/*
 * Maintenance:
 * ------------
 * Required Files: 
 * DBElement.cs, DBEngine.cs, Display.cs, PersistEngine.cs 
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
using System.Timers;

namespace Project2Starter
{
#if (TEST_SCHEDULER)
    class TestScheduler
    {
        static void Main(string[] args)
        {
            "Testing Scheduler package".title();
            //Loading DB for testing
            DBEngine<string, DBElement<string, List<string>>> dbString = new DBEngine<string, DBElement<string, List<string>>>();
            DBElement<string, List<String>> elemString = new DBElement<string, List<String>>();
            elemString.name = "Element2";
            elemString.descr = "testelement2";
            elemString.timeStamp = DateTime.Now;
            elemString.children.AddRange(new List<string> { "SMA1", "Syracuse2", "NY3" });
            elemString.payload = new List<string>();
            elemString.payload.AddRange(new List<string> { "we", "rock", "the ", "world" });

            dbString.insert("Prohject2", elemString);

            DBElement<string, List<String>> elemString2 = new DBElement<string, List<String>>();
            elemString2.name = "Element3";
            elemString2.descr = "test element3";
            elemString2.timeStamp = DateTime.Now;
            elemString2.children.AddRange(new List<string> { "SMA2", "Syracuse22", "NY33" });
            elemString2.payload = new List<string>();
            elemString2.payload.AddRange(new List<string> { "Thug", "Life" });
            
            dbString.insert("Thug3", elemString2);

            Scheduler<string> sch = new Scheduler<string>();
            sch.scheduledSave(dbString);

        }
    }
#endif

    public class Scheduler<Key>
    {
        private PersistEngine<Key> PE = new PersistEngine<Key>();
        private Timer scheduler { get; set; } = new Timer();

        public void scheduledSave(DBEngine<Key, DBElement<Key, List<string>>> db)
        {
            //Setting scheduler parameters
            scheduler.Interval = 1000;
            scheduler.AutoReset = true;
            scheduler.Elapsed += (object source, ElapsedEventArgs e) =>
            {
                Console.WriteLine("\nScheduled Save started at {0}", e.SignalTime);
                PE.createXML(db);       //Calling persist engine to create a XML
            };
            scheduler.Enabled = true;
            Console.ReadKey();
            Console.Write("Persisted database into XML -----\n\n");
            Console.WriteLine("\nXML Saved @/bin/Debug");
            Console.WriteLine("\nPlease open the XML file in the specified path to see the contents\n\n");
            Console.WriteLine();
            
        }
        
    }


}
