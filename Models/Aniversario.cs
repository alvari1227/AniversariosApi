namespace AniversariosApi.Models
{
    public class Aniversario
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public DateTime Data { get; set; }

        public string? Observacao { get; set; } 
    }
}
