using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rifoms.Domain.Data.Entities.Base
{
    public class BaseUser
    {
        public int AppUserId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Fathername { get; set; }
        public string Mobile { get; set; }
    }
}
