using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimalApi.Dominio.Entidades;
using minimalApi.Infraestrutura.Db;
using minimalApi.Dominio.Servicos;
using System.Reflection;

namespace Test.Dominio.Entidades;

[TestClass]
public class AdministradorServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {

        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
        
        var builder = new ConfigurationBuilder()
            .SetBasePath(path)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        
        var config = builder.Build();

        return new DbContexto(config);
    }
    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        //Arrange
        var contexto = CriarContextoDeTeste();
        contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
        
        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "123";
        adm.Perfil = "Adm";
        var admServico = new AdministradorServico(contexto);

        //Act
        admServico.Incluir(adm);
        

        //Assert
        Assert.AreEqual(1, admServico.Todos(1).Count);
    }

    [TestMethod]
    public void TestantoBuscarPorId()
    {
        //Arrange
        var contexto = CriarContextoDeTeste();
        contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
        
        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "123";
        adm.Perfil = "Adm";
        
        var admServico = new AdministradorServico(contexto);

        //Act
        admServico.Incluir(adm);
        var admteste = admServico.ObterPorId(adm.Id);
        

        //Assert
        Assert.AreEqual(1, admteste.Id);
    }
}