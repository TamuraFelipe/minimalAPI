using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimalApi.Dominio.DTO;
using minimalApi.Dominio.Entidades;

namespace minimalApi.Dominio.Interfaces
{
    public interface IAdministradorServico
    {
        Administrador Login(LoginDTO loginDTO);

        Administrador Incluir(Administrador administrador);

        Administrador ObterPorId(int id);

        List<Administrador> Todos(int? pagina);
    }
}