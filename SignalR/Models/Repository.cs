using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SignalR.Models
{
    public class Repository
    {
        SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public List<Employee> GetAllMessages()
        {
            var messages = new List<Employee>();
            using (var cmd = new SqlCommand(@"SELECT [MaCK],  
                                           [GiaMua1],[SoLuongMua1],[GiaMua2],[SoLuongMua2],[GiaMua3],[SoLuongMua3],
                                            [GiaKhop],[SoLuongKhop],[GiaBan1],[SoLuongBan1],[GiaBan2],[SoLuongBan2],
                                            [GiaBan3],[SoLuongBan3],[TongSo] FROM [dbo].[BangGiaTrucTuyen]", con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                var dependency = new SqlDependency(cmd);
                dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                DataSet ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    messages.Add(item: new Employee
                    {
              
                        MaCK = ds.Tables[0].Rows[i][0].ToString(),
                        GiaMua1 = ds.Tables[0].Rows[i][1].ToString(),
                        SoLuongMua1 = ds.Tables[0].Rows[i][2].ToString(),
                        GiaMua2 = ds.Tables[0].Rows[i][3].ToString(),
                        SoLuongMua2 = ds.Tables[0].Rows[i][4].ToString(),
                        GiaMua3 = ds.Tables[0].Rows[i][5].ToString(),
                        SoLuongMua3 =ds.Tables[0].Rows[i][6].ToString(),
                        GiaKhop = ds.Tables[0].Rows[i][7].ToString(),
                        SoLuongKhop = ds.Tables[0].Rows[i][8].ToString(),
                        GiaBan1 = ds.Tables[0].Rows[i][9].ToString(),
                        SoLuongBan1 = ds.Tables[0].Rows[i][10].ToString(),
                        GiaBan2 = ds.Tables[0].Rows[i][11].ToString(),
                        SoLuongBan2 = ds.Tables[0].Rows[i][12].ToString(),
                        GiaBan3 = ds.Tables[0].Rows[i][13].ToString(),
                        SoLuongBan3 = ds.Tables[0].Rows[i][14].ToString(),
                        TongSo = ds.Tables[0].Rows[i][15].ToString(),
                    });
                }
            }
            return messages;
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e) //this will be called when any changes occur in db table. 
        {
            if (e.Type == SqlNotificationType.Change)
            {
                MyHub.SendMessages();
            }
        }
    }
}