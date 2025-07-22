using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Unit
{
    [Key]
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int ParentId { get; set; }

    public int UnitLevelId { get; set; }

    [StringLength(50)]
    public string Title { get; set; } = null!;

    public int OrderNumber { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Units")]
    public virtual Course Course { get; set; } = null!;

    [InverseProperty("Unit")]
    public virtual ICollection<CourseOutline> CourseOutlines { get; set; } = new List<CourseOutline>();

    [InverseProperty("Unit")]
    public virtual ICollection<Discussion> Discussions { get; set; } = new List<Discussion>();

    [InverseProperty("Parent")]
    public virtual ICollection<Unit> InverseParent { get; set; } = new List<Unit>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual Unit Parent { get; set; } = null!;

    [InverseProperty("Unit")]
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    [ForeignKey("UnitLevelId")]
    [InverseProperty("Units")]
    public virtual UnitLevel UnitLevel { get; set; } = null!;
}
