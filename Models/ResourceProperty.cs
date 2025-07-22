using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class ResourceProperty
{
    [Key]
    public int Id { get; set; }

    public int ResourceId { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("ResourceId")]
    [InverseProperty("ResourceProperties")]
    public virtual Resource Resource { get; set; } = null!;
}
