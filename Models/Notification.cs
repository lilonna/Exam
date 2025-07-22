using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam.Models;

public partial class Notification
{
    [Key]
    public int Id { get; set; }

    public int NotificationTypeId { get; set; }

    public int UserId { get; set; }

    [StringLength(50)]
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    [InverseProperty("Notification")]
    public virtual ICollection<NotificationReceiver> NotificationReceivers { get; set; } = new List<NotificationReceiver>();

    [ForeignKey("NotificationTypeId")]
    [InverseProperty("Notifications")]
    public virtual NotificationType NotificationType { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Notifications")]
    public virtual User User { get; set; } = null!;
}
