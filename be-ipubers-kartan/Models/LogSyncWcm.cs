using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("LogSyncWcm", Schema = "dbo_tebus")]
public partial class LogSyncWcm
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NoOrder { get; set; } = null!;

    [Unicode(false)]
    public string? Payload { get; set; }

    public int? HttpResponseCode { get; set; }

    [Unicode(false)]
    public string? Response { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RequestAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ResponseAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
