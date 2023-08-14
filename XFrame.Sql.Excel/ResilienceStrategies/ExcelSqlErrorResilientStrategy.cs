using Microsoft.Extensions.Logging;
using System.ComponentModel;
using XFrame.Resilience;
using XFrame.Sql.Excel.Configurations;

namespace XFrame.Sql.Excel.ResilienceStrategies
{
    public class ExcelSqlErrorResilientStrategy : IExcelSqlErrorResilientStrategy
    {
        private readonly ILogger<ExcelSqlErrorResilientStrategy> _logger;
        private readonly IExcelSqlConfiguration _excelSqlConfiguration;

        public ExcelSqlErrorResilientStrategy(
            ILogger<ExcelSqlErrorResilientStrategy> logger,
            IExcelSqlConfiguration excelSqlConfiguration)
        {
            _logger = logger;
            _excelSqlConfiguration = excelSqlConfiguration;
        }

        public virtual Repeat CheckRetry(
            Exception exception,
            TimeSpan totalExecutionTime,
            int currentRepeatCount)
        {
            return Repeat.No;
        }
    }
}
