namespace GRC.Application.Services
{
    public interface IAuditService
    {
        Task LogActionAsync(int userId, string actionTypeEn, string actionTypeAr, string tableName, int? recordId, string details);
        Task<List<dynamic>> GetAuditLogsAsync(int page, int pageSize);
    }
}
