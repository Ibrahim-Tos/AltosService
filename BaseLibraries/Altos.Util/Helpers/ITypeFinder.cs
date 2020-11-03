using System;
using System.Collections.Generic;
using System.Reflection;
using Altos.Util.Dependency;

namespace Altos.Util.Helpers
{
    public interface ITypeFinder : ISingletonDependency
    {
        Type[] Find(Func<Type, bool> predicate);
        Type[] FindAll();
        IEnumerable<Assembly> GetAssemblies();
    }
}
