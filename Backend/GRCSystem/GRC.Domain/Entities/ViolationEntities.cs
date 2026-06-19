using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Domain.Entities
{
    public class Violation
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCRNumber { get; set; }
        public DateTime ViolationDate { get; set; }
        public string ViolationTypeAr { get; set; }
        public string ViolationTypeEn { get; set; }
        public string ArticleTextAr { get; set; }
        public string ArticleTextEn { get; set; }
        public string PenaltyAr { get; set; }
        public string PenaltyEn { get; set; }
        public decimal FineAmount { get; set; }
        public string CurrencyCode { get; set; } = "KWD";
        public string DecisionNumber { get; set; }
        public DateTime? DecisionDate { get; set; }
        public string Status { get; set; } = "Active";
        public string SourceUrl { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<ViolationAttachment> Attachments { get; set; } = new List<ViolationAttachment>();
    }

    public class ViolationAttachment
    {
        public int Id { get; set; }
        public int ViolationId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedDate { get; set; } = DateTime.UtcNow;

        public Violation Violation { get; set; }
    }
}
