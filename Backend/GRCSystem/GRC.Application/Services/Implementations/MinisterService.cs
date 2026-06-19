using GRC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Application.Services.Implementations
{
    public class MinisterService : IMinisterService
    {
        public Task<MinisterDto> CreateMinisterAsync(CreateMinisterDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMinisterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MinisterDto> GetMinisterByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(List<MinisterDto> data, int total)> GetMinistersAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<MinisterTimelineDto> GetMinisterTimelineByMinistryAsync(int ministryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MinisterDto>> SearchMinistersAsync(string nameAr, int? ministryId, DateTime? fromDate, DateTime? toDate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMinisterAsync(int id, UpdateMinisterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
