using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class InsertController : ApiController
    {
        // GET: api/Insert
        public IEnumerable<string> Get()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["kitacolle"].ConnectionString;

            int id = 0;
            float ondo = 0;

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                var aa = connection.Database;
                DataTable bb = connection.GetSchema("Tables");
                

                var command = new SqlCommand();
                command.CommandText = "SELECT * FROM dbo.Kitacolle WHERE 30<Ondo";
                command.Connection = connection;

                //var reader2 = command.ExecuteReader();
                var reader = command.ExecuteReader();

                Thread.Sleep(5000);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int kari1 = reader.GetInt32(0);
                        var temp = reader.GetValue(1);
                        var kari2 = float.Parse(temp.ToString());
                        Debug.Print("{0} {1}", kari1, kari2);
                        id = kari1;
                        ondo = kari2;
                    }
                }

                Debug.WriteLine("State: {0}", connection.State);
                Debug.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }
            
            return new string[] { id.ToString(),ondo.ToString() };
        }

        // GET: api/Insert/5
        public string Get(int id)
        {
            return "value";
        }
        /// <summary>
        /// データ読込リクエスト
        /// </summary>
        /// <param name="read">読込判定</param>
        /// <param name="ondo">検索温度</param>
        /// <param name="today">0:今日 1:明日</param>
        /// <returns></returns>
        public string Get(int read,int ondo,int today)
        {

            var connectionString = ConfigurationManager.ConnectionStrings["kitacolle"].ConnectionString;
            
            return "value2";

        }


        // POST: api/Insert
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Insert/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Insert/5
        public void Delete(int id)
        {
        }
    }
}
