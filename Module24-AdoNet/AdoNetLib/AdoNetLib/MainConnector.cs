using AdoNetLib.Configurations;
using System.Threading.Tasks;
using System.Data;
using System;
using System.Data.SqlClient;

namespace AdoNetLib
{
    public class MainConnector
    {
        public async Task<bool> ConnectAsync()
        {
            bool result;
            try
            {
                var connection = new SqlConnection(ConnectionString.MsSqlConnection);
                await connection.OpenAsync();

                result = true;
                
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public bool Connect()
        {
            bool result;
            try
            {
                var connection = new SqlConnection(ConnectionString.MsSqlConnection);
                connection.Open();

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public SqlConnection GetConnection()
        {
            try
            {
                var connection = new SqlConnection(ConnectionString.MsSqlConnection);
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    return connection;
                }
                else
                {
                    throw new Exception("Подключение уже закрыто!");
                }
            }
            catch (Exception)
            {

                throw new Exception("Подключение уже закрыто!");
            }
        }

        public async void DisconnectAsync()
        {
            var connection = new SqlConnection(ConnectionString.MsSqlConnection);

            if (connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }
}
