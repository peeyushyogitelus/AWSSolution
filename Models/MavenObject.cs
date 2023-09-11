using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSMavenPages.Models
{
    public class MavenObject
    {
        public struct SessionField
        {
            public const string Mlaccount = "MLAccount";
            public const string Mlbearer = "MLBearer";
            public const string MlPermissions = "MLPermissions";
            public const string Mluserid = "MLUserId";
            public const string Mluser = "MLUser";
            public const string Mluseremail = "MLUserEmail";
            public const string IsPunchClock = "IsPunchClock";
        }
        public struct AccountPermission
        {
            public const string Administrator = "ADMINISTRATOR";
            public const string Project_lead = "PROJECT_LEAD";
            public const string Reports_viewer_with_cost = "REPORTS_VIEWER_WITH_COST";
            public const string Reports_viewer = "REPORTS_VIEWER";
            public const string Owner = "OWNER";
            public const string Project_creator = "PROJECT_CREATOR";
            public const string Collaborator = "COLLABORATOR";
            public const string Punch_Clock = "PUNCH_CLOCK";
            public const string No_Permission = "NO_PERMISSIONS";
        }
        public struct ProjectStatus
        {
            public const int Active = 300;
            public const int NeedsReview_Orange = 420;
        }

        public const string SiteUrl = "https://app.mavenlink.com/";
        public const string APIUrl = "https://api.mavenlink.com/api/";
        public const string APIVersion = "v1/";
        public const string APIBaseUrl = APIUrl + APIVersion;
        public const string APITokenGeneration = SiteUrl + "oauth/token?client_id={0}&client_secret={1}&grant_type=authorization_code&redirect_uri={2}&code={3}";
        public const string APICodeGeneration = SiteUrl + "oauth/authorize?response_type=code&client_id=";
        public const string CFTypeCurrency = "currency";
        public const string CFTypeSingle = "single";
        public const string CFTypeMultiChoice = "choice";
        public const string CFTypeNumber = "number";
        public const string CFMultiChoice = "multi";
        public const string CFText = "text";

        #region API Urls       
        public const string APICurrentUserDetails = APIBaseUrl + "users/me.json";
        public const string UrlPostCF = APIBaseUrl + "custom_field_values";
        public const string UrlGetCustomField = APIBaseUrl + "custom_fields.json?include=choices&per_page=200&page=";
        public const string UrlWorkspaceChange = APIBaseUrl + "workspace_status_changes.json";
        public const string UrlGetWorkspace_allocations = APIBaseUrl + "workspace_allocations.json";
        public const string UrlGetworkspace_resources = APIBaseUrl + "workspace_resources";
        public const string UrlGetAllRateCard = APIBaseUrl + "rate_card_sets?include=rate_cards&has_currency={0}&per_page=200&page=";
        public const string UrlGetParticipations = APIBaseUrl + "participations";
        public const string UrlGetSingleparticipations = APIBaseUrl + "participations/{0}";
        #endregion

        [Serializable]
        public class workspace_resources
        {
            public string id { get; set; }
            public string label { get; set; }
            public string role_name { get; set; }
            public string full_name { get; set; }
            public string workspace_id { get; set; }
            public string user_id { get; set; }
            public string role_id { get; set; }
            public string participation_id { get; set; }
            public string Name_Role { get; set; }
            public string email_address { get; set; }
            public external_references external_reference { get; set; }

        }
        [Serializable]
        public class RateCard
        {
            public string ID { get; set; }
            public string RateCardSetId { get; set; }
            public string Currency { get; set; }
            public DateTime Date { get; set; }
            public DateTime UpdatedDate { get; set; }
            public string Rate { get; set; }
        }
        [Serializable]
        public class Projects
        {
            public string id { get; set; }
            public string workspace_id { get; set; }
            public string title { get; set; }
            public string budgeted { get; set; }
            public string start_date { get; set; }
            public string due_date { get; set; }
            public string description { get; set; }
            public string currency { get; set; }
            public string access_level { get; set; }
            public string consultant_role_name { get; set; }
            public string rate_card_id { get; set; }
            public string tasks_default_non_billable { get; set; }
            public string stories_are_fixed_fee_by_default { get; set; }
            public string expenses_in_burn_rate { get; set; }
            public string workspace_group_ids { get; set; }
            public string price { get; set; }
            public string change_orders_enabled { get; set; }
            public string require_expense_approvals { get; set; }
            public string require_time_approvals { get; set; }
            public string estimate_scenario_id { get; set; }
            public string change_orders { get; set; }
            public List<CustomFields> customFieldDetails { get; set; } = new List<CustomFields>();
            public string comments { get; set; }
            public string currencySymbol { get; set; }
            public string base_Unit { get; set; }
            public string price_in_cents { get; set; }
            public string target_margin { get; set; }
            public string client_role_name { get; set; }
            public string primary_workspace_group_id { get; set; }
            public List<workspace_groups> lstworkspace_groups { get; set; } = new List<workspace_groups>();
            public List<Organization> lstOrganization { get; set; }

        }
        [Serializable]
        public class Story
        {
            public string story_id { get; set; }
            public string roleId { get; set; }
            public string story_name { get; set; }
            public string workspace_id { get; set; }
            public string title { get; set; }
            public string story_type { get; set; }
            public string description { get; set; }
            public string start_date { get; set; }
            public string due_date { get; set; }
            public string state { get; set; }
            public string parent_id { get; set; }
            public string root_id { get; set; }
            public string archived { get; set; }
            public string budget_estimate_in_cents { get; set; }
            public string time_estimate_in_minutes { get; set; }
            public string tag_list { get; set; }
            public string percentage_complete { get; set; }
            public string fixed_fee { get; set; }
            public string billable { get; set; }
            public string weight { get; set; }
            public string priority { get; set; }
            public string time_trackable { get; set; }
            public string attachment_id { get; set; }
            public List<string> checklist = new List<string>();
            public List<string> assignee_ids = new List<string>();
            public List<string> follower_ids = new List<string>();
            public List<external_references> external_reference { get; set; } = new List<external_references>();
            public string RevenuePercentageId { get; set; } = string.Empty;
            public string RevenuePercentageValue { get; set; } = string.Empty;
            public string HardCostOptionYesId { get; set; } = string.Empty;
            public string HardCostOptionYesValue { get; set; } = string.Empty;
            public string FreelancerOptionYesId { get; set; } = string.Empty;
            public string FreelancerOptionYesValue { get; set; } = string.Empty;
            public string RevRecBudgetId { get; set; } = string.Empty;
            public string RevRecBudgetValue { get; set; } = string.Empty;
            public int temp_id { get; set; }
            public string level { get; set; }
            public int position { get; set; }
            public List<string> ancestors_id { get; set; }
            public List<CustomFieldValues> custom_fields { get; set; }

            public List<assignments> assignments { get; set; }
        }
        [Serializable]
        public class assignments
        {
            public string workspace_resource_id { get; set; }
            public string estimated_minutes { get; set; }
        }
        [Serializable]
        public class CustomFieldValues {
            public long custom_field_id { get; set; }
            public string value { get; set; }
        }

        [Serializable]
        public class CustomFields
        {
            public string id { get; set; }
            public string value { get; set; }
            public string type { get; set; }
            public string subject { get; set; }
            public string subjectId { get; set; }
            public string currency { get; set; }
            public int temp_id { get; set; }
        }
        [Serializable]
        public class CommonObjects
        {
            public string ID { get; set; }
            public string Title { get; set; }
        }
        public class GetRequestParams
        {
            public string strFilter { get; set; }
            public string strToken { get; set; }
            public int? iPageSize { get; set; }
            public int? iPageLimit { get; set; }
        }
        [Serializable]
        public class Users
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string EmailId { get; set; }
        }
        [Serializable]
        public class invitation
        {
            public string full_name { get; set; }
            public string email_address { get; set; }
            public string invitee_role { get; set; }
            public string subject { get; set; }
            public string message { get; set; }

        }
        [Serializable]
        public class workspace_allocation
        {
            public string resource_id { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
            public bool hard { get; set; }
            public string minutes { get; set; }
            public string notes { get; set; }
        }
        [Serializable]
        public class roles
        {
            public string name { get; set; }
            public string id { get; set; }

        }
        [Serializable]
        public class AllRateCard
        {
            public string title { get; set; }
            public string id { get; set; }
            public string date { get; set; }
            public string rate_card_currency { get; set; }
            public string active_rate_card_set_version_id { get; set; }
        }

        [Serializable]
        public class participations
        {
            public string id { get; set; }
            public string workspace_id { get; set; }
            public string role { get; set; }
            public string user_id { get; set; }
            public bool can_invite { get; set; }
            public string permissions { get; set; }
            public bool team_lead { get; set; }
            public string name { get; set; }
            public string email_address { get; set; }
            public string active_role_name { get; set; }
            public string is_team_lead { get; set; }
            public bool IsAllowed { get; set; }
            public string UserName { get; set; }
            public string updated_at { get; set; }
            public string external_status { get; set; }
            public string external_message { get; set; }
            public string survey_templete_id { get; set; }
            public string LastReviewDate { get; set; }
            public string ApprovedHoursLastReview { get; set; }
            public string TotalApprovedHours { get; set; }
            public string OutstandingDelegated { get; set; }
            public string Prior { get; set; }
            public string WorkspaceId { get; set; }
            public string WorkspaceName { get; set; }
            public string disabled { get; set; }
            public string tooltip { get; set; }
            public string reviewer { get; set; }
            public string open_date { get; set; }
            public string status { get; set; }
            public string permission { get; set; }
        }
        [Serializable]
        public class HighPriority
        {
            public string name { get; set; }
            public string symbol { get; set; }
            public string iso_code { get; set; }
            public bool in_paypal { get; set; }
            public int subunit_to_unit { get; set; }
            public string separator { get; set; }
            public string delimiter { get; set; }
        }
        public class ExtRefrences
        {
            public external_references external_reference { get; set; }
        }

        public class workspace_groups
        {
            public string id { get; set; }
            public string name { get; set; }
            public bool company { get; set; }
            public string contact_name { get; set; }
            public string email { get; set; }
            public string phone_number { get; set; }
            public string address { get; set; }
            public string website { get; set; }
            public string notes { get; set; }
        }
        public class estimate_scenario_resource
        {
            public string id { get; set; }
            public string estimate_scenario_id { get; set; }
            public string label { get; set; }
            public string role_id { get; set; }
            public string role_name { get; set; }
            public string display_label { get; set; }
            public string cost_rate { get; set; }
            public string bill_rate { get; set; }
            public string estimated_fees { get; set; }
            public allocation_attributes allocation { get; set; }
            public roles role { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public string estimated_minutes { get; set; }
            public Nullable<DateTime> created_at { get; set; }
            public organization_memberships organization_membership { get; set; }
            public List<estimate_scenario_resource_skills> estimate_scenario_resource_skill { get; set; }
        }
        public class organization_memberships {
            public string member_id { get; set; }
            public string geography_id { get; set; }
            public string department_id { get; set; }
        }
        public class estimate
        {
            public string id { get; set; }
            public string name { get; set; }
            public bool is_locked { get; set; }
            public string description { get; set; }
            public string workspace_group_id { get; set; }
            public string favorite_scenario_id { get; set; }
            public string currency { get; set; }
            public bool resetResources { get; set; }
            public string clientName { get; set; }
            public string created_at { get; set; }
            public string clientContact { get; set; }
            public List<estimate_scenarios> estimate_Scenarios { get; set; }
            public List<estimate_scenarios> sorted_estimate_Scenarios { get; set; }
            public List<external_references> external_References { get; set; }
        }
        public class estimate_scenarios
        {
            public string id { get; set; }
            public string name { get; set; }
            public string start_date { get; set; }
            public string rate_card_id { get; set; }
            public string budget_in_cents { get; set; }
            public string estimate_id { get; set; }
            public rate_cards rate_Cards { get; set; }
            public Nullable<DateTime> created_at { get; set; }
            public Nullable<DateTime> updated_at { get; set; }
            public bool isRateUpdated { get; set; }
        }
        public class external_references
        {
            public string id { get; set; }
            public string subject_type { get; set; }
            public string subject_id { get; set; }
            public string service_name { get; set; }
            public string service_model { get; set; }
            public string service_model_ref { get; set; }
            public string status { get; set; }
            public string external_status { get; set; }
            public string external_link { get; set; }
            public string external_message { get; set; }
            public string locked { get; set; }
            public string updated_at { get; set; }

        }
        public class rate_cards
        {
            public string id { get; set; }
            public string name { get; set; }
            public string currency { get; set; }
        }
        public class allocation_attributes
        {
            public string duration_days { get; set; }
            public string percent_allocated { get; set; }
            public string relative_start_day { get; set; }

        }
        public class holiday
        {
            public string id { get; set; }
            public string name { get; set; }
            public DateTime start_date { get; set; }
            public DateTime end_date { get; set; }
            public string paid { get; set; }
            public string total_hours { get; set; }
            public int userId { get; set; }

        }
        public class holiday_calendars
        {
            public string id { get; set; }
            public string name { get; set; }
        }
        public class HolidayCalendarMemberships
        {
            public string holiday_calendar_id { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
            public string user_id { get; set; }
            public string in_use { get; set; }
        }
        public class HolidayCalendarAssociations
        {
            public string holiday_calendar_id { get; set; }
            public string holiday_calendar_name { get; set; }
            public string holiday_id { get; set; }
            public string holiday_name { get; set; }
        }
        public class holidayDetails
        {
            public string id { get; set; }
            public string name { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
            public string paid { get; set; }
            public string total_hours { get; set; }
            public int userId { get; set; }
        }
        public class Organization
        {
            public string member_type { get; set; }
            public string department_id { get; set; }
            public string geography_id { get; set; }
        }
        public class FlatObject
        {
            public string Id { get; set; }
            public string ParentId { get; set; }
            public string Name { get; set; }
            public FlatObject(string id, string parentId, string name)
            {
                Id = id;
                ParentId = parentId;
                Name = name;
            }
        }
        public class RecursiveObject
        {
            public string Id { get; set; }
            public string ParentId { get; set; }
            public string Name { get; set; }
            public List<RecursiveObject> Children { get; set; }
        }
        public class UsersDetails
        {
            public string id { get; set; }
            public string account_id { get; set; }
            public string account_membership_id { get; set; }
            public string full_name { get; set; }
            public string email_address { get; set; }
            public string role_id { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
            public string photo_path { get; set; }
            public string website { get; set; }
            public string account_permission { get; set; }
            public List<int> lstCustomFieldIds { get; set; }
            public List<int> lstSkillsIds { get; set; }
            public List<int> lstSkillMembershipIds { get; set; }
        }
        public class access_group_memberships
        {
            public string id { get; set; }
            public string access_group_id { get; set; }
            public string user_id { get; set; }
            public string access_group_name { get; set; }
        }
        public class estimate_scenario_resource_skills
        {
            public string level { get; set; }
            public string max_level { get; set; }
            public string cached_skill_name { get; set; }
            public string skill_id { get; set; }
            public string creator_id { get; set; }
            public string estimate_scenario_resource_id { get; set; }
            public string id { get; set; }
        }
        public class organization_membership {
            public string department_id { get; set; }
            public string geography_id { get; set; }
            public string member_id { get; set; }
            public string member_type { get; set; }
        }
        public class Expenses
        {
            public string id { get; set; }
            public string active_submission_id { get; set; }
            public string amount_in_cents { get; set; }
            public string category { get; set; }
            public string currency { get; set; }
            public string currency_base_unit { get; set; }
            public string currency_symbol { get; set; }
            public string date { get; set; }
            public string expense_category_id { get; set; }
            public string is_billable { get; set; }
            public string is_invoiced { get; set; }
            public string notes { get; set; }
            public string receipt_id { get; set; }
            public string filesize { get; set; }
            public string recent_submission_id { get; set; }
            public string reimbursable { get; set; }
            public string role_id { get; set; }
            public string story_id { get; set; }
            public string story_title { get; set; }
            public string taxable { get; set; }
            public string user_id { get; set; }
            public string vendor_id { get; set; }
            public string workspace_id { get; set; }
            public string workspace_title { get; set; }
            public string status { get; set; }
            public string rate { get; set; }
            public string source_currency { get; set; }
            public external_references objExternalReference { get; set; }
        }

        public class Project_accounting_records
        {
            [JsonProperty("workspace_id")]
            public long Workspace_id { get; set; }
            [JsonProperty("start_date")]
            public string Start_date { get; set; }
            [JsonProperty("end_date")]
            public string End_date { get; set; }
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("currency")]
            public string Currency { get; set; }
            [JsonProperty("amount")]
            public long Amount { get; set; }
            [JsonProperty("notes")]
            public string Notes { get; set; }
            [JsonProperty("service_type")]
            public string Service_type { get; set; }
            [JsonProperty("user_id")]
            public long User_id { get; set; }
        }
        [Serializable]
        public class Workweeks
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("start_date")]
            public string StartDate { get; set; }

            [JsonProperty("end_date")]
            public string EndDate { get; set; }

            [JsonProperty("sunday_minutes")]
            public string SundayMinutes { get; set; }

            [JsonProperty("monday_minutes")]
            public string MondayMinutes { get; set; }

            [JsonProperty("tuesday_minutes")]
            public string TuesdayMinutes { get; set; }

            [JsonProperty("wednesday_minutes")]
            public string WednesdayMinutes { get; set; }

            [JsonProperty("thursday_minutes")]
            public string ThursdayMinutes { get; set; }

            [JsonProperty("friday_minutes")]
            public string FridayMinutes { get; set; }

            [JsonProperty("saturday_minutes")]
            public string SaturdayMinutes { get; set; }

            [JsonProperty("total_minutes")]
            public string TotalMinutes { get; set; }

            [JsonProperty("default")]
            public string Default { get; set; }

            [JsonProperty("workweek_membership_ids")]
            public List<int> WorkweekMembershipIds { get; set; }
            public List<WorkweekMemberships> LstWorkweekMembership { get; set; }
        }

        public class SkillDetails
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("max_level")]
            public int MaxLevel { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("skill_category_id")]
            public string SkillCategoryId { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            public SkillCategory SkillCategory { get; set; }
        }
        [Serializable]
        public class SkillCategory
        {
            public string name { get; set; }
            public string Id { get; set; }
        }
        public class Skill
        {
            public List<SkillDetails> SkillDetails { get; set; }
            public string Error { get; set; } = string.Empty;
        }

        public class Role
        {
            public List<roles> RoleDetails { get; set; }
            public string Error { get; set; } = string.Empty;
        }
        public class OrganizationsDetails
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("parent_id")]
            public string ParentId { get; set; }

            [JsonProperty("ancestor_ids")]
            public List<string> AncestorIds { get; set; }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public string UpdatedAt { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
        }

        public class Organizations
        {
            public List<OrganizationsDetails> OrganizationsDetails { get; set; }
        }
        public class AccountColorDetails
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("default_color")]
            public bool DefaultColor { get; set; }
            [JsonProperty("enabled")]
            public bool Enabled { get; set; }
            [JsonProperty("hex")]
            public string Hex { get; set; }
            [JsonProperty("id")]
            public string Id { get; set; }
        }
        public class AccountColor
        {
            public List<AccountColorDetails> AccountColors { get; set; }
        }

        [Serializable]
        public class WorkweekMemberships
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("user_id")]
            public string UserId { get; set; }

            [JsonProperty("workweek_id")]
            public string WorkweekId { get; set; }

            [JsonProperty("start_date")]
            public string StartDate { get; set; }

            [JsonProperty("end_date")]
            public string EndDate { get; set; }
        }
        [Serializable]
        public class TimeOffEntries
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("requested_date")]
            public string RequestedDate { get; set; }

            [JsonProperty("submission_date")]
            public string SubmissionDate { get; set; }

            [JsonProperty("hours")]
            public string Hours { get; set; }

            [JsonProperty("user_id")]
            public string UserId { get; set; }
        }
        public class StoryAllocation
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("assignment_id")]
            public string AssignmentId { get; set; }
            [JsonProperty("current")]
            public string Current { get; set; }
            [JsonProperty("date")]
            public string Date { get; set; }
            [JsonProperty("minutes")]
            public string Minutes { get; set; }
            [JsonProperty("story_id")]
            public string Story_id { get; set; }
            [JsonProperty("workspace_id")]
            public string Workspace_id { get; set; }
            [JsonProperty("workspace_title")]
            public string Workspace_title { get; set; }
            [JsonProperty("story_title")]
            public string Story_title { get; set; }
        }

        public class OrganizationMemberships
        {
            [JsonProperty("menber_id")]
            public string MemberId { get; set; }

            [JsonProperty("menber_type")]
            public string MemberType { get; set; }

            [JsonProperty("department_id")]
            public string DepartmentId { get; set; }

            public string DepartmentName { get; set; }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public string UpdatedAt { get; set; }

            [JsonProperty("geography_id")]
            public string GeographyId { get; set; }

            public string GeogrpahyName { get; set; }
        }

        [Serializable]
        public class StatusReport
        {
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("color")]
            public string color { get; set; }
            [JsonProperty("description")]
            public string description { get; set; }
            [JsonProperty("created_at")]
            public string created_at { get; set; }
            [JsonProperty("updated_at")]
            public string updated_at { get; set; }
            [JsonProperty("workspace_id")]
            public string workspace_id { get; set; }
            [JsonProperty("creator_id")]
            public string creator_id { get; set; }
            public string updater_id { get; set; }
            public List<StatusReportDetails> lstDetails { get; set; } = new List<StatusReportDetails>();
            public List<long> lstExternalRefIds { get; set; }
            public List<external_references> lstExternalReferences { get; set; }
            public external_references objExternalReference { get; set; }
            public List<CommonObjects> lstUsers { get; set; }
            public CommonObjects objWorkspace { get; set; }
        }

        [Serializable]
        public class StatusReportDetails
        {
            public string category { get; set; }
            public string color { get; set; }
            public string description { get; set; }
        }
    }
    public class Assignments
    {
        public string id { get; set; }
        public string estimated_minutes { get; set; }
        public string allocated_minutes { get; set; }
        public string resource_id { get; set; }
        public string story_id { get; set; }
        public string assignee_id { get; set; }
        public string current { get; set; }
    }

    public class CustomBranding
    {
        public string button_color { get; set; }
        public string link_color { get; set; }
        public string header_color { get; set; }
        public string left_nav_background_color { get; set; }
        public string custom_login_message { get; set; }
        public string left_nav_button_color { get; set; }
        public string business_name { get; set; }
        public string logo_url { get; set; }
        public string state { get; set; }      
        public string id { get; set; }
    }
    public class Skill_Memberships
    {
        public List<SkillMembership> SkillMemberships { get; set; }
        public string Error { get; set; } = string.Empty;
    }
    public class SkillMembership
    {
        public string id { get; set; }
        public string level { get; set; }
        public string skillId { get; set; }
        public string skillName { get; set; }
        public string maxLevel { get; set; }
        public string createdDate { get; set; }
        public string updatedDate { get; set; }
        public string SkillCategoryId { get; set; }
        public string SkillCategoryName { get; set; }
        public string SkillDescription { get; set; }
    }
}
