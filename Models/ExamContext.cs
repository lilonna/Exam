using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class ExamContext : DbContext
{
    public ExamContext()
    {
    }

    public ExamContext(DbContextOptions<ExamContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicProgram> AcademicPrograms { get; set; }

    public virtual DbSet<AllocationType> AllocationTypes { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<AssessmentType> AssessmentTypes { get; set; }

    public virtual DbSet<ContentType> ContentTypes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseAllocation> CourseAllocations { get; set; }

    public virtual DbSet<CourseContent> CourseContents { get; set; }

    public virtual DbSet<CourseOutline> CourseOutlines { get; set; }

    public virtual DbSet<CourseOutlineResource> CourseOutlineResources { get; set; }

    public virtual DbSet<CourseOutlineSection> CourseOutlineSections { get; set; }

    public virtual DbSet<CourseRegistration> CourseRegistrations { get; set; }

    public virtual DbSet<Diagram> Diagrams { get; set; }

    public virtual DbSet<Discussion> Discussions { get; set; }

    public virtual DbSet<DiscussionReply> DiscussionReplys { get; set; }

    public virtual DbSet<ExamParagraph> ExamParagraphs { get; set; }

    public virtual DbSet<FillTheBlankAnswer> FillTheBlankAnswers { get; set; }

    public virtual DbSet<Instruction> Instructions { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<MatchingOption> MatchingOptions { get; set; }

    public virtual DbSet<MatchingRelation> MatchingRelations { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationReceiver> NotificationReceivers { get; set; }

    public virtual DbSet<NotificationType> NotificationTypes { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionType> QuestionTypes { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<ResourceFile> ResourceFiles { get; set; }

    public virtual DbSet<ResourceOrigin> ResourceOrigins { get; set; }

    public virtual DbSet<ResourceProperty> ResourceProperties { get; set; }

    public virtual DbSet<ResourceType> ResourceTypes { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAnswer> StudentAnswers { get; set; }

    public virtual DbSet<StudentFillBlankAnswer> StudentFillBlankAnswers { get; set; }

    public virtual DbSet<StudentMark> StudentMarks { get; set; }

    public virtual DbSet<StudentMatchingAnswer> StudentMatchingAnswers { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<UnitLevel> UnitLevels { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=ExamConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicProgram>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<AllocationType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.AssessmentType).WithMany(p => p.Assessments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assessments_AssessmentTypes");

            entity.HasOne(d => d.Course).WithMany(p => p.Assessments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assessments_Courses");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Assessments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assessments_Users");

            entity.HasOne(d => d.Section).WithMany(p => p.Assessments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assessments_Sections");
        });

        modelBuilder.Entity<AssessmentType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<ContentType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.AcademicProgram).WithMany(p => p.Courses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_AcademicPrograms");
        });

        modelBuilder.Entity<CourseAllocation>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.AllocationType).WithMany(p => p.CourseAllocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseAllocations_AllocationTypes");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseAllocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseAllocations_Courses");

            entity.HasOne(d => d.Instructor).WithMany(p => p.CourseAllocations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseAllocations_Instructors");
        });

        modelBuilder.Entity<CourseContent>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.ActionByNavigation).WithMany(p => p.CourseContents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseContents_Users");

            entity.HasOne(d => d.ContentType).WithMany(p => p.CourseContents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseContents_ContentTypes");

            entity.HasOne(d => d.Resource).WithMany(p => p.CourseContents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseContents_Resources");

            entity.HasOne(d => d.Section).WithMany(p => p.CourseContents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseContents_Sections");
        });

        modelBuilder.Entity<CourseOutline>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CourseAllocation).WithMany(p => p.CourseOutlines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseOutlines_CourseAllocations");

            entity.HasOne(d => d.Unit).WithMany(p => p.CourseOutlines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseOutlines_Units");
        });

        modelBuilder.Entity<CourseOutlineResource>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CourseOutline).WithMany(p => p.CourseOutlineResources)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseOutlineResources_CourseOutlines");

            entity.HasOne(d => d.Resource).WithMany(p => p.CourseOutlineResources)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseOutlineResources_Resources");
        });

        modelBuilder.Entity<CourseOutlineSection>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CourseOutline).WithMany(p => p.CourseOutlineSections)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseOutlineSections_CourseOutlines");

            entity.HasOne(d => d.Section).WithMany(p => p.CourseOutlineSections)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseOutlineSections_Sections");
        });

        modelBuilder.Entity<CourseRegistration>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CourseAllocation).WithMany(p => p.CourseRegistrations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseRegistrations_CourseAllocations");

            entity.HasOne(d => d.Student).WithMany(p => p.CourseRegistrations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseRegistrations_Students");
        });

        modelBuilder.Entity<Diagram>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Assessment).WithMany(p => p.Diagrams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Diagrams_Assessments");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Diagrams)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Diagrams_Users");
        });

        modelBuilder.Entity<Discussion>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Course).WithMany(p => p.Discussions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Discussions_Courses");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Discussions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Discussions_Users");

            entity.HasOne(d => d.Unit).WithMany(p => p.Discussions).HasConstraintName("FK_Discussions_Units");
        });

        modelBuilder.Entity<DiscussionReply>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscussionReplys_DiscussionReplys");

            entity.HasOne(d => d.User).WithMany(p => p.DiscussionReplies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiscussionReplys_Users");
        });

        modelBuilder.Entity<ExamParagraph>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Assessment).WithMany(p => p.ExamParagraphs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamParagraphs_Assessments");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ExamParagraphs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExamParagraphs_Users");
        });

        modelBuilder.Entity<FillTheBlankAnswer>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Question).WithMany(p => p.FillTheBlankAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FillTheBlankAnswers_Questions");
        });

        modelBuilder.Entity<Instruction>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Assessment).WithMany(p => p.Instructions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Instructions_Assessments");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.User).WithMany(p => p.Instructors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Instructors_Users");
        });

        modelBuilder.Entity<MatchingOption>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Instruction).WithMany(p => p.MatchingOptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchingOptions_Instructions");
        });

        modelBuilder.Entity<MatchingRelation>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Instruction).WithMany(p => p.MatchingRelations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchingRelations_Instructions");

            entity.HasOne(d => d.MatchingOption).WithMany(p => p.MatchingRelations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchingRelations_MatchingOptions");

            entity.HasOne(d => d.Question).WithMany(p => p.MatchingRelations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchingRelations_Questions");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_NotificationTypes");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_Users");
        });

        modelBuilder.Entity<NotificationReceiver>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Notification).WithMany(p => p.NotificationReceivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationReceivers_Notifications");

            entity.HasOne(d => d.User).WithMany(p => p.NotificationReceivers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NotificationReceivers_Users");
        });

        modelBuilder.Entity<NotificationType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Question).WithMany(p => p.Options)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Options_Questions");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_Users");

            entity.HasOne(d => d.Instruction).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_Instructions");

            entity.HasOne(d => d.QuestionType).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_QuestionTypes");
        });

        modelBuilder.Entity<QuestionType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.ActionByNavigation).WithMany(p => p.Resources)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resources_Users");

            entity.HasOne(d => d.Course).WithMany(p => p.Resources)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resources_Courses");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Resources)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resources_Instructors");

            entity.HasOne(d => d.ResourceOrigin).WithMany(p => p.Resources)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resources_ResourceOrigins");

            entity.HasOne(d => d.ResourceType).WithMany(p => p.Resources)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resources_ResourceTypes");
        });

        modelBuilder.Entity<ResourceFile>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Resource).WithMany(p => p.ResourceFiles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResourceFiles_Resources");
        });

        modelBuilder.Entity<ResourceOrigin>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<ResourceProperty>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Resource).WithMany(p => p.ResourceProperties)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResourceProperties_Resources");
        });

        modelBuilder.Entity<ResourceType>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Course).WithMany(p => p.Sections)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sections_Courses");

            entity.HasOne(d => d.Unit).WithMany(p => p.Sections)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sections_Units");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Users");
        });

        modelBuilder.Entity<StudentAnswer>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Option).WithMany(p => p.StudentAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentAnswers_Options");

            entity.HasOne(d => d.Question).WithMany(p => p.StudentAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentAnswers_Questions");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentAnswers_Students");
        });

        modelBuilder.Entity<StudentFillBlankAnswer>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Question).WithMany(p => p.StudentFillBlankAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentFillBlankAnswers_Questions");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentFillBlankAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentFillBlankAnswers_Students");
        });

        modelBuilder.Entity<StudentMark>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Assessment).WithMany(p => p.StudentMarks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentMarks_Assessments");

            entity.HasOne(d => d.GradedByNavigation).WithMany(p => p.StudentMarks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentMarks_Users");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentMarks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentMarks_Students");
        });

        modelBuilder.Entity<StudentMatchingAnswer>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.MatchingOption).WithMany(p => p.StudentMatchingAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentMatchingAnswers_MatchingOptions");

            entity.HasOne(d => d.Question).WithMany(p => p.StudentMatchingAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentMatchingAnswers_Questions");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentMatchingAnswers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentMatchingAnswers_Students");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Course).WithMany(p => p.Units)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Units_Courses");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Units_Units");

            entity.HasOne(d => d.UnitLevel).WithMany(p => p.Units)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Units_UnitLevels");
        });

        modelBuilder.Entity<UnitLevel>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
