using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Instruction
{
    [Key]
    public int Id { get; set; }

    public int QuestionTypeId { get; set; }

    public double Weight { get; set; }

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int AssessmentId { get; set; }

    [ForeignKey("AssessmentId")]
    [InverseProperty("Instructions")]
    public virtual Assessment Assessment { get; set; } = null!;

    [InverseProperty("Instruction")]
    public virtual ICollection<MatchingOption> MatchingOptions { get; set; } = new List<MatchingOption>();

    [InverseProperty("Instruction")]
    public virtual ICollection<MatchingRelation> MatchingRelations { get; set; } = new List<MatchingRelation>();

    [InverseProperty("Instruction")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
