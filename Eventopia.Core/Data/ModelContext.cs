﻿using System;
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

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<ContactUsEntry> ContactUsEntries { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Profilesetting> Profilesettings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=xe)));User Id=ramzi;Password=A1a1a1a1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("RAMZI")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008495");

            entity.ToTable("BANK");

            entity.HasIndex(e => e.CardNumber, "UQ_BANK_CARDNUMBER").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Balance)
                .HasColumnType("NUMBER")
                .HasColumnName("BALANCE");
            entity.Property(e => e.CardHolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CARDHOLDER");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CARDNUMBER");
            entity.Property(e => e.CVV)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CVV");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("DATE")
                .HasColumnName("EXPIRATIONDATE");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008504");

            entity.ToTable("BOOKING");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.BookingDate)
                .HasColumnType("DATE")
                .HasColumnName("BOOKINGDATE");
            entity.Property(e => e.EventId)
                .HasColumnType("NUMBER")
                .HasColumnName("EVENTID");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Event).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_BOOKING_EVENTID");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_BOOKING_USERID");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008488");

            entity.ToTable("CATEGORY");

			entity.HasIndex(e => e.Name, "UQ_CATEGORY_NAME").IsUnique();

			entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.AdminId)
                .HasColumnType("NUMBER")
                .HasColumnName("ADMINID");
            entity.Property(e => e.CreationDate)
                .HasColumnType("DATE")
                .HasColumnName("CREATIONDATE");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IMAGEPATH");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.HasOne(d => d.Admin).WithMany(p => p.Categories)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CATEGORY_ADMINID");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008509");

            entity.ToTable("COMMENTS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CONTENT");
            entity.Property(e => e.EventId)
                .HasColumnType("NUMBER")
                .HasColumnName("EVENTID");
			entity.Property(e => e.UserId)
				.HasColumnType("NUMBER")
				.HasColumnName("USERID");

			entity.HasOne(d => d.Event).WithMany(p => p.Comments)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_COMMENT_EVENTID");
			entity.HasOne(d => d.User).WithMany(p => p.Comments)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_COMMENT_USERID");
		});

        modelBuilder.Entity<ContactUsEntry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008499");

            entity.ToTable("CONTACT_US_ENTRIES");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.AdminId)
                .HasColumnType("NUMBER")
                .HasColumnName("ADMINID");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CONTENT");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("NUMBER")
                .HasColumnName("PHONENUMBER");
            entity.Property(e => e.Subject)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");

            entity.HasOne(d => d.Admin).WithMany(p => p.ContactUsEntries)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CONTACTENTRIES_ADMINID");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008491");

            entity.ToTable("EVENT");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.AttendingCost)
                .HasColumnType("FLOAT")
                .HasColumnName("ATTENDINGCOST");
            entity.Property(e => e.CategoryId)
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORYID");
            entity.Property(e => e.EndDate)
                .HasColumnType("DATE")
                .HasColumnName("ENDDATE");
            entity.Property(e => e.EventCapacity)
                .HasColumnType("NUMBER")
                .HasColumnName("EVENTCAPACITY");
            entity.Property(e => e.EventCreatorId)
                .HasColumnType("NUMBER")
                .HasColumnName("EVENTCREATORID");
            entity.Property(e => e.EventDescription)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EVENTDESCRIPTION");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IMAGEPATH");
            entity.Property(e => e.Latitude)
                .HasColumnType("NUMBER")
                .HasColumnName("LATITUDE");
            entity.Property(e => e.Longitude)
                .HasColumnType("NUMBER")
                .HasColumnName("LONGITUDE");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.StartDate)
                .HasColumnType("DATE")
                .HasColumnName("STARTDATE");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STATUS");
			entity.Property(e => e.Address)
				.HasMaxLength(100)
				.IsUnicode(false)
				.HasColumnName("ADDRESS");

			entity.HasOne(d => d.Category).WithMany(p => p.Events)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_EVENT_CATEGORYID");

            entity.HasOne(d => d.Eventcreator).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventCreatorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_EVENT_CREATORID");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008463");

            entity.ToTable("MESSAGE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CONTENT");
            entity.Property(e => e.IsDeleted)
                .HasColumnType("NUMBER")
                .HasColumnName("ISDELETED");
            entity.Property(e => e.IsRead)
                .HasColumnType("NUMBER")
                .HasColumnName("ISREAD");
            entity.Property(e => e.MessageDate)
                .HasColumnType("DATE")
                .HasColumnName("MESSAGEDATE");
            entity.Property(e => e.ReceiverId)
                .HasColumnType("NUMBER")
                .HasColumnName("RECEIVERID");
            entity.Property(e => e.SenderId)
                .HasColumnType("NUMBER")
                .HasColumnName("SENDERID");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_MESSAGE_RECEIVERID");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_MESSAGE_SENDERID");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008479");

            entity.ToTable("NOTIFICATION");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CONTENT");
            entity.Property(e => e.ReceivedDate)
                .HasColumnType("DATE")
                .HasColumnName("RECEIVEDDATE");
            entity.Property(e => e.ReceiverId)
                .HasColumnType("NUMBER")
                .HasColumnName("RECEIVERID");

            entity.HasOne(d => d.Receiver).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_NOTIFICATION_RECEIVERID");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008482");

            entity.ToTable("PAGE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.AdminId)
                .HasColumnType("NUMBER")
                .HasColumnName("ADMINID");
            entity.Property(e => e.BackgroundImagePath)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("BACKGROUNDIMAGEPATH");
            entity.Property(e => e.Content1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CONTENT1");
            entity.Property(e => e.Content2)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CONTENT2");

            entity.HasOne(d => d.Admin).WithMany(p => p.Pages)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PAGE_ADMINID");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008517");

            entity.ToTable("PAYMENT");

            entity.Property(e => e.Amount)
                .HasColumnType("FLOAT")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PAYMENTTYPE");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("DATE")
                .HasColumnName("PAYMENTDATE");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");
			entity.Property(e => e.EventId)
				.HasColumnType("NUMBER")
				.HasColumnName("EVENTID");

			entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PAYMENT_USERID");
			entity.HasOne(d => d.Event).WithMany()
				.HasForeignKey(d => d.EventId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_PAYMENT_EVENTID");
		});

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008472");

            entity.ToTable("PROFILE");

            entity.HasIndex(e => e.PhoneNumber, "UQ_PROFILE_PHONENUMBER").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Bio)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("BIO");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("DATE")
                .HasColumnName("DATEOFBIRTH");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IMAGEPATH");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.PhoneNumber)
				.HasMaxLength(13)
				.IsUnicode(false)
				.HasColumnName("PHONENUMBER");
            entity.Property(e => e.Rate)
                .HasColumnType("NUMBER")
                .HasColumnName("RATE");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PROFILE_USERID");
        });

        modelBuilder.Entity<Profilesetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008476");

            entity.ToTable("PROFILESETTING");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LANGUAGE");
            entity.Property(e => e.ProfileId)
                .HasColumnType("NUMBER")
                .HasColumnName("PROFILEID");
            entity.Property(e => e.Theme)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("THEME");

            entity.HasOne(d => d.Profile).WithMany(p => p.Profilesettings)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PROFILESETTING_PROFILEID");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008424");

            entity.ToTable("ROLE_");

            entity.HasIndex(e => e.RoleName, "UQ_ROLE_ROLENAME").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008485");

            entity.ToTable("TESTIMONIAL");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CONTENT");
            entity.Property(e => e.CreationDate)
                .HasColumnType("DATE")
                .HasColumnName("CREATIONDATE");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.Testimonials)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TESTIMONIAL_USERID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008427");

            entity.ToTable("USER_");

            entity.HasIndex(e => e.Email, "UQ_USER_EMAIL").IsUnique();

            entity.HasIndex(e => e.Username, "UQ_USER_USERNAME").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.RoleId)
                .HasColumnType("NUMBER")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
            entity.Property(e => e.UserStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USERSTATUS");
            entity.Property(e => e.Verfiicationcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VERFIICATIONCODE");
			entity.Property(e => e.Profits)
				.HasColumnType("FLOAT")
				.HasColumnName("PROFITS");

			entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_USER_ROLEID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
