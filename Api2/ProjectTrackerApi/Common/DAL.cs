namespace ProjectTrackerApi;

using System.Data;
using System.Data.SqlClient;

public class DAL
{
    private readonly string _connectionString;

    public DAL(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
