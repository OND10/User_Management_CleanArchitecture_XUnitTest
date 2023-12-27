using Microsoft.AspNetCore.Mvc;
using UserManagement_Application.DTOs.Requests;
using UserManagement_Application.DTOs.Responses;
using UserManagement_Application.Services;
using UserManagement_Application.Utly;
using UserManagement_Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement_WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IUserRepository _userRepository;
        

        public UserController(IUserService service,IUserRepository userRepository)
        {
            _service = service;
            _userRepository = userRepository;
        }

       

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<UserResponseDTO>> Get()
        {
            var list=await _service.GetAllAsync();
            return list.Data;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UserRequestDTO> GetId(int id)
        {
            var findid = await _service.GetByIdAsync(id);
            return findid.Data;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<bool> Post([FromBody] UserRequestDTO model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    var addres = await _service.CreateAsync(model);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {

            try
            {
                if (id <= 0)  // Check if id is a valid positive integer
                {
                    return false;
                }

                var delete = await GetId(id);
                if (ModelState.IsValid)
                {


                    if (delete != null && delete != null)
                    {
                        _ = await _service.DeleteAsync(delete);
                        return true;
                    }
                    else
                    {
                        // Handle the case where the specified user with the given id was not found
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new ArgumentNullException(nameof(id));
            }
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        var delete = await _service.GetByIdAsync(id);
            //        _ = await _service.DeleteAsync(delete.Data);
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }

            //}
            //catch (Exception)
            //{
            //    throw new ArgumentNullException(nameof(id));
            //}

        }
    }
}
