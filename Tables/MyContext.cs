using System;
using System.Collections.Generic;
using Base.Services;
using Microsoft.EntityFrameworkCore;

namespace HrAdm.Tables;

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

    public virtual DbSet<Leave> Leave { get; set; }

    public virtual DbSet<UserJob> UserJob { get; set; }

    public virtual DbSet<UserLang> UserLang { get; set; }

    public virtual DbSet<UserLicense> UserLicense { get; set; }

    public virtual DbSet<UserSchool> UserSchool { get; set; }

    public virtual DbSet<UserSkill> UserSkill { get; set; }

    public virtual DbSet<XpCode> XpCode { get; set; }

    public virtual DbSet<XpDept> XpDept { get; set; }

    public virtual DbSet<XpEasyRpt> XpEasyRpt { get; set; }

    public virtual DbSet<XpFlow> XpFlow { get; set; }

    public virtual DbSet<XpFlowLine> XpFlowLine { get; set; }

    public virtual DbSet<XpFlowNode> XpFlowNode { get; set; }

    public virtual DbSet<XpFlowSign> XpFlowSign { get; set; }

    public virtual DbSet<XpImportLog> XpImportLog { get; set; }

    public virtual DbSet<XpProg> XpProg { get; set; }

    public virtual DbSet<XpRole> XpRole { get; set; }

    public virtual DbSet<XpRoleProg> XpRoleProg { get; set; }

    public virtual DbSet<XpTestFlowSign> XpTestFlowSign { get; set; }

    public virtual DbSet<XpTestFlowSource> XpTestFlowSource { get; set; }

    public virtual DbSet<XpTranLog> XpTranLog { get; set; }

    public virtual DbSet<XpUser> XpUser { get; set; }

    public virtual DbSet<XpUserRole> XpUserRole { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_Fun.Config.Db);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cms>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CmsType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Creator)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DataType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(100);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.Revised).HasColumnType("datetime");
            entity.Property(e => e.Reviser)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<CustInput>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FldColor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FldDt).HasColumnType("datetime");
            entity.Property(e => e.FldFile).HasMaxLength(100);
            entity.Property(e => e.FldSelect)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FldText)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AgentId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Creator)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(100);
            entity.Property(e => e.FlowStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Hours).HasColumnType("decimal(5, 1)");
            entity.Property(e => e.LeaveType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Revised).HasColumnType("datetime");
            entity.Property(e => e.Reviser)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserJob>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CorpName).HasMaxLength(30);
            entity.Property(e => e.JobDesc).IsUnicode(false);
            entity.Property(e => e.JobName).HasMaxLength(30);
            entity.Property(e => e.JobPlace).HasMaxLength(30);
            entity.Property(e => e.JobType).HasMaxLength(30);
            entity.Property(e => e.StartEnd)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserLang>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LangName).HasMaxLength(30);
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserLicense>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FileName).HasMaxLength(100);
            entity.Property(e => e.LicenseName).HasMaxLength(30);
            entity.Property(e => e.StartEnd)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserSchool>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SchoolDept).HasMaxLength(20);
            entity.Property(e => e.SchoolName).HasMaxLength(30);
            entity.Property(e => e.SchoolType).HasMaxLength(20);
            entity.Property(e => e.StartEnd)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserSkill>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SkillDesc).HasMaxLength(500);
            entity.Property(e => e.SkillName).HasMaxLength(30);
            entity.Property(e => e.UserId)
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
            entity.Property(e => e.Name_enUS).HasMaxLength(30);
            entity.Property(e => e.Name_zhCN).HasMaxLength(30);
            entity.Property(e => e.Name_zhTW).HasMaxLength(30);
            entity.Property(e => e.Note).HasMaxLength(255);
        });

        modelBuilder.Entity<XpDept>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Dept");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MgrId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.TopDeptId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XpEasyRpt>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Sql).HasMaxLength(500);
            entity.Property(e => e.ToEmails)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TplFile).HasMaxLength(100);
        });

        modelBuilder.Entity<XpFlow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Flow");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<XpFlowLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_FlowLine");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CondStr)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FlowId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FromNodeId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FromType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ToNodeId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XpFlowNode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_FlowNode");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FlowId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.NodeType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PassType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SignerType)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.SignerValue)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XpFlowSign>(entity =>
        {
            entity.HasKey(e => e.Sn).HasName("PK_FlowSign");

            entity.HasIndex(e => e.Id, "XpFlowSign_Id").IsUnique();

            entity.Property(e => e.FlowId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NodeName).HasMaxLength(30);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.SignStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SignTime).HasColumnType("datetime");
            entity.Property(e => e.SignerId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SignerName).HasMaxLength(20);
            entity.Property(e => e.SourceId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XpImportLog>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.CreatorName).HasMaxLength(30);
            entity.Property(e => e.FileName).HasMaxLength(100);
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XpProg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Prog");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Icon)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XpRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Role");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<XpRoleProg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RoleProg");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ProgId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XpTestFlowSign>(entity =>
        {
            entity.HasKey(e => e.Sn);

            entity.HasIndex(e => e.Id, "XpTestFlowSign_Id").IsUnique();

            entity.Property(e => e.FlowId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NodeName).HasMaxLength(30);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.SignStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SignTime).HasColumnType("datetime");
            entity.Property(e => e.SignerId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SignerName).HasMaxLength(20);
            entity.Property(e => e.SourceId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XpTestFlowSource>(entity =>
        {
            entity.HasKey(e => e.Sn);

            entity.HasIndex(e => e.Id, "XpTestFlowSource_Id").IsUnique();

            entity.Property(e => e.Sn).ValueGeneratedNever();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.FlowStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.InputJson).HasMaxLength(500);
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XpTranLog>(entity =>
        {
            entity.HasKey(e => e.Sn);

            entity.Property(e => e.Act)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ColName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.NewValue).HasMaxLength(500);
            entity.Property(e => e.OldValue).HasMaxLength(500);
            entity.Property(e => e.RowId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TableName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XpUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Account)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DeptId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.PhotoFile).HasMaxLength(100);
            entity.Property(e => e.Pwd)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XpUserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserRole");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RoleId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
