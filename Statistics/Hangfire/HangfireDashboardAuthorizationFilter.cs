using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Statistics.Hangfire
{
    public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            // This is needed for accessing hangfire dashboard in Prod.
            // You would normally check whether the person has the required role.
            // Can be done by checking the context or jwt
            return true;
        }
    }
}
