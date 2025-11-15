using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using HappyPawsKennel.Data;          
using Microsoft.EntityFrameworkCore;

namespace HappyPawsKennel.Health
{
    public class DbHealthCheck : IHealthCheck
    {
        private readonly HappyPawsContext _context;

        public DbHealthCheck(HappyPawsContext context)
        {
            _context = context;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                
                var canConnect = await _context.Database.CanConnectAsync(cancellationToken);

                if (canConnect)
                    return HealthCheckResult.Healthy("Database reachable.");
                else
                    return HealthCheckResult.Unhealthy("Database not reachable.");
            }
            catch (System.Exception ex)
            {
                // Return unhealthy.
                return HealthCheckResult.Unhealthy("Database check threw an exception.", ex);
            }
        }
    }
}

