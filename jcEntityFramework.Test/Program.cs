using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using jcEntityFramework.DataLayer;
using jcEntityFramework.DataLayer.EF;
using jcEntityFramework.PCL;

namespace jcEntityFramework.Test {
    class Program {
        static double jcEFsingleInsertOnly()
        {
            DateTime start = DateTime.Now;

            var jFactory = new jcEntityFactory();

            jFactory.JCEF_ExecuteTestSP();

            return DateTime.Now.Subtract(start).TotalSeconds;
        }

        static double jcEFvariantInsertOnly(int numberIterations)
        {
            DateTime start = DateTime.Now;

            var jFactory = new jcEntityFactory();
            jFactory.JCEF_ExecuteTestSP();
            //  var total = 0.0;

            //  for (int x = 0; x < numberIterations; x++) {
            //jFactory.JCEF_ExecuteTestSP();
         //   }

            return DateTime.Now.Subtract(start).TotalSeconds;
        }

        static double msEFvariantInsertOnly(int numberIterations) {
            DateTime start = DateTime.Now;

            var eFactory = new XMS_ColaEntities();

          
                 eFactory.JCEFExecuteTestSP();

            return DateTime.Now.Subtract(start).TotalSeconds;

        }

        static void InsertOnlyTests()
        {
            Console.WriteLine("jcEntityFramework:");

            jcEFvariantInsertOnly(1);

            jcEFvariantInsertOnly(10);

            jcEFvariantInsertOnly(100);

            jcEFvariantInsertOnly(1000);

            Console.WriteLine("");

            Console.WriteLine("Microsoft EntityFramework:");

            msEFvariantInsertOnly(1);

            msEFvariantInsertOnly(10);

            msEFvariantInsertOnly(100);

            msEFvariantInsertOnly(1000);
        }

        static double jcEFSelectRows()
        {
            DateTime start = DateTime.Now;

            var jFactory = new jcEntityFactory();

            var list = jFactory.JCEFSelectTestSP();

            return DateTime.Now.Subtract(start).TotalSeconds;
        }

        static double efSelectRows()
        {
            DateTime start = DateTime.Now;

            var eFactory = new XMS_ColaEntities();

            var list = eFactory.JCEFSelectTestSP();

            return DateTime.Now.Subtract(start).TotalSeconds;
        }

        static void SelectOnlyTests() {
            Console.WriteLine("jcEntityFramework:");

            jcEFSelectRows();

            Console.WriteLine("");

            Console.WriteLine("Microsoft EntityFramework:");

            efSelectRows();
        }

        static double jcEFSelectRowsWebAPI() {
            DateTime start = DateTime.Now;

            var ht = new HandlerTest("http://localhost/api/");

            var list = ht.Get(false);

            return DateTime.Now.Subtract(start).TotalSeconds;
        }

        static double msEFSelectRowsWebAPI() {
            DateTime start = DateTime.Now;

            var ht = new HandlerTest("http://localhost/api/");

            var list = ht.Get(true);

            return DateTime.Now.Subtract(start).TotalSeconds;
        }

        static void SelectOnlyTestsWebAPI() {
            Console.WriteLine("jcEntityFramework:");

            Console.WriteLine("{0} seconds", jcEFSelectRowsWebAPI());

            Console.WriteLine("");

            Console.WriteLine("Microsoft EntityFramework:");

            Console.WriteLine("{0} seconds", msEFSelectRowsWebAPI());
        }

        static void Main(string[] args)
        {
            Thread.Sleep(2000);

            Console.WriteLine("Console App Tests");
            Console.WriteLine("");

             int iterations = Convert.ToInt32(args[0]);

            var total = 0.0;

            for (int x = 1; x <= iterations; x++) {
                total += jcEFvariantInsertOnly(x * 10);
            }

            Console.WriteLine(String.Format("JC EF {0} Iterations with average of {1}", iterations, total / iterations));

            total = 0.0;

            for (int x = 1; x <= iterations; x++) {
                total += msEFvariantInsertOnly(x * 10);
            }

            Console.WriteLine(String.Format("MS EF {0} Iterations with average of {1}", iterations, total / iterations));

            Console.WriteLine("");
            Console.WriteLine("WebAPI Tests");
            Console.WriteLine("");

            jcEFSelectRowsWebAPI();
            jcEFSelectRowsWebAPI();

            total = 0.0;

            for (int x = 1; x <= 10; x++) {
                total += jcEFSelectRowsWebAPI();
            }

            Console.WriteLine(String.Format("JC EF {0} Iterations with average of {1}", iterations, total / iterations));

            total = 0.0;

            for (int x = 1; x <= 10; x++) {
                total += msEFSelectRowsWebAPI();
            }

            Console.WriteLine(String.Format("MS EF {0} Iterations with average of {1}", iterations, total / iterations));

        }
    }
}
