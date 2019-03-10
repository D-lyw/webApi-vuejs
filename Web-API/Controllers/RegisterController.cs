using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class RegisterController : ApiController
    {
        // GET: api/Register
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Register/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Register
        public string Post([FromBody]User user)
        {
            SqlConnection sqlConnect = new SqlConnection();

            sqlConnect.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS-PC\Desktop\D-lyw\webApi-vuejs\Web-API\App_Data\webApplicationDev.mdf;Integrated Security=True";

            try
            {
                sqlConnect.Open();

                SqlCommand cmd = new SqlCommand("insert into UserInfo(username, password) values ('" + user.UserName + "', '" + user.PassWord+ "')", sqlConnect);
                int dr = cmd.ExecuteNonQuery();

                return JsonConvert.SerializeObject(dr);
            }
            catch
            {
                Console.WriteLine("connect error!!!!!!!!!");
                string errMsg = "select data error!";
                return JsonConvert.SerializeObject(errMsg);
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        // PUT: api/Register/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Register/5
        public void Delete(int id)
        {
        }
    }
}
