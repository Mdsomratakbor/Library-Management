using LibraryManagement.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class LMContext : IdentityDbContext<LMUser>
    {
         public LMContext() : base("LMConnectionString")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

            modelBuilder.Entity<LMUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<BookPicture> BookPictures { get; set; }
        public DbSet<StudentPicture> StudentPictures { get; set; }
        public DbSet<StaffPicture> StaffPictures { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public static LMContext Create()
        {
            return new LMContext();
        }
    }
}
