using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("AppVersion")]
public partial class AppVersion
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string Version { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TanggalUpdate { get; set; }

    public short RequiredUpdate { get; set; }

    [StringLength(2000)]
    [Unicode(false)]
    public string? Deskripsi { get; set; }
}
