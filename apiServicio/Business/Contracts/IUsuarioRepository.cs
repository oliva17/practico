using System.Collections.Generic;
using System.Threading.Tasks;
using apiServicio.Models;

namespace apiServicio.Business.Contracts
{
      public interface IUsuarioRepository
    {
        Task<Usuario> GetNombreUsuario(string nombreusuario);
        Task<List<Usuario>> GetList();
        Task<Usuario> AgregaActualiza(Usuario l, string t);

    }
}
