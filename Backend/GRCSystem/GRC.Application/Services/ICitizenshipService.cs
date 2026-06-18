namespace GRC.Application.Services
{
    public interface ICitizenshipService
    {
        Task<dynamic> GetCasesAsync(int page, int pageSize);
        Task<dynamic> GetCaseByIdAsync(int id);
        Task<List<dynamic>> SearchCasesAsync(string nameAr, string status, DateTime? fromDate, DateTime? toDate);
    }
}
