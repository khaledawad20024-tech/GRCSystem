using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GRC.Application.DTOs;

namespace GRC.Application.Services
{
    public interface IComplianceService
    {
        // Books
        Task<(List<ComplianceBookDto> data, int total)> GetBooksAsync(int page, int pageSize);
        Task<ComplianceBookDto> GetBookByIdAsync(int id);
        Task<ComplianceBookDto> CreateBookAsync(CreateComplianceBookDto dto);
        Task<bool> UpdateBookAsync(int id, UpdateComplianceBookDto dto);
        Task<bool> DeleteBookAsync(int id);

        // Articles
        Task<(List<ComplianceArticleDto> data, int total)> GetArticlesAsync(int page, int pageSize);
        Task<ComplianceArticleDto> GetArticleByIdAsync(int id);
        Task<ComplianceArticleDto> CreateArticleAsync(CreateComplianceArticleDto dto);
        Task<bool> UpdateArticleAsync(int id, UpdateComplianceArticleDto dto);
        Task<bool> DeleteArticleAsync(int id);

        // Departments
        Task<List<DepartmentDto>> GetDepartmentsAsync();
        Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentDto dto);
    }
}
