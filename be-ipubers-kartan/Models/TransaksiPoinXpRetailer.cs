using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("TransaksiPoinXpRetailer")]
[Index("Id", Name = "TransaksiPoinXpRetailer_Id_uindex", IsUnique = true)]
public partial class TransaksiPoinXpRetailer
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string IdRetailer { get; set; } = null!;

    public int Tipe { get; set; }

    public int Nilai { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Aktivitas { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;
}
