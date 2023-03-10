// <auto-generated />
using System;
using AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace aspnetcore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("AspNetCore.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AspNetCore.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("End")
                        .HasColumnType("TEXT");

                    b.Property<string>("Funder")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Start")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("AspNetCore.ProjectSupervisor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Project_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Supervisor_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SupervisorsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectsId");

                    b.HasIndex("SupervisorsId");

                    b.ToTable("ProjectSupervisors");
                });

            modelBuilder.Entity("AspNetCore.Super", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SuperviseeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Supervisor_TableId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SuperviseeId");

                    b.HasIndex("Supervisor_TableId");

                    b.ToTable("Supers");
                });

            modelBuilder.Entity("AspNetCore.Supervisee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Employee_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.ToTable("Supervisees");
                });

            modelBuilder.Entity("AspNetCore.Supervisor_Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Employee_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.ToTable("Supervisors");
                });

            modelBuilder.Entity("AspNetCore.Timesheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Hours")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Minutes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Project_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("SupervisorId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SupervisorsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Task")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.HasIndex("ProjectsId");

                    b.HasIndex("SupervisorsId");

                    b.ToTable("Timesheets");
                });

            modelBuilder.Entity("AspNetCore.ProjectSupervisor", b =>
                {
                    b.HasOne("AspNetCore.Project", "Projects")
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCore.Supervisor_Table", "Supervisors")
                        .WithMany()
                        .HasForeignKey("SupervisorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projects");

                    b.Navigation("Supervisors");
                });

            modelBuilder.Entity("AspNetCore.Super", b =>
                {
                    b.HasOne("AspNetCore.Supervisee", "Supervisee")
                        .WithMany()
                        .HasForeignKey("SuperviseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCore.Supervisor_Table", "Supervisor_Table")
                        .WithMany()
                        .HasForeignKey("Supervisor_TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supervisee");

                    b.Navigation("Supervisor_Table");
                });

            modelBuilder.Entity("AspNetCore.Supervisee", b =>
                {
                    b.HasOne("AspNetCore.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AspNetCore.Supervisor_Table", b =>
                {
                    b.HasOne("AspNetCore.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("AspNetCore.Timesheet", b =>
                {
                    b.HasOne("AspNetCore.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCore.Project", "Projects")
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCore.Supervisor_Table", "Supervisors")
                        .WithMany()
                        .HasForeignKey("SupervisorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Projects");

                    b.Navigation("Supervisors");
                });
#pragma warning restore 612, 618
        }
    }
}
