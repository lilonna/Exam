using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class ResourceFile
{
    [Key]
    public int Id { get; set; }

    public int ResourceId { get; set; }

    [StringLength(100)]
    public string FileName { get; set; } = null!;

    [StringLength(200)]
    public string Url { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("ResourceId")]
    [InverseProperty("ResourceFiles")]
    public virtual Resource Resource { get; set; } = null!;
}
