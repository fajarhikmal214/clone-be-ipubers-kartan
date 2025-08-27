using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("LogSMS")]
[Index("Id", Name = "LogSMS_Id_uindex", IsUnique = true)]
public partial class LogSm
{
    [Key]
    public int Id { get; set; }

    public int SendType { get; set; }

    public int SendVia { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string From { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string Recepient { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string? Message { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Result { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
}
