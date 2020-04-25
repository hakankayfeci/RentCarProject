namespace RCP.DL.EntityFramework
{
    using RCP.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class RentCarContext : DbContext
    {
        // Your context has been configured to use a 'RentCarContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RCP.DL.EntityFramework.RentCarContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RentCarContext' 
        // connection string in the application configuration file.
        public RentCarContext()
            : base("name=RentCarContext")
        {
        }
        //tablolarýn sonuna s takýsý getiren algoritmayý kaldýrýyor.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
            Database.SetInitializer<RentCarContext>(new CreateDatabaseIfNotExists<RentCarContext>());//Eðer veritabaný yoksa vritabaný oluþtur.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Address> Address { get; set; }
         public virtual DbSet<Advert> Advert { get; set; }
         public virtual DbSet<CarPhoto>CarPhoto { get; set; }
         public virtual DbSet<Blog> Blog { get; set; }
         public virtual DbSet<BlogComment> BlogComment { get; set; }
        public virtual DbSet<BlogPhoto> BlogPhoto { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
         public virtual DbSet<Role> Role { get; set; }
         public virtual DbSet<User> User { get; set; }
         public virtual DbSet<UserRole> UserRole { get; set; }
        
    }

 
}