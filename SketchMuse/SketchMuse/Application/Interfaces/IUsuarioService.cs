namespace SketchMuse.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<User?> Registro(string email, string password);
        Task<User?> Login(string email, string password);
    }
}
