using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using simple_database.Model;
using System.IO;

namespace simple_database.View;

public partial class LoginView : Window
{
    public string FileName;
    public DataManager DataManager;
    public LoginView()
    {
        DataManager = new DataManager();
        InitializeComponent();
    }

    private void Login_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
       if(e.LeftButton == MouseButtonState.Pressed)
           DragMove();
    }

    private void MinimizeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void CreateBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (NameBox.Text != "")
        {
            FileName = NameBox.Text;
            MainModelView mainModelView = new MainModelView(FileName, DataManager);
            mainModelView.Show();
            this.Hide();
        }
        else
        {
            NameBox.BorderBrush = Brushes.Tomato;
        }
    }
    

    private void NameBox_OnGotFocus(object sender, RoutedEventArgs e)
    {
        NameBox.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#252422"));
    }

    private void LoadBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
        dialog.Filter = "InvManager file (*.json)|*.json";
        dialog.FilterIndex = 2;
        Nullable<bool> result = dialog.ShowDialog();
        if (result == true)
        {
            // Открыть документ
            FileName = dialog.FileName;
            DataManager.LoadData(FileName);
            FileName = System.IO.Path.GetFileName(FileName);
            MainModelView mainModelView = new MainModelView(FileName, DataManager);
            mainModelView.Show();
            this.Hide();
        }
    }
}