using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BoxRepository : IBoxRepository
    {
        private readonly ArchiveContext _context;
        public BoxRepository(ArchiveContext context)
        {
            _context = context;
        }

        public async Task<Box> GetBoxByIdAsync(int id)
        {
            return await _context.Boxes.FindAsync(id);
        }

        public async Task<IReadOnlyList<Box>> GetBoxesAsync()
        {
            return await _context.Boxes.ToListAsync();
        }
    }
}