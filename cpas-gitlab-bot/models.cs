
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace cpas_gitlab_bot
{
    public partial class MergeRequest
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("iid")]
        public long Iid { get; set; }

        [JsonProperty("project_id")]
        public long ProjectId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }


        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("merged_by")]
        public object MergedBy { get; set; }

        [JsonProperty("merged_at")]
        public object MergedAt { get; set; }

        [JsonProperty("closed_by")]
        public object ClosedBy { get; set; }

        [JsonProperty("closed_at")]
        public object ClosedAt { get; set; }

        [JsonProperty("source_branch")]
        public string SourceBranch { get; set; }

        [JsonProperty("user_notes_count")]
        public long UserNotesCount { get; set; }

        [JsonProperty("upvotes")]
        public long Upvotes { get; set; }

        [JsonProperty("downvotes")]
        public long Downvotes { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("assignees")]
        public Author[] Assignees { get; set; }

        [JsonProperty("assignee")]
        public Author Assignee { get; set; }

        [JsonProperty("source_project_id")]
        public long SourceProjectId { get; set; }

        [JsonProperty("target_project_id")]
        public long TargetProjectId { get; set; }

        [JsonProperty("labels")]
        public string[] Labels { get; set; }

        [JsonProperty("work_in_progress")]
        public bool WorkInProgress { get; set; }

        [JsonProperty("milestone")]
        public object Milestone { get; set; }

        [JsonProperty("merge_when_pipeline_succeeds")]
        public bool MergeWhenPipelineSucceeds { get; set; }

        [JsonProperty("merge_status")]
        public string MergeStatus { get; set; }

        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("merge_commit_sha")]
        public object MergeCommitSha { get; set; }

        [JsonProperty("squash_commit_sha")]
        public object SquashCommitSha { get; set; }

        [JsonProperty("discussion_locked")]
        public object DiscussionLocked { get; set; }

        [JsonProperty("should_remove_source_branch")]
        public object ShouldRemoveSourceBranch { get; set; }

        [JsonProperty("force_remove_source_branch")]
        public bool ForceRemoveSourceBranch { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("references")]
        public References References { get; set; }

        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }

        [JsonProperty("time_stats")]
        public TimeStats TimeStats { get; set; }

        [JsonProperty("squash")]
        public bool Squash { get; set; }

        [JsonProperty("task_completion_status")]
        public TaskCompletionStatus TaskCompletionStatus { get; set; }

        [JsonProperty("has_conflicts")]
        public bool HasConflicts { get; set; }

        [JsonProperty("blocking_discussions_resolved")]
        public bool BlockingDiscussionsResolved { get; set; }

        [JsonProperty("approvals_before_merge")]
        public object ApprovalsBeforeMerge { get; set; }
    }

    public partial class Author
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar_url")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }
    }

    public partial class References
    {
        [JsonProperty("short")]
        public string Short { get; set; }

        [JsonProperty("relative")]
        public string Relative { get; set; }

        [JsonProperty("full")]
        public string Full { get; set; }
    }

    public partial class TaskCompletionStatus
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("completed_count")]
        public long CompletedCount { get; set; }
    }

    public partial class TimeStats
    {
        [JsonProperty("time_estimate")]
        public long TimeEstimate { get; set; }

        [JsonProperty("total_time_spent")]
        public long TotalTimeSpent { get; set; }

        [JsonProperty("human_time_estimate")]
        public object HumanTimeEstimate { get; set; }

        [JsonProperty("human_total_time_spent")]
        public object HumanTotalTimeSpent { get; set; }
    }



}
