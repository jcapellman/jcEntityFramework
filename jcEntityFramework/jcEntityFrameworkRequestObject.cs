using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcEntityFramework {
    public class jcEntityFrameworkRequestObject : jcEntityFrameworkObject {
        private List<jcEntityFrameworkParameter> parameters { get; set; }

        public jcEntityFrameworkRequestObject() {
            parameters = new List<jcEntityFrameworkParameter>();
        }

        public void AddParamater(string name, Type paramType, string val) { parameters.Add(new jcEntityFrameworkParameter(name, paramType, val)); }

        public SqlCommand ToSqlCommand(SqlConnection sqlConnection) {
            var sqlCommand = new SqlCommand(GetType().Name, sqlConnection) {CommandType = CommandType.StoredProcedure};

            foreach (var param in parameters) {
                sqlCommand.Parameters.AddWithValue("@" + param.Name, param.Val).Direction = System.Data.ParameterDirection.Input;;
            }

            return sqlCommand;
        }
    }
}
