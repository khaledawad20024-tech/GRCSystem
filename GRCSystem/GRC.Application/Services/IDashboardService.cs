namespace GRC.Application.Services
{
    public interface IDashboardService
    {
        Task<dynamic> GetKPIsAsync();
        Task<dynamic> GetStatisticsAsync();
        Task<List<dynamic>> GetRecentActivitiesAsync(int limit);
        Task<dynamic> GetChartDataAsync(string chartType);
    }
}
