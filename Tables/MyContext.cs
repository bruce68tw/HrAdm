using System;
using Base.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HrAdm.Tables
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cms> Cms { get; set; }
        public virtual DbSet<CustInput> CustInput { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserJob> UserJob { get; set; }
        public virtual DbSet<UserLang> UserLang { get; set; }
        public virtual DbSet<UserLicense> UserLicense { get; set; }
        public virtual DbSet<UserSchool> UserSchool { get; set; }
        public virtual DbSet<UserSkill> UserSkill { get; set; }
        public virtual DbSet<XpCode> XpCode { get; set; }
        public virtual DbSet<XpEasyRpt> XpEasyRpt { get; set; }
        public virtual DbSet<XpFlow> XpFlow { get; set; }
        public virtual DbSet<XpFlowLine> XpFlowLine { get; set; }
        public virtual DbSet<XpFlowNode> XpFlowNode { get; set; }
        public virtual DbSet<XpFlowSign> XpFlowSign { get; set; }
        public virtual DbSet<XpImportLog> XpImportLog { get; set; }
        public virtual DbSet<XpProg> XpProg { get; set; }
        public virtual DbSet<XpRole> XpRole { get; set; }
        public virtual DbSet<XpRoleProg> XpRoleProg { get; set; }
        public virtual DbSet<XpTranLog> XpTranLog { get; set; }
        public virtual DbSet<XpUserRole> XpUserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_Fun.Config.Db);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cms>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CmsType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DataType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))")
                    .HasComment("資料種類");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.Revised).HasColumnType("datetime");

                entity.Property(e => e.Reviser)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CustInput>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FldColor)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FldDate).HasColumnType("datetime");

                entity.Property(e => e.FldDatetime).HasColumnType("datetime");

                entity.Property(e => e.FldFile)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FldHtml).IsRequired();

                entity.Property(e => e.FldNum2).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.FldSelect)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FldText)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FldTextarea)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MgrId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AgentId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.FlowStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Hours).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.LeaveType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Revised).HasColumnType("datetime");

                entity.Property(e => e.Reviser)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Account, "User_Account")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeptId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhotoFile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserJob>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CorpName).HasMaxLength(30);

                entity.Property(e => e.JobDesc).IsUnicode(false);

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.JobPlace).HasMaxLength(30);

                entity.Property(e => e.JobType).HasMaxLength(30);

                entity.Property(e => e.StartEnd)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLang>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LangName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ListenLevel)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ReadLevel)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SpeakLevel)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WriteLevel)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<UserLicense>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.LicenseName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.StartEnd)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserSchool>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolDept).HasMaxLength(20);

                entity.Property(e => e.SchoolName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SchoolType).HasMaxLength(20);

                entity.Property(e => e.StartEnd)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SkillDesc).HasMaxLength(500);

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XpCode>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.Value });

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ext)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name_enUS).HasMaxLength(50);

                entity.Property(e => e.Name_zhCN).HasMaxLength(30);

                entity.Property(e => e.Name_zhTW)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Note).HasMaxLength(255);
            });

            modelBuilder.Entity<XpEasyRpt>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Sql)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ToEmails)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TplFile)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XpFlow>(entity =>
            {
                entity.HasIndex(e => e.Code, "NonClusteredIndex-20210205-193224")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<XpFlowLine>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CondStr)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndNode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlowId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartNode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XpFlowNode>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlowId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.NodeType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PassType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SignerType)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SignerValue)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XpFlowSign>(entity =>
            {
                entity.HasIndex(e => e.FlowLevel, "XpFlowSign_FlowLevel");

                entity.HasIndex(e => e.SignTime, "XpFlowSign_SignTime");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlowId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NodeName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.SignStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SignTime).HasColumnType("datetime");

                entity.Property(e => e.SignerId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SignerName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SourceId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XpImportLog>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatorName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XpProg>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Sort).HasDefaultValueSql("((99))");

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XpRole>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<XpRoleProg>(entity =>
            {
                entity.HasIndex(e => new { e.RoleId, e.ProgId }, "NonClusteredIndex-20210116-190117")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProgId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XpTranLog>(entity =>
            {
                entity.HasKey(e => e.Sn);

                entity.Property(e => e.Act)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ColName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.RowId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XpUserRole>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.RoleId }, "NonClusteredIndex-20210116-185929")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
