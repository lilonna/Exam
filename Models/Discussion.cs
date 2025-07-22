using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Discussion
{
    [Key]
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int? UnitId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Discussions")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("Discussions")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("UnitId")]
    [InverseProperty("Discussions")]
    public virtual Unit? Unit { get; set; }
}
