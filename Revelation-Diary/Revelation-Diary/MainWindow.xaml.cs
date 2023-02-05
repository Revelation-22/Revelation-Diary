using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Revelation_Diary
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

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      Engine.MySqlDbManager dbMgr = new Engine.MySqlDbManager("localhost", "3306", "test", "root", "root");
      var dt = dbMgr.GetDataTable("SELECT * FROM test");
      var size = dt.Columns.Count;
      string tempText = "";
      for (int i = 0; i < size; i++)
      {
        tempText += dt.Rows[i]["id"].ToString();
        tempText += dt.Rows[i]["label"].ToString();
      }
      TB_tempText.Text = tempText;

    }

    private void Window_Unloaded(object sender, RoutedEventArgs e)
    {

    }
  }
}
