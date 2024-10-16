using minimalApi.Dominio.DTO;
using minimalApi.Dominio.Entidades;
using minimalApi.Dominio.Interfaces;


namespace Test.Mocks;

public class AdministradorServicoMock : IAdministradorServico
{
    private static List<Administrador> administradores = new List<Administrador>(){
        new Administrador{
            Id = 1,
            Email = "teste@teste.com",
            Senha = "123",
            Perfil = "Adm"
        },
        new Administrador{
            Id = 2,
            Email = "user@teste.com",
            Senha = "123",
            Perfil = "Editor"
        }
    };

    public Administrador Incluir(Administrador administrador)
    {
        administrador.Id = administradores.Count() + 1;
        administradores.Add(administrador);

        return administrador;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        return administradores.Find(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);
    }

    public Administrador ObterPorId(int id)
    {
        return administradores.FirstOrDefault(a => a.Id == id) 
            ?? throw new KeyNotFoundException("Administrador não encontrado.");
    }

    public List<Administrador> Todos(int? pagina)
    {
        return administradores;
    }
}