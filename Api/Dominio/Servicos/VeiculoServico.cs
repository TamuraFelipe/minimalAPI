using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minimalApi.Dominio.Entidades;
using minimalApi.Dominio.Interfaces;
using minimalApi.Infraestrutura.Db;

namespace minimalApi.Dominio.Servicos
{
    public class VeiculoServico : IVeiculoServico
    {
        private readonly DbContexto _contexto;

        public VeiculoServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public List<Veiculo> Todos(int? pagina = 1, string nome = null, string marca = null)
        {
            var query =  _contexto.Veiculos.AsQueryable();
            if(!string.IsNullOrEmpty(nome))
            {
                query = query.Where(v => EF.Functions.Like(v.Nome, $"%{nome}%"));
            }

            int itensPorPagina = 10;
            if(pagina != null)
            {
                query = query.Skip((int)((pagina - 1) * itensPorPagina)).Take(itensPorPagina);
            }
            return query.ToList();
        }

        public Veiculo? BuscaPorId(int id)
        {
            return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault();
        }

        public void Incluir(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        void IVeiculoServico.Atualizar(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public void Apagar(int id)
        {
            _contexto.Veiculos.Remove(_contexto.Veiculos.Find(id));
            _contexto.SaveChanges();
        }
    }
}