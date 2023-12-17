using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSoccer.Models
{
    public class Message 
    {
        public Guid SenderId { get; set; }
        public ApplicationUser AppSender { get; set; }
        public Guid ReceiverId { get; set; }
        public ApplicationUser AppReceiver { get; set; }
        public string Content { get; set; } 
        public DateTime Timestamp {  get; set; }
    }
}
