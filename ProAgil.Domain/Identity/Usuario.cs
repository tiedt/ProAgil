using Microsoft.AspNetCore.IdentityUser;
namespace ProAgil.Domain.Identity
{
    public class Usuario : IdentityUser<int>
    {
        [Column(TypeName = "nvarchar(150)")]
        public string NomeCompleto { get; set; }

        public List<PapeisUsuario> PapeisUsuario {get;set;}
    }
}