using System;

namespace ProAgil.Domain
{
    public class Lote
    {
        public int LoteId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quatidade { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; }
    }
}