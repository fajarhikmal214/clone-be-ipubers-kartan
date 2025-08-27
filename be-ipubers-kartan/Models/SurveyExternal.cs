using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("SurveyExternal")]
public partial class SurveyExternal
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Provider { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string? NamaSurvey { get; set; }

    [Column("isDismissable")]
    public int IsDismissable { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [InverseProperty("IdSurveyExternalNavigation")]
    public virtual ICollection<SurveyExternalRetailer> SurveyExternalRetailers { get; set; } = new List<SurveyExternalRetailer>();
}
