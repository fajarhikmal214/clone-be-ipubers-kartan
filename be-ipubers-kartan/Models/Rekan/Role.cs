using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("roles")]
public partial class Role
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("access_configurations")]
    public bool AccessConfigurations { get; set; }

    [Column("export_chart")]
    public bool ExportChart { get; set; }

    [Column("edit_instance_variables")]
    public bool EditInstanceVariables { get; set; }

    [Column("alert_close_open")]
    public bool AlertCloseOpen { get; set; }

    [Column("alert_add_remarks")]
    public bool AlertAddRemarks { get; set; }

    [Column("alert_assign_members")]
    public bool AlertAssignMembers { get; set; }

    [Column("alert_policy_edit")]
    public bool AlertPolicyEdit { get; set; }

    [Column("alert_event_handler_edit")]
    public bool AlertEventHandlerEdit { get; set; }

    [Column("end_process")]
    public bool EndProcess { get; set; }

    [Column("config_instances")]
    public bool ConfigInstances { get; set; }

    [Column("config_privilege")]
    public bool ConfigPrivilege { get; set; }

    [Column("config_user_profile")]
    public bool ConfigUserProfile { get; set; }

    [Column("config_self_profile")]
    public bool ConfigSelfProfile { get; set; }

    [Column("all_groups_access")]
    public bool AllGroupsAccess { get; set; }

    [Column("config_data_purge")]
    public bool ConfigDataPurge { get; set; }

    [Column("config_data_repository")]
    public bool ConfigDataRepository { get; set; }

    [Column("retrieve_log")]
    public bool RetrieveLog { get; set; }

    [Column("config_activate_and_license")]
    public bool ConfigActivateAndLicense { get; set; }

    [Column("top_query_policy_edit")]
    public bool TopQueryPolicyEdit { get; set; }

    [Column("config_schedule_report")]
    public bool ConfigScheduleReport { get; set; }

    [Column("config_custom_metric")]
    public bool ConfigCustomMetric { get; set; }

    [Column("config_application_settings")]
    public bool ConfigApplicationSettings { get; set; }

    [Column("config_date_time")]
    public bool ConfigDateTime { get; set; }

    [Column("config_log_house_keeping")]
    public bool ConfigLogHouseKeeping { get; set; }

    [Column("export_migration")]
    public bool ExportMigration { get; set; }

    [Column("config_ldap_setting")]
    public bool ConfigLdapSetting { get; set; }

    [Column("config_security")]
    public bool ConfigSecurity { get; set; }

    [Column("alert_sql_statment_show")]
    public bool AlertSqlStatmentShow { get; set; }

    [Column("access_query_analyzer")]
    public bool AccessQueryAnalyzer { get; set; }

    [Column("access_sql_profiler")]
    public bool AccessSqlProfiler { get; set; }

    [Column("edit_trace")]
    public bool EditTrace { get; set; }

    [Column("config_certificates")]
    public bool ConfigCertificates { get; set; }
}
