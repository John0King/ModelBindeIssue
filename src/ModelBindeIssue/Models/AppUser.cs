using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindeIssue.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Company { get; set; }

        [StringLength(255)]
        public List<string> CompanyLocation { get; set; } = new List<string>();

        public string CompanyAddress { get; set; }

        public DateTimeOffset CreateTime { get; set; } = DateTimeOffset.Now;
    }
}
