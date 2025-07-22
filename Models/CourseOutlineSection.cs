using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class CourseOutlineSection
{
    [Key]
    public int Id { get; set; }

    public int CourseOutlineId { get; set; }

    public int SectionId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("CourseOutlineId")]
    [InverseProperty("CourseOutlineSections")]
    public virtual CourseOutline CourseOutline { get; set; } = null!;

    [ForeignKey("SectionId")]
    [InverseProperty("CourseOutlineSections")]
    public virtual Section Section { get; set; } = null!;
}
