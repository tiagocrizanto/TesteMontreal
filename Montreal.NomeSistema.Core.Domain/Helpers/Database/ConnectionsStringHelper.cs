using System.Configuration;

namespace Montreal.NomeSistema.Core.Domain.Helpers.Database
{
    /// <summary>
    /// Este helper deve ser utilizado para buscar strings de conexão de banco de dados
    /// </summary>
    public static class ConnectionsStringHelper
    {
        public static string DapperConnection
        {
            get { return ConfigurationManager.ConnectionStrings["ApplicationContext"].ConnectionString; }
        }
    }
}
