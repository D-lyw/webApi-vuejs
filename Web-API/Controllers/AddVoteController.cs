using System;
using System.Collections.Generic;
using System.Data;
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
    public class AddVoteController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage AddVoteItem(VoteItem voteItem)
        {
            string retMsg;
            SqlConnection sqlConnect = new SqlConnection();

            sqlConnect.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS-PC\Desktop\D-lyw\webApi-vuejs\Web-API\App_Data\webApplicationDev.mdf;Integrated Security=True";
            try
            {
                sqlConnect.Open();
                //string sql = @"INSERT into votelist (title, Statue, Username, StopTime) values (@title, @Statue, @Username, @StopTime); select @ItemId=@@IDENTITY;";
                /*SqlParameter[] para = {
                    new SqlParameter("@title", SqlDbType.NVarChar, 50),
                    new SqlParameter("@Statue", SqlDbType.Int),
                    new SqlParameter("@Username", SqlDbType.NVarChar, 50),
                    new SqlParameter("@StopTime", SqlDbType.NVarChar, 50),
                    new SqlParameter("@ItemId", SqlDbType.Int)

                para[0].Value = voteItem.Title;
                para[1].Value = voteItem.Statue;
                para[2].Value = voteItem.UserName;
                para[3].Value = voteItem.StopTime;
                para[4].Direction = ParameterDirection.Output;
                DbHelperSQL
                DBHelper.ExecuteNonData(sql, para);
                };*/
                string addcmd = "INSERT into votelist (title, Statue, Username, StopTime) values (N'" + voteItem.Title + "','" +voteItem.Statue+ "',N'"+ voteItem.UserName+"','" +voteItem.StopTime + "') ";

                //string getId = "select @@IDENTITY";
                //SqlCommand cmdId = new SqlCommand(getId, sqlConnect);
                SqlCommand cmdAdd = new SqlCommand(addcmd, sqlConnect);
                int line;
                line = cmdAdd.ExecuteNonQuery();
                //int id = (Int32)cmdId.ExecuteScalar();
                if(line == 1)
                {
                    string itemid = "select max(ItemId) from votelist;";
                    SqlCommand getId = new SqlCommand(itemid, sqlConnect);
                    int id = (Int32)getId.ExecuteScalar();

                    string insertStr = "";
                    for(int i = 0; i < voteItem.ItemsNum.Length; i++)
                    {
                        insertStr += "insert into itemdetails(ItemId, ItemName, ItemNameNum) values ('" + id + "',N'" + voteItem.Items[i] + "','" + voteItem.ItemsNum[i] + "');";
                    }

                    SqlCommand insertDetail = new SqlCommand(insertStr, sqlConnect);
                    int result = insertDetail.ExecuteNonQuery();
                    retMsg = result.ToString();
                    return new HttpResponseMessage { Content = new StringContent(retMsg, System.Text.Encoding.UTF8, "application/json") };
                } else
                {
                    retMsg = "false";
                    return new HttpResponseMessage { Content = new StringContent(retMsg, System.Text.Encoding.UTF8, "application/json") };
                }
            }
            catch
            {
                retMsg = "server error";
                return new HttpResponseMessage { Content = new StringContent(retMsg, System.Text.Encoding.UTF8, "application/json") };
            }
            finally
            {
                sqlConnect.Close();
            }


            //return new HttpResponseMessage { Content = new StringContent(strJson, System.Text.Encoding.UTF8, "application/json") };
        }

        [NonAction]
        public static string ObjToJson<T>(VoteItem data)
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
