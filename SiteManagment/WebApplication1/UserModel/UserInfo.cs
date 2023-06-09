using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RGR.Models.UserModel;

namespace Models.UserModel
{
    public class UserInfo
    {
        public User Id { get; set; }
        public List<Result> Results { get; set; }
    }
}
