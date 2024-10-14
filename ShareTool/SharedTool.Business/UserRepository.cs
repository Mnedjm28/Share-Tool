using SharedTool.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTool.Business
{
    public class UserRepository
    {
        public async Task<List<User>> GetAllTools()
        {
            var context = new SharedToolDb();
            return await context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var context = new SharedToolDb();
            return await context.Users.FindAsync(id);
        }

        public async Task Add(User user)
        {
            var context = new SharedToolDb();
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var context = new SharedToolDb();
            var user = await context.Users.FindAsync(id);
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            var context = new SharedToolDb();
            var oldUser = await context.Users.FindAsync(user.Id);
            context.Entry(oldUser).CurrentValues.SetValues(user);
            await context.SaveChangesAsync();
        }
    }
}
