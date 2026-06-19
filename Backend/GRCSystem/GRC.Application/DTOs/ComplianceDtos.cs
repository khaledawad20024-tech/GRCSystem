using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Application.DTOs
{
    public class ComplianceBookDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public bool IsActive { get; set; }
        public int ArticleCount { get; set; }
    }

    public class CreateComplianceBookDto
    {
        public string Code { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
    }

    public class UpdateComplianceBookDto
    {
        public string Code { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public bool IsActive { get; set; }
    }

    public class ComplianceArticleDto
    {
        public int Id { get; set; }
        public string ReferenceNo { get; set; }
        public int? BookId { get; set; }
        public int? ChapterId { get; set; }
        public string ArticleNo { get; set; }
        public string ArticleTextAr { get; set; }
        public string ArticleTextEn { get; set; }
        public string EffectivePeriod { get; set; }
        public bool IsActive { get; set; }
        public List<DepartmentDto> Departments { get; set; }
    }

    public class CreateComplianceArticleDto
    {
        public int? BookId { get; set; }
        public int? ChapterId { get; set; }
        public string ReferenceNo { get; set; }
        public string ArticleNo { get; set; }
        public string ArticleTextAr { get; set; }
        public string ArticleTextEn { get; set; }
        public string EffectivePeriod { get; set; }
        public List<int> DepartmentIds { get; set; }
    }

    public class UpdateComplianceArticleDto
    {
        public string ReferenceNo { get; set; }
        public string ArticleNo { get; set; }
        public string ArticleTextAr { get; set; }
        public string ArticleTextEn { get; set; }
        public string EffectivePeriod { get; set; }
        public bool IsActive { get; set; }
    }

    public class DepartmentDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
    }

    public class CreateDepartmentDto
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
    }
}

