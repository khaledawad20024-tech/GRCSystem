-- GRC System Database Schema
-- SQL Server 2022

CREATE DATABASE GRCSystem
GO

USE GRCSystem
GO

-- ==================== AUTHENTICATION & USERS ====================

CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(100) UNIQUE NOT NULL,
    FullName NVARCHAR(200) NOT NULL,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    Email NVARCHAR(200) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(20),
    IsActive BIT DEFAULT 1,
    LastLoginDate DATETIME2,
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    UpdatedDate DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) UNIQUE NOT NULL,
    Description NVARCHAR(500),
    CreatedDate DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE UserRoles (
    UserId INT NOT NULL,
    RoleId INT NOT NULL,
    PRIMARY KEY (UserId, RoleId),
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
    FOREIGN KEY (RoleId) REFERENCES Roles(Id) ON DELETE CASCADE
);

CREATE TABLE Permissions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) UNIQUE NOT NULL,
    Description NVARCHAR(500)
);

CREATE TABLE RolePermissions (
    RoleId INT NOT NULL,
    PermissionId INT NOT NULL,
    PRIMARY KEY (RoleId, PermissionId),
    FOREIGN KEY (RoleId) REFERENCES Roles(Id) ON DELETE CASCADE,
    FOREIGN KEY (PermissionId) REFERENCES Permissions(Id) ON DELETE CASCADE
);

-- ==================== COMPLIANCE MATRIX ====================

CREATE TABLE ComplianceBooks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Code NVARCHAR(50) UNIQUE,
    NameAr NVARCHAR(500) NOT NULL,
    NameEn NVARCHAR(500) NOT NULL,
    DescriptionAr NVARCHAR(MAX),
    DescriptionEn NVARCHAR(MAX),
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    UpdatedDate DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE ComplianceChapters (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    BookId INT NOT NULL,
    Code NVARCHAR(50),
    NameAr NVARCHAR(500) NOT NULL,
    NameEn NVARCHAR(500) NOT NULL,
    SequenceNumber INT,
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (BookId) REFERENCES ComplianceBooks(Id) ON DELETE CASCADE
);

CREATE TABLE ComplianceArticles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    BookId INT,
    ChapterId INT,
    ReferenceNo NVARCHAR(100) UNIQUE,
    ArticleNo NVARCHAR(100),
    ArticleTextAr NVARCHAR(MAX) NOT NULL,
    ArticleTextEn NVARCHAR(MAX),
    EffectivePeriod NVARCHAR(200),
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    UpdatedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (BookId) REFERENCES ComplianceBooks(Id),
    FOREIGN KEY (ChapterId) REFERENCES ComplianceChapters(Id)
);

CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NameAr NVARCHAR(300) NOT NULL,
    NameEn NVARCHAR(300) NOT NULL,
    Code NVARCHAR(50) UNIQUE,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE ArticleDepartments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ArticleId INT NOT NULL,
    DepartmentId INT NOT NULL,
    ResponsibilityLevel NVARCHAR(100),
    FOREIGN KEY (ArticleId) REFERENCES ComplianceArticles(Id) ON DELETE CASCADE,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id) ON DELETE CASCADE,
    UNIQUE(ArticleId, DepartmentId)
);

CREATE TABLE Attachments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ArticleId INT,
    ViolationId INT,
    CaseId INT,
    FileName NVARCHAR(500) NOT NULL,
    FileUrl NVARCHAR(MAX) NOT NULL,
    FileSize BIGINT,
    FileType NVARCHAR(50),
    UploadedDate DATETIME2 DEFAULT GETDATE(),
    UploadedBy INT,
    FOREIGN KEY (ArticleId) REFERENCES ComplianceArticles(Id) ON DELETE CASCADE,
    FOREIGN KEY (UploadedBy) REFERENCES Users(Id)
);

-- ==================== CMA VIOLATIONS ====================

