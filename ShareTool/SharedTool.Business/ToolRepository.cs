using SharedTool.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTool.Business
{
    public class ToolRepository
    {
        public async Task<List<Tool>> GetAllTools()
        {
            var context = new SharedToolDb();

            return (await context.Tools.ToListAsync()).Select(o => new Tool
            {
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                ImageUrl = o.ImageUrl,
                Quantity = o.Quantity - o.BorrowedTools.Where(b => b.Approved).Count(),
            }).ToList();
        }

        public async Task<Tool> GetToolById(int id)
        {
            var context = new SharedToolDb();
            return await context.Tools.FindAsync(id);
        }

        public async Task Add(Tool tool)
        {
            var context = new SharedToolDb();
            context.Tools.Add(tool);
            await context.SaveChangesAsync();
        }

        public async Task<string> Delete(int id)
        {
            var context = new SharedToolDb();
            var tool = await context.Tools.FindAsync(id);
            context.Tools.Remove(tool);
            await context.SaveChangesAsync();
            return tool.ImageUrl;
        }

        public async Task Update(Tool tool)
        {
            var context = new SharedToolDb();
            var oldTool = await context.Tools.FindAsync(tool.Id);
            context.Entry(oldTool).CurrentValues.SetValues(tool);
            await context.SaveChangesAsync();
        }
    }
}
