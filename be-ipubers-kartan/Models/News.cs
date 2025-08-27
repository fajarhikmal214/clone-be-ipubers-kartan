using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models;

public partial class News
{
    /// <summary>
    /// id berita guid
    /// </summary>
    [Key]
    [StringLength(128)]
    public string Id { get; set; } = null!;

    [StringLength(5)]
    [Unicode(false)]
    public string? Type { get; set; }

    /// <summary>
    /// url image dr firebase
    /// </summary>
    [StringLength(250)]
    public string? Image { get; set; }

    /// <summary>
    /// judul berita
    /// </summary>
    [StringLength(250)]
    public string? Title { get; set; }

    /// <summary>
    /// isi berita
    /// </summary>
    [Unicode(false)]
    public string? Body { get; set; }

    /// <summary>
    /// valid from berita
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? ValidFrom { get; set; }

    /// <summary>
    /// valid until berita
    /// </summary>
    [Column(TypeName = "datetime")]
    public DateTime? ValidUntil { get; set; }

    /// <summary>
    /// status berita, default = 1, deleted = 2
    /// </summary>
    public bool? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [StringLength(250)]
    public string? CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [StringLength(250)]
    public string? UpdatedBy { get; set; }

    [InverseProperty("NewsNavigation")]
    public virtual ICollection<FcmNotification> FcmNotifications { get; set; } = new List<FcmNotification>();

    [InverseProperty("IdNewsNavigation")]
    public virtual ICollection<NewsAccessLog> NewsAccessLogs { get; set; } = new List<NewsAccessLog>();
}
