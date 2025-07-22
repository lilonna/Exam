using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class DiscussionReply
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ParentId { get; set; }

    public string Reply { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ReplyDate { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("Parent")]
    public virtual ICollection<DiscussionReply> InverseParent { get; set; } = new List<DiscussionReply>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual DiscussionReply Parent { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("DiscussionReplies")]
    public virtual User User { get; set; } = null!;
}
