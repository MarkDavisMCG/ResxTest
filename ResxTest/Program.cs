using System;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.Loader;

namespace ResxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: resxtest [c|i]");
                return;
            }

            bool isCwqi = string.Compare(args[0], "c", true) == 0;

            string executableLocation = AppContext.BaseDirectory;
            string resourceName = isCwqi ? "CWQIResources" : "IndiciaResources";
            string assemblyPath = Path.Combine(executableLocation, $"{resourceName}.dll");
            AssemblyName assemblyName = AssemblyLoadContext.GetAssemblyName(assemblyPath);
            Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);

            ResourceManager resourceManager = new ResourceManager($"{resourceName}.Resources", assembly);
            string text = resourceManager.GetString("Application.Title");
            
            Console.WriteLine($"Hello {text}!");
        }
    }
}
