
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using Pacial.Domine;

namespace Parcial.Data
{
    public class ProductoData

    {
        string cadenaConexion = "server=localhost\\SQLEXPRESS; Database=Parcial; Integrated Security = true";
        public List<Producto> Listar()
        {
            var listado = new List<Producto>();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand(" SELECT * FROM Producto ", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Producto producto;
                            while (lector.Read())
                            {
                                producto = new Producto();
                                producto.IdProducto = int.Parse(lector[0].ToString());
                                producto.Nombre = lector[1].ToString();
                                producto.Marca = lector[2].ToString();
                                producto.Precio = decimal.Parse(lector[3].ToString());


                                listado.Add(producto);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public Producto BuscarPorId(int id)
        {
            Producto producto = new Producto();
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand(" SELECT * FROM Producto WHERE IdProducto = @IdProducto ", conexion))
                {
                    comando.Parameters.AddWithValue("@IdProducto", id);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            lector.Read();
                            producto.IdProducto = int.Parse(lector[0].ToString());
                            producto.Nombre = lector[1].ToString();
                            producto.Marca = lector[2].ToString();
                            producto.Precio = decimal.Parse(lector[3].ToString());


                        }
                    }
                }
            }
            return producto;
        }

        public bool Insertar(Producto producto)
        {
            int filasInsertadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = " INSERT INTO Producto(Nombre,Marca,Precio,Stock) "+
                    " VALUES(@Nombre,@Marca,@Precio,@stock) ";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Marca", producto.Marca);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    filasInsertadas = comando.ExecuteNonQuery();

                }
            }
            return filasInsertadas > 0;
        }

        public bool Actualizar(Producto producto)
        {
            int filasActualizadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = " UPDATE Producto SET Nombre = @Nombre, Marca = @Marca, Precio = @Precio  " +
                    " WHERE IdProducto = @IdProducto ";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Marca", producto.Marca);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@IdProducto", producto.IdProducto);

                    filasActualizadas = comando.ExecuteNonQuery();
                }
            }
            return filasActualizadas > 0;
        }

        public bool Eliminar(int id)
        {
            int filasEiminadas = 0;
            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                var sql = " DELETE FROM Producto WHERE IdProducto = @IdProducto ";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@IdProducto", id);
                    filasEiminadas = comando.ExecuteNonQuery();
                }
            }
            return filasEiminadas > 0;
        }
    }
}
