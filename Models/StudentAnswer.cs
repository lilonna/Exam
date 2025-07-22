using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class StudentAnswer
{
    [Key]
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public int StudentId { get; set; }

    public int OptionId { get; set; }

    public bool IsSelected { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("OptionId")]
    [InverseProperty("StudentAnswers")]
    public virtual Option Option { get; set; } = null!;

    [ForeignKey("QuestionId")]
    [InverseProperty("StudentAnswers")]
    public virtual Question Question { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("StudentAnswers")]
    public virtual Student Student { get; set; } = null!;
}
