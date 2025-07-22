using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class StudentMark
{
    [Key]
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int AssessmentId { get; set; }

    public double TotalMark { get; set; }

    public int GradedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime GradedAt { get; set; }

    public string Feedback { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("AssessmentId")]
    [InverseProperty("StudentMarks")]
    public virtual Assessment Assessment { get; set; } = null!;

    [ForeignKey("GradedBy")]
    [InverseProperty("StudentMarks")]
    public virtual User GradedByNavigation { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("StudentMarks")]
    public virtual Student Student { get; set; } = null!;
}
