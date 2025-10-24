using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdImagen, URL, Descripcion, IdPersonaje FROM IMAGENES;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen img = new Imagen
                    {
                        IdImagen = (int)datos.Lector["IdImagen"],
                        UrlImagen = datos.Lector["URL"].ToString(),
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        IdPersonaje = (int)datos.Lector["IdPersonaje"]
                    };

                    lista.Add(img);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar imagenes: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarImagen(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Imagenes (Url, Descripcion, IdPersonaje) VALUES (@url, @descripcion, @idPersonaje)");
                datos.setearParametros("@url", imagen.UrlImagen);
                datos.setearParametros("@descripcion", imagen.Descripcion);
                datos.setearParametros("@idPersonaje", imagen.IdPersonaje);
                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificarImagen(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                    "UPDATE IMAGENES SET " +
                    "IdArticulo = @idArticulo, " +
                    "URL = @imagenUrl, " +
                    "Descripcion = @idPersonaje " +
                    "WHERE Id = @idImagen");

                datos.setearParametros("@idImagen", imagen.IdImagen);
                datos.setearParametros("@imagenUrl", imagen.UrlImagen);
                datos.setearParametros("@descripcion", imagen.Descripcion);
                datos.setearParametro("@idPersonaje", imagen.IdPersonaje);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM IMAGENES WHERE IdImagen = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
