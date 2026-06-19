using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GRC.Application.Services.Implementations.AuthService;

namespace GRC.Application.Services.Implementations
{
    public class AuthService : IAuditService
    {
        public Task<List<dynamic>> GetAuditLogsAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task LogActionAsync(int userId, string actionTypeEn, string actionTypeAr, string tableName, int? recordId, string details)
        {
            throw new NotImplementedException();
        }
    }
}
