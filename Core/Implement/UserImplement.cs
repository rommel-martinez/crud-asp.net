using CRUD.Core.Interface;
using CRUD.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Core.Implement
{
    public class UserImplement : IUser
    {
        private readonly DataContext context;

        public UserImplement(DataContext _context)
        {
            context = _context;
        }

        public async Task<UserModel> AddUpdate(UserModel model)
        {
            if(model.Id == 0){
                await context.Users.AddAsync(model);
            }
            else{
                var mdl = await GetItem(model.Id);
                mdl.FirstName = model.FirstName;
                mdl.LastName = model.LastName;
                mdl.Age = model.Age;
                mdl.Gender = model.Gender;
                mdl.MobileNo = model.MobileNo;
                mdl.Email = model.Email;
            }

            await context.SaveChangesAsync();

            return await GetItem(model.Id);
        }

        public async Task<UserModel> Delete(int Id)
        {
            var mdl = await GetItem(Id);
            if(mdl != null){
                mdl.Active = false;
                await context.SaveChangesAsync();
            }

            return await GetItem(Id);
        }

        public async Task<UserModel> GetItem(int Id)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<UserModel>> GetItemAll()
        {
            return await context.Users.Where(x => x.Active == true).ToListAsync();
        }

    }
}