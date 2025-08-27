using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

public partial class MasterTargetKio
{
    [Key]
    public int Id { get; set; }

    public int Tipe { get; set; }

    public int Tahun { get; set; }

    public int Jumlah { get; set; }
}
