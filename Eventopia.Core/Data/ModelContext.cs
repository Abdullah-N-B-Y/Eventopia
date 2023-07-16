using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Eventopia.Core.Data;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoryy> Categoryys { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Stdcourse> Stdcourses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=xe)));User Id=ramzi;Password=A1a1a1a1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("RAMZI")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Categoryy>(entity =>
        {
            entity.HasKey(e => e.Categoryyid).HasName("SYS_C008362");

            entity.ToTable("CATEGORYY");

            entity.HasIndex(e => e.Categoryname, "UQ_CATEGORYY_CATEGORYNAME").IsUnique();

            entity.Property(e => e.Categoryyid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CATEGORYYID");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CATEGORYNAME");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Courseid).HasName("SYS_C008368");

            entity.ToTable("COURSE");

            entity.Property(e => e.Courseid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COURSEID");
            entity.Property(e => e.Categoryyid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CATEGORYYID");
            entity.Property(e => e.Coursename)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("COURSENAME");
            entity.Property(e => e.Imagename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IMAGENAME");

            entity.HasOne(d => d.Categoryy).WithMany(p => p.Courses)
                .HasForeignKey(d => d.Categoryyid)
                .HasConstraintName("FK_COURSE_CATEGORYYID");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Loginid).HasName("SYS_C008356");

            entity.ToTable("LOGIN");

            entity.HasIndex(e => e.Username, "UQ_LOGIN_USERNAME").IsUnique();

            entity.Property(e => e.Loginid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("LOGINID");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Roleid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Studentid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STUDENTID");
            entity.Property(e => e.Username)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Role).WithMany(p => p.Logins)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LOGIN_ROLEID");

            entity.HasOne(d => d.Student).WithMany(p => p.Logins)
                .HasForeignKey(d => d.Studentid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LOGIN_STUDENTID");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("SYS_C008348");

            entity.ToTable("ROLE");

            entity.Property(e => e.Roleid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Stdcourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008375");

            entity.ToTable("STDCOURSE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Courseid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COURSEID");
            entity.Property(e => e.Dateofregister)
                .HasColumnType("DATE")
                .HasColumnName("DATEOFREGISTER");
            entity.Property(e => e.Markofstd)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("MARKOFSTD");
            entity.Property(e => e.Stdid)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STDID");

            entity.HasOne(d => d.Course).WithMany(p => p.Stdcourses)
                .HasForeignKey(d => d.Courseid)
                .HasConstraintName("FK_STDCOURSE_COURSEID");

            entity.HasOne(d => d.Std).WithMany(p => p.Stdcourses)
                .HasForeignKey(d => d.Stdid)
                .HasConstraintName("FK_STDCOURSE_STUDENTID");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("SYS_C008352");

            entity.ToTable("STUDENT");

            entity.Property(e => e.Studentid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STUDENTID");
            entity.Property(e => e.Dateofbirth)
                .HasColumnType("DATE")
                .HasColumnName("DATEOFBIRTH");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
