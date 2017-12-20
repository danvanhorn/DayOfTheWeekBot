using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DayOfTheWeekSlackBot
{
    class SlackBot
    {
        public static void Main(string[] args)
        {
            Task.WaitAll(IntegrateWithSlackAsync());
        }

        private static async Task IntegrateWithSlackAsync()
        {
            //Set the valid URL of the Slack's Webhook.
            Uri webhookUrl = new Uri("https://hooks.slack.com/services/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");
            SlackClient slackClient = new SlackClient(webhookUrl);
            HashSet<DateTime> dates = new HashSet<DateTime>();

            dates.Add(DateTime.Today);

            while (true)
            {
                if (!dates.Contains(DateTime.Today))
                {
                    string msg = string.Format("It's {0}, my dudes.", DateTime.Today.DayOfWeek.ToString());
                    HttpResponseMessage response = await slackClient.SendMessageAsync(msg);

                    dates.Add(DateTime.Today);
                }
            }
        }
    }
}