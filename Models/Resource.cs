using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Resource
{
    [Key]
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int ResourceTypeId { get; set; }

    public int ResourceOriginId { get; set; }

    public int InstructorId { get; set; }

    public string Description { get; set; } = null!;

    [StringLength(200)]
    public string Url { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public int ActionBy { get; set; }

    public bool IsPublished { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("ActionBy")]
    [InverseProperty("Resources")]
    public virtual User ActionByNavigation { get; set; } = null!;

    [ForeignKey("CourseId")]
    [InverseProperty("Resources")]
    public virtual Course Course { get; set; } = null!;

    [InverseProperty("Resource")]
    public virtual ICollection<CourseContent> CourseContents { get; set; } = new List<CourseContent>();

    [InverseProperty("Resource")]
    public virtual ICollection<CourseOutlineResource> CourseOutlineResources { get; set; } = new List<CourseOutlineResource>();

    [ForeignKey("InstructorId")]
    [InverseProperty("Resources")]
    public virtual Instructor Instructor { get; set; } = null!;

    [InverseProperty("Resource")]
    public virtual ICollection<ResourceFile> ResourceFiles { get; set; } = new List<ResourceFile>();

    [ForeignKey("ResourceOriginId")]
    [InverseProperty("Resources")]
    public virtual ResourceOrigin ResourceOrigin { get; set; } = null!;

    [InverseProperty("Resource")]
    public virtual ICollection<ResourceProperty> ResourceProperties { get; set; } = new List<ResourceProperty>();

    [ForeignKey("ResourceTypeId")]
    [InverseProperty("Resources")]
    public virtual ResourceType ResourceType { get; set; } = null!;
}
