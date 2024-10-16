
using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Query;
using minimalApi.Dominio.DTO;
using minimalApi.Dominio.ModelViews;
using Test.Helpers;

namespace Test.Requests
{
    [TestClass]
    public class AdministradorRequestTest
    {
        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Setup.ClassInit(testContext);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Setup.ClassCleanup();
        }

        [TestMethod]
        public async Task TestarGetSetPropriedades()
        {
            //Arrange
            var loginDTO = new LoginDTO{
                Email = "teste@teste.com",
                Senha = "123"
            };
            var content = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "application/json");
            
            //Act
            var response = await Setup.client.PostAsync("/administradores/login", content);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            
            var result = await response.Content.ReadAsStringAsync();
            var admLogado = JsonSerializer.Deserialize<AdmLogado>(result, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            });

            Assert.IsNotNull(admLogado?.Email);
            Assert.IsNotNull(admLogado.Perfil);
            Assert.IsNotNull(admLogado.Token); 
        }
    }
}