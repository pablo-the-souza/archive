using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly ArchiveContext _context;
        public PolicyRepository(ArchiveContext context)
        {
            _context = context;
        }

        public async Task<Policy> GetPolicyByIdAsync(Guid id)
        {
            return await _context.Policies
            .Include(p => p.Box)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

         public async Task<IReadOnlyList<Policy>> GetPoliciesAsync()
        {
            return await _context.Policies
            .Include(p => p.Box)
            .ToListAsync();
        }
    }
}