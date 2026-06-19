using GRC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Infrastructure.Data
{
    public class GrcDbContext : DbContext
    {
        public GrcDbContext(DbContextOptions<GrcDbContext> options) : base(options)
        {
        }

        // Authentication
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        // Compliance
        public DbSet<ComplianceBook> ComplianceBooks { get; set; }
        public DbSet<ComplianceChapter> ComplianceChapters { get; set; }
        public DbSet<ComplianceArticle> ComplianceArticles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ArticleDepartment> ArticleDepartments { get; set; }
        public DbSet<Attachments> Attachments { get; set; }

        // Violations
        public DbSet<Violation> Violations { get; set; }
        public DbSet<ViolationAttachment> ViolationAttachments { get; set; }

        // Ministries
        public DbSet<Ministry> Ministries { get; set; }
        public DbSet<Minister> Ministers { get; set; }

        // National Assembly
        public DbSet<ParliamentaryTerm> ParliamentaryTerms { get; set; }
        public DbSet<ElectoralDistrict> ElectoralDistricts { get; set; }
        public DbSet<NationalAssemblyMember> NationalAssemblyMembers { get; set; }
        public DbSet<MemberTerm> MemberTerms { get; set; }

        // Citizenship
        public DbSet<CitizenshipCase> CitizenshipCases { get; set; }
        public DbSet<CitizenshipAttachment> CitizenshipAttachments { get; set; }

        // Audit
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User-Role relationship
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // Configure Role-Permission relationship
            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);

            // Configure Article-Department relationship
            modelBuilder.Entity<ArticleDepartment>()
                .HasKey(ad => new { ad.ArticleId, ad.DepartmentId });
            modelBuilder.Entity<ArticleDepartment>()
                .HasOne(ad => ad.Article)
                .WithMany(a => a.ArticleDepartments)
                .HasForeignKey(ad => ad.ArticleId);
            modelBuilder.Entity<ArticleDepartment>()
                .HasOne(ad => ad.Department)
                .WithMany(d => d.ArticleDepartments)
                .HasForeignKey(ad => ad.DepartmentId);

            // Configure MemberTerm relationship
            modelBuilder.Entity<MemberTerm>()
                .HasKey(mt => new { mt.MemberId, mt.TermId });
            modelBuilder.Entity<MemberTerm>()
                .HasOne(mt => mt.Member)
                .WithMany(m => m.MemberTerms)
                .HasForeignKey(mt => mt.MemberId);
            modelBuilder.Entity<MemberTerm>()
                .HasOne(mt => mt.Term)
                .WithMany(t => t.MemberTerms)
                .HasForeignKey(mt => mt.TermId);
        }
    }
}
