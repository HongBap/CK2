using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Models
{
    public class Employee
    {
        public int Id { set; get; }
        public string MaCK { set; get; }
        public string GiaMua1 { set; get; }
        public string SoLuongMua1 { set; get; }
        public string GiaMua2 { set; get; }
        public string SoLuongMua2 { set; get; }
        public string GiaMua3 { set; get; }
        public string SoLuongMua3 { set; get; }
        public string GiaKhop { set; get; }
        public string SoLuongKhop { set; get; }
        public string GiaBan1 { set; get; }
        public string SoLuongBan1 { set; get; }
        public string GiaBan2 { set; get; }
        public string SoLuongBan2 { set; get; }
        public string GiaBan3 { set; get; }
        public string SoLuongBan3 { set; get; }

        public string TongSo { set; get; }
    }
}