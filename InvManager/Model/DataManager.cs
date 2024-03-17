using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace simple_database.Model;
/// <summary>
/// Класс для роаботы с данными модели
/// </summary>
public class DataManager
{
    private ObservableCollection<DataModel> _data;

    public DataManager()
    {
        _data = new ObservableCollection<DataModel>();
    }

    public ObservableCollection<DataModel> Data => _data;

    /// <summary>
    /// Добавляет новый элемент в коллекцию.
    /// </summary>
    public void Add(DataModel item)
    {
        item.Id = _data.Count;
        _data.Add(item);
    }

    /// <summary>
    /// Удаляет элемент из коллекции.
    /// </summary>
    public void Remove(DataModel item)
    {
        _data.Remove(item);
    }

    /// <summary>
    /// Обновляет существующий элемент в коллекции.
    /// </summary>
    public void Update(DataModel item)
    {
        int index = _data.IndexOf(item);
        if (index != -1)
        {
            _data[index] = item;
        }
    }
    public void SaveData(string filePath)
    { ;
        string json = JsonConvert.SerializeObject(_data);
        File.WriteAllText(filePath, json);
    }

    public void LoadData(string filePath)
    {
        if (!File.Exists(filePath))
        {
            _data = new ObservableCollection<DataModel>();
        }

        string json = File.ReadAllText(filePath);
        _data = JsonConvert.DeserializeObject<ObservableCollection<DataModel>>(json);
    }
}

