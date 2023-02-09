using System.Data;
using System.Data.SqlClient;

namespace AdoNetLib
{
    public class DbExecutor
    {
        private readonly MainConnector connector;

        public DbExecutor(MainConnector connector)
        {
            this.connector = connector;
        }

        public DataTable SelectAll(string table)
        {
            var selectcommandtext = $"select * from {table};";
            var adapter = new SqlDataAdapter(selectcommandtext, connector.GetConnection());

            var ds = new DataSet();
            adapter.Fill(ds);

            return ds.Tables[0];
        }

        public SqlDataReader SelectAllCommandReader(string table)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = $"select * from {table};",
                Connection = connector.GetConnection(),
            };

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                return reader;
            }

            return null;
        }

        public int DeleteByColumn(string table, string column, string value)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = $"delete from {table} where {column} = '{value}';",
                Connection = connector.GetConnection(),
            };

            return command.ExecuteNonQuery();
        }

        public int ExecProcedureAdding(string name, string login, byte[] cardNumber)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddingUserProc",
                Connection = connector.GetConnection(),
            };

            command.Parameters.Add(new SqlParameter("@Name", name));
            command.Parameters.Add(new SqlParameter("@Login", login));
            command.Parameters.Add(new SqlParameter("@CardNumber", cardNumber));

            return command.ExecuteNonQuery();
        }

        public int UpdateByColumn(string table, string columnToCheck, string valueCheck, string columnToUpdate, string valueUpdate)
        {
            var command = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = $"update {table} set {columnToUpdate} = '{valueUpdate}' where {columnToCheck} = '{valueCheck}';",
                Connection = connector.GetConnection(),
            };

            return command.ExecuteNonQuery();
         }
    }
}
