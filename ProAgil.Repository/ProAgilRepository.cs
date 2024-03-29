using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using ProAgil.Respository;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;
        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
            // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; aqui destravamos todos nossos recursos
        }

        //Gerais
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //Evento
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);
            if (includePalestrantes)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                .ThenInclude(p => p.Palestrante);
            }
            query = query.AsNoTracking().OrderBy(c => c.EventoId);
            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetAllEventosAsyncById(int EventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);
            if (includePalestrantes)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                .ThenInclude(p => p.Palestrante);
            }
            query = query.AsNoTracking().OrderBy(c => c.EventoId)
            .Where(c => c.EventoId == EventoId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);
            if (includePalestrantes)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                .ThenInclude(p => p.Palestrante);
            }
            query = query.AsNoTracking().OrderByDescending(c => c.DataEvento)
            .Where(c => c.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
        }

        //Palestrante
        public async Task<Palestrante[]> GetAllPalestranteAsyncByName(string name, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                       .Include(c => c.RedesSociais);
            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                .ThenInclude(e => e.Evento);
            }
            query = query.AsNoTracking().Where(c => c.Nome.ToLower().Contains(name.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteAsyncById(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(c => c.RedesSociais);
            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                .ThenInclude(e => e.Evento);
            }
            query = query.AsNoTracking().OrderBy(c => c.Nome).Where(p => p.PalestranteId == PalestranteId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(c => c.RedesSociais);
            if (includeEventos)
            {
                query = query.Include(pe => pe.PalestranteEventos)
                .ThenInclude(p => p.Evento);
            }
            query = query.AsNoTracking().OrderByDescending(c => c.Nome);
            return await query.ToArrayAsync();
        }
    }
}