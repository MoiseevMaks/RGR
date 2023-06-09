using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGR.Models.TestModel;
using RGR.Models.UserModel;

namespace Models.UserModel
{
    public class Result
    {
        public Test Test { get; set; }
        public User User { get; set; }
        public DateTime EndTime { get; set; }
        public int PercentOfDone { get; set; }
        public int CalculateScore { get; set; }
    }
}
