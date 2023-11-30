using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSoccer.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get;set; }
    }
}
