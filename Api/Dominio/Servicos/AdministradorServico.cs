using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using minimalApi.Dominio.DTO;
using minimalApi.Dominio.Entidades;
using minimalApi.Dominio.Interfaces;
using minimalApi.Infraestrutura.Db;

namespace minimalApi.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;
        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Administrador Incluir(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();

            return administrador;
        }

        public Administrador Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores
                .Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha)
                .FirstOrDefault();
            return adm;
        }

        public Administrador ObterPorId(int id)
        {
            var adm = _contexto.Administradores
                .Where(a => a.Id == id)
                .FirstOrDefault();

            return adm;
        }

        public List<Administrador> Todos(int? pagina)
        {
            var query = _contexto.Administradores.AsQueryable();

            int itensPorPagina = 10;

            if(pagina != null)
            {
                query = query.Skip((int)((pagina - 1) * itensPorPagina)).Take(itensPorPagina);
            }

            return query.ToList();
        }
    }
}