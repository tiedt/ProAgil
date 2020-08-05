using System.ComponentModel.DataAnnotations;

public class LoteDto
    {
        public int LoteId { get; set; }
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        
        [Range(2,120000, ErrorMessage="A quantidade é entre 2 e 120 mil")]
        public int Quatidade { get; set; }
    }