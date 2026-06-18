namespace GRC.Application.Services
{
    public interface IAssemblyMemberService
    {
        Task<dynamic> GetMembersAsync(int page, int pageSize);
        Task<dynamic> GetMemberByIdAsync(int id);
        Task<List<dynamic>> SearchMembersAsync(string nameAr, string districtNumber, DateTime? fromDate, DateTime? toDate);
    }
}
