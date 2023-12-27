using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services;
using UserManagement_Application.Utly;
using UserManagement_Domain.Entities;
using UserManagement_Domain.Interfaces;
using UserManagement_Infustracture.DBContext;

namespace UserManagement_Infustracture.GraphQl
{
    public class UserQuery
    {

        private readonly IUserRepository _repository;
        private readonly AppDbContext _context;
        private readonly IUserService _service;

        public UserQuery(IUserRepository repository, AppDbContext context, IUserService service)
        {
            _repository = repository;
            _context = context;
            _service = service;
        }

        //protected void Configure(IObjectTypeDescriptor descriptor)
        //{
        //    descriptor.Field("users")
        //        .Type<UserType>()
        //        .Argument("id", arg => arg.Type<IntType>())
        //        .Resolve(context =>
        //        {
        //            var userId = context.ArgumentValue<int>("id");
        //            var user = _repository.GetByIdAsync(userId);
        //            return user;
        //        });
        //}



        public async Task<IEnumerable<User>> Users()
        {
            return await _repository.GetAllAsync();
        }

    }
}
