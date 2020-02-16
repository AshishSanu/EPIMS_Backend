using EPIMS.Data.Models;
using EPIMS.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EPIMS.Repository.Services
{
    public class UserService : IUsers
    {
        private readonly UnitOfWork _unitOfWork;

        public UserService(IUnitOfWork _uow)
        {
            this._unitOfWork = _uow as UnitOfWork;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _unitOfWork.Repository<Users>().GetAll();
        }

        public IEnumerable<Users> GetAllUsersBySP()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetUserById(int id)
        {
            throw new NotImplementedException();
        }
        public void PostUser(Users users)
        {
            _unitOfWork.Repository<Users>().Add(users);
        }
        public Task<ActionResult<Users>> PostUsers(Users users)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateUser(int id, Users users)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Users>> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Userrole> GetAllUserRoles()
        {
            throw new NotImplementedException();
        }


        public Task<ActionResult<Userrole>> PostUserRole(Userrole userrole)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Userrole>> DeleteUserRole(int id)
        {
            throw new NotImplementedException();
        }

        

       
    }
}
