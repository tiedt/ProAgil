using Microsoft.AspNetCore.IdentityUser;
namespace ProAgil.Domain.Identity
{
    public class Papeis : IdentityRole<int>
    {
        public List<PapeisUsuario> PapeisUsuario { get; set; }
    }
}