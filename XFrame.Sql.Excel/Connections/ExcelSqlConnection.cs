using Microsoft.Extensions.Logging;
using XFrame.Common;
using XFrame.Resilience;
using XFrame.Sql.Excel.Configurations;
using XFrame.Sql.Excel.ResilienceStrategies;

namespace XFrame.Sql.Excel.Connections
{
    public class ExcelSqlConnection
        : SqlConnection<IExcelSqlConfiguration, IExcelSqlErrorResilientStrategy, IExcelSqlConnectionFactory>, IExcelSqlConnection
    {
        public ExcelSqlConnection(
            ILogger<ExcelSqlConnection> logger,
            IExcelSqlConfiguration configuration,
            IExcelSqlConnectionFactory connectionFactory,
            ITransientFaultHandler<IExcelSqlErrorResilientStrategy> transientFaultHandler)
            : base(logger, configuration, connectionFactory, transientFaultHandler)
        {
        }

        public override Task<IReadOnlyCollection<TResult>> InsertMultipleAsync<TResult, TRow>(
            Label label,
            string connectionStringName,
            CancellationToken cancellationToken,
            string sql,
            IEnumerable<TRow> rows)
        {
            //TODO -- till we figure out what to do
            throw new NotImplementedException("Till we figure out what to do");
        }
    }
}