CREATE TABLE Violations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CompanyName NVARCHAR(500) NOT NULL,
    CompanyCRNumber NVARCHAR(100),
    ViolationDate DATE NOT NULL,
    ViolationTypeAr NVARCHAR(1000) NOT NULL,
    ViolationTypeEn NVARCHAR(1000),
    ArticleTextAr NVARCHAR(MAX),
    ArticleTextEn NVARCHAR(MAX),
    PenaltyAr NVARCHAR(MAX) NOT NULL,
    PenaltyEn NVARCHAR(MAX),
    FineAmount DECIMAL(18,3),
    CurrencyCode NVARCHAR(10) DEFAULT 'KWD',
    DecisionNumber NVARCHAR(100),
    DecisionDate DATE,
    Status NVARCHAR(100) DEFAULT 'Active',
    SourceUrl NVARCHAR(2000),
    Notes NVARCHAR(MAX),
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    UpdatedDate DATETIME2 DEFAULT GETDATE()
);

-- ==================== MINISTRIES & MINISTERS ====================

CREATE TABLE Ministries (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NameAr NVARCHAR(300) NOT NULL,
    NameEn NVARCHAR(300) NOT NULL,
    Code NVARCHAR(50) UNIQUE,
    LogoUrl NVARCHAR(2000),
    EstablishedYear INT,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE Ministers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullNameAr NVARCHAR(300) NOT NULL,
    FullNameEn NVARCHAR(300),
    CivilId VARCHAR(20) UNIQUE,
    MinistryId INT NOT NULL,
    PositionTitleAr NVARCHAR(300),
    PositionTitleEn NVARCHAR(300),
    StartDate DATE NOT NULL,
    EndDate DATE,
    PhotoUrl NVARCHAR(2000),
    IsCurrentMinister BIT DEFAULT 0,
    Notes NVARCHAR(MAX),
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    UpdatedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (MinistryId) REFERENCES Ministries(Id) ON DELETE CASCADE
);

-- ==================== NATIONAL ASSEMBLY ====================

CREATE TABLE ParliamentaryTerms (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TermNumberAr NVARCHAR(100) NOT NULL,
    TermNumberEn NVARCHAR(100),
    StartDate DATE NOT NULL,
    EndDate DATE,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE ElectoralDistricts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DistrictNumberAr NVARCHAR(100) NOT NULL,
    DistrictNumberEn NVARCHAR(100),
    DistrictNameAr NVARCHAR(200),
    DistrictNameEn NVARCHAR(200),
    CreatedDate DATETIME2 DEFAULT GETDATE()
);

CREATE TABLE NationalAssemblyMembers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullNameAr NVARCHAR(300) NOT NULL,
    FullNameEn NVARCHAR(300),
    CivilId VARCHAR(20) UNIQUE,
    ElectoralDistrictId INT,
    MembershipStatus NVARCHAR(100),
    ElectionYear INT,
    StartDate DATE NOT NULL,
    EndDate DATE,
    PhotoUrl NVARCHAR(2000),
    Notes NVARCHAR(MAX),
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    UpdatedDate DATETIME2 DEFAULT GETDATE(),
    FOREIGN KEY (ElectoralDistrictId) REFERENCES ElectoralDistricts(Id)
);

CREATE TABLE MemberTerms (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MemberId INT NOT NULL,
    TermId INT NOT NULL,
    PositionNameAr NVARCHAR(200),
    PositionNameEn NVARCHAR(200),
    CommitteeName NVARCHAR(200),
    FOREIGN KEY (MemberId) REFERENCES NationalAssemblyMembers(Id) ON DELETE CASCADE,
    FOREIGN KEY (TermId) REFERENCES ParliamentaryTerms(Id) ON DELETE CASCADE,
    UNIQUE(MemberId, TermId)
);

-- ==================== CITIZENSHIP CASES ====================

