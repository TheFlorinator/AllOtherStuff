using System.Configuration;
using System.Data.Common;

namespace Database
{
    public static class Connector
    {
        public static DbConnection GetOpenConnection(string connStringKey)
        {
            var connectionConfig = ConfigurationManager.ConnectionStrings[connStringKey];
           

            var connection = DbProviderFactories
                .GetFactory(connectionConfig.ProviderName)
                .CreateConnection();

            connection.ConnectionString = connectionConfig.ConnectionString;
            connection.Open();

            return connection;
        }
    }
}
