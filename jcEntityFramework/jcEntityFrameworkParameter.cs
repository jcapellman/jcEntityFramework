using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcEntityFramework {
    public class jcEntityFrameworkParameter {
        public Type ParamType { get; set; }

        public string Name { get; set; }

        public string Val { get; set; }
        public jcEntityFrameworkParameter() { }

        public jcEntityFrameworkParameter(string name, Type paramType, string val) {
            Name = name;
            ParamType = paramType;
            Val = val;
        }
    }
}
