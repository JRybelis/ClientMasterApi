using System.Data.Entity;
using System.Data.SQLite;
using System.Data.SQLite.EF6;
using Core.Models;


namespace ClientMasterApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base(new SQLiteConnection()
        {
            ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = ".\\ClientMaster.db", ForeignKeys = true
            }.ConnectionString
        }, true)
        {

        }

        public static DataContext Create()
        {
            return new DataContext();
        }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating (DbModelBuilder modelBuilder)
        {
            ConfigureEntityPrimaryKeys(modelBuilder);
            ConfigureEntityProperties(modelBuilder);
        }

        private static void ConfigureEntityPrimaryKeys(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);
        }

        private static void ConfigureEntityProperties(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(c => c.Forename)
                .HasMaxLength(56)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.Surname)
                .HasMaxLength(56)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.Age)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.Comment)
                .HasMaxLength(224);
        }
    }
    
}
