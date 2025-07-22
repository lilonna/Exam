using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Section
{
    [Key]
    public int Id { get; set; }

    public int UnitId { get; set; }

    public int CourseId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public int OrderNumber { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("Section")]
    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    [ForeignKey("CourseId")]
    [InverseProperty("Sections")]
    public virtual Course Course { get; set; } = null!;

    [InverseProperty("Section")]
    public virtual ICollection<CourseContent> CourseContents { get; set; } = new List<CourseContent>();

    [InverseProperty("Section")]
    public virtual ICollection<CourseOutlineSection> CourseOutlineSections { get; set; } = new List<CourseOutlineSection>();

    [ForeignKey("UnitId")]
    [InverseProperty("Sections")]
    public virtual Unit Unit { get; set; } = null!;
}
