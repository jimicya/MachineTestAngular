using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Models;

public partial class LoanManagementDbContext : DbContext
{
    public LoanManagementDbContext()
    {
    }

    public LoanManagementDbContext(DbContextOptions<LoanManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BackgroundVerification> BackgroundVerifications { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Help> Helps { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<LoanApplication> LoanApplications { get; set; }

    public virtual DbSet<LoanVerification> LoanVerifications { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =DESKTOP-0UVACDJ; Initial Catalog =LoanManagement_db; Integrated Security = True; Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BackgroundVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__Backgrou__306D4927595E62A5");

            entity.ToTable("BackgroundVerification");

            entity.Property(e => e.VerificationId).HasColumnName("VerificationID");
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.LoanOfficerId).HasColumnName("LoanOfficerID");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Application).WithMany(p => p.BackgroundVerifications)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK__Backgroun__Appli__5EBF139D");

            entity.HasOne(d => d.LoanOfficer).WithMany(p => p.BackgroundVerifications)
                .HasForeignKey(d => d.LoanOfficerId)
                .HasConstraintName("FK__Backgroun__LoanO__5FB337D6");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B83578A617");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AnnualIncome).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Customers__UserI__5070F446");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6AABBDEC3");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.Comments).HasColumnType("text");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Feedback__UserID__6C190EBB");
        });

        modelBuilder.Entity<Help>(entity =>
        {
            entity.HasKey(e => e.HelpId).HasName("PK__Help__90E3232E6E0C14A2");

            entity.ToTable("Help");

            entity.Property(e => e.HelpId).HasColumnName("HelpID");
            entity.Property(e => e.Answer).HasColumnType("text");
            entity.Property(e => e.Question).HasColumnType("text");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Helps)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Help__CreatedBy__68487DD7");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__Loans__4F5AD437F6E62F6E");

            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.InterestRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LoanName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaxAmount).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<LoanApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__LoanAppl__C93A4F79473D7AE4");

            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.ApplicationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.RequestedAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.LoanApplications)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK__LoanAppli__Appro__59FA5E80");

            entity.HasOne(d => d.Customer).WithMany(p => p.LoanApplications)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__LoanAppli__Custo__5812160E");

            entity.HasOne(d => d.Loan).WithMany(p => p.LoanApplications)
                .HasForeignKey(d => d.LoanId)
                .HasConstraintName("FK__LoanAppli__LoanI__59063A47");
        });

        modelBuilder.Entity<LoanVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__LoanVeri__306D4927F8E1E489");

            entity.ToTable("LoanVerification");

            entity.Property(e => e.VerificationId).HasColumnName("VerificationID");
            entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");
            entity.Property(e => e.LoanOfficerId).HasColumnName("LoanOfficerID");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Application).WithMany(p => p.LoanVerifications)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK__LoanVerif__Appli__6477ECF3");

            entity.HasOne(d => d.LoanOfficer).WithMany(p => p.LoanVerifications)
                .HasForeignKey(d => d.LoanOfficerId)
                .HasConstraintName("FK__LoanVerif__LoanO__656C112C");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A00DCDF71");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B6160E010A963").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACAD9795AD");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4EFDB7EDC").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
