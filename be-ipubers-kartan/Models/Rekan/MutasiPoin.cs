using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("MutasiPoin")]
public partial class MutasiPoin
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string IdPelangganRetailer { get; set; } = null!;

    public int? PoinAwal { get; set; }

    public int? PoinAkhir { get; set; }

    public int? JumlahPoin { get; set; }

    public int? TipeTransaksi { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? TanggalPoint { get; set; }
}
