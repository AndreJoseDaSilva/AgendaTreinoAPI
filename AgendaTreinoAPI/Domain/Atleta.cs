using System;

namespace AgendaTreinoAPI.Domain
{
    public sealed class Atleta
    {
        public  long Id { get; set; }   
        public string Nome { get; set; }
        public string Aplelido { get; set; }    
        public string Celular { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? CanceladoEm { get; set; }
    }
}
