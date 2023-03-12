using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Library.DataModel
{
    public partial class osc_centerContext : DbContext
    {
        public osc_centerContext()
        {
        }

        public osc_centerContext(DbContextOptions<osc_centerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Commission> Commissions { get; set; }
        public virtual DbSet<Consultancy> Consultancies { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<EducationPlan> EducationPlans { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<RegisterCourse> RegisterCourses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<UserSystem> UserSystems { get; set; }
        public virtual DbSet<Wish> Wishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=MSI\\TunaQQ;Initial Catalog=osc_center;Integrated Security=True");
                optionsBuilder.UseSqlServer("workstation id=ocscenter.mssql.somee.com;packet size=4096;user id=tuan2701_SQLLogin_3;pwd=ri5svf3mmy;data source=ocscenter.mssql.somee.com;persist security info=False;initial catalog=ocscenter");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<Commission>(entity =>
            {
                entity.ToTable("commission");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("end_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StudentId).HasColumnName("student_id");
            });

            modelBuilder.Entity<Consultancy>(entity =>
            {
                entity.ToTable("consultancy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content");

                entity.Property(e => e.LastContact)
                    .HasColumnType("datetime")
                    .HasColumnName("last_contact");

                entity.Property(e => e.NextContact)
                    .HasColumnType("datetime")
                    .HasColumnName("next_contact");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.StudentId).HasColumnName("student_id");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("contract");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.AmountPaid).HasColumnName("amount_paid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("note");

                entity.Property(e => e.RestPaid).HasColumnName("rest_paid");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.ActiveFlag).HasColumnName("active_flag");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.DayToStudy)
                    .HasMaxLength(50)
                    .HasColumnName("day_to_study");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NumberOfSession).HasColumnName("number_of_session");

                entity.Property(e => e.OpeningDay)
                    .HasColumnType("datetime")
                    .HasColumnName("opening_day");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.StartTime).HasColumnName("start_time");
            });

            modelBuilder.Entity<EducationPlan>(entity =>
            {
                entity.ToTable("education_plan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EDate)
                    .HasColumnType("datetime")
                    .HasColumnName("e_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Resolve)
                    .HasMaxLength(255)
                    .HasColumnName("resolve");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.StudentId).HasColumnName("student_id");
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.ToTable("income");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.DatePayment)
                    .HasColumnType("date")
                    .HasColumnName("date_payment");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.PaymentMethods).HasColumnName("payment_methods");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StudentId).HasColumnName("student_id");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.ToTable("record");

                entity.Property(e => e.RecordId).HasColumnName("record_id");

                entity.Property(e => e.AdmissionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("admission_date");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.Email1)
                    .HasMaxLength(255)
                    .HasColumnName("email1");

                entity.Property(e => e.Email2)
                    .HasMaxLength(255)
                    .HasColumnName("email2");

                entity.Property(e => e.LastContact)
                    .HasColumnType("datetime")
                    .HasColumnName("last_contact");

                entity.Property(e => e.Major)
                    .HasMaxLength(255)
                    .HasColumnName("major");

                entity.Property(e => e.NextContact)
                    .HasColumnType("datetime")
                    .HasColumnName("next_contact");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("datetime")
                    .HasColumnName("register_date");

                entity.Property(e => e.SchoolAddress)
                    .HasMaxLength(255)
                    .HasColumnName("school_address");

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(255)
                    .HasColumnName("school_name");

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasColumnName("status");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.SubmitDate)
                    .HasColumnType("datetime")
                    .HasColumnName("submit_date");
            });

            modelBuilder.Entity<RegisterCourse>(entity =>
            {
                entity.ToTable("register_course");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.Property(e => e.RegisterDay)
                    .HasColumnType("datetime")
                    .HasColumnName("register_day");

                entity.Property(e => e.StudentId).HasColumnName("student_id");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.ActiveFlag).HasColumnName("active_flag");

                entity.Property(e => e.StudentAddress).HasColumnName("student_address");

                entity.Property(e => e.StudentCccd).HasColumnName("student_cccd");

                entity.Property(e => e.StudentDob)
                    .HasColumnType("date")
                    .HasColumnName("student_dob");

                entity.Property(e => e.StudentName).HasColumnName("student_name");

                entity.Property(e => e.StudentNote).HasColumnName("student_note");

                entity.Property(e => e.StudentPhone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("student_phone");

                entity.Property(e => e.StudentSource).HasColumnName("student_source");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<UserSystem>(entity =>
            {
                entity.ToTable("user_system");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Wish>(entity =>
            {
                entity.ToTable("wish");

                entity.Property(e => e.WishId).HasColumnName("wish_id");

                entity.Property(e => e.AddressTo).HasColumnName("address_to");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.MajorTo).HasColumnName("major_to");

                entity.Property(e => e.SchoolTo).HasColumnName("school_to");

                entity.Property(e => e.StudentId).HasColumnName("student_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
