using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Question
{
    [Key]
    public int Id { get; set; }

    public int InstructionId { get; set; }

    public int QuestionTypeId { get; set; }

    public int QuestionNumber { get; set; }

    [Column("Question")]
    public string Question1 { get; set; } = null!;

    public double Weight { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("Questions")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("Question")]
    public virtual ICollection<FillTheBlankAnswer> FillTheBlankAnswers { get; set; } = new List<FillTheBlankAnswer>();

    [ForeignKey("InstructionId")]
    [InverseProperty("Questions")]
    public virtual Instruction Instruction { get; set; } = null!;

    [InverseProperty("Question")]
    public virtual ICollection<MatchingRelation> MatchingRelations { get; set; } = new List<MatchingRelation>();

    [InverseProperty("Question")]
    public virtual ICollection<Option> Options { get; set; } = new List<Option>();

    [ForeignKey("QuestionTypeId")]
    [InverseProperty("Questions")]
    public virtual QuestionType QuestionType { get; set; } = null!;

    [InverseProperty("Question")]
    public virtual ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();

    [InverseProperty("Question")]
    public virtual ICollection<StudentFillBlankAnswer> StudentFillBlankAnswers { get; set; } = new List<StudentFillBlankAnswer>();

    [InverseProperty("Question")]
    public virtual ICollection<StudentMatchingAnswer> StudentMatchingAnswers { get; set; } = new List<StudentMatchingAnswer>();
}
