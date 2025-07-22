using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class CourseAllocation
{
    [Key]
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int InstructorId { get; set; }

    public int CourseAllocationGuid { get; set; }

    public int AllocationTypeId { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("AllocationTypeId")]
    [InverseProperty("CourseAllocations")]
    public virtual AllocationType AllocationType { get; set; } = null!;

    [ForeignKey("CourseId")]
    [InverseProperty("CourseAllocations")]
    public virtual Course Course { get; set; } = null!;

    [InverseProperty("CourseAllocation")]
    public virtual ICollection<CourseOutline> CourseOutlines { get; set; } = new List<CourseOutline>();

    [InverseProperty("CourseAllocation")]
    public virtual ICollection<CourseRegistration> CourseRegistrations { get; set; } = new List<CourseRegistration>();

    [ForeignKey("InstructorId")]
    [InverseProperty("CourseAllocations")]
    public virtual Instructor Instructor { get; set; } = null!;
}
