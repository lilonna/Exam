using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(200)]
    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    [InverseProperty("ActionByNavigation")]
    public virtual ICollection<CourseContent> CourseContents { get; set; } = new List<CourseContent>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Diagram> Diagrams { get; set; } = new List<Diagram>();

    [InverseProperty("User")]
    public virtual ICollection<DiscussionReply> DiscussionReplies { get; set; } = new List<DiscussionReply>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Discussion> Discussions { get; set; } = new List<Discussion>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<ExamParagraph> ExamParagraphs { get; set; } = new List<ExamParagraph>();

    [InverseProperty("User")]
    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    [InverseProperty("User")]
    public virtual ICollection<NotificationReceiver> NotificationReceivers { get; set; } = new List<NotificationReceiver>();

    [InverseProperty("User")]
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    [InverseProperty("CreatedByNavigation")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    [InverseProperty("ActionByNavigation")]
    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();

    [InverseProperty("GradedByNavigation")]
    public virtual ICollection<StudentMark> StudentMarks { get; set; } = new List<StudentMark>();

    [InverseProperty("User")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
