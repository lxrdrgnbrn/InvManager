using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace simple_database.View;

public partial class AboutView : Window
{
    public AboutView()
    {
        InitializeComponent();
    }

    private void AboutView_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if(e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }
    /// <summary>
    /// Обработчик событий для навигации по гиперссылке.
    /// </summary>
    /// <param name="sender">Источник события.</param>
    /// <param name="e">Аргументы события навигации.</param>
    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        // Создаем новый экземпляр ProcessStartInfo с URL, на который указывает гиперссылка.
        var startInfo = new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri)
        {
            // UseShellExecute устанавливается в true, чтобы оболочка операционной системы была использована для запуска процесса.
            // Когда UseShellExecute установлено в true, можно запускать документы или URL-адреса, а операционная система использует зарегистрированный по умолчанию приложение.
            UseShellExecute = true
        };

        // Запускаем процесс с помощью созданной информации о запуске.
        System.Diagnostics.Process.Start(startInfo);

        // Устанавливаем свойство Handled в true, чтобы указать, что событие было обработано.
        // Это предотвращает дальнейшую обработку события в цепочке обработчиков событий.
        e.Handled = true;
    }
    private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}