using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Domain.Entities
{
    public class ComplianceBook
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<ComplianceChapter> Chapters { get; set; } = new List<ComplianceChapter>();
        public ICollection<ComplianceArticle> Articles { get; set; } = new List<ComplianceArticle>();
    }

    public class ComplianceChapter
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Code { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int? SequenceNumber { get; set; }
        public bool IsActive { get; set; } = true;

        public ComplianceBook Book { get; set; }
        public ICollection<ComplianceArticle> Articles { get; set; } = new List<ComplianceArticle>();
    }

    public class ComplianceArticle
    {
        [Key]
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? ChapterId { get; set; }
        public string ReferenceNo { get; set; }
        public string ArticleNo { get; set; }
        public string ArticleTextAr { get; set; }
        public string ArticleTextEn { get; set; }
        public string EffectivePeriod { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public ComplianceBook Book { get; set; }
        public ComplianceChapter Chapter { get; set; }
        public ICollection<ArticleDepartment> ArticleDepartments { get; set; } = new List<ArticleDepartment>();
        public ICollection<Attachments> Attachments { get; set; } = new List<Attachments>();
    }

    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<ArticleDepartment> ArticleDepartments { get; set; } = new List<ArticleDepartment>();
    }

    public class ArticleDepartment
    {
        [Key]
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int DepartmentId { get; set; }
        public string ResponsibilityLevel { get; set; }

        public ComplianceArticle Article { get; set; }
        public Department Department { get; set; }
    }

    public class Attachments
    {
        [Key]
        public int Id { get; set; }
        public int? ArticleId { get; set; }
        public int? ViolationId { get; set; }
        public int? CaseId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }
        public DateTime UploadedDate { get; set; } = DateTime.UtcNow;
        public int? UploadedBy { get; set; }

        public ComplianceArticle Article { get; set; }
        public User UploadedByUser { get; set; }
    }
}
