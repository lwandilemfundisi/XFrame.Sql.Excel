using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System.ServiceProcess;
using XFrame.Common;
using XFrame.Resilience;
using XFrame.Sql.Excel.Configurations;
using XFrame.Sql.Excel.Connections;
using XFrame.Sql.Excel.ResilienceStrategies;

namespace XFrame.Sql.Excel.Tests
{
    public class Tests
    {
        IServiceProvider serviceProvider;

        [SetUp]
        public void Setup()
        {
            var testExcelPath = "Book1.xlsx";
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(l => l.AddConsole());
            serviceCollection.TryAddTransient<IExcelSqlConnection, ExcelSqlConnection>();
            serviceCollection.TryAddTransient<IExcelSqlConnectionFactory, ExcelSqlConnectionFactory>();
            serviceCollection.TryAddTransient<IExcelSqlErrorResilientStrategy, ExcelSqlErrorResilientStrategy>();
            serviceCollection.TryAddTransient<ITransientFaultHandler<IExcelSqlErrorResilientStrategy>, TransientFaultHandler<IExcelSqlErrorResilientStrategy>>();
            serviceCollection.TryAddSingleton(_ => ExcelSqlConfiguration
            .New
            .SetConnectionString($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={testExcelPath};Extended Properties=Excel 12.0;"));

            serviceProvider = serviceCollection
                .BuildServiceProvider();
        }

        [Test]
        public async Task Test1()
        {
            var connection = serviceProvider
                .GetService<IExcelSqlConnection>();

            var result = await connection.QueryAsync<object>(
                Label.Named("just-test"),
                "",
                CancellationToken.None,
                @"select * from [Sheet1$]");

            Assert.Pass();
        }
    }
}