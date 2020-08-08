using Hangfire;

namespace Statistics.Hangfire
{
    public class HangfireJobScheduler
    {
        public static void ScheduleRecurringJob()
        {
            RecurringJob.AddOrUpdate<StatisticJob>(job => job.Run(), Cron.Daily); // fires at midnight utc
        }
    }
}
