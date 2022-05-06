namespace SystemSale.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? SegundoNome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }

        public Login()
        {
        }
        public Login(int id, string nome, string segundoNome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            SegundoNome = segundoNome;
            Email = email;
            Senha = senha;
        }
    }
}
