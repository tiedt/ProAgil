namespace ProAgil.Domain
{
    public class RedeSocial
    {
        public int RedeSocialId { get; set; }
        public string Nome { get; set; }
        public string  ImagemURL { get; set; }
        public  int? EventoId  { get; set; }
        public Evento Evento { get; }
        public int? PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
    }
}