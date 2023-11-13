using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProject.Model
{
    public class ClassInfo
    {
        public string ClassName { get; set; }
        public string ClassKhoaHoc { get; set; }
        public string ClassGiaoVien { get; set; }
        public int ClassSiSoToiDa { get; set; }
        public int ClassSoLuongDangKy { get; set; }

    }

    public class CalendarViewModel
    {
        public DateTime StartDate { get; set; }
        public List<DateTime> DisplayDates { get; set; }
        public Dictionary<DateTime, List<ClassInfo>> ClassesByDate { get; set; }
    }
}