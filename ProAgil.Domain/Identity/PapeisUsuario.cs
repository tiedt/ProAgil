using Microsoft.AspNetCore.Identity;

namespace ProAgil.Domain.Identity
{
    public class PapeisUsuario : IdentityUserRole<int>
    {
        public Usuario Usuario { get; set; }
        public Papeis Papeis { get; set; }
    }
}