using LibraryManagement.Data;
using LibraryManagement.Entities;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class StudentServices : IStudentServices
    {
        public List<Student> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search)
        {

            using (var _LMContext = new LMContext())
            {
                string columnNameAsc = "";
                string columnNameDsc = "";
                List<Student> Students = new List<Student>();
                if (sortCol == 0 && sortDir == "asc") columnNameAsc = "Name";
                else if (sortCol == 0 && sortDir == "dsc") columnNameDsc = "Name";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "Code";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "Code";
                else if (sortCol == 2 && sortDir == "asc") columnNameAsc = "Semester";
                else if (sortCol == 2 && sortDir == "dsc") columnNameDsc = "Semester";
                else if (sortCol == 3 && sortDir == "asc") columnNameAsc = "Gender";
                else if (sortCol == 3 && sortDir == "dsc") columnNameDsc = "Gender";
                else if (sortCol == 4 && sortDir == "asc") columnNameAsc = "Address";
                else if (sortCol == 4 && sortDir == "dsc") columnNameDsc = "Address";
                else if (sortCol == 5 && sortDir == "asc") columnNameAsc = "City";
                else if (sortCol == 5 && sortDir == "dsc") columnNameDsc = "City";
                else if (sortCol == 6 && sortDir == "asc") columnNameAsc = "Phone";
                else if (sortCol == 6 && sortDir == "dsc") columnNameDsc = "Phone";

                if (sortDir == "asc" && string.IsNullOrEmpty(search) == false)
                {
                    Students = _LMContext.Students.OrderBy(x => columnNameAsc).Where(x => x.Name.ToString().ToLower().Contains(search.ToLower()) || x.Code.ToString().ToLower().Contains(search.ToLower()) || x.Semester.ToString().ToLower().Contains(search.ToLower()) || x.Gender.ToString().ToLower().Contains(search.ToLower()) || x.Email.ToString().ToLower().Contains(search.ToLower()) || x.Address.ToString().ToLower().Contains(search.ToLower()) || x.City.ToString().ToLower().Contains(search.ToLower()) || x.Phone.ToString().ToLower().Contains(search.ToLower())).Include(y => y.StudentPictures.Select(x => x.Pictures)).Include(w => w.Departments).ToList();
                }

                else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
                {
                    Students = _LMContext.Students.OrderBy(x => columnNameDsc).Where(x => x.Name.ToString().ToLower().Contains(search.ToLower()) || x.Code.ToString().ToLower().Contains(search.ToLower()) || x.Semester.ToString().ToLower().Contains(search.ToLower()) || x.Gender.ToString().ToLower().Contains(search.ToLower()) || x.Email.ToString().ToLower().Contains(search.ToLower()) || x.Address.ToString().ToLower().Contains(search.ToLower()) || x.City.ToString().ToLower().Contains(search.ToLower()) || x.Phone.ToString().ToLower().Contains(search.ToLower())).Include(y => y.StudentPictures.Select(x => x.Pictures)).Include(w => w.Departments).ToList();
                }
                else if (sortDir == "asc")
                {
                    Students = _LMContext.Students.OrderBy(x => columnNameAsc).Include(y => y.StudentPictures.Select(x => x.Pictures)).Include(w => w.Departments).ToList();
                }
                else
                {
                    Students = _LMContext.Students.OrderBy(x => columnNameDsc).Include(y => y.StudentPictures.Select(x => x.Pictures)).Include(w => w.Departments).ToList();
                }
                return Students;
            }

        }

        public int TotalRowCount()
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Students.Count();
            }

        }

        public Student GetDataById(int id)
        {
            using (var _LMContext = new LMContext())
            {
                return _LMContext.Students.Where(x => x.ID == id).Include(y => y.StudentPictures.Select(x => x.Pictures)).FirstOrDefault();
            }
        }

        public bool SaveData(Student model)
        {
            using (var _LMContext = new LMContext())
            {
                _LMContext.Students.Add(model);
                return _LMContext.SaveChanges() > 0;
            }
        }

        public bool UpdateData(Student model)
        {
            using (var _LMContext = new LMContext())
            {
                var existingStudent = _LMContext.Students.Find(model.ID);
                _LMContext.StudentPictures.RemoveRange(existingStudent.StudentPictures);
                _LMContext.Entry(existingStudent).CurrentValues.SetValues(model);
                _LMContext.StudentPictures.AddRange(model.StudentPictures);
                return _LMContext.SaveChanges() > 0;
            }
        }
        public bool DeleteData(int id)
        {
            using (var _LMContext = new LMContext())
            {
                var Student = _LMContext.Students.Find(id);
                _LMContext.Entry(Student).State = System.Data.Entity.EntityState.Modified;
                _LMContext.Students.Remove(Student);
                return _LMContext.SaveChanges() > 0;
            }
        }
    }
}
