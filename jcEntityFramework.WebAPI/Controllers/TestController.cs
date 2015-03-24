using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using jcEntityFramework.DataLayer;
using jcEntityFramework.DataLayer.EF;
using jcEntityFramework.PCL.Transports;

namespace jcEntityFramework.WebAPI.Controllers {
    public class TestController : ApiController {
        public List<jcSelectTest> GET(bool useEF)
        {
            List<jcSelectTest> list;

            if (useEF) {
                var eFactory = new XMS_ColaEntities();

                list = eFactory.JCEFSelectTestSP().ToList().Select(a => new jcSelectTest {Active = a.Active, Created = a.Created, Description = a.Description, Enabled = a.Enabled, ID = a.ID, Modified = a.Modified, Name = a.Name, StoredProcedure = a.StoredProcedure, XMS_ModuleID = a.XMS_ModuleID}).ToList();
            } else {
                var jFactory = new jcEntityFactory();

                list = jFactory.JCEFSelectTestSP().Select(a => new jcSelectTest { Active = a.Active, Created = a.Created, Description = a.Description, Enabled = a.Enabled, ID = a.ID, Modified = a.Modified, Name = a.Name, StoredProcedure = a.StoredProcedure, XMS_ModuleID = a.XMS_ModuleID}).ToList();
            }

            return list;
        } 
    }
}
