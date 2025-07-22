using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class CourseRegistration
{
    [Key]
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseAllocationId { get; set; }

    public int CourseRegitrationGuid { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RegisteredDate { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("CourseAllocationId")]
    [InverseProperty("CourseRegistrations")]
    public virtual CourseAllocation CourseAllocation { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("CourseRegistrations")]
    public virtual Student Student { get; set; } = null!;
}
