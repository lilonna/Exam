using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Option
{
    [Key]
    public int Id { get; set; }

    public int QuestionId { get; set; }

    [StringLength(50)]
    public string Label { get; set; } = null!;

    public string Text { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("Options")]
    public virtual Question Question { get; set; } = null!;

    [InverseProperty("Option")]
    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
}
