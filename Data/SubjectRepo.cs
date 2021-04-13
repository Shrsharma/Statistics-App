using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SubjectRepo
    {
        private readonly AppContext _context;

        public SubjectRepo(AppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SubjectModel>> Index()
        {
            return await _context.SubjectModel.ToListAsync();
        }

        public async Task<SubjectModel> Details(string id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.SubjectModel.FirstOrDefaultAsync(m => m.ID == id);
            
        }

    }
}
