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

    /// <summary>
    ///  Конструктор DataManager
    /// </summary>
    public DataManager()
    {
        _data = new ObservableCollection<DataModel>();
    }

    /// <summary>
    ///  Коллекция данных типа DataModel
    /// </summary>
    public ObservableCollection<DataModel> Data => _data;

    /// <summary>
    /// Добавление нового элемента в коллекцию
    /// </summary>
    /// <param name="item">Элемент коллекции (Data)</param>
    public void Add(DataModel item)
    {
        item.Id = _data.Count;
        _data.Add(item);
    }

    /// <summary>
    /// Удаление элемента из коллекции
    /// </summary>
    /// <param name="item">Элемент коллекции (Data)</param>
    public void Remove(DataModel item)
    {
        _data.Remove(item);
    }

    /// <summary>
    /// Обновление элемента в коллекции
    /// </summary>
    /// <param name="item">Элемент коллекции (Data)</param>
    public void Update(DataModel item)
    {
        int index = _data.IndexOf(item);
        if (index != -1)
        {
            _data[index] = item;
        }
    }
    /// <summary>
    ///  Сохранение данных в файл
    /// </summary>
    /// <param name="filePath">Путь файла</param>
    public void SaveData(string filePath)
    { ;
        string json = JsonConvert.SerializeObject(_data);
        File.WriteAllText(filePath, json);
    }

    /// <summary>
    /// Загрузка данных из файла
    /// </summary>
    /// <param name="filePath">Путь файла</param>
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

