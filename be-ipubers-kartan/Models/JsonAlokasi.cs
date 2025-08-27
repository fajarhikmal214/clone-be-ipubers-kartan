using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

/// <summary>
/// response api eAlokasi
/// </summary>
[Table("json_alokasi")]
[Index("CreatedAt", Name = "json_alokasi_createdAt_index", AllDescending = true)]
public partial class JsonAlokasi
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("response")]
    public string? Response { get; set; }

    [Column("createdBy")]
    [StringLength(6)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Catatan { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? IdRetailer { get; set; }
}
