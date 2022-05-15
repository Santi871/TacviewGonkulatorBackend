using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TacviewGonkulatorBackend.Services
{
    public interface ITacviewService
    {
        public Task<Processedtacviewmodel> GetProcessedTacview(string sha256Hash);
        public Task<Processedtacviewmodel> GetProcessedTacview(Guid guid);
        public Task RegisterTacview(Processedtacviewmodel tacview);
        public Task<IEnumerable<Tacviewmodel>> GetAllTacviews();
        public Task<IEnumerable<Blacklistedmissilemodel>> GetMissileBlacklist();
    }

    public class TacviewService : ITacviewService
    {
        private readonly missile_dataContext _context;

        public TacviewService(missile_dataContext context)
        {
            _context = context;
        }

        public async Task<Processedtacviewmodel> GetProcessedTacview(string sha256Hash)
        {
            return await _context.Processedtacviewmodels
                .FirstOrDefaultAsync(t => t.Filehash == sha256Hash);
        }
        
        public async Task<Processedtacviewmodel> GetProcessedTacview(Guid guid)
        {
            return await _context.Processedtacviewmodels
                .FirstOrDefaultAsync(t => t.TacviewGuid == guid);
        }

        public async Task RegisterTacview(Processedtacviewmodel tacview)
        {
            tacview.Completed = false;
            await _context.Processedtacviewmodels.AddAsync(tacview);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tacviewmodel>> GetAllTacviews()
        {
            return await _context
                .Tacviewmodels
                .Include(t => t.Missileshotmodels)
                .ToListAsync();
        }

        public async Task<IEnumerable<Blacklistedmissilemodel>> GetMissileBlacklist()
        {
            return await _context.Blacklistedmissilemodels.ToListAsync();
        }
    }
}