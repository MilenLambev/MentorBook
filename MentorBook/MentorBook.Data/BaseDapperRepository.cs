using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MentorBook.Data
{
    public class BaseDapperRepository
    {
        protected readonly string DB_CONNECTION;

        protected BaseDapperRepository(string dbConnString)
        {
            DB_CONNECTION = dbConnString;
        }

        protected List<T> Query<T>(string SQLQuery, object param = null)
        {
            List<T> result = new List<T>();

            using (var connection = new SqlConnection(DB_CONNECTION))
            {
                connection.Open();

                result = connection.Query<T>(SQLQuery, param).ToList();
            }

            return result;
        }

        protected int Execute(string SQLQuery, object obj = null)
        {
            int result = -1;

            using (var connection = new SqlConnection(DB_CONNECTION))
            {
                connection.Open();

                result = connection.Execute(SQLQuery, obj);
            }

            return result;
        }
    }
}
