using AutoMapper;
using System;
using System.Linq;
using Altos.Util.Helpers;

namespace Altos.Util.Dependency
{
    public class AutoMapperDynamicMapProfile : Profile
    {
        private readonly ITypeFinder _typeFinder = null;

        public AutoMapperDynamicMapProfile(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;

            CreateDynamicMaps();
        }

        private void CreateDynamicMaps()
        {
            var attrType = typeof(AutoMapAttribute);
            var automappedTypes = _typeFinder.Find((x) => x.IsDefined(attrType, false));
            foreach (var t1 in automappedTypes)
            {
                var attributes = t1.CustomAttributes.Where(r => r.AttributeType == attrType);
                foreach (var attribute in attributes)
                {
                    var parameterType = attribute.ConstructorArguments[0].Value;
                    var t2 = (parameterType as Type);
                    if (t2 != null)
                    {
                        CreateMap(t1, t2); //regular mapping
                        CreateMap(t2, t1); //reverse mapping (allows to and from configured type)
                    }
                }
            }
        }
    }   
}
