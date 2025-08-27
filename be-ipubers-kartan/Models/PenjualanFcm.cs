using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("PenjualanFcm")]
[Index("IdPenjualan", Name = "KEY_PenjualanFcm_IdPenjualan", IsUnique = true)]
public partial class PenjualanFcm
{
    public int IdPenjualan { get; set; }

    [Unicode(false)]
    public string FcmToken { get; set; } = null!;

    [Key]
    public int Id { get; set; }

    [ForeignKey("IdPenjualan")]
    [InverseProperty("PenjualanFcm")]
    public virtual Penjualan IdPenjualanNavigation { get; set; } = null!;
}
