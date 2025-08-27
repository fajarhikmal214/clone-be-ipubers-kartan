using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("_migAgentKartuTani")]
[Index("AgentId", Name = "_migAgentKartuTani_AgentId_uindex", IsUnique = true)]
public partial class MigAgentKartuTani
{
    [Key]
    [StringLength(30)]
    [Unicode(false)]
    public string AgentId { get; set; } = null!;

    [StringLength(255)]
    public string? NamaKios { get; set; }

    [StringLength(255)]
    public string Bank { get; set; } = null!;
}
