using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSoccer.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        [NotMapped]
        public string Name { get; set; }
        [ValidateNever]
        public List<Message> Messages { get; set; }
    }
}
