using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Domain.Entities
{
    public class Ministry
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string LogoUrl { get; set; }
        public int? EstablishedYear { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<Minister> Ministers { get; set; } = new List<Minister>();
    }

    public class Minister
    {
        public int Id { get; set; }
        public string FullNameAr { get; set; }
        public string FullNameEn { get; set; }
        public string CivilId { get; set; }
        public int MinistryId { get; set; }
        public string PositionTitleAr { get; set; }
        public string PositionTitleEn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsCurrentMinister { get; set; } = false;
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        public Ministry Ministry { get; set; }
    }
}
