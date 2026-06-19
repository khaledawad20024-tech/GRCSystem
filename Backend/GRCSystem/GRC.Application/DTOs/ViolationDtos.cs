using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Application.DTOs
{
    public class ViolationDto
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
        public string CurrencyCode { get; set; }
        public string DecisionNumber { get; set; }
        public DateTime? DecisionDate { get; set; }
        public string Status { get; set; }
        public string SourceUrl { get; set; }
        public string Notes { get; set; }
        public List<AttachmentDto> Attachments { get; set; }
    }

    public class CreateViolationDto
    {
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
        public string CurrencyCode { get; set; }
        public string DecisionNumber { get; set; }
        public DateTime? DecisionDate { get; set; }
        public string SourceUrl { get; set; }
        public string Notes { get; set; }
    }

    public class UpdateViolationDto
    {
        public string CompanyName { get; set; }
        public string CompanyCRNumber { get; set; }
        public string ViolationTypeAr { get; set; }
        public string ViolationTypeEn { get; set; }
        public string PenaltyAr { get; set; }
        public string PenaltyEn { get; set; }
        public decimal FineAmount { get; set; }
        public string Status { get; set; }
    }

    public class AttachmentDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadedDate { get; set; }
    }
}
