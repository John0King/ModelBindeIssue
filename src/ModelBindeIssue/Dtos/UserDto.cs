using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindeIssue.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Company { get; set; }
        public string UserName { get; set; }

        public virtual List<string> CompanyLocation { get; set; } = new List<string>();

        public virtual string CompanyAddress { get; set; }
    }
}
