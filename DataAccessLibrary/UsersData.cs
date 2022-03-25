using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class UsersData : IUsersData
    {
        private readonly ISqlDataAccess _db;

        public UsersData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<UserModel>> GetUsers()
        {
            string sql = "select * from dbo.Users";

            return _db.LoadData<UserModel, dynamic>(sql, new { });
        }

        public Task<List<RoleModel>> GetRoles()
        {
            string sql = "select * from dbo.Roles";

            return _db.LoadData<RoleModel, dynamic>(sql, new { });
        }

        public Task InsertUser(UserModel user)
        {
            string sql = @"insert into dbo.Users (
                Email, 
                Username, 
                PasswordHash, 
                PasswordSalt, 
                RoleId, 
                DateOfBirth) values (
                @Email, 
                @Username, 
                @PasswordHash, 
                @PasswordSalt, 
                @RoleId, 
                @DateOfBirth);";

            return _db.SaveData(sql, user);
        }
    }
}
