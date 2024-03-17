using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using simple_database.Model;

namespace simple_database.View;

public partial class UpdateModelView : Window
{
    private ConditionToStringConverter _converter = new ConditionToStringConverter();
    private DataManager _dataManager;
    private DataModel _data;
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

    private void UpdateView_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if(e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }

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

    private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}