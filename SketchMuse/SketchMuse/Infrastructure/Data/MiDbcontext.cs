using Microsoft.EntityFrameworkCore;
using SketchMuse.Domain.Entities;

namespace SketchMuse.Infrastructure.Data { 
public class MiDbcontext : DbContext
{
    public MiDbcontext(DbContextOptions<MiDbcontext> options) : base(options)
    {
    }
    public DbSet<Usuario> Usuarios { get; set; }
}
}