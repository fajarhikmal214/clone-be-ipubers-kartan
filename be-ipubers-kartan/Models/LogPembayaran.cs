using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("LogPembayaran", Schema = "dbo_tebus")]
public partial class LogPembayaran
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NoOrder { get; set; } = null!;

    [Unicode(false)]
    public string? Payload { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RequestAt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ResponseAt { get; set; }

    public int? ResponseCode { get; set; }

    [Unicode(false)]
    public string? ResponseMessage { get; set; }
}
