namespace VD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.vd_AboutUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        IsTop = c.Boolean(nullable: false),
                        IsShowHompage = c.Boolean(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_AboutUsTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        AboutUsId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_AboutUs", t => t.AboutUsId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .Index(t => t.AboutUsId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_Lang",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Code = c.String(maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 150),
                        Flag = c.String(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_Candidate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 254, unicode: false),
                        Password = c.String(),
                        Name = c.String(),
                        Website = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        GenderId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        CVActiveId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_City", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Gender", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.GenderId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.vd_City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rate = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_Job",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company_name = c.String(),
                        Company_email = c.String(),
                        Company_location = c.String(),
                        Company_phone = c.String(),
                        Company_address = c.String(),
                        Title = c.String(),
                        JobDescription = c.String(),
                        AreKoreanCandidates = c.Boolean(nullable: false),
                        WorkLocation = c.String(),
                        ContactPerson = c.String(),
                        Consultant_Fullname = c.String(),
                        Consultant_Email = c.String(),
                        Consultant_Phone = c.String(),
                        IsHotJob = c.Boolean(nullable: false),
                        IsNewJob = c.Boolean(nullable: false),
                        EmployyeId = c.Int(nullable: false),
                        YearExperienceId = c.Int(nullable: false),
                        JobIndustryId = c.Int(nullable: false),
                        JobLevelId = c.Int(nullable: false),
                        DegreesId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        JobWorkTypeId = c.Int(nullable: false),
                        SalaryWageId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_City", t => t.CityId, cascadeDelete: false)
                .ForeignKey("dbo.vd_Degrees", t => t.DegreesId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Employee", t => t.EmployyeId, cascadeDelete: true)
                .ForeignKey("dbo.vd_JobIndustry", t => t.JobIndustryId, cascadeDelete: true)
                .ForeignKey("dbo.vd_JobLevel", t => t.JobLevelId, cascadeDelete: true)
                .ForeignKey("dbo.vd_JobWorkType", t => t.JobWorkTypeId, cascadeDelete: true)
                .ForeignKey("dbo.vd_SalaryWage", t => t.SalaryWageId, cascadeDelete: true)
                .ForeignKey("dbo.vd_YearExperience", t => t.YearExperienceId, cascadeDelete: true)
                .Index(t => t.EmployyeId)
                .Index(t => t.YearExperienceId)
                .Index(t => t.JobIndustryId)
                .Index(t => t.JobLevelId)
                .Index(t => t.DegreesId)
                .Index(t => t.CityId)
                .Index(t => t.JobWorkTypeId)
                .Index(t => t.SalaryWageId);
            
            CreateTable(
                "dbo.vd_CVApplyJob",
                c => new
                    {
                        JobId = c.Int(nullable: false),
                        CVId = c.Int(nullable: false),
                        DateApply = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CandidatesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobId, t.CVId })
                .ForeignKey("dbo.vd_CV", t => t.CVId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Job", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId)
                .Index(t => t.CVId);
            
            CreateTable(
                "dbo.vd_CV",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Message = c.String(),
                        GenderId = c.Int(nullable: false),
                        HitView = c.Int(nullable: false),
                        AreKoreanCandidates = c.Boolean(nullable: false),
                        JobTitle = c.String(nullable: false, maxLength: 1000),
                        CityId = c.Int(nullable: false),
                        JobIndustryId = c.Int(nullable: false),
                        YearExperienceId = c.Int(nullable: false),
                        SalaryWageId = c.Int(nullable: false),
                        DegreesId = c.Int(nullable: false),
                        CandidateId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Candidate", t => t.CandidateId, cascadeDelete: false)
                .ForeignKey("dbo.vd_City", t => t.CityId, cascadeDelete: false)
                .ForeignKey("dbo.vd_Degrees", t => t.DegreesId, cascadeDelete: false)
                .ForeignKey("dbo.vd_Gender", t => t.GenderId, cascadeDelete: false)
                .ForeignKey("dbo.vd_JobIndustry", t => t.JobIndustryId, cascadeDelete: false)
                .ForeignKey("dbo.vd_SalaryWage", t => t.SalaryWageId, cascadeDelete: false)
                .ForeignKey("dbo.vd_YearExperience", t => t.YearExperienceId, cascadeDelete: false)
                .Index(t => t.GenderId)
                .Index(t => t.CityId)
                .Index(t => t.JobIndustryId)
                .Index(t => t.YearExperienceId)
                .Index(t => t.SalaryWageId)
                .Index(t => t.DegreesId)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.vd_CVAttachFile",
                c => new
                    {
                        CVId = c.Int(nullable: false),
                        FileData = c.Binary(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        LastDownloaded = c.DateTime(),
                        TotalDownload = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CVId)
                .ForeignKey("dbo.vd_CV", t => t.CVId)
                .Index(t => t.CVId);
            
            CreateTable(
                "dbo.vd_Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_DegreesTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DegreesId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Degrees", t => t.DegreesId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .Index(t => t.DegreesId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_Gender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_GenderTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GenderId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Gender", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .Index(t => t.GenderId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_JobIndustry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_JobIndustryTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LangId = c.Int(nullable: false),
                        JobIndustryId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_JobIndustry", t => t.JobIndustryId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .Index(t => t.LangId)
                .Index(t => t.JobIndustryId);
            
            CreateTable(
                "dbo.vd_SalaryWage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.Int(nullable: false),
                        To = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        IsRename = c.Boolean(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_SalaryWageTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SalaryWageId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .ForeignKey("dbo.vd_SalaryWage", t => t.SalaryWageId, cascadeDelete: true)
                .Index(t => t.SalaryWageId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_YearExperience",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_YearExperienceTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        YearExperienceId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .ForeignKey("dbo.vd_YearExperience", t => t.YearExperienceId, cascadeDelete: true)
                .Index(t => t.YearExperienceId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 254, unicode: false),
                        Password = c.String(),
                        Company = c.String(),
                        Phone = c.String(),
                        AboutCompany = c.String(),
                        Website = c.String(),
                        Address = c.String(),
                        ContactPerson = c.String(),
                        EmployeeServiceId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_EmployeeService", t => t.EmployeeServiceId, cascadeDelete: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.EmployeeServiceId);
            
            CreateTable(
                "dbo.vd_EmployeeService",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_EmployeeServiceTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmployeeServiceId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_EmployeeService", t => t.EmployeeServiceId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .Index(t => t.EmployeeServiceId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_RememberMeEmployees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CookieKey = c.String(),
                        CookieValue = c.String(),
                        Time = c.DateTime(),
                        TimeExpires = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.vd_JobLevel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_JobLevelTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        JobLevelId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_JobLevel", t => t.JobLevelId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .Index(t => t.JobLevelId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_JobWorkType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_JobWorkTypeTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        JobWorkTypeId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_JobWorkType", t => t.JobWorkTypeId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .Index(t => t.JobWorkTypeId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_RememberMeCandidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidateId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CookieKey = c.String(),
                        CookieValue = c.String(),
                        Time = c.DateTime(),
                        TimeExpires = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Candidate", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.vd_Conf",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 254, unicode: false),
                        Description = c.String(),
                        IsHtmlEditor = c.Boolean(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        IsMulLang = c.Boolean(nullable: false),
                        Content = c.String(),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Key, unique: true);
            
            CreateTable(
                "dbo.vd_ConfTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(storeType: "ntext"),
                        ConfId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Conf", t => t.ConfId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .Index(t => t.ConfId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_Counter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_IndustryFocus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        IndustryFocusCatId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_IndustryFocusCat", t => t.IndustryFocusCatId, cascadeDelete: true)
                .Index(t => t.IndustryFocusCatId);
            
            CreateTable(
                "dbo.vd_IndustryFocusCat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Rate = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_IndustryFocusCatTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IndustryFocusCatId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_IndustryFocusCat", t => t.IndustryFocusCatId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .Index(t => t.IndustryFocusCatId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_IndustryFocusTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IndustryFocusId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_IndustryFocus", t => t.IndustryFocusId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .Index(t => t.IndustryFocusId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.JobDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        Location = c.String(),
                        CompanyEmail = c.String(nullable: false),
                        CompanyPhone = c.String(nullable: false),
                        Adrress = c.String(),
                        JobTitle = c.String(nullable: false),
                        Description = c.String(),
                        ContactPerson = c.String(),
                        CityId = c.Int(nullable: false),
                        JobIndustryId = c.Int(nullable: false),
                        JobLevelId = c.Int(nullable: false),
                        JobWorkTypeId = c.Int(nullable: false),
                        SalaryWageId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_City", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.vd_Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.vd_JobIndustry", t => t.JobIndustryId, cascadeDelete: true)
                .ForeignKey("dbo.vd_JobLevel", t => t.JobLevelId, cascadeDelete: true)
                .ForeignKey("dbo.vd_JobWorkType", t => t.JobWorkTypeId, cascadeDelete: true)
                .ForeignKey("dbo.vd_SalaryWage", t => t.SalaryWageId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.JobIndustryId)
                .Index(t => t.JobLevelId)
                .Index(t => t.JobWorkTypeId)
                .Index(t => t.SalaryWageId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.vd_Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        LogTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_LogType", t => t.LogTypeId, cascadeDelete: true)
                .Index(t => t.LogTypeId);
            
            CreateTable(
                "dbo.vd_LogException",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ExceptionMsg = c.String(),
                        ExceptionType = c.String(),
                        ExceptionSource = c.String(),
                        ExceptionURL = c.String(),
                        Logdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Log", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.vd_LogType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_OurClient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImagePath = c.String(),
                        Order = c.Int(nullable: false),
                        OurClientCatId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_OurClientCat", t => t.OurClientCatId, cascadeDelete: true)
                .Index(t => t.OurClientCatId);
            
            CreateTable(
                "dbo.vd_OurClientCat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Rate = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_OurClientCatTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OurClientCatId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .ForeignKey("dbo.vd_OurClientCat", t => t.OurClientCatId, cascadeDelete: true)
                .Index(t => t.OurClientCatId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_OurService",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        IsTop = c.Boolean(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_OurServiceTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        OurServiceId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .ForeignKey("dbo.vd_OurService", t => t.OurServiceId, cascadeDelete: true)
                .Index(t => t.OurServiceId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_Permission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_Role",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                        UserStatusId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.vd_UserStatus", t => t.UserStatusId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserStatusId);
            
            CreateTable(
                "dbo.vd_RememberMe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CookieKey = c.String(),
                        CookieValue = c.String(),
                        Time = c.DateTime(),
                        TimeExpires = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.vd_UserStatus",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_Setting",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        sys_email = c.String(),
                        sys_email_robot = c.String(),
                        sys_email_robot_pw = c.String(),
                        smpt_port = c.Int(nullable: false),
                        smpt_host = c.String(),
                        smpt_enable_ssl = c.Boolean(nullable: false),
                        smpt_use_default_credentials = c.Boolean(nullable: false),
                        ddl_row_per_page = c.String(),
                        max_num_top_job = c.Int(nullable: false),
                        max_korean_candidates_hompage = c.Int(nullable: false),
                        row_per_page = c.Int(nullable: false),
                        rpp_job = c.Int(nullable: false),
                        rpp_cv = c.Int(nullable: false),
                        rpp_industry_focus = c.Int(nullable: false),
                        rpp_cv_apply_job = c.Int(nullable: false),
                        rpp_search_resume = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_Slider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Order = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_TipForCandidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        IsTop = c.Boolean(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_TipForCandidatesTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        TipForCandidatesId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .ForeignKey("dbo.vd_TipForCandidates", t => t.TipForCandidatesId, cascadeDelete: true)
                .Index(t => t.TipForCandidatesId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.vd_TipForEmployee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        IsTop = c.Boolean(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vd_TipForEmployeeTrans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        TipForEmployeeId = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        LangId = c.Int(nullable: false),
                        IsSys = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.vd_Lang", t => t.LangId, cascadeDelete: true)
                .ForeignKey("dbo.vd_TipForEmployee", t => t.TipForEmployeeId, cascadeDelete: true)
                .Index(t => t.TipForEmployeeId)
                .Index(t => t.LangId);
            
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Permission_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Permission_Id })
                .ForeignKey("dbo.vd_Role", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.vd_Permission", t => t.Permission_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Permission_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.vd_TipForEmployeeTrans", "TipForEmployeeId", "dbo.vd_TipForEmployee");
            DropForeignKey("dbo.vd_TipForEmployeeTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_TipForCandidatesTrans", "TipForCandidatesId", "dbo.vd_TipForCandidates");
            DropForeignKey("dbo.vd_TipForCandidatesTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_User", "UserStatusId", "dbo.vd_UserStatus");
            DropForeignKey("dbo.vd_User", "RoleId", "dbo.vd_Role");
            DropForeignKey("dbo.vd_RememberMe", "UserID", "dbo.vd_User");
            DropForeignKey("dbo.RolePermissions", "Permission_Id", "dbo.vd_Permission");
            DropForeignKey("dbo.RolePermissions", "Role_Id", "dbo.vd_Role");
            DropForeignKey("dbo.vd_OurServiceTrans", "OurServiceId", "dbo.vd_OurService");
            DropForeignKey("dbo.vd_OurServiceTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_OurClient", "OurClientCatId", "dbo.vd_OurClientCat");
            DropForeignKey("dbo.vd_OurClientCatTrans", "OurClientCatId", "dbo.vd_OurClientCat");
            DropForeignKey("dbo.vd_OurClientCatTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_Log", "LogTypeId", "dbo.vd_LogType");
            DropForeignKey("dbo.vd_LogException", "Id", "dbo.vd_Log");
            DropForeignKey("dbo.JobDescriptions", "SalaryWageId", "dbo.vd_SalaryWage");
            DropForeignKey("dbo.JobDescriptions", "JobWorkTypeId", "dbo.vd_JobWorkType");
            DropForeignKey("dbo.JobDescriptions", "JobLevelId", "dbo.vd_JobLevel");
            DropForeignKey("dbo.JobDescriptions", "JobIndustryId", "dbo.vd_JobIndustry");
            DropForeignKey("dbo.JobDescriptions", "EmployeeId", "dbo.vd_Employee");
            DropForeignKey("dbo.JobDescriptions", "CityId", "dbo.vd_City");
            DropForeignKey("dbo.vd_IndustryFocusTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_IndustryFocusTrans", "IndustryFocusId", "dbo.vd_IndustryFocus");
            DropForeignKey("dbo.vd_IndustryFocus", "IndustryFocusCatId", "dbo.vd_IndustryFocusCat");
            DropForeignKey("dbo.vd_IndustryFocusCatTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_IndustryFocusCatTrans", "IndustryFocusCatId", "dbo.vd_IndustryFocusCat");
            DropForeignKey("dbo.vd_ConfTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_ConfTrans", "ConfId", "dbo.vd_Conf");
            DropForeignKey("dbo.vd_RememberMeCandidates", "CandidateId", "dbo.vd_Candidate");
            DropForeignKey("dbo.vd_Candidate", "GenderId", "dbo.vd_Gender");
            DropForeignKey("dbo.vd_Candidate", "CityId", "dbo.vd_City");
            DropForeignKey("dbo.vd_Job", "YearExperienceId", "dbo.vd_YearExperience");
            DropForeignKey("dbo.vd_Job", "SalaryWageId", "dbo.vd_SalaryWage");
            DropForeignKey("dbo.vd_JobWorkTypeTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_JobWorkTypeTrans", "JobWorkTypeId", "dbo.vd_JobWorkType");
            DropForeignKey("dbo.vd_Job", "JobWorkTypeId", "dbo.vd_JobWorkType");
            DropForeignKey("dbo.vd_Job", "JobLevelId", "dbo.vd_JobLevel");
            DropForeignKey("dbo.vd_JobLevelTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_JobLevelTrans", "JobLevelId", "dbo.vd_JobLevel");
            DropForeignKey("dbo.vd_Job", "JobIndustryId", "dbo.vd_JobIndustry");
            DropForeignKey("dbo.vd_RememberMeEmployees", "EmployeeId", "dbo.vd_Employee");
            DropForeignKey("dbo.vd_Job", "EmployyeId", "dbo.vd_Employee");
            DropForeignKey("dbo.vd_Employee", "EmployeeServiceId", "dbo.vd_EmployeeService");
            DropForeignKey("dbo.vd_EmployeeServiceTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_EmployeeServiceTrans", "EmployeeServiceId", "dbo.vd_EmployeeService");
            DropForeignKey("dbo.vd_Job", "DegreesId", "dbo.vd_Degrees");
            DropForeignKey("dbo.vd_CVApplyJob", "JobId", "dbo.vd_Job");
            DropForeignKey("dbo.vd_CV", "YearExperienceId", "dbo.vd_YearExperience");
            DropForeignKey("dbo.vd_YearExperienceTrans", "YearExperienceId", "dbo.vd_YearExperience");
            DropForeignKey("dbo.vd_YearExperienceTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_CV", "SalaryWageId", "dbo.vd_SalaryWage");
            DropForeignKey("dbo.vd_SalaryWageTrans", "SalaryWageId", "dbo.vd_SalaryWage");
            DropForeignKey("dbo.vd_SalaryWageTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_CV", "JobIndustryId", "dbo.vd_JobIndustry");
            DropForeignKey("dbo.vd_JobIndustryTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_JobIndustryTrans", "JobIndustryId", "dbo.vd_JobIndustry");
            DropForeignKey("dbo.vd_CV", "GenderId", "dbo.vd_Gender");
            DropForeignKey("dbo.vd_GenderTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_GenderTrans", "GenderId", "dbo.vd_Gender");
            DropForeignKey("dbo.vd_CV", "DegreesId", "dbo.vd_Degrees");
            DropForeignKey("dbo.vd_DegreesTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_DegreesTrans", "DegreesId", "dbo.vd_Degrees");
            DropForeignKey("dbo.vd_CVAttachFile", "CVId", "dbo.vd_CV");
            DropForeignKey("dbo.vd_CVApplyJob", "CVId", "dbo.vd_CV");
            DropForeignKey("dbo.vd_CV", "CityId", "dbo.vd_City");
            DropForeignKey("dbo.vd_CV", "CandidateId", "dbo.vd_Candidate");
            DropForeignKey("dbo.vd_Job", "CityId", "dbo.vd_City");
            DropForeignKey("dbo.vd_AboutUsTrans", "LangId", "dbo.vd_Lang");
            DropForeignKey("dbo.vd_AboutUsTrans", "AboutUsId", "dbo.vd_AboutUs");
            DropIndex("dbo.RolePermissions", new[] { "Permission_Id" });
            DropIndex("dbo.RolePermissions", new[] { "Role_Id" });
            DropIndex("dbo.vd_TipForEmployeeTrans", new[] { "LangId" });
            DropIndex("dbo.vd_TipForEmployeeTrans", new[] { "TipForEmployeeId" });
            DropIndex("dbo.vd_TipForCandidatesTrans", new[] { "LangId" });
            DropIndex("dbo.vd_TipForCandidatesTrans", new[] { "TipForCandidatesId" });
            DropIndex("dbo.vd_RememberMe", new[] { "UserID" });
            DropIndex("dbo.vd_User", new[] { "UserStatusId" });
            DropIndex("dbo.vd_User", new[] { "RoleId" });
            DropIndex("dbo.vd_OurServiceTrans", new[] { "LangId" });
            DropIndex("dbo.vd_OurServiceTrans", new[] { "OurServiceId" });
            DropIndex("dbo.vd_OurClientCatTrans", new[] { "LangId" });
            DropIndex("dbo.vd_OurClientCatTrans", new[] { "OurClientCatId" });
            DropIndex("dbo.vd_OurClient", new[] { "OurClientCatId" });
            DropIndex("dbo.vd_LogException", new[] { "Id" });
            DropIndex("dbo.vd_Log", new[] { "LogTypeId" });
            DropIndex("dbo.JobDescriptions", new[] { "EmployeeId" });
            DropIndex("dbo.JobDescriptions", new[] { "SalaryWageId" });
            DropIndex("dbo.JobDescriptions", new[] { "JobWorkTypeId" });
            DropIndex("dbo.JobDescriptions", new[] { "JobLevelId" });
            DropIndex("dbo.JobDescriptions", new[] { "JobIndustryId" });
            DropIndex("dbo.JobDescriptions", new[] { "CityId" });
            DropIndex("dbo.vd_IndustryFocusTrans", new[] { "LangId" });
            DropIndex("dbo.vd_IndustryFocusTrans", new[] { "IndustryFocusId" });
            DropIndex("dbo.vd_IndustryFocusCatTrans", new[] { "LangId" });
            DropIndex("dbo.vd_IndustryFocusCatTrans", new[] { "IndustryFocusCatId" });
            DropIndex("dbo.vd_IndustryFocus", new[] { "IndustryFocusCatId" });
            DropIndex("dbo.vd_ConfTrans", new[] { "LangId" });
            DropIndex("dbo.vd_ConfTrans", new[] { "ConfId" });
            DropIndex("dbo.vd_Conf", new[] { "Key" });
            DropIndex("dbo.vd_RememberMeCandidates", new[] { "CandidateId" });
            DropIndex("dbo.vd_JobWorkTypeTrans", new[] { "LangId" });
            DropIndex("dbo.vd_JobWorkTypeTrans", new[] { "JobWorkTypeId" });
            DropIndex("dbo.vd_JobLevelTrans", new[] { "LangId" });
            DropIndex("dbo.vd_JobLevelTrans", new[] { "JobLevelId" });
            DropIndex("dbo.vd_RememberMeEmployees", new[] { "EmployeeId" });
            DropIndex("dbo.vd_EmployeeServiceTrans", new[] { "LangId" });
            DropIndex("dbo.vd_EmployeeServiceTrans", new[] { "EmployeeServiceId" });
            DropIndex("dbo.vd_Employee", new[] { "EmployeeServiceId" });
            DropIndex("dbo.vd_Employee", new[] { "Email" });
            DropIndex("dbo.vd_YearExperienceTrans", new[] { "LangId" });
            DropIndex("dbo.vd_YearExperienceTrans", new[] { "YearExperienceId" });
            DropIndex("dbo.vd_SalaryWageTrans", new[] { "LangId" });
            DropIndex("dbo.vd_SalaryWageTrans", new[] { "SalaryWageId" });
            DropIndex("dbo.vd_JobIndustryTrans", new[] { "JobIndustryId" });
            DropIndex("dbo.vd_JobIndustryTrans", new[] { "LangId" });
            DropIndex("dbo.vd_GenderTrans", new[] { "LangId" });
            DropIndex("dbo.vd_GenderTrans", new[] { "GenderId" });
            DropIndex("dbo.vd_DegreesTrans", new[] { "LangId" });
            DropIndex("dbo.vd_DegreesTrans", new[] { "DegreesId" });
            DropIndex("dbo.vd_CVAttachFile", new[] { "CVId" });
            DropIndex("dbo.vd_CV", new[] { "CandidateId" });
            DropIndex("dbo.vd_CV", new[] { "DegreesId" });
            DropIndex("dbo.vd_CV", new[] { "SalaryWageId" });
            DropIndex("dbo.vd_CV", new[] { "YearExperienceId" });
            DropIndex("dbo.vd_CV", new[] { "JobIndustryId" });
            DropIndex("dbo.vd_CV", new[] { "CityId" });
            DropIndex("dbo.vd_CV", new[] { "GenderId" });
            DropIndex("dbo.vd_CVApplyJob", new[] { "CVId" });
            DropIndex("dbo.vd_CVApplyJob", new[] { "JobId" });
            DropIndex("dbo.vd_Job", new[] { "SalaryWageId" });
            DropIndex("dbo.vd_Job", new[] { "JobWorkTypeId" });
            DropIndex("dbo.vd_Job", new[] { "CityId" });
            DropIndex("dbo.vd_Job", new[] { "DegreesId" });
            DropIndex("dbo.vd_Job", new[] { "JobLevelId" });
            DropIndex("dbo.vd_Job", new[] { "JobIndustryId" });
            DropIndex("dbo.vd_Job", new[] { "YearExperienceId" });
            DropIndex("dbo.vd_Job", new[] { "EmployyeId" });
            DropIndex("dbo.vd_Candidate", new[] { "CityId" });
            DropIndex("dbo.vd_Candidate", new[] { "GenderId" });
            DropIndex("dbo.vd_Candidate", new[] { "Email" });
            DropIndex("dbo.vd_AboutUsTrans", new[] { "LangId" });
            DropIndex("dbo.vd_AboutUsTrans", new[] { "AboutUsId" });
            DropTable("dbo.RolePermissions");
            DropTable("dbo.vd_TipForEmployeeTrans");
            DropTable("dbo.vd_TipForEmployee");
            DropTable("dbo.vd_TipForCandidatesTrans");
            DropTable("dbo.vd_TipForCandidates");
            DropTable("dbo.vd_Slider");
            DropTable("dbo.vd_Setting");
            DropTable("dbo.vd_UserStatus");
            DropTable("dbo.vd_RememberMe");
            DropTable("dbo.vd_User");
            DropTable("dbo.vd_Role");
            DropTable("dbo.vd_Permission");
            DropTable("dbo.vd_OurServiceTrans");
            DropTable("dbo.vd_OurService");
            DropTable("dbo.vd_OurClientCatTrans");
            DropTable("dbo.vd_OurClientCat");
            DropTable("dbo.vd_OurClient");
            DropTable("dbo.vd_LogType");
            DropTable("dbo.vd_LogException");
            DropTable("dbo.vd_Log");
            DropTable("dbo.JobDescriptions");
            DropTable("dbo.vd_IndustryFocusTrans");
            DropTable("dbo.vd_IndustryFocusCatTrans");
            DropTable("dbo.vd_IndustryFocusCat");
            DropTable("dbo.vd_IndustryFocus");
            DropTable("dbo.vd_Counter");
            DropTable("dbo.vd_ConfTrans");
            DropTable("dbo.vd_Conf");
            DropTable("dbo.vd_RememberMeCandidates");
            DropTable("dbo.vd_JobWorkTypeTrans");
            DropTable("dbo.vd_JobWorkType");
            DropTable("dbo.vd_JobLevelTrans");
            DropTable("dbo.vd_JobLevel");
            DropTable("dbo.vd_RememberMeEmployees");
            DropTable("dbo.vd_EmployeeServiceTrans");
            DropTable("dbo.vd_EmployeeService");
            DropTable("dbo.vd_Employee");
            DropTable("dbo.vd_YearExperienceTrans");
            DropTable("dbo.vd_YearExperience");
            DropTable("dbo.vd_SalaryWageTrans");
            DropTable("dbo.vd_SalaryWage");
            DropTable("dbo.vd_JobIndustryTrans");
            DropTable("dbo.vd_JobIndustry");
            DropTable("dbo.vd_GenderTrans");
            DropTable("dbo.vd_Gender");
            DropTable("dbo.vd_DegreesTrans");
            DropTable("dbo.vd_Degrees");
            DropTable("dbo.vd_CVAttachFile");
            DropTable("dbo.vd_CV");
            DropTable("dbo.vd_CVApplyJob");
            DropTable("dbo.vd_Job");
            DropTable("dbo.vd_City");
            DropTable("dbo.vd_Candidate");
            DropTable("dbo.vd_Lang");
            DropTable("dbo.vd_AboutUsTrans");
            DropTable("dbo.vd_AboutUs");
        }
    }
}
