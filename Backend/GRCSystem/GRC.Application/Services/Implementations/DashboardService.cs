using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Application.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        public Task<dynamic> GetChartDataAsync(string chartType)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetKPIsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<dynamic>> GetRecentActivitiesAsync(int limit)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetStatisticsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
