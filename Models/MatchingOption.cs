using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class MatchingOption
{
    [Key]
    public int Id { get; set; }

    public int InstructionId { get; set; }

    public int OrderNumber { get; set; }

    [StringLength(50)]
    public string Label { get; set; } = null!;

    public string AnswerOption { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("InstructionId")]
    [InverseProperty("MatchingOptions")]
    public virtual Instruction Instruction { get; set; } = null!;

    [InverseProperty("MatchingOption")]
    public virtual ICollection<MatchingRelation> MatchingRelations { get; set; } = new List<MatchingRelation>();

    [InverseProperty("MatchingOption")]
    public virtual ICollection<StudentMatchingAnswer> StudentMatchingAnswers { get; set; } = new List<StudentMatchingAnswer>();
}
