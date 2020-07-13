using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.WebApi.Commands
{
    public class ConsolidadoCommands
    {
        public class AutenticarUsuarioCommand
        {
            public string Login { get; set; }
            public string Senha { get; set; }
        }

        public class ObterConsolidadoCommand
        {
        }
    }
}
