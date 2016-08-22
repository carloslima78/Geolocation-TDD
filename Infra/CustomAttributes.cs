using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomAttributes : System.Attribute
    {
        public bool NoMapp { get; set; }

        public CustomAttributes()
        { }

        public CustomAttributes(bool noMapp)
        {
            this.NoMapp = noMapp;
        }
    }
}

