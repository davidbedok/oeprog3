using System;
using System.Reflection;
using ComplexNumbers;
using WhatsNewAttributes;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            Console.WriteLine("Az alaposzt�ly met�dusai");
            TestComplexClass();

            Console.WriteLine("\nFut�si idej� attrib�tumok");
            TestCustomAttributes("ComplexNumbers");
        }

        private static void TestComplexClass()
        {
            Complex cplx = new Complex(1.0, -1.1);
            cplx.Imaginary += 2;
            Console.WriteLine(cplx);

            cplx = 4;
            cplx.Imaginary -= 0.15;
            Console.WriteLine(cplx);

            cplx.Imaginary += 0.15;
            Console.WriteLine(cplx == 4);

            double d = (double) cplx;
            Console.WriteLine(d);

            /*
            P�lda: Fut�si idej� hib�t okoz� explicit t�pus�talak�t�s (az imagin�rius r�sz nem 0.0)
            cplx.Imaginary += 3;
            d = (double) cplx;
            Console.WriteLine(d);
            */

            Complex cplx2 = new Complex(2.4, 3.5);
            Console.WriteLine(cplx + cplx2);
        }

        private static void TestCustomAttributes(string assemblyFileName)
        {
            Assembly assembly = Assembly.Load(assemblyFileName);
            Attribute supportsWhatsNew = Attribute.GetCustomAttribute(assembly, typeof(SupportsWhatsNewAttribute));
            if (supportsWhatsNew != null)
            {
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    Console.WriteLine("{0} oszt�ly m�dos�t�sai:", type.Name);
                    object[] classAttributes = type.GetCustomAttributes(typeof(LastModifiedAttribute), false);
                    foreach (LastModifiedAttribute attribute in classAttributes)
                        Console.WriteLine(String.Format("{0} ({1})", attribute.DateModified, attribute.Changes));

                    Console.WriteLine();
                    Console.WriteLine("{0} oszt�ly met�dusainak m�dos�t�sai:", type.Name);
                    MethodInfo[] methods = type.GetMethods();
                    foreach (MethodInfo method in methods)
                    {
                        object[] methodAttributes = method.GetCustomAttributes(typeof(LastModifiedAttribute), false);
                        foreach (LastModifiedAttribute attribute in methodAttributes)
                            Console.WriteLine(String.Format("{0}(): {1} ({2})", method.Name, attribute.DateModified, attribute.Changes));
                    }
                }
            }
        }
    }
}