using EPIMS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPIMS.Repository.Interfaces
{
    public interface IUsers
    {
        
        IEnumerable<Users> GetAllUsers();
        IEnumerable<Users> GetUserById(int id);
        IEnumerable<Users> GetAllUsersBySP();
        void PostUser(Users users);
        Task<ActionResult<Users>> PostUsers(Users users);
        Task<IActionResult> UpdateUser(int id, Users users);
        Task<ActionResult<Users>> DeleteUser(int id);

        IEnumerable<Userrole> GetAllUserRoles();
        Task<ActionResult<Userrole>> PostUserRole(Userrole userrole);        
        Task<ActionResult<Userrole>> DeleteUserRole(int id);
    }
}
