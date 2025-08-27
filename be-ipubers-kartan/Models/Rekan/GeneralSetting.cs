using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("general_settings")]
public partial class GeneralSetting
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("password_min_length")]
    public int? PasswordMinLength { get; set; }

    [Column("different_from_username")]
    public bool? DifferentFromUsername { get; set; }

    [Column("include_upper_lower_number")]
    public bool? IncludeUpperLowerNumber { get; set; }

    [Column("at_least_one_symbol")]
    public bool? AtLeastOneSymbol { get; set; }

    [Column("show_24_hour")]
    public bool? Show24Hour { get; set; }

    [Column("ldap_ip")]
    [StringLength(255)]
    public string? LdapIp { get; set; }

    [Column("ldap_port")]
    public int? LdapPort { get; set; }

    [Column("ldap_encryption")]
    [StringLength(255)]
    public string? LdapEncryption { get; set; }

    [Column("ldap_allow_anonymous")]
    public bool? LdapAllowAnonymous { get; set; }

    [Column("ldap_user_search_base")]
    [StringLength(255)]
    public string? LdapUserSearchBase { get; set; }

    [Column("ldap_auth_username")]
    [StringLength(255)]
    public string? LdapAuthUsername { get; set; }

    [Column("ldap_auth_password")]
    [StringLength(255)]
    public string? LdapAuthPassword { get; set; }

    [Column("ldap_auth_mode")]
    [StringLength(255)]
    public string? LdapAuthMode { get; set; }

    [Column("ldap_user_search_attribute")]
    [StringLength(255)]
    public string? LdapUserSearchAttribute { get; set; }

    [Column("ad_ip")]
    [StringLength(255)]
    public string? AdIp { get; set; }

    [Column("ad_port")]
    public int? AdPort { get; set; }

    [Column("ad_encryption")]
    [StringLength(255)]
    public string? AdEncryption { get; set; }

    [Column("ad_allow_anonymous")]
    public bool? AdAllowAnonymous { get; set; }

    [Column("ad_user_search_base")]
    [StringLength(255)]
    public string? AdUserSearchBase { get; set; }

    [Column("ad_auth_username")]
    [StringLength(255)]
    public string? AdAuthUsername { get; set; }

    [Column("ad_auth_password")]
    [StringLength(255)]
    public string? AdAuthPassword { get; set; }

    [Column("ad_auth_mode")]
    [StringLength(255)]
    public string? AdAuthMode { get; set; }

    [Column("ad_user_search_attribute")]
    [StringLength(255)]
    public string? AdUserSearchAttribute { get; set; }

    [Column("data_purging_alert_day")]
    public int? DataPurgingAlertDay { get; set; }

    [Column("data_purging_performance_day")]
    public int? DataPurgingPerformanceDay { get; set; }

    [Column("ldap_password_attr", TypeName = "text")]
    public string? LdapPasswordAttr { get; set; }

    [Column("share_usage_data")]
    public bool? ShareUsageData { get; set; }
}
