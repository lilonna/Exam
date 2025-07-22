using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class StudentMatchingAnswer
{
    [Key]
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int QuestionId { get; set; }

    public int MatchingOptionId { get; set; }

    public bool IsCorrect { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("MatchingOptionId")]
    [InverseProperty("StudentMatchingAnswers")]
    public virtual MatchingOption MatchingOption { get; set; } = null!;

    [ForeignKey("QuestionId")]
    [InverseProperty("StudentMatchingAnswers")]
    public virtual Question Question { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("StudentMatchingAnswers")]
    public virtual Student Student { get; set; } = null!;
}
