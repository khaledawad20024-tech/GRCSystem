using GRC.Application.DTOs;


namespace GRC.Application.Services
{
    public interface IViolationService
    {
        Task<(List<ViolationDto> data, int total)> GetViolationsAsync(int page, int pageSize);
        Task<ViolationDto> GetViolationByIdAsync(int id);
        Task<ViolationDto> CreateViolationAsync(CreateViolationDto dto);
        Task<bool> UpdateViolationAsync(int id, UpdateViolationDto dto);
        Task<bool> DeleteViolationAsync(int id);
        Task<List<ViolationDto>> SearchViolationsAsync(string companyName, string violationType, decimal? minFine, decimal? maxFine);
        Task<dynamic> GetViolationStatisticsAsync();
    }
}
