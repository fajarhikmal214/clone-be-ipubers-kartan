using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace be_ipubers_kartan.Helpers
{
    public class QueryHelper
    {
        private readonly string _connectionString;
        public QueryHelper(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
        }

        public struct LogicalOperator
        {
            public const string OR = "OR";
            public const string AND = "AND";
        }

        public static string WhereClause(string[] criterias, string logicalOperator)
        {
            StringBuilder sbuilder = new StringBuilder();

            if (criterias.Length > 0)
                sbuilder.Append(" where ");

            for (int i = 0; i < criterias.Length; i++)
            {
                sbuilder.Append(criterias[i]);
                if (i < criterias.Length - 1)
                    sbuilder.Append(logicalOperator);
            }

            return sbuilder.ToString();
        }

        public async Task<IEnumerable<T>> SelectDataAsync<T>(string query, object parameter, string connString = "")
        {
            try
            {
                if (string.IsNullOrEmpty(connString))
                    connString = _connectionString;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    var result = await conn.QueryAsync<T>(query, parameter, commandTimeout: 120);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<IEnumerable<T>> SelectDataAsyncWithConnection<T>(string query, object parameter, SqlConnection conn, SqlTransaction transaction)
        {
            try
            {
                var result = await conn.QueryAsync<T>(query, parameter, transaction, commandTimeout: 120);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> SelectData<T>(string query, object parameter)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    var result = conn.Query<T>(query, parameter);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T SelectScalar<T>(string query, object parameter)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    var result = conn.ExecuteScalar<T>(query, parameter);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  async Task<T> SelectScalarAsync<T>(string query, object parameter)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    var result = await conn.ExecuteScalarAsync<T>(query, parameter);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> ExecuteQueryAsync(string query, object parameter)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    var result = await conn.ExecuteAsync(query, parameter);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> ExecuteProcedureAsync<T>(string spName, object parameter)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    var result = await conn.QueryAsync<T>(spName, parameter, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int ExecuteQuery(SqlConnection conn, SqlTransaction transaction, string query, object parameter)
        {
            try
            {
                var result = conn.Execute(query, parameter, transaction);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<T> DataPaging<T>(IEnumerable<T> data, int page, int limit)
        {
            int skipCount = page > 1 ? (page * limit) - limit : 0;
            var result = data;
            if (page != 0 && limit != 0)
                result = data.Skip(skipCount).Take(limit);

            return result;
        }
    }
}
