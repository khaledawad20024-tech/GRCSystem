using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GRC.Application.DTOs;


using GRC.Domain.Entities;
using GRC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GRC.Application.Services.Implementations
{
    public class ComplianceService : IComplianceService
    {
        private readonly GrcDbContext _context;

        public ComplianceService(GrcDbContext context)
        {
            _context = context;
        }

        // ===== BOOKS =====
        public async Task<(List<ComplianceBookDto> data, int total)> GetBooksAsync(int page, int pageSize)
        {
            var query = _context.ComplianceBooks.AsQueryable();
            var total = await query.CountAsync();
            var books = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(b => new ComplianceBookDto
                {
                    Id = b.Id,
                    Code = b.Code,
                    NameAr = b.NameAr,
                    NameEn = b.NameEn,
                    DescriptionAr = b.DescriptionAr,
                    DescriptionEn = b.DescriptionEn,
                    IsActive = b.IsActive,
                    ArticleCount = b.Articles.Count
                })
                .ToListAsync();

            return (books, total);
        }

        public async Task<ComplianceBookDto> GetBookByIdAsync(int id)
        {
            var book = await _context.ComplianceBooks
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) return null;

            return new ComplianceBookDto
            {
                Id = book.Id,
                Code = book.Code,
                NameAr = book.NameAr,
                NameEn = book.NameEn,
                DescriptionAr = book.DescriptionAr,
                DescriptionEn = book.DescriptionEn,
                IsActive = book.IsActive,
                ArticleCount = book.Articles.Count
            };
        }

        public async Task<ComplianceBookDto> CreateBookAsync(CreateComplianceBookDto dto)
        {
            var book = new ComplianceBook
            {
                Code = dto.Code,
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
                DescriptionAr = dto.DescriptionAr,
                DescriptionEn = dto.DescriptionEn,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            _context.ComplianceBooks.Add(book);
            await _context.SaveChangesAsync();

            return new ComplianceBookDto
            {
                Id = book.Id,
                Code = book.Code,
                NameAr = book.NameAr,
                NameEn = book.NameEn,
                DescriptionAr = book.DescriptionAr,
                DescriptionEn = book.DescriptionEn,
                IsActive = book.IsActive,
                ArticleCount = 0
            };
        }

        public async Task<bool> UpdateBookAsync(int id, UpdateComplianceBookDto dto)
        {
            var book = await _context.ComplianceBooks.FindAsync(id);
            if (book == null) return false;

            book.Code = dto.Code;
            book.NameAr = dto.NameAr;
            book.NameEn = dto.NameEn;
            book.DescriptionAr = dto.DescriptionAr;
            book.DescriptionEn = dto.DescriptionEn;
            book.IsActive = dto.IsActive;
            book.UpdatedDate = DateTime.UtcNow;

            _context.ComplianceBooks.Update(book);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.ComplianceBooks.FindAsync(id);
            if (book == null) return false;

            _context.ComplianceBooks.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }

        // ===== ARTICLES =====
        public async Task<(List<ComplianceArticleDto> data, int total)> GetArticlesAsync(int page, int pageSize)
        {
            var query = _context.ComplianceArticles.AsQueryable();
            var total = await query.CountAsync();

            var articles = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(a => a.ArticleDepartments)
                .ThenInclude(ad => ad.Department)
                .Select(a => new ComplianceArticleDto
                {
                    Id = a.Id,
                    ReferenceNo = a.ReferenceNo,
                    BookId = a.BookId,
                    ChapterId = a.ChapterId,
                    ArticleNo = a.ArticleNo,
                    ArticleTextAr = a.ArticleTextAr,
                    ArticleTextEn = a.ArticleTextEn,
                    EffectivePeriod = a.EffectivePeriod,
                    IsActive = a.IsActive,
                    Departments = a.ArticleDepartments
                        .Select(ad => new DepartmentDto
                        {
                            Id = ad.DepartmentId,
                            NameAr = ad.Department.NameAr,
                            NameEn = ad.Department.NameEn,
                            Code = ad.Department.Code
                        })
                        .ToList()
                })
                .ToListAsync();

            return (articles, total);
        }

        public async Task<ComplianceArticleDto> GetArticleByIdAsync(int id)
        {
            var article = await _context.ComplianceArticles
                .Include(a => a.ArticleDepartments)
                .ThenInclude(ad => ad.Department)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (article == null) return null;

            return new ComplianceArticleDto
            {
                Id = article.Id,
                ReferenceNo = article.ReferenceNo,
                BookId = article.BookId,
                ChapterId = article.ChapterId,
                ArticleNo = article.ArticleNo,
                ArticleTextAr = article.ArticleTextAr,
                ArticleTextEn = article.ArticleTextEn,
                EffectivePeriod = article.EffectivePeriod,
                IsActive = article.IsActive,
                Departments = article.ArticleDepartments
                    .Select(ad => new DepartmentDto
                    {
                        Id = ad.DepartmentId,
                        NameAr = ad.Department.NameAr,
                        NameEn = ad.Department.NameEn,
                        Code = ad.Department.Code
                    })
                    .ToList()
            };
        }

        public async Task<ComplianceArticleDto> CreateArticleAsync(CreateComplianceArticleDto dto)
        {
            var article = new ComplianceArticle
            {
                BookId = dto.BookId,
                ChapterId = dto.ChapterId,
                ReferenceNo = dto.ReferenceNo,
                ArticleNo = dto.ArticleNo,
                ArticleTextAr = dto.ArticleTextAr,
                ArticleTextEn = dto.ArticleTextEn,
                EffectivePeriod = dto.EffectivePeriod,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            _context.ComplianceArticles.Add(article);
            await _context.SaveChangesAsync();

            // Add department mappings
            if (dto.DepartmentIds != null && dto.DepartmentIds.Count > 0)
            {
                var articleDepts = dto.DepartmentIds.Select(deptId => new ArticleDepartment
                {
                    ArticleId = article.Id,
                    DepartmentId = deptId
                }).ToList();

                _context.ArticleDepartments.AddRange(articleDepts);
                await _context.SaveChangesAsync();
            }

            return new ComplianceArticleDto
            {
                Id = article.Id,
                ReferenceNo = article.ReferenceNo,
                ArticleTextAr = article.ArticleTextAr,
                EffectivePeriod = article.EffectivePeriod,
                IsActive = article.IsActive
            };
        }

        public async Task<bool> UpdateArticleAsync(int id, UpdateComplianceArticleDto dto)
        {
            var article = await _context.ComplianceArticles.FindAsync(id);
            if (article == null) return false;

            article.ReferenceNo = dto.ReferenceNo;
            article.ArticleNo = dto.ArticleNo;
            article.ArticleTextAr = dto.ArticleTextAr;
            article.ArticleTextEn = dto.ArticleTextEn;
            article.EffectivePeriod = dto.EffectivePeriod;
            article.IsActive = dto.IsActive;
            article.UpdatedDate = DateTime.UtcNow;

            _context.ComplianceArticles.Update(article);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            var article = await _context.ComplianceArticles.FindAsync(id);
            if (article == null) return false;

            _context.ComplianceArticles.Remove(article);
            await _context.SaveChangesAsync();

            return true;
        }

        // ===== DEPARTMENTS =====
        public async Task<List<DepartmentDto>> GetDepartmentsAsync()
        {
            return await _context.Departments
                .Where(d => d.IsActive)
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    NameAr = d.NameAr,
                    NameEn = d.NameEn,
                    Code = d.Code
                })
                .ToListAsync();
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentDto dto)
        {
            var department = new Department
            {
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
                Code = dto.Code,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return new DepartmentDto
            {
                Id = department.Id,
                NameAr = department.NameAr,
                NameEn = department.NameEn,
                Code = department.Code
            };
        }
    }
}