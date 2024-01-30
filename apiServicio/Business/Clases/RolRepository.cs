using apiServicio.Business.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using apiServicio.Models;
using System;
using apiServicio.Business.Contracts;
using System.Collections.Generic;  // Agrega esta línea para List<>
using System.Threading.Tasks;

namespace apiServicio.Business.Clases
{
    public class RolRepository: IRolRepository
    {
        private readonly string conect;
        public RolRepository(IConfiguration _con)
        {
            conect = _con.GetConnectionString("conBase");
        }

        public async Task<List<Rol>> GetList()
        {
            List<Rol> list= new List<Rol>();
            Rol l;
            using (SqlConnection con = new SqlConnection(conect))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from Rol;",con);
                using(var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync()) 
                    {
                        l = new Rol();
                        l.Id = Convert.ToInt32(reader["Id"]);
                        l.NombreRol = Convert.ToString(reader["NombreRol"]);
                        list.Add(l);
                    }
                }
            }
                return list;
        }

        public async Task<Rol> AgregaActualiza(Rol l, string nombre)
        {
            // Aquí implementa la lógica para agregar o actualizar un rol
            // Puedes utilizar la conexión a la base de datos y ejecutar las consultas necesarias

            // Ejemplo simple: Crear un nuevo Rol con los parámetros dados
            Rol nuevoRol = new Rol
            {
                Id = l.Id,
                NombreRol = nombre
            };

            // Puedes realizar la lógica real para agregar o actualizar en tu base de datos aquí

            return nuevoRol;
        }
    }
}
