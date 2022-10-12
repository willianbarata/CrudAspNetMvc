using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaData.DAO
{
    public class BdSqlServerDao
    {
        //Configuração do banco de dados
        public readonly string conexaoSqlServer = @"Data Source=(localdb)\MSSQLLocalDB;" +
            " Database=Empresa;" +
            " Integrated Security=True";
    }
}
