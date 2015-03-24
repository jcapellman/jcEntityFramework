using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace jcEntityFramework {
    public class Factory : IDisposable {
        private readonly string _connectionString;

        private SqlConnection _sqlConnection;

        public Factory() {
            if (ConfigurationManager.ConnectionStrings["jcEF_ConnectionString"] == null) {
                throw new Exception("Could not get the connection string from the config");
            }

            _connectionString = ConfigurationManager.ConnectionStrings["jcEF_ConnectionString"].ConnectionString;
        }

        public Factory(string connectionString) { _connectionString = connectionString; }

        public void Execute<T>(T request) where T : jcEntityFrameworkRequestObject {
            openSqlConnection();

            request.ToSqlCommand(_sqlConnection).ExecuteNonQuery();

            closeSqlConnection();
        }

        public List<K> Execute<T, K>(T request) where T : jcEntityFrameworkRequestObject where K : jcEntityFrameworkResponseObject {
            openSqlConnection();

            var list = new List<K>();

            K obj = default(K);

            using (var dr = request.ToSqlCommand(_sqlConnection).ExecuteReader()) {
                while (dr.Read()) {
                    obj = Activator.CreateInstance<K>();

                    foreach (PropertyInfo prop in obj.GetType().GetProperties()) {
                        if (!object.Equals(dr[prop.Name], DBNull.Value)) {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }

                    list.Add(obj);
                }
            }

            closeSqlConnection();

            return list;
        }

        private void openSqlConnection() {
            try {
                _sqlConnection = new SqlConnection(_connectionString);

                _sqlConnection.Open();
            } catch (Exception) {
                throw new Exception(String.Format("Could not open database {0}", _connectionString));
            }
        }

        private void closeSqlConnection() {
            if (_sqlConnection.State != ConnectionState.Closed) {
                _sqlConnection.Close();
            }
        }

        public K Get<T, K>(T request) where T : jcEntityFrameworkRequestObject where K : jcEntityFrameworkResponseObject {
            openSqlConnection();

            var returnObject = (K)Activator.CreateInstance(typeof(K));
       
            using (var reader = request.ToSqlCommand(_sqlConnection).ExecuteReader()) {                
                while (reader.Read()) {
                    
                }
            }

            closeSqlConnection();

            return returnObject;
        }

        public void Dispose() { closeSqlConnection(); }
    }
}
