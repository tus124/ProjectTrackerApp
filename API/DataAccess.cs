using System.Data.SqlClient;
using System.Data;
using ProjectTrackerAPI.Models;

namespace ProjectTrackerAPI;

public class DataAccess<T>
{
    private string ConnnectionString { get; set; }
    public DataAccess(string _connectionString)
    {
        this.ConnnectionString = _connectionString;
    }

    public List<T> ExecuteStoredProcedure<T>(string procedureName, SqlParameter[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(ConnnectionString))
        {
            using (SqlCommand command = new SqlCommand(procedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                var dataReaderResults = command.ExecuteReader();
                var results = dataReaderResults.DataReaderMapToList<T>();

                return results;
            }
        }
    }
}

