using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSupport.Models
{
    public class MTask
    {
        public int IdTask { get; set; }
        public int IdUser { get; set; }
        public string Activity { get; set; }
        public System.DateTime DateIni { get; set; }
        public System.DateTime DateEnd { get; set; }
        public System.TimeSpan HourIni { get; set; }
        public System.TimeSpan HourEnd { get; set; }
        public string Place { get; set; }
        public List<MDetailTask> ListDetailTask { get; set; }

    }
}