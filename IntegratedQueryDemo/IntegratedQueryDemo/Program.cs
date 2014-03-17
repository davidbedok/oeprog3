using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace IntegratedQueryDemo
{
    public class Program
    {

        private static void Main(string[] args)
        {
            Program.testSchool();
            Program.testXml();

            Console.ReadKey();
        }

        private static void testSchool()
        {
            SchoolTest schoolTest = new SchoolTest();
            Console.WriteLine(schoolTest);
            Console.WriteLine(schoolTest.listStudentWithCertificate("PHP"));
            Console.WriteLine(schoolTest.listStudentWithSubject("Physics"));
            Console.WriteLine(schoolTest.listStudentWithInstructors(Instructor.Alice));
            Console.WriteLine(schoolTest.listStudentWithMinimumCredits(6));
        }

        private static void testXml()
        {
            XmlTest xmlTest = new XmlTest("http://nik.uni-obuda.hu/workers.php");
            Console.WriteLine(xmlTest.getNameByEmail("bkiss.judit@nik.uni-obuda.hu"));
            Console.WriteLine(xmlTest.getAnonymousClassByLimitAndDivider(150, 2));
        }

    }
}
