using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IUsersData
    {
        Task<List<UserModel>> GetUsers();
        Task<List<RoleModel>> GetRoles();
        Task InsertUser(UserModel user);
    }
}