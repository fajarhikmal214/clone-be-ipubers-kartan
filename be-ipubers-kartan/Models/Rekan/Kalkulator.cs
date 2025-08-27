using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("Kalkulator")]
public partial class Kalkulator
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string NoHp { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? SewaTempat { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? ModalUsaha { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Gaji { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? AtkDll { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Laba { get; set; }

    public int? Payback { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("Kalkulator")]
    public virtual ICollection<KalkulatorProduk> KalkulatorProduks { get; set; } = new List<KalkulatorProduk>();
}
