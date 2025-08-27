using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("MasterProdusen")]
public partial class MasterProdusen
{
    [Key]
    [StringLength(5)]
    [Unicode(false)]
    public string Kode { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Perusahaan { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? IndukPerusahaan { get; set; }

    [StringLength(5)]
    [Unicode(false)]
    public string? KodeIndukPerusahaan { get; set; }
}
