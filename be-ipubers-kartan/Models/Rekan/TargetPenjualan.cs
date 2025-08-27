using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("TargetPenjualan")]
public partial class TargetPenjualan
{
    [Key]
    public int Id { get; set; }

    public int? Bulan { get; set; }

    public int? Tahun { get; set; }

    public long? Target { get; set; }
}
