using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenjualanBilling")]
public partial class PenjualanBilling
{
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string IdBilling { get; set; } = null!;

    public int IdPenjualan { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string NoNota { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string? KodeAgen { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? IdRetailer { get; set; }

    [ForeignKey("IdPenjualan")]
    [InverseProperty("PenjualanBillings")]
    public virtual Penjualan IdPenjualanNavigation { get; set; } = null!;
}
