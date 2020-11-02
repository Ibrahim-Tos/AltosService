using System;

namespace Altos.Api.Framework.Infrastructure.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PermissionPolicyAttribute : Attribute
    {
        public Type PolicyClass { get; }

        public PermissionPolicyAttribute(Type policyClass)
        {
            // Something like this, will only give runtime error... and/or we need to make a reflection test...
            if (!typeof(IPermissionPolicy).IsAssignableFrom(policyClass))
            {
                throw new ArgumentException("The type must implement IPermissionPolicy");
            }

            this.PolicyClass = policyClass;
        }
    }
}
