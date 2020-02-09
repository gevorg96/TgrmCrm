using Microsoft.EntityFrameworkCore;
using TgrmCRM.Entities;

namespace TgrmCRM
{
    public class TgrmDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<ContactPartner> ContactPartners { get; set; }
        public DbSet<ContactsMessages> ContactsMessages { get; set; }
        public DbSet<ThemeMessage> ThemeMessages { get; set; }
        public DbSet<MessageAnswer> MessageAnswers { get; set; }
        public TgrmDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = new PostgreSqlConnectionStringBuilder("da08a3hhm92jmc",
                "ec2-46-137-177-160.eu-west-1.compute.amazonaws.com",
                "1839c9adc3bf5d180f4bd87b8be174398420534664a0e15e1ad2207c8442beb3",
                "udhoqnhoganvuh",
                5432,
                true,
                true,
                SslMode.Require);
            optionsBuilder.UseNpgsql(conn.ConnectionString);
        }

    }
}
