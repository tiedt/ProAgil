using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProAgil.Domain.Identity
{
    public class Papeis : IdentityRole<int>
    {
        public List<PapeisUsuario> PapeisUsuario { get; set; }
    }
}