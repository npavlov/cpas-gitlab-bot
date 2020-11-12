using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NCrontab;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace cpas_gitlab_bot
{
    public class NotifyService : BackgroundService
    {
        private CrontabSchedule _schedule;
        private DateTime _nextRun;

        private string Schedule => "0 6 * * 1-5"; 

        public NotifyService()
        {
            _schedule = CrontabSchedule.Parse(Schedule);
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                var nextrun = _schedule.GetNextOccurrence(now);
                if (nextrun > _nextRun)
                {
                    Process();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }
                await Task.Delay(5000, stoppingToken); //5 seconds delay
            }
            while (!stoppingToken.IsCancellationRequested);
        }

        private void Process()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var bot_token = Environment.GetEnvironmentVariable("bot_token");
            var gitlab_token = Environment.GetEnvironmentVariable("gitlab_token");
            var team = Environment.GetEnvironmentVariable("team");

            TelegramBotClient Bot = new TelegramBotClient(bot_token);


            var client = new RestClient("http://gitlab.k8s.alfa.link/api/v4/")
            {
                Authenticator = new JwtAuthenticator(gitlab_token)
            };

            var users = team.Split(';');


            MergeRequest[] getMRs(string userId)
            {
                var request = new RestRequest($"merge_requests?state=opened&scope=all&per_page=100&author_username={userId}", DataFormat.Json);

                var response = client.Get(request);


                return JsonConvert.DeserializeObject<MergeRequest[]>(response.Content);
            }

            var mergeRequests = new List<MergeRequest>();

            Array.ForEach(users, user =>
            {
                mergeRequests.AddRange(getMRs(user.ToLower()));
            });

            var sr = new StringBuilder();

            mergeRequests.GroupBy(mr => mr.Author.Name).Select(g => new { name = g.Key, mrs = g.ToList() }).ToList().ForEach(group =>
            {

                sr.AppendLine("");
                sr.AppendLine($"*{group.name}*");

                group.mrs.ForEach(mr =>
                {
                    sr.AppendLine("");
                    sr.AppendLine($"*Название:*             {mr.Title}");
                    sr.AppendLine($"*Когда обновлялся:*     {mr.UpdatedAt.ToString("dd-MM-yyyy")}");
                    sr.AppendLine($"*Дней с обновления:*    {(int)(DateTime.Now - mr.UpdatedAt).TotalDays}");
                    sr.AppendLine($"*WIP:*                  {mr.WorkInProgress}");
                    sr.AppendLine($"*Проект:*               {(mr.ProjectId == 452 ? "AKIT" : "ASSR")}");
                    sr.AppendLine($"*Конфликты:*            {mr.HasConflicts}");
                    sr.AppendLine($"[ссылка]({mr.WebUrl})");
                });
            });

            Bot.SendTextMessageAsync("-345821829", sr.ToString(), parseMode: ParseMode.Markdown).Wait();

            Console.WriteLine(sr.ToString());
        }
    }
}
