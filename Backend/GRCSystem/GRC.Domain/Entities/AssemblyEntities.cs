using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Domain.Entities
{
    public class ParliamentaryTerm
    {
        public int Id { get; set; }
        public string TermNumberAr { get; set; }
        public string TermNumberEn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<MemberTerm> MemberTerms { get; set; } = new List<MemberTerm>();
    }

    public class ElectoralDistrict
    {
        public int Id { get; set; }
        public string DistrictNumberAr { get; set; }
        public string DistrictNumberEn { get; set; }
        public string DistrictNameAr { get; set; }
        public string DistrictNameEn { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<NationalAssemblyMember> Members { get; set; } = new List<NationalAssemblyMember>();
    }

    public class NationalAssemblyMember
    {
        public int Id { get; set; }
        public string FullNameAr { get; set; }
        public string FullNameEn { get; set; }
        public string CivilId { get; set; }
        public int? ElectoralDistrictId { get; set; }
        public string MembershipStatus { get; set; }
        public int? ElectionYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhotoUrl { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public ElectoralDistrict ElectoralDistrict { get; set; }
        public ICollection<MemberTerm> MemberTerms { get; set; } = new List<MemberTerm>();
    }

    public class MemberTerm
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int TermId { get; set; }
        public string PositionNameAr { get; set; }
        public string PositionNameEn { get; set; }
        public string CommitteeName { get; set; }

        public NationalAssemblyMember Member { get; set; }
        public ParliamentaryTerm Term { get; set; }
    }
}
