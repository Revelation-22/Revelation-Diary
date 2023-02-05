using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Engine
{
  public class MySqlDbManager
  {
    public MySqlDbManager() { }
    public MySqlDbManager(string hostIp, string port, string database, string uid, string password)
    {
      m_password = password;
      m_uid = uid;
      m_database = database;
      m_hostIp = hostIp;
      m_port = port;

      m_connectionPath = "DATA SOURCE=" + m_hostIp + ";PORT="+ m_port + ";DATABASE=" + m_database + ";UID=" + m_uid + ";PASSWORD=" + m_password +";";
    }

    private string m_hostIp;
    private string m_database;
    private string m_port;
    private string m_uid;
    private string m_password;

    private string m_connectionPath;

    private MySqlConnection m_mySqlConnection;
    private MySqlCommand m_mySqlCommand;
    
    public DataTable GetDataTable(string query)
    {
      DataTable dt = new DataTable();

      m_mySqlConnection = new MySqlConnection(m_connectionPath);
      m_mySqlCommand = new MySqlCommand(query, m_mySqlConnection);
      m_mySqlConnection.Open();
      MySqlDataAdapter dtAdapter = new MySqlDataAdapter(m_mySqlCommand);
      dtAdapter.Fill(dt);
      
      return dt;
    }






    //DB 연결

    //커넥션 풀



  }
}