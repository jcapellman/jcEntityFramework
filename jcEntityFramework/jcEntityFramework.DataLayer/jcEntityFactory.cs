using System.Collections.Generic;
using jcEntityFramework.Test.DBO;

namespace jcEntityFramework.DataLayer {
    public class jcEntityFactory : Factory {
        public void JCEF_ExecuteTestSP()
        {
            Execute(new Test.DBO.JCEFExecuteTestSP());
        }

        public List<JCEFSelectTestSP_ReturnResult> JCEFSelectTestSP() { return Execute<JCEFSelectTestSP, JCEFSelectTestSP_ReturnResult>(new JCEFSelectTestSP()); } 
    }
}
