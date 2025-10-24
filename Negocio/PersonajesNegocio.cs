using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PersonajesNegocio
    {
        public List<Personajes> Listar()
        {
            List<Personajes> lista = new List<Personajes>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT " +
                    "p.Id, " +
                    "p.Codigo,  " +
                    " p.Nombre, " +
                    " p.Descripcion, " +
                    "r.NombreRol AS Rol, " +
                    " h.TipoDeNen AS TipoDeNen, " +
                    " i.Url AS ImagenUrl " +
                    "FROM Personajes p " +
                    "INNER JOIN RolesProtagonicos r ON p.IdRol = r.IdRol " +
                    " INNER JOIN Habilidades h ON p.IdHabilidad = h.IdHabilidad " +
                    " LEFT JOIN Imagenes i ON i.IdPersonaje = p.Id " +
                    "ORDER BY p.Id;"
                    );

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Personajes personaje = new Personajes
                    {
                        Id = (int)datos.Lector["Id"],
                        Codigo = datos.Lector["Codigo"].ToString(),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Descripcion = datos.Lector["Descripcion"].ToString(),
                        Rol = new RolProtagonico
                        {
                            Descripcion = datos.Lector["Rol"].ToString()
                        },
                        Habilidad = new Habilidad
                        {
                            Descripcion = datos.Lector["TipoDeNen"].ToString()
                        }
                    };

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        personaje.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(personaje);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar personajes: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}