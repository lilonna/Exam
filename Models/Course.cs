using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Course
{
    [Key]
    public int Id { get; set; }

    public int AcademicProgramId { get; set; }

    public int CourseGuid { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    [StringLength(100)]
    public string Code { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("AcademicProgramId")]
    [InverseProperty("Courses")]
    public virtual AcademicProgram AcademicProgram { get; set; } = null!;

    [InverseProperty("Course")]
    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    [InverseProperty("Course")]
    public virtual ICollection<CourseAllocation> CourseAllocations { get; set; } = new List<CourseAllocation>();

    [InverseProperty("Course")]
    public virtual ICollection<Discussion> Discussions { get; set; } = new List<Discussion>();

    [InverseProperty("Course")]
    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();

    [InverseProperty("Course")]
    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    [InverseProperty("Course")]
    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
