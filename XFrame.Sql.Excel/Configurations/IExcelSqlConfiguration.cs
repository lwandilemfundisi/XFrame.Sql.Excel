using XFrame.Resilience;

namespace XFrame.Sql.Excel.Configurations
{
    public interface IExcelSqlConfiguration 
        : ISqlConfiguration<IExcelSqlConfiguration>
    {
        RepeatDelay ServerBusyRepeatDelay { get; }

        IExcelSqlConfiguration SetServerBusyRepeatDelay(RepeatDelay repeatDelay);
    }
}
