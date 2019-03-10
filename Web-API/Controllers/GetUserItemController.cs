using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class GetUserItemController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetUserItem(User user)
        {

            List<VoteItem> data = new List<VoteItem>();

            SqlConnection sqlConnect = new SqlConnection();

            sqlConnect.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS-PC\Desktop\D-lyw\webApi-vuejs\Web-API\App_Data\webApplicationDev.mdf;Integrated Security=True";
            try
            {
                sqlConnect.Open();
                SqlCommand cmd1 = new SqlCommand("Select * FROM votelist where Username = '" + user.UserName + "';", sqlConnect);
                SqlDataReader dr = cmd1.ExecuteReader();


                int count = 0;
                // 遍历投票信息
                while (dr.Read())
                {
                    VoteItem voteItem = new VoteItem();

                    voteItem.ItemId = Int32.Parse(dr[0].ToString().Trim());
                    voteItem.Title = dr[1].ToString().Trim();
                    voteItem.Statue = Int32.Parse(dr[2].ToString().Trim());
                    voteItem.Items = new string[6];
                    voteItem.ItemsNum = new int[6];
                    //voteItem.ItemCountNum = Int32.Parse(dr[5].ToString().Trim());

                    data.Add(voteItem);
                    count++;
                }
                sqlConnect.Close();

                sqlConnect.Open();
                SqlCommand cmd2 = new SqlCommand("select * from itemdetails;", sqlConnect);
                SqlDataReader dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    int itemId = Int32.Parse(dr2[1].ToString().Trim());
                    for (int i = 0; i < count; i++)
                    {
                        if (itemId == data[i].ItemId)
                        {
                            data[i].ItemCountNum = data[i].ItemCountNum == 0 ? 1 : data[i].ItemCountNum + 1;
                            data[i].Items[data[i].ItemCountNum - 1] = dr2[2].ToString().Trim();
                            data[i].ItemsNum[data[i].ItemCountNum - 1] = Int32.Parse(dr2[3].ToString().Trim());
                        }
                        else
                        {
                            data[i].ItemsNum[i] = i;
                        }
                    }
                }
                sqlConnect.Close();

                string strJson = ObjToJson<List<VoteItem>>(data);
                return new HttpResponseMessage { Content = new StringContent(strJson, System.Text.Encoding.UTF8, "application/json") };
            }
            catch
            {
                Console.WriteLine("connect error!!!!!!!!!");
                //string errMsg = "select data error!";
                //return JsonConvert.SerializeObject(errMsg);
                string json = "{\"result\":\"false\"}";
                return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
            }

        }

        /*public void GetDetai()
        {
            SqlConnection sqlConnect2 = new SqlConnection();

            sqlConnect2.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS-PC\Desktop\D-lyw\webApi-vuejs\Web-API\App_Data\webApplicationDev.mdf;Integrated Security=True";

            try
            {
               sqlConnect2.Open();
               SqlCommand cmd2 = new SqlCommand("select * from itemdetails;", sqlConnect);
               SqlDataReader dr2 = cmd2.ExecuteReader();

               while (dr2.Read())
               {
                   int itemId = Int32.Parse(dr2[1].ToString().Trim());
                   for (int i =0; i < count; i++)
                   {
                       if (itemId == data[i].ItemId)
                       {
                           data[i].Items[i] = dr2[2].ToString().Trim();
                           data[i].ItemsNum[i] = Int32.Parse(dr2[3].ToString().Trim());
                       }
                   }
               }
               sqlConnect2.Close();

            }
        }*/

        [NonAction]
        public static string ObjToJson<T>(T data)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, data);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
