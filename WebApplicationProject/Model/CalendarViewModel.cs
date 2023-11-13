using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationProject.Model
{
    public class ClassInfo
    {
        public string ClassName { get; set; }
        public string ClassTenCaHoc { get; set; }
        public string ClassGiaoVien { get; set; }

    }

    public class CalendarViewModel
    {
        public DateTime StartDate { get; set; }
        public List<DateTime> DisplayDates { get; set; }
        public Dictionary<DateTime, List<ClassInfo>> ClassesByDate { get; set; }
    }
}