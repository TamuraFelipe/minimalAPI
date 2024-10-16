using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimalApi.Dominio.Entidades;

namespace minimalApi.Dominio.Interfaces
{
    public interface IVeiculoServico
    {
        
        List<Veiculo>? Todos(int? pagina = 1, string? nome = null, string? marca = null);

        Veiculo? BuscaPorId(int id);

        void Incluir(Veiculo veiculo);

        void Atualizar(Veiculo veiculo);

        void Apagar(int id);
    }
}