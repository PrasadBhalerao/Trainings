using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using System.Threading;
using ExploreCalifornia.Processor.Contracts;

namespace ExploreCalifornia.Processor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press CTRL+C to exit");
            var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var pluginsPath = Path.Combine(currentPath, "plugins");
            if (!Directory.Exists(pluginsPath))
            {
                Directory.CreateDirectory(pluginsPath);
            }

            while (true)
            {
                try
                {
                    var possiblePluginPaths = Directory.EnumerateFiles(
                        pluginsPath, 
                        "*.dll", 
                        SearchOption.AllDirectories);

                    var possiblePluginAssemblies = 
                        possiblePluginPaths.Select(LoadAssembly);

                    var inputPlugins = GetPlugins<IInputPlugin>(
                        possiblePluginAssemblies)
                        .ToList();

                    if (!inputPlugins.Any())
                    {
                        Log("No plugins found");
                        continue;
                    }

                    var bookings = inputPlugins.SelectMany(
                        plugin => plugin.GetBookings());

                    Log($"Retrieved {bookings.Count()} bookings from {inputPlugins.Count} sources");
                }
                catch (Exception ex)
                {
                    Log(ex.ToString());
                }
                finally
                {
                    Thread.Sleep(2000);
                }
            }
        }

        static Assembly LoadAssembly(string assemblyLocation)
        {
            var loadContext = new PluginAssemblyLoadContext(assemblyLocation);
            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(assemblyLocation)));
        }

        private static IEnumerable<T> GetPlugins<T>(IEnumerable<Assembly> possiblePluginAssemblies)
        {
            var result = possiblePluginAssemblies.SelectMany(CreatePlugins<T>);
            return result;
        }

        static IEnumerable<T> CreatePlugins<T>(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (!typeof(T).IsAssignableFrom(type))
                {
                    continue;
                }

                Log($"Found plugin {type.Name}");
                if (Activator.CreateInstance(type) is T result)
                {
                    yield return result;
                }

            }
        }

        static void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now} - {message}");
        }
    }
}