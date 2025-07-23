using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class QuestionType
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("QuestionType")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
