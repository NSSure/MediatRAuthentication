using System;
using System.Collections.Generic;
using System.Linq;

namespace AttributeInjection.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RestrictedAttribute : Attribute
    {
        public Guid ID = Guid.NewGuid();

        public List<string> Permissions = new List<string>();

        private readonly HttpContextFactory _authenticationFactory;

        public RestrictedAttribute(params string[] permissions)
        {
            this.Permissions = permissions.ToList();
        }
    }
}
