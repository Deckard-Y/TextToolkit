using System.Text.Json;

namespace TextToolkit
{
    public class ConfigurationManager<T> where T : new()
    {
        private string _filePath;
        public T Settings { get; private set; }

        public ConfigurationManager(string filePath)
        {
            _filePath = filePath;
            // デフォルトの設定インスタンスを作成
            Settings = new T();
        }

        public void Load()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                Settings = JsonSerializer.Deserialize<T>(json);
            }
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(Settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}