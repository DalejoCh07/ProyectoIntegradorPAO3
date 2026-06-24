using System.Data;
using System.Data.SqlClient;

namespace AgroControl.Model
{
    public static class DataAccess
    {
        public static readonly string ConnectionString = "server=localhost\\SQLDEVELOPER; Database=agroControl; Trusted_Connection=True;";

        public static DataTable GetQuery(string sql, List<SqlParameter>? parametros = null)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new(sql, conn);
            if (parametros != null)
                foreach (var p in parametros) cmd.Parameters.Add(p);
            using SqlDataAdapter da = new(cmd);
            DataSet ds = new();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static int ExecQuery(string sql, List<SqlParameter>? parametros = null)
        {
            using SqlConnection conn = new(ConnectionString);
            using SqlCommand cmd = new(sql, conn);
            if (parametros != null)
                foreach (var p in parametros) cmd.Parameters.Add(p);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}
