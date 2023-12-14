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
        public int Id { get; set; } 
        public int ConversationId { get;set; }
        [ForeignKey("ConversationId")]
        public Conversation Conversation { get; set; }
        public Guid SenderId { get; set; }
        [ForeignKey("SenderId")]
        public ApplicationUser AppSenderId { get; set; }
        public Guid ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public ApplicationUser AppReceiverId { get; set; }
        public string Content { get; set; } 
        public DateTime Timestamp {  get; set; }
    }
}
