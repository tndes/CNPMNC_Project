using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPMNC_Project.Models
{
    public class ChiTietPhongBan
    {
        public int Id { get; set; }
        public int MANV { get; set; }
        public string TenCV { get; set; }
        public string HOTENNV { get; set; }
        public string DIACHI { get; set; }
        public string GIOITINH { get; set; }
        public string NGAYSINH { get; set; }
        public string CMND { get; set; }
        public string QUEQUAN { get; set; }
        public Nullable<int> SDT { get; set; }
        public string DANTOC { get; set; }
        public string SOBH { get; set; }
    }
}