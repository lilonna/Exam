using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class FillTheBlankAnswer
{
    [Key]
    public int Id { get; set; }

    public int QuestionId { get; set; }

    public int DashOrder { get; set; }

    public string CorrectAnswer { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("FillTheBlankAnswers")]
    public virtual Question Question { get; set; } = null!;
}
