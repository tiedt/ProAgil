using System.Collections.Generic;

public class PalestranteDto
    {
        public int PalestranteId { get; set; }
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImagemURL { get; set;}
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set;} 
        public List<EventoDto> Eventos {get;set;}
    }