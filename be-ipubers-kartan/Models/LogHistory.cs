using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("LogHistory", Schema = "dbo_tebus")]
public partial class LogHistory
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Table { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Column { get; set; } = null!;

    public int Key { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Nomor { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? Action { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? User { get; set; }

    public int? StatusCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }
}
