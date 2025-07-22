using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class CourseOutline
{
    [Key]
    public int Id { get; set; }

    public int UnitId { get; set; }

    public int CourseAllocationId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    public int NumberOfDays { get; set; }

    public bool IsDone { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("CourseAllocationId")]
    [InverseProperty("CourseOutlines")]
    public virtual CourseAllocation CourseAllocation { get; set; } = null!;

    [InverseProperty("CourseOutline")]
    public virtual ICollection<CourseOutlineResource> CourseOutlineResources { get; set; } = new List<CourseOutlineResource>();

    [InverseProperty("CourseOutline")]
    public virtual ICollection<CourseOutlineSection> CourseOutlineSections { get; set; } = new List<CourseOutlineSection>();

    [ForeignKey("UnitId")]
    [InverseProperty("CourseOutlines")]
    public virtual Unit Unit { get; set; } = null!;
}
