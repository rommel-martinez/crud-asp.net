using CRUD.Core.Model;

namespace CRUD.Core.Interface
{
    public interface IUser
    {
         Task<UserModel> AddUpdate(UserModel model);

         Task<UserModel> GetItem(int Id);

         Task<List<UserModel>> GetItemAll();

         Task<UserModel> Delete(int Id);
    }
}