using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }
        */

        
        // POST: api/Login
        public string  Post([FromBody]User user)
        {
            SqlConnection sqlConnect = new SqlConnection();

            sqlConnect.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS-PC\Desktop\D-lyw\webApi-vuejs\Web-API\App_Data\webApplicationDev.mdf;Integrated Security=True";

            try
            {
                sqlConnect.Open();
                
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM UserInfo where username = '"+ user.UserName + "' and password = '"+ user.PassWord+ "';", sqlConnect);
                int dr = (int)cmd.ExecuteScalar();

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

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
