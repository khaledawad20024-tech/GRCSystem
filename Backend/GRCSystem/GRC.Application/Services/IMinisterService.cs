using GRC.Application.DTOs;



namespace GRC.Application.Services
{
    public interface IMinisterService
    {
        Task<(List<MinisterDto> data, int total)> GetMinistersAsync(int page, int pageSize);
        Task<MinisterDto> GetMinisterByIdAsync(int id);
        Task<MinisterTimelineDto> GetMinisterTimelineByMinistryAsync(int ministryId);
        Task<MinisterDto> CreateMinisterAsync(CreateMinisterDto dto);
        Task<bool> UpdateMinisterAsync(int id, UpdateMinisterDto dto);
        Task<bool> DeleteMinisterAsync(int id);
        Task<List<MinisterDto>> SearchMinistersAsync(string nameAr, int? ministryId, DateTime? fromDate, DateTime? toDate);
    }
}


