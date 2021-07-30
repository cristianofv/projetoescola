using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensino.Web.Models.Enum
{
    public enum Genero
    {
        [Description("Masculino")]
        Masculino = 'M',
        [Description("Feminino")]
        Feminino = 'F',
        [Description("Não Informado")]
        NaoInformado = 'O',
    }
}
