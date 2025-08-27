using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("AppVersion")]
public partial class AppVersion
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Version { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime TanggalUpdate { get; set; }

    public short RequiredUpdate { get; set; }

    public short? Apps { get; set; }

    public bool? IsBetaVersion { get; set; }
}
