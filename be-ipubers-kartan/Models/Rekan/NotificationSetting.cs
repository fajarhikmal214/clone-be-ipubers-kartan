using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace be_ipubers_kartan.Models.Rekan;

[Table("notification_settings")]
public partial class NotificationSetting
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("email_when_system_error")]
    public bool EmailWhenSystemError { get; set; }

    [Column("email_when_alert_notification")]
    public bool EmailWhenAlertNotification { get; set; }

    [Column("email_smtp_server_host")]
    [StringLength(255)]
    public string EmailSmtpServerHost { get; set; } = null!;

    [Column("email_smtp_server_port")]
    public int EmailSmtpServerPort { get; set; }

    [Column("email_secure_connection")]
    public bool EmailSecureConnection { get; set; }

    [Column("email_smtp_require_login")]
    public bool EmailSmtpRequireLogin { get; set; }

    [Column("email_smtp_username")]
    [StringLength(255)]
    public string EmailSmtpUsername { get; set; } = null!;

    [Column("email_smtp_password")]
    [StringLength(255)]
    public string EmailSmtpPassword { get; set; } = null!;

    [Column("email_smtp_from_email")]
    [StringLength(255)]
    public string EmailSmtpFromEmail { get; set; } = null!;

    [Column("snmp_when_alert_notification")]
    public bool SnmpWhenAlertNotification { get; set; }

    [Column("snmp_target_host")]
    [StringLength(255)]
    public string SnmpTargetHost { get; set; } = null!;

    [Column("snmp_target_port")]
    public int SnmpTargetPort { get; set; }

    [Column("snmp_community_string")]
    [StringLength(255)]
    public string SnmpCommunityString { get; set; } = null!;

    [Column("sms_when_alert_notification")]
    public bool SmsWhenAlertNotification { get; set; }

    [Column("sms_service_provider")]
    public int SmsServiceProvider { get; set; }

    [Column("sms_provider_1_api_key")]
    [StringLength(255)]
    public string SmsProvider1ApiKey { get; set; } = null!;

    [Column("sms_provider_2_account_sid")]
    [StringLength(255)]
    public string SmsProvider2AccountSid { get; set; } = null!;

    [Column("sms_provider_2_auth_token")]
    [StringLength(255)]
    public string SmsProvider2AuthToken { get; set; } = null!;

    [Column("sms_provider_2_use_phone_number")]
    public bool SmsProvider2UsePhoneNumber { get; set; }

    [Column("sms_provider_2_phone_number")]
    [StringLength(255)]
    public string SmsProvider2PhoneNumber { get; set; } = null!;

    [Column("sms_provider_2_messaging_service_sid")]
    [StringLength(255)]
    public string SmsProvider2MessagingServiceSid { get; set; } = null!;

    [Column("sms_provider_0_api_url")]
    [StringLength(255)]
    public string SmsProvider0ApiUrl { get; set; } = null!;

    [Column("sms_provider_0_request_method")]
    [StringLength(255)]
    public string SmsProvider0RequestMethod { get; set; } = null!;

    [Column("sms_provider_0_key_value")]
    [StringLength(255)]
    public string SmsProvider0KeyValue { get; set; } = null!;

    [Column("sms_provider_0_content_key")]
    [StringLength(255)]
    public string SmsProvider0ContentKey { get; set; } = null!;

    [Column("sms_provider_0_recipient_key")]
    [StringLength(255)]
    public string SmsProvider0RecipientKey { get; set; } = null!;

    [Column("slack_when_alert_notification")]
    public bool SlackWhenAlertNotification { get; set; }

    [Column("slack_web_hook")]
    [StringLength(255)]
    public string SlackWebHook { get; set; } = null!;

    [Column("slack_channel")]
    [StringLength(255)]
    public string SlackChannel { get; set; } = null!;
}
