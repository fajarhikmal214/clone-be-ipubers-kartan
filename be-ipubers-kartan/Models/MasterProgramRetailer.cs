using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("MasterProgramRetailer")]
public partial class MasterProgramRetailer
{
    [Key]
    public int Id { get; set; }

    [StringLength(12)]
    public string? RetailerCode { get; set; }

    public int? MasterProgramId { get; set; }

    [ForeignKey("MasterProgramId")]
    [InverseProperty("MasterProgramRetailers")]
    public virtual MasterProgram? MasterProgram { get; set; }

    [ForeignKey("RetailerCode")]
    [InverseProperty("MasterProgramRetailers")]
    public virtual Retailer? RetailerCodeNavigation { get; set; }
}