CREATE TABLE CitizenshipCases (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullNameAr NVARCHAR(300) NOT NULL,
    FullNameEn NVARCHAR(300),
    CivilId VARCHAR(20) UNIQUE,
    DecisionNumber NVARCHAR(100) UNIQUE NOT NULL,
    DecisionDate DATE NOT NULL,
    DecisionAuthority NVARCHAR(300),
    LegalBasisAr NVARCHAR(MAX),
    LegalBasisEn NVARCHAR(MAX),
    Status NVARCHAR(100),
    CaseStatusAr NVARCHAR(100),
    CaseStatusEn NVARCHAR(100),
    Notes NVARCHAR(MAX),
    SourceUrl NVARCHAR(2000),
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    UpdatedDate DATETIME2 DEFAULT GETDATE()
);

-- ==================== AUDIT LOGS ====================

CREATE TABLE AuditLogs (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT,
    ActionTypeAr NVARCHAR(100),
    ActionTypeEn NVARCHAR(100),
    TableName NVARCHAR(100),
    RecordId INT,
    OldValues NVARCHAR(MAX),
    NewValues NVARCHAR(MAX),
    ActionDate DATETIME2 DEFAULT GETDATE(),
    IPAddress NVARCHAR(50),
    Details NVARCHAR(MAX),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- ==================== INDEXES ====================

CREATE INDEX IX_Ministers_FullName ON Ministers(FullNameAr);
CREATE INDEX IX_Ministers_CivilId ON Ministers(CivilId);
CREATE INDEX IX_Ministers_MinistryId ON Ministers(MinistryId);
CREATE INDEX IX_Ministers_StartDate ON Ministers(StartDate);

CREATE INDEX IX_AssemblyMembers_FullName ON NationalAssemblyMembers(FullNameAr);
CREATE INDEX IX_AssemblyMembers_CivilId ON NationalAssemblyMembers(CivilId);
CREATE INDEX IX_AssemblyMembers_District ON NationalAssemblyMembers(ElectoralDistrictId);

CREATE INDEX IX_CitizenshipCases_FullName ON CitizenshipCases(FullNameAr);
CREATE INDEX IX_CitizenshipCases_CivilId ON CitizenshipCases(CivilId);
CREATE INDEX IX_CitizenshipCases_DecisionDate ON CitizenshipCases(DecisionDate);

CREATE INDEX IX_Violations_CompanyName ON Violations(CompanyName);
CREATE INDEX IX_Violations_ViolationDate ON Violations(ViolationDate);
CREATE INDEX IX_Violations_FineAmount ON Violations(FineAmount);

CREATE INDEX IX_ComplianceArticles_ReferenceNo ON ComplianceArticles(ReferenceNo);
CREATE INDEX IX_ComplianceArticles_BookId ON ComplianceArticles(BookId);

CREATE INDEX IX_Users_UserName ON Users(UserName);
CREATE INDEX IX_AuditLogs_ActionDate ON AuditLogs(ActionDate);

-- ==================== SEED DATA ====================

INSERT INTO Roles (Name, Description) VALUES 
('Admin', 'مسؤول النظام'),
('Manager', 'مدير'),
('Viewer', 'عارض'),
('Auditor', 'مدقق');

INSERT INTO Permissions (Name, Description) VALUES
('Create', 'إنشاء'),
('Read', 'قراءة'),
('Update', 'تحديث'),
('Delete', 'حذف'),
('Export', 'تصدير'),
('Audit', 'تدقيق');

INSERT INTO Ministries (NameAr, NameEn, Code) VALUES
('وزارة المالية', 'Ministry of Finance', 'MOF'),
('وزارة الصحة', 'Ministry of Health', 'MOH'),
('وزارة التعليم', 'Ministry of Education', 'MOE'),
('وزارة الداخلية', 'Ministry of Interior', 'MOI'),
('وزارة الدفاع', 'Ministry of Defense', 'MOD');

INSERT INTO Departments (NameAr, NameEn, Code) VALUES
('قسم الامتثال', 'Compliance Department', 'CD001'),
('قسم التدقيق', 'Audit Department', 'AD001'),
('قسم القانون', 'Legal Department', 'LD001'),
('قسم العمليات', 'Operations Department', 'OD001');

PRINT 'Database created successfully!';
