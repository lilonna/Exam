using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Student
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int StudentGuid { get; set; }

    public int IdNumber { get; set; }

    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [StringLength(50)]
    public string Gender { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<CourseRegistration> CourseRegistrations { get; set; } = new List<CourseRegistration>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentFillBlankAnswer> StudentFillBlankAnswers { get; set; } = new List<StudentFillBlankAnswer>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentMark> StudentMarks { get; set; } = new List<StudentMark>();

    [InverseProperty("Student")]
    public virtual ICollection<StudentMatchingAnswer> StudentMatchingAnswers { get; set; } = new List<StudentMatchingAnswer>();

    [ForeignKey("UserId")]
    [InverseProperty("Students")]
    public virtual User User { get; set; } = null!;
}
