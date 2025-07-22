using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class NotificationReceiver
{
    [Key]
    public int Id { get; set; }

    public int NotificationId { get; set; }

    public int UserId { get; set; }

    public bool IsRead { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [ForeignKey("NotificationId")]
    [InverseProperty("NotificationReceivers")]
    public virtual Notification Notification { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("NotificationReceivers")]
    public virtual User User { get; set; } = null!;
}
