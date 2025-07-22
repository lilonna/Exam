using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class CourseContent
{
    [Key]
    public int Id { get; set; }

    public int SectionId { get; set; }

    public int ContentTypeId { get; set; }

    public int ResourceId { get; set; }

    public int OrderNumber { get; set; }

    public string Description { get; set; } = null!;

    public int ActionBy { get; set; }

    public bool IsPublished { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("ActionBy")]
    [InverseProperty("CourseContents")]
    public virtual User ActionByNavigation { get; set; } = null!;

    [ForeignKey("ContentTypeId")]
    [InverseProperty("CourseContents")]
    public virtual ContentType ContentType { get; set; } = null!;

    [ForeignKey("ResourceId")]
    [InverseProperty("CourseContents")]
    public virtual Resource Resource { get; set; } = null!;

    [ForeignKey("SectionId")]
    [InverseProperty("CourseContents")]
    public virtual Section Section { get; set; } = null!;
}
