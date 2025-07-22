using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class CourseOutlineResource
{
    [Key]
    public int Id { get; set; }

    public int ResourceId { get; set; }

    public int CourseOutlineId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("CourseOutlineId")]
    [InverseProperty("CourseOutlineResources")]
    public virtual CourseOutline CourseOutline { get; set; } = null!;

    [ForeignKey("ResourceId")]
    [InverseProperty("CourseOutlineResources")]
    public virtual Resource Resource { get; set; } = null!;
}
