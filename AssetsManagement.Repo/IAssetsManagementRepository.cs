using AssetsManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetsManagement.Repo
{
    public interface IAssetsManagementRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangeAsync();
        Task<Assets[]> GetAllAssets();
        Task<Assets> GetAssetsById(int id);
        Task<Assets[]> GetAssetsByName(string name);
        Task<Assets> GetAssetsByAssetsNumber(int assetsNumber);
        Task<User[]> GetAllUsers();
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task<User> GetUserById(int id);
        Task<User[]> GetUsersByEmail(string email);
    }
}
