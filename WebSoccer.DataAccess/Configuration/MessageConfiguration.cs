using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSoccer.Models;

namespace WebSoccer.DataAccess.Configuration
{
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Message");
            builder.HasKey(x => new {x.SenderId,x.ReceiverId});
            builder.Property(x=>x.Content).IsRequired().HasMaxLength(1024);
            builder.HasOne(m => m.AppSender)
              .WithMany(x=>x.SentMessages)
              .HasForeignKey(m => m.SenderId)
              .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(m => m.AppReceiver)
              .WithMany(x=>x.ReceivedMessages)
              .HasForeignKey(m => m.ReceiverId)
              .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
