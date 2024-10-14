using SharedTool.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTool.Business
{
   public class BorrowedToolRepository
    {
        public async Task<List<BorrowedTool>> GetAllBorrowedTools()
        {
            var context = new SharedToolDb();
            var borrowedTools = await context.BorrowedTools.ToListAsync();
            return borrowedTools;
        }
        public async Task<BorrowedTool> GetBorrowedToolById(int id)
        {
            var context = new SharedToolDb();
            var borrowedTool = await context.BorrowedTools.FindAsync(id);
            return borrowedTool;
        }
        public async Task Add(BorrowedTool borrowedTool)
        {
            var context = new SharedToolDb();
            context.BorrowedTools.Add(borrowedTool);
            await context.SaveChangesAsync();

        }
        public async Task Delete(int id)
        {
            var context = new SharedToolDb();
            var borrowedTool = context.BorrowedTools.Find(id);
            context.BorrowedTools.Remove(borrowedTool);
            await context.SaveChangesAsync();
        }
        public async Task Update(BorrowedTool borrowedTool)
        {
            var context = new SharedToolDb();
            var oldBorrowedTool = context.BorrowedTools.Find(borrowedTool.Id);
            context.Entry(oldBorrowedTool).CurrentValues.SetValues(borrowedTool);
            await context.SaveChangesAsync();
        }
    }
}

