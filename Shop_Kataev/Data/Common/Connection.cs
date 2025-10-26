using MySql.Data.MySqlClient;

namespace Shop_Kataev.Data.Common
{
    public class Connection
    {
        readonly static string ConnectionData = "server=127.0.0.1;port=3306;database=Shop;uid=root"; // строка данных для подключения к БД

        // Метод открытия соединения с базой данных
        public static MySqlConnection MySqlOpen() 
        {
            MySqlConnection NewMySqlConnection = new MySqlConnection(ConnectionData);
            NewMySqlConnection.Open();

            return NewMySqlConnection;
        }

        // Метод выполнения sql запроса
        public static MySqlDataReader MySqlQuery(string Query, MySqlConnection Connection) 
        {
            MySqlCommand NewMySqlCommand = new MySqlCommand(Query, Connection);
            return NewMySqlCommand.ExecuteReader();
        }

        // Метод закрытия соединения с базой данных
        public static void MySqlClose(MySqlConnection connection) 
        {
            connection.Close();
        }
    }
}
