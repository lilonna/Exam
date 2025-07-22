using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class ExamParagraph
{
    [Key]
    public int Id { get; set; }

    public int AssessmentId { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public string Paragraph { get; set; } = null!;

    public int CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("AssessmentId")]
    [InverseProperty("ExamParagraphs")]
    public virtual Assessment Assessment { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ExamParagraphs")]
    public virtual User CreatedByNavigation { get; set; } = null!;
}
