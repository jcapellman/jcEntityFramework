using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcEntityFramework.Test.DBO {
    public class JCEFSelectTestSP_ReturnResult : jcEntityFrameworkResponseObject {
        public int ID { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }

        public bool Active { get; set; }

        public string StoredProcedure { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 

        public bool Enabled { get; set; }

        public int XMS_ModuleID { get; set; }
    }
}
