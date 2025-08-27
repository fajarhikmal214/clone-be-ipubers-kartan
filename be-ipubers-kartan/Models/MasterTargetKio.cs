using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

public partial class MasterTargetKio
{
    [Key]
    public int Id { get; set; }

    public int Tipe { get; set; }

    public int Tahun { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? Jumlah { get; set; }
}
