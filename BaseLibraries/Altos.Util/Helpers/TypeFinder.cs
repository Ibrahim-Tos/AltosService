using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Altos.Util.Extensions;

namespace Altos.Util.Helpers
{
    /// <summary>
    /// Provides helper methods for scanning assemblies/types.
    /// </summary>
    public class TypeFinder : ITypeFinder
    {
        private Assembly[] _assemblies;
        private Type[] _types;

        private readonly object _typeLoadSyncObj = new object();
        private readonly object _assemblyLoadSyncObj = new object();

        private static string[] _excludedAssemblyNames = new string[] {
            "Microsoft.VisualStudio.TraceDataCollector",
            "System.Threading.AccessControl",
            "System.Runtime.Remoting",
            "System.Runtime.Remoting",
            "System.Windows.Forms",
            "System.Diagnostics.PerformanceCounter"
        };

        public Type[] Find(Func<Type, bool> predicate)
        {
            return GetAllTypes().Where(predicate).ToArray();
        }

        public Type[] FindAll()
        {
            return GetAllTypes().ToArray();
        }

        public IEnumerable<Assembly> GetAssemblies()
        {
            if (_assemblies == null)
            {
                lock (_assemblyLoadSyncObj)
                {
                    if (_assemblies == null)
                    {
                        var assembliesToScan = new List<Assembly>();
                        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => !_excludedAssemblyNames.Any(z => x.FullName.Contains(z)));
                        assembliesToScan.AddRange(assemblies);
                        var moreAssemblies = assemblies.SelectMany(x => x.GetReferencedAssemblies().Where(x => !_excludedAssemblyNames.Any(z => x.FullName.Contains(z))).Select(z => Assembly.Load(z.Name)));
                        assembliesToScan.AddRange(moreAssemblies);
                        assembliesToScan = assembliesToScan.Where(x => !_excludedAssemblyNames.Any(z => x.FullName.Contains(z))).ToList();

                        _assemblies = assembliesToScan.Distinct().ToArray();
                    }
                }
            }

            return _assemblies;
        }

        private Type[] GetAllTypes()
        {
            if (_types == null)
            {
                lock (_typeLoadSyncObj)
                {
                    if (_types == null)
                    {
                        _types = CreateTypeList().ToArray();
                    }
                }
            }

            return _types;
        }

        private List<Type> CreateTypeList()
        {
            var allTypes = new List<Type>();
            var assemblies = GetAssemblies();
            foreach (var assembly in assemblies)
            {
                Type[] typesInThisAssembly;

                try
                {
                    typesInThisAssembly = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException ex)
                {
                    typesInThisAssembly = ex.Types;
                }

                if (typesInThisAssembly.IsNullOrEmpty())
                {
                    continue;
                }

                allTypes.AddRange(typesInThisAssembly.Where(type => type != null));
            }

            return allTypes;
        }
    }
}
