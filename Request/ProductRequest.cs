namespace ProductTestProject.Request
{
    public class ProductRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public int year { get; set; }
        public float price { get; set; }
        public string CPUmodel { get; set; }
        public string Harddisksize { get; set; }
    }
}