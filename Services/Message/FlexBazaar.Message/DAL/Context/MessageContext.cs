using FlexBazaar.Message.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FlexBazaar.Message.DAL.Context
{
    public class MessageContext :DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {

        }
        public DbSet<UserMessage> UserMessages { get; set; }

    }
}
