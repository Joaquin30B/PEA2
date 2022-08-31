using Pacial.Domine;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Parcial.Data
{
    public class CategoriaData
    {
        string cadenaConexion = "server=localhost\\SQLEXPRESS; database=Parcial; Integrated Security=true";
        public List<Categoria> Listar()
        {
            var listado = new List<Categoria>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Categoria", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Categoria Cat;
                            while (lector.Read())
                            {
                                Cat = new Categoria();
                                Cat.IdCategoria = int.Parse(lector[0].ToString());
                                Cat.CodigoCategoria = lector[1].ToString();
                                Cat.Nombre = lector[2].ToString();
                                Cat.Observacion = lector[3].ToString();
                                listado.Add(Cat);
                            }
                        }
                    }
                }
            }
            return listado;
        }


        public Categoria BuscarPorId(int id)
        {
            var categoria = new Categoria();
            return categoria;
        }

        public bool Insertar()
        {
            return true;
        }


    }
}
