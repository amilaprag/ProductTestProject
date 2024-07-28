using Newtonsoft.Json;

namespace ProductTestProject.Utility
{
    public class ConfigUtility
    {
        public static string GetConfiguration()
        {
            var path = string.Concat(AppDomain.CurrentDomain.BaseDirectory.Split("ProductTestProject").FirstOrDefault(), "ProductTestProject\\Configuration\\config.json");
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                dynamic items = JsonConvert.DeserializeObject<dynamic>(json);
                var value = items.BaseUri.ToString();
                return value;
            }
        }
    }
}