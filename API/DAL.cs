namespace ProjectTrackerAPI;

using ProjectTrackerAPI.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;

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
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                var rows = command.ExecuteNonQuery();
            }
        }
    }

    public List<Project> ExecuteStoredProcedureForProject(string procedureName, SqlParameter[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
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
                var results = dataReaderResults.DataReaderMapToList<Project>();

                return results;
            }
        }
    }


    public static T ProcessValue<T>(T value)
    {
        // Perform some processing on the value (if needed)
        Console.WriteLine($"Processing value: {value}");

        // Return the processed value
        return value;
    }
}
