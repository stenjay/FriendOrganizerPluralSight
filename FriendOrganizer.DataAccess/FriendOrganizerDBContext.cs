using FriendOrganizer.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDBContext : DbContext
    {
        public FriendOrganizerDBContext():base("FriendOrganizerDb")
        {

        }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<FriendPhoneNumber> FriendPhoneNumbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Fluent API configuration class utilization example

            //modelBuilder.Configurations.Add(new FriendConfiguration());
        }
    }

    //Fluent API configuration class example

    //public class FriendConfiguration : EntityTypeConfiguration<Friend>
    //{
    //    public FriendConfiguration()
    //    {
    //        Property(f => f.FirstName)
    //            .IsRequired()
    //            .HasMaxLength(50);
    //    }
    //}
}
