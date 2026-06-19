using GRC.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Application.Services.Implementations
{
    public class ViolationService : IViolationService
    {
        public Task<ViolationDto> CreateViolationAsync(CreateViolationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteViolationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ViolationDto> GetViolationByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(List<ViolationDto> data, int total)> GetViolationsAsync(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GetViolationStatisticsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ViolationDto>> SearchViolationsAsync(string companyName, string violationType, decimal? minFine, decimal? maxFine)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateViolationAsync(int id, UpdateViolationDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
