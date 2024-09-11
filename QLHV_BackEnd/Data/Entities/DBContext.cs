using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QLHV_BackEnd.Data.Entities
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        // Khai báo các table
        public DbSet<IncomingDocuments> IncomingDocuments { get; set; }
        public DbSet<ActionNotification> ActionNotification { get; set; }
        public DbSet<OutgoingDocument> OutgoingDocument { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentRequest> StudentRequest { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<TeachingSchedule> TeachingSchedule { get; set; }
        public DbSet<CorporatePartner> CorporatePartner { get; set; }
        public DbSet<Alumni> Alumni { get; set; }
        public DbSet<Internship> Internship { get; set; }

        public DBContext(DbContextOptions<DBContext> opt) : base(opt) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /// Khởi tạo tbl
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("User");
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");


            builder.Entity<IncomingDocuments>();
            builder.Entity<ActionNotification>();
            builder.Entity<OutgoingDocument>();
            builder.Entity<Student>();
            builder.Entity<StudentRequest>();
            builder.Entity<Faculty>();
            builder.Entity<TeachingSchedule>();
            builder.Entity<CorporatePartner>();
            builder.Entity<Alumni>();
            builder.Entity<Internship>();


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
