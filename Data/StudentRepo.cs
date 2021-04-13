using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Data
{
    public class StudentRepo
    {
        private readonly AppContext _context;

        public StudentRepo(AppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentModel>> Index()
        {
            return await _context.StudentModel.ToListAsync();
        }

        public async Task<StudentModel> Details(string id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.StudentModel.FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task Create(StudentModel studentModel)
        {
            _context.Add(studentModel);
            await _context.SaveChangesAsync();
        }

        public async Task<StudentModel> Edit(string id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.StudentModel.FindAsync(id);
        }

        public async Task<StudentModel> Edit(string id, StudentModel studentModel)
        {
            if (id != studentModel.ID)
            {
                return null;
            }

            try
            {
                _context.Update(studentModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(studentModel.ID))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return studentModel;

        }

        public async Task<StudentModel> Delete(string id)
        {
            if (id == null)
            {
                return null;
            }

            return await _context.StudentModel.FirstOrDefaultAsync(m => m.ID == id);
            
        }

        public async Task DeleteConfirmed(string id)
        {
            var studentModel = await _context.StudentModel.FindAsync(id);
            _context.StudentModel.Remove(studentModel);
            await _context.SaveChangesAsync();
        }


        private bool StudentModelExists(string id)
        {
            return _context.StudentModel.Any(e => e.ID == id);
        }

    }
}
