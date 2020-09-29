using AssetsManagement.Domain;
using AssetsManagement.Repo.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsManagement.Repo
{
    public class AssetsManagementRepository : IAssetsManagementRepository
    {
        private readonly AssetsContext _context;

        public AssetsManagementRepository(AssetsContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Assets[]> GetAllAssets()
        {
            IQueryable<Assets> query = _context.Assets.Include(x => x.Brand);

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Assets> GetAssetsById(int id)
        {
            IQueryable<Assets> query = _context.Assets.Include(x => x.Brand);

            query = query.AsNoTracking()
                         .Where(x => x.Id == id)
                         .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Assets> GetAssetsByAssetsNumber(int assetsNumber)
        {
            IQueryable<Assets> query = _context.Assets.Include(x => x.Brand);

            query = query.AsNoTracking()
                         .Where(x => x.AssetNumber == assetsNumber)
                         .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Assets[]> GetAssetsByName(string name)
        {
            IQueryable<Assets> query = _context.Assets.Include(x => x.Brand);

            query = query.AsNoTracking()
                         .Where(x => x.Name.Contains(name))
                         .OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }
        public async Task<User[]> GetAllUsers()
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking()
                         .Where(x => x.Id == id)
                         .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<User[]> GetUsersByEmail(string email)
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking()
                         .Where(x => x.Email.Contains(email))
                         .OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }
        public async Task<User> GetUserByEmailAndPassword(string email, string password)
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking()
                         .Where(x => x.Email == email && x.Password == password)
                         .OrderBy(x => x.Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangeAsync()
        {
           return  (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
             _context.Update(entity);
        }


    }
}
