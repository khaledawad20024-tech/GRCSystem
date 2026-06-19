using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Domain.Entities
{
    public class CitizenshipCase
    {
        public int Id { get; set; }
        public string FullNameAr { get; set; }
        public string FullNameEn { get; set; }
        public string CivilId { get; set; }
        public string DecisionNumber { get; set; }
        public DateTime DecisionDate { get; set; }
        public string DecisionAuthority { get; set; }
        public string LegalBasisAr { get; set; }
        public string LegalBasisEn { get; set; }
        public string Status { get; set; }
        public string CaseStatusAr { get; set; }
        public string CaseStatusEn { get; set; }
        public string Notes { get; set; }
        public string SourceUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<CitizenshipAttachment> Attachments { get; set; } = new List<CitizenshipAttachment>();
    }

    public class CitizenshipAttachment
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedDate { get; set; } = DateTime.UtcNow;

        public CitizenshipCase Case { get; set; }
    }
}
