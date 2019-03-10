using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.Models;

using Newtonsoft.Json;

namespace Web_API.Controllers
{
    public class GetItemController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetItem(VoteItem voteItem)
        {

            VoteItem vI = new VoteItem();
            SqlConnection sqlConnect = new SqlConnection();

            sqlConnect.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS-PC\Desktop\D-lyw\webApi-vuejs\Web-API\App_Data\webApplicationDev.mdf;Integrated Security=True";
            try
            {
                sqlConnect.Open();
                string findSql = "select * from votelist where ItemId = '"+voteItem.ItemId+"';";
                SqlCommand findCmd = new SqlCommand(findSql, sqlConnect);

                SqlDataReader dr = findCmd.ExecuteReader();
                while (dr.Read())
                {
                    vI.ItemId = Int32.Parse(dr[0].ToString().Trim());
                    vI.Title = dr[1].ToString().Trim();
                    vI.Statue = Int32.Parse(dr[2].ToString().Trim());
                    vI.Items = new string[6];
                    vI.ItemsNum = new int[6];
                }
                sqlConnect.Close();

                sqlConnect.Open();
                SqlCommand cmd2 = new SqlCommand("select * from itemdetails where ItemId = '"+ voteItem.ItemId +"';", sqlConnect);
                SqlDataReader dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    vI.ItemCountNum = vI.ItemCountNum == 0 ? 1 : vI.ItemCountNum + 1;
                    vI.Items[vI.ItemCountNum - 1] = dr2[2].ToString().Trim();
                    vI.ItemsNum[vI.ItemCountNum - 1] = Int32.Parse(dr2[3].ToString().Trim());
                }
                sqlConnect.Close();
                string strJson = JsonConvert.SerializeObject(vI);
                //string strJson = ObjToJson1<VoteItem>(vI);
                return new HttpResponseMessage { Content = new StringContent(strJson, System.Text.Encoding.UTF8, "application/json") };

            }
            catch
            {
                string msg = "err";
                return new HttpResponseMessage { Content = new StringContent(msg, System.Text.Encoding.UTF8, "application/json") };
            }



            
        }

        
    }
}
