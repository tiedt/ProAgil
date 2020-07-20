using Microsoft.AspNetCore.IdentityUser;
namespace ProAgil.Domain.Identity
{
    public class PapeisUsuario : IdentityUserRole<int>
    {
        public Usuario Usuario { get; set; }
        public Papeis Papeis { get; set; }
    }
}