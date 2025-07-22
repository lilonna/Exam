using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Diagram
{
    [Key]
    public int Id { get; set; }

    public int AssessmentId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    [StringLength(200)]
    public string Url { get; set; } = null!;

    public int CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("AssessmentId")]
    [InverseProperty("Diagrams")]
    public virtual Assessment Assessment { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("Diagrams")]
    public virtual User CreatedByNavigation { get; set; } = null!;
}
