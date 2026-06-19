using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Application.DTOs
{
    public class MinisterDto
    {
        public int Id { get; set; }
        public string FullNameAr { get; set; }
        public string FullNameEn { get; set; }
        public string CivilId { get; set; }
        public int MinistryId { get; set; }
        public string MinistryNameAr { get; set; }
        public string MinistryNameEn { get; set; }
        public string PositionTitleAr { get; set; }
        public string PositionTitleEn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsCurrentMinister { get; set; }
        public string Notes { get; set; }
    }

    public class CreateMinisterDto
    {
        public string FullNameAr { get; set; }
        public string FullNameEn { get; set; }
        public string CivilId { get; set; }
        public int MinistryId { get; set; }
        public string PositionTitleAr { get; set; }
        public string PositionTitleEn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhotoUrl { get; set; }
        public string Notes { get; set; }
    }

    public class UpdateMinisterDto
    {
        public string FullNameAr { get; set; }
        public string FullNameEn { get; set; }
        public int MinistryId { get; set; }
        public string PositionTitleAr { get; set; }
        public string PositionTitleEn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhotoUrl { get; set; }
        public string Notes { get; set; }
    }

    public class MinisterTimelineDto
    {
        public int MinistryId { get; set; }
        public string MinistryNameAr { get; set; }
        public string MinistryNameEn { get; set; }
        public List<MinisterTimelineEntry> Timeline { get; set; }
    }

    public class MinisterTimelineEntry
    {
        public int MinisterId { get; set; }
        public string FullNameAr { get; set; }
        public string FullNameEn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Period { get; set; }
        public int DaysInOffice { get; set; }
    }
}
