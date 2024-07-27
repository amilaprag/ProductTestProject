using ProductTestProject.Request;

namespace ProductTestProject
{
    public class UintTest1
    {
        [Fact]
        public void Test1()
        {
            // Act
            ProductRequest request = new ProductRequest
            {
                name = "ss",
                data = new Data
                {
                    price = 100,
                }
            };

            // Arrange

            // Assert
        }
    }
}