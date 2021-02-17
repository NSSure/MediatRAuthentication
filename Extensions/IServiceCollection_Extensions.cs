using AttributeInjection.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollection_Extensions
    {
        public static void AddPermissions<TAttribute>() where TAttribute : Attribute
        {
            foreach (Type type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()))
            {
                RestrictedAttribute _restrictedAttribute = type.GetCustomAttribute(typeof(RestrictedAttribute));
            }
        }
    }
}
