using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class AcademicProgram
{
    [Key]
    public int Id { get; set; }

    public int AcademicProgramGuid { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    [StringLength(50)]
    public string Program { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("AcademicProgram")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
