using System.Threading.Tasks;
using FMBQ.Hub.Database;
using FMBQ.Hub.Models;

namespace FMBQ.Hub
{
    public class PersonStore
    {
        private readonly IConnectionProvider connectionProvider;

        public PersonStore(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public async Task<Person> GetById()
        {
            using (var command = connectionProvider.Connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT * FROM person
                ";

                using (var reader = await command.ExecuteReaderAsync())
                {
                    return null;
                }
            }
        }
    }
}
