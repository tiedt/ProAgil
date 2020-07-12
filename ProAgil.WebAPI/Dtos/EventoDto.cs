using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class EventoDto
    {
        public int EventoId { get; set; }
        [Required (ErrorMessage="Campo Obrigatório")]
        [StringLength(100,MinimumLength=3,ErrorMessage="Local é entre 3 e 100 caracteres")]
        public string Local { get; set; }
        public string DataEvento { get; set; }
        
        [Required (ErrorMessage="O Tema deve ser obrigatório")]
        public string Tema { get; set; }
        [Range(1,120000, ErrorMessage="Quantidade de pessoas é entre 2 e 120 mil")]
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }
        
        [EmailAddress]
        public string Email {get;set;}
        [Phone]
        public string Telefone {get;set;}
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set;}
        public List<PalestranteDto> Palestrantes { get; set; }


    }
