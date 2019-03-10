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
    public class UpdateItemController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetItem(ItemDetail itemDetail)
        {
            SqlConnection sqlConnect = new SqlConnection();

            sqlConnect.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS-PC\Desktop\D-lyw\webApi-vuejs\Web-API\App_Data\webApplicationDev.mdf;Integrated Security=True";
            try
            {
                sqlConnect.Open();
                SqlCommand updateItem = new SqlCommand("update itemdetails set ItemNameNum = '" + itemDetail.ItemNameNum + "' where ItemId = '" + itemDetail.ItemId + "' AND ItemName = N'" + itemDetail.ItemName + "' ;", sqlConnect);
                int line = updateItem.ExecuteNonQuery();
                return new HttpResponseMessage { Content = new StringContent(line.ToString(), System.Text.Encoding.UTF8, "application/json") };
            }
            catch
            {
                int err = -1;
                return new HttpResponseMessage { Content = new StringContent(err.ToString(), System.Text.Encoding.UTF8, "application/json") };
            }
            finally
            {
                sqlConnect.Close();
            }
        }
    }
}
