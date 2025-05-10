using FlexBazaar.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlexBazaar.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog=FlexBazaarCommentDb;User=sa;Password=Qwe1-asd23..");
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
