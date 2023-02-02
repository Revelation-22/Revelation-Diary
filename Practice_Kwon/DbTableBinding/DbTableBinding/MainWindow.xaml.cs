using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;


namespace DbTableBinding
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    OracleConnection conn;

    private void DB_Connect(object sender, RoutedEventArgs e)
    {
      try
      {
        string strCon = "data source=xe;User ID=scott;Password=1234";
        //      string strCon = @"XE =
        //(DESCRIPTION =
        //  (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-VST2LD4)(PORT = 1521))
        //  (CONNECT_DATA =
        //    (SERVER = DEDICATED)
        //    (SERVICE_NAME = XE)
        //  )
        //);User Id=scott;Password=1234";
        conn = new OracleConnection(strCon);
        conn.Open();

        MessageBox.Show("DB Connection OK!");
      }
      catch (Exception error)
      {
        MessageBox.Show(error.ToString());
      }
    }

    private void Select_Emp(object sender, RoutedEventArgs e)
    {
      string sql = "select empno, ename, job from emp";

      OracleCommand comm = new OracleCommand();
      if (conn == null) DB_Connect(this, null);
      comm.Connection = conn;
      comm.CommandText = sql;

      OracleDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
      List<EmpViewModel> emps = new List<EmpViewModel>();
      while (reader.Read())
      {
        emps.Add(new EmpViewModel()
        {
          Empno = reader.GetInt32(reader.GetOrdinal("empno")),
          Ename = reader.GetString(reader.GetOrdinal("ename")),
          Job = reader.GetString(reader.GetOrdinal("job"))
          // Empno = reader.GetInt32(0),
          // Ename = reader.GetString(1),
          // Job = reader.GetString(2)
        });
      }
      lstView.ItemsSource = emps;
      reader.Close();
    }
  }
}
