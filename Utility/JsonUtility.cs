using Newtonsoft.Json;
using System.Text.Json;

namespace ProductTestProject.Utility
{
    public class JsonUtility
    {
        public static void SavedJson(object request, string fileName)
        {
            // Get the path to the project's main directory (e.g., where the project file is located)
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;

            // Define the folder path (e.g., "Data")
            string folderPath = Path.Combine(projectRoot, "Data");

            Directory.CreateDirectory(folderPath);
            string filePath = Path.Combine(folderPath, fileName + ".json");

            string jsonString = System.Text.Json.JsonSerializer.Serialize(request, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }

        public static object ReadJson(string fileName)
        {
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
            string folderPath = Path.Combine(projectRoot, "Data");
            string filePath = Path.Combine(folderPath, fileName + ".json");

            // Read the JSON string from the file
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                dynamic data = JsonConvert.DeserializeObject<object>(jsonString);
                return data;
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
                return null;
            }
        }

    }
}