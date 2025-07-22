using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class StudentFillBlankAnswer
{
    [Key]
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public int StudentId { get; set; }

    public int DashOrder { get; set; }

    [StringLength(100)]
    public string Answer { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("StudentFillBlankAnswers")]
    public virtual Question Question { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("StudentFillBlankAnswers")]
    public virtual Student Student { get; set; } = null!;
}
