using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimalApi.Dominio.ModelViews
{
    public struct Home
    {
        public string Mesagem { get => "Bem vindo a API de Veículos - Minimal API"; }
        public string Doc { get => "/swagger"; }
    }
}