using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.Models.TestModel
{
    public class Test
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Question> Questions { get; set; }

    }
}