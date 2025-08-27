using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

[Table("TutorialParent")]
public partial class TutorialParent
{
    [Key]
    public int Id { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string Judul { get; set; } = null!;

    [InverseProperty("Parent")]
    public virtual ICollection<Tutorial> Tutorials { get; set; } = new List<Tutorial>();
}
