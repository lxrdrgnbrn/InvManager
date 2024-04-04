using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using simple_database.Model;

namespace simple_database.View;

public partial class UpdateModelView : Window
{
    private DataManager _dataManager;
    private DataModel _data;
    /// <summary>
    ///  Иницилизация окна обновления элемента
    /// </summary>
    /// <param name="dataManager">Коллекця</param>
    /// <param name="data">Элемент</param>
    public UpdateModelView(DataManager dataManager, DataModel data) 
    {
        InitializeComponent();
        _dataManager = dataManager;
        _data = data;
        ConditionBox.DataContext = _data;
        NameBox.Text = _data.Name;
        DescriptionBox.Text = _data.Description;
        CategoryBox.Text = _data.Category;
        InvNumberBox.Text = _data.InventoryNumber;
        DataBox.Text = _data.PurchaseDate.ToString("dd.MM.yy");
    }

    /// <summary>
    ///  Перестаскивание окна
    /// </summary>
    private void UpdateView_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if(e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }
    
    /// <summary>
    ///  Кнопка добавления
    /// </summary>
    private void AddBtn_OnClick(object sender, RoutedEventArgs e)
    {
        
        if (NameBox.Text != "")
        {
            _data.Name = NameBox.Text;
            if (DescriptionBox.Text != "")
            {
                _data.Description = DescriptionBox.Text;
                if (CategoryBox.Text != "")
                {
                    _data.Category = CategoryBox.Text;
                    if (InvNumberBox.Text != "")
                    {
                        _data.InventoryNumber = InvNumberBox.Text;
                        if (DataBox.Text != "")
                        {
                            _data.PurchaseDate = DataBox.SelectedDate.Value;
                            if (ConditionBox.SelectedItem != null)
                            {
                                _dataManager.Update(_data);
                                // установка владельца
                                MainModelView mainModelView = this.Owner as MainModelView;
                                mainModelView.UpdateTableItemSource();
                                this.Close();
                            }
                            else
                            {
                                ConditionBox.BorderBrush = Brushes.Tomato;
                            }
                        }
                        else
                        {
                            DataBox.BorderBrush = Brushes.Tomato;
                        }
                    }
                    else
                    {
                        InvNumberBox.BorderBrush = Brushes.Tomato;
                    }
                }
                else
                {
                    CategoryBox.BorderBrush = Brushes.Tomato;
                }
            }
            else
            {
                DescriptionBox.BorderBrush = Brushes.Tomato;
            }
        }
        else
        {
            NameBox.BorderBrush = Brushes.Tomato;
        }
    }

    /// <summary>
    /// Обработчик кнопки закрытия
    /// </summary>
    private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}