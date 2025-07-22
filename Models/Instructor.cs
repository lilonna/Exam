using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Instructor
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int InstructorGuid { get; set; }

    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(50)]
    public string Gender { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("Instructor")]
    public virtual ICollection<CourseAllocation> CourseAllocations { get; set; } = new List<CourseAllocation>();

    [InverseProperty("Instructor")]
    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();

    [ForeignKey("UserId")]
    [InverseProperty("Instructors")]
    public virtual User User { get; set; } = null!;
}
