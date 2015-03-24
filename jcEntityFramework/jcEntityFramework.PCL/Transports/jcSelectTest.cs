using System;

namespace jcEntityFramework.PCL.Transports {
    public class jcSelectTest {
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