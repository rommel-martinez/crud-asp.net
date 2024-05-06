using CRUD.Core.Interface;
using CRUD.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{

    private readonly IUser iUser;

    public UserController(IUser _iUser)
    {
        iUser = _iUser;
    }

    [HttpPost]
    public async Task<UserModel> AddUpdate(UserModel model)
    {
        return await iUser.AddUpdate(model);
    }

    [HttpGet]
    public async Task<UserModel> GetUser(int Id)
    {
        return await iUser.GetItem(Id);
    }

    [HttpGet]
    public async Task<List<UserModel>> GetAllUser()
    {
        return await iUser.GetItemAll();
    } 

    [HttpDelete]
    public async Task<UserModel> DeleteUser(int Id)
    {
        return await iUser.Delete(Id);
    }        
}
