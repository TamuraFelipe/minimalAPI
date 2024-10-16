using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimalApi.Dominio.Enums;

namespace minimalApi.Dominio.DTO
{
    public class AdministradorDTO
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public Perfil? Perfil { get; set; }
    }
}