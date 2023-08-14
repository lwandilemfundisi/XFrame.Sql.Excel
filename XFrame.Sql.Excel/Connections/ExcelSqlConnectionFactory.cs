using System.Data;
using System.Data.OleDb;

namespace XFrame.Sql.Excel.Connections
{
    public class ExcelSqlConnectionFactory : IExcelSqlConnectionFactory
    {
        public async Task<IDbConnection> OpenConnectionAsync(
            string connectionString,
            CancellationToken cancellationToken)
        {
            if (OperatingSystem.IsWindows())
            {
                var sqlConnection = new OleDbConnection(connectionString);
                await sqlConnection.OpenAsync(cancellationToken).ConfigureAwait(false);
                return sqlConnection;
            }

            throw new NotSupportedException("Cannot read excel files on other platforms other than Windows with this package!");
        }
    }
}
