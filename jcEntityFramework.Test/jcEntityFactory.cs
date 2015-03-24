using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jcEntityFramework.Test.DBO;

namespace jcEntityFramework.Test {
    internal class jcEntityFactory : Factory {
        public void JCEF_ExecuteTestSP()
        {
            Execute(new DBO.JCEFExecuteTestSP());
        }

        public List<JCEFSelectTestSP_ReturnResult> JCEFSelectTestSP() { return Execute<JCEFSelectTestSP, JCEFSelectTestSP_ReturnResult>(new JCEFSelectTestSP()); } 
    }
}
