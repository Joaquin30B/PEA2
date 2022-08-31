using Pacial.Domine;
using Parcial.Data;
using System.Collections.Generic;

namespace Parcial.Logic
{
    public class CategoriaBL
    {
        public static List<Categoria> Listar()
        {
            var categoriaData = new CategoriaData();
            return categoriaData.Listar();
        }
    }
}
