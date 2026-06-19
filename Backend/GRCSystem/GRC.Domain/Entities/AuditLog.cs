using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Domain.Entities
{
    public class AuditLog
    {
        public int LogId { get; set; }
        public int? UserId { get; set; }
        public string ActionTypeAr { get; set; }
        public string ActionTypeEn { get; set; }
        public string TableName { get; set; }
        public int? RecordId { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;
        public string IPAddress { get; set; }
        public string Details { get; set; }

        public User User { get; set; }
    }
}
