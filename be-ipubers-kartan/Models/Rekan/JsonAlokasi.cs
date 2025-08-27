using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

/// <summary>
/// response api eAlokasi
/// </summary>
[Table("json_alokasi")]
[Index("CreatedAt", Name = "json_alokasi_createdAt_index", AllDescending = true)]
[Index("IdRetailer", Name = "json_alokasi_idRetailer_index")]
public partial class JsonAlokasi
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("response")]
    public string? Response { get; set; }

    [Column("idRetailer")]
    [StringLength(12)]
    [Unicode(false)]
    public string? IdRetailer { get; set; }

    [Column("createdBy")]
    [StringLength(6)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column("createdAt", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }
}
