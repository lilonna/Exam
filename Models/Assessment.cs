using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Assessment
{
    [Key]
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int AssessmentTypeId { get; set; }

    public int SectionId { get; set; }

    public double Weight { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DurationMinutes { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("AssessmentTypeId")]
    [InverseProperty("Assessments")]
    public virtual AssessmentType AssessmentType { get; set; } = null!;

    [ForeignKey("CourseId")]
    [InverseProperty("Assessments")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("Assessments")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("Assessment")]
    public virtual ICollection<Diagram> Diagrams { get; set; } = new List<Diagram>();

    [InverseProperty("Assessment")]
    public virtual ICollection<ExamParagraph> ExamParagraphs { get; set; } = new List<ExamParagraph>();

    [ForeignKey("SectionId")]
    [InverseProperty("Assessments")]
    public virtual Section Section { get; set; } = null!;

    [InverseProperty("Assessment")]
    public virtual ICollection<StudentMark> StudentMarks { get; set; } = new List<StudentMark>();
}
