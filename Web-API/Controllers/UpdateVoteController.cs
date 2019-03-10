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
    public class UpdateVoteController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage UpdateVote(VoteItem voteItem)
        {
            SqlConnection sqlConnect = new SqlConnection();

            sqlConnect.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS-PC\Desktop\D-lyw\webApi-vuejs\Web-API\App_Data\webApplicationDev.mdf;Integrated Security=True";
            try
            {
                sqlConnect.Open();
                SqlCommand updateVote = new SqlCommand("update votelist set Statue = '" + voteItem.Statue + "' where ItemId = '" + voteItem.ItemId + "'", sqlConnect);
                int line = updateVote.ExecuteNonQuery();
                return new HttpResponseMessage { Content = new StringContent(line.ToString(), System.Text.Encoding.UTF8, "application/json") };
            }
            catch
            {
                int line = 0;
                return new HttpResponseMessage { Content = new StringContent(line.ToString(), System.Text.Encoding.UTF8, "application/json") };
            }
        }
    }
}
