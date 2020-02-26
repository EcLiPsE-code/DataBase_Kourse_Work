﻿// <auto-generated />
using CompanyASP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompanyASP.Migrations
{
    [DbContext(typeof(CompanyContext))]
    partial class CompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompanyASP.Models.Departament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountEmployee");

                    b.Property<string>("FullName");

                    b.HasKey("Id");

                    b.ToTable("Departaments");
                });

            modelBuilder.Entity("CompanyASP.Models.DepartamentValuationFact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartamentId");

                    b.Property<double>("PerfomanceQuarter");

                    b.Property<double>("PerfomanceYear");

                    b.Property<int>("Quarter");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.ToTable("DepartamentValuationFacts");
                });

            modelBuilder.Entity("CompanyASP.Models.DepartamentValuationPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartamentId");

                    b.Property<double>("PerfomanceQuarter");

                    b.Property<double>("PerfomanceYear");

                    b.Property<int>("Quarter");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.ToTable("DepartamentValuationPlans");
                });

            modelBuilder.Entity("CompanyASP.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<int>("DepartamentId");

                    b.Property<string>("FullName");

                    b.Property<double>("Raiting");

                    b.Property<double>("Salary");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CompanyASP.Models.EmployeeFact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<double>("PerfomanceQuarter");

                    b.Property<double>("PerfomanceYear");

                    b.Property<int>("Quarter");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeFacts");
                });

            modelBuilder.Entity("CompanyASP.Models.EmployeePlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<double>("PerfomanceQuarter");

                    b.Property<double>("PerfomanceYear");

                    b.Property<int>("Quarter");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeePlans");
                });

            modelBuilder.Entity("CompanyASP.Models.Indicators.ListDepartamentMetrics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartamentId");

                    b.Property<int>("MarkQuarter");

                    b.Property<int>("MarkYear");

                    b.Property<int>("Quarter");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.ToTable("ListDepartamentMetrics");
                });

            modelBuilder.Entity("CompanyASP.Models.Indicators.ListEmployeesMetrics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<int>("MarkQuarter");

                    b.Property<int>("MarkYear");

                    b.Property<int>("Quarter");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ListEmployeesMetrics");
                });

            modelBuilder.Entity("CompanyASP.Models.ProgressEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID");

                    b.Property<string>("Progress");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeID");

                    b.ToTable("ProgressEmployees");
                });

            modelBuilder.Entity("CompanyASP.Models.DepartamentValuationFact", b =>
                {
                    b.HasOne("CompanyASP.Models.Departament", "Departament")
                        .WithMany("DepartamentValuationFacts")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompanyASP.Models.DepartamentValuationPlan", b =>
                {
                    b.HasOne("CompanyASP.Models.Departament", "Departament")
                        .WithMany("DepartamentValuationPlans")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompanyASP.Models.Employee", b =>
                {
                    b.HasOne("CompanyASP.Models.Departament", "Departament")
                        .WithMany("Employees")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompanyASP.Models.EmployeeFact", b =>
                {
                    b.HasOne("CompanyASP.Models.Employee", "Employee")
                        .WithMany("EmployeeFacts")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompanyASP.Models.EmployeePlan", b =>
                {
                    b.HasOne("CompanyASP.Models.Employee", "Employee")
                        .WithMany("EmployeePlans")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompanyASP.Models.Indicators.ListDepartamentMetrics", b =>
                {
                    b.HasOne("CompanyASP.Models.Departament", "Departament")
                        .WithMany()
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompanyASP.Models.Indicators.ListEmployeesMetrics", b =>
                {
                    b.HasOne("CompanyASP.Models.Employee", "Employee")
                        .WithMany("ListEmployeesMetrics")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompanyASP.Models.ProgressEmployee", b =>
                {
                    b.HasOne("CompanyASP.Models.Employee", "Employee")
                        .WithMany("ProgressEmployees")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
