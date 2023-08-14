using XFrame.Resilience;
using XFrame.Sql;

namespace XFrame.Sql.Excel.Configurations
{
    public class ExcelSqlConfiguration 
        : SqlConfiguration<IExcelSqlConfiguration>, IExcelSqlConfiguration
    {
        public static ExcelSqlConfiguration New => new();

        private ExcelSqlConfiguration()
        {
        }

        public RepeatDelay ServerBusyRepeatDelay { get; private set; } = RepeatDelay.Between(
            TimeSpan.FromSeconds(10),
            TimeSpan.FromSeconds(15));

        public IExcelSqlConfiguration SetServerBusyRepeatDelay(RepeatDelay repeatDelay)
        {
            ServerBusyRepeatDelay = repeatDelay;

            return this;
        }
    }
}
