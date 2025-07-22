using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class MatchingRelation
{
    [Key]
    public int Id { get; set; }

    public int InstructionId { get; set; }

    public int QuestionId { get; set; }

    public int MatchingOptionId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("InstructionId")]
    [InverseProperty("MatchingRelations")]
    public virtual Instruction Instruction { get; set; } = null!;

    [ForeignKey("MatchingOptionId")]
    [InverseProperty("MatchingRelations")]
    public virtual MatchingOption MatchingOption { get; set; } = null!;

    [ForeignKey("QuestionId")]
    [InverseProperty("MatchingRelations")]
    public virtual Question Question { get; set; } = null!;
}
