namespace ApiAppCot.Models
{
    public class Ativos
    {
        public int Id { get; set; }
        public int fk_idfavoritos { get; set; }
        public string? Nome { get; set; }
        public double valor_alvo { get; set; }
        public bool Alarme { get; set; }
    }
}
