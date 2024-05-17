using DatabaseHelper.Common;
using Microsoft.Data.SqlClient;
using System.Data;

namespace G19_ProductImport
{
    public class DatabaseImporter : DatabaseCommon<SqlConnection, SqlCommand, SqlParameter, SqlTransaction>
    {
        private readonly string _connectionString;

        public DatabaseImporter(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public void ImportData(IEnumerable<Category> categories)
        {
            OpenConnection();

            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    var commandText = "sp_ImportProduct";


                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@CategoryName", SqlDbType.VarChar) { Value = category.Name },
                            new SqlParameter("@CategoryIsActive", SqlDbType.Bit) { Value = category.IsActive },
                            new SqlParameter("@ProductCode", SqlDbType.VarChar) { Value = product.Code },
                            new SqlParameter("@ProductName", SqlDbType.VarChar) { Value = product.Name },
                            new SqlParameter("@ProductPrice", SqlDbType.Decimal) { Value = product.Price },
                            new SqlParameter("@ProductIsActive", SqlDbType.Bit) { Value = product.IsActive }
                    };

                    ExecuteNonQuery(commandText, CommandType.StoredProcedure, parameters);
                }
            }

            CloseConnection();
        }
    }
}