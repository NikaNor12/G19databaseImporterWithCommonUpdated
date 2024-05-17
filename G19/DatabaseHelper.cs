using Microsoft.Data.SqlClient;
using DatabaseHelper.Common;
using System.Data;

namespace DatabaseHelper.SQL
{
    public sealed class DatabaseHelper : DatabaseCommon<SqlConnection, SqlCommand, SqlParameter, SqlTransaction>
    {
        public DatabaseHelper(string connectionString) : base(connectionString) { }

    }
}