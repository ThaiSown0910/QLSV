using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManament_GUI
{
    public class Student
    {
        private List<Student> StudentList = null;
        public Student()
        {
            StudentList = new List<Student>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public double MathPoint { get; set; }
        public double PhysicPoint { get; set; }
        public double ChemistryPoint { get; set; }
        public double GPA { get; set; }
        public string Achie { get; set; }

        public int GenerateID()
        {
            int max = 1;
            if (StudentList != null && StudentList.Count > 0)
            {
                max = StudentList[0].ID;
                foreach (Student student in StudentList)
                {
                    if (max < student.ID)
                    {
                        max = student.ID;
                    }
                }
                max++;
            }
            return max;
        }
        public int CountStudents()
        {
            int Count = 0;
            if (StudentList != null)
            {
                Count = StudentList.Count;
            }
            return Count;
        }
        private void CalculateGPA(Student student)
        {
            double DiemTB = (student.MathPoint + student.PhysicPoint + student.ChemistryPoint) / 3;
            student.GPA = Math.Round(DiemTB, 2, MidpointRounding.AwayFromZero);
        }
        private void CalculateAchie(Student student)
        {
            if (student.GPA >= 8)
            {
                student.Achie = "Gioi";
            }
            else if (student.GPA >= 6.5)
            {
                student.Achie = "Kha";
            }
            else if (student.GPA >= 5)
            {
                student.Achie = "Trung Binh";
            }
            else
            {
                student.Achie = "Yeu";
            }
        }
        public void AddStudent(String name, String gender, int age, double math, double physic, double chemistry)
        {
            // Khởi tạo một sinh viên mới
            Student student = new Student();
            student.ID = GenerateID();
            student.Name = name;

            student.Sex = gender;

            student.Age = age;

            student.MathPoint = math;

            student.PhysicPoint = physic;

            student.ChemistryPoint = chemistry;

            CalculateGPA(student);
            CalculateAchie(student);

            StudentList.Add(student);
        }
        public Student FindByID(int ID)
        {
            Student searchResult = null;
            if (StudentList != null && StudentList.Count > 0)
            {
                foreach (Student student in StudentList)
                {
                    if (student.ID == ID)
                    {
                        searchResult = student;
                    }
                }
            }
            return searchResult;
        }
        public List<Student> FindByName(String keyword)
        {
            List<Student> searchResult = new List<Student>();
            if (StudentList != null && StudentList.Count > 0)
            {
                foreach (Student student in StudentList)
                {
                    if (student.Name.ToUpper().Contains(keyword.ToUpper()))
                    {
                        searchResult.Add(student);
                    }
                }
            }
            return searchResult;
        }
        public void UpdateStudent(int ID, String name, String sex, int age, double math, double physic, double chemistry)
        {
            Student student = FindByID(ID);
            if (student != null)
            {
                student.Name = name;
                student.Sex = sex;
                student.Age = age;
                student.MathPoint = math;
                student.PhysicPoint = physic;
                student.ChemistryPoint = chemistry;
                CalculateGPA(student);
                CalculateAchie(student);
            }
        }
        public void SortByID()
        {
            StudentList.Sort(delegate (Student student1, Student student2) {
                return student1.ID.CompareTo(student1.ID);
            });
        }
        public void SortByName()
        {
            StudentList.Sort(delegate (Student student1, Student student2) {
                return student1.Name.CompareTo(student2.Name);
            });
        }
        public void SortByGPA()
        {
            StudentList.Sort(delegate (Student student1, Student student2) {
                return student1.GPA.CompareTo(student2.GPA);
            });
        }
        public bool DeleteById(int ID)
        {
            bool IsDeleted = false;
            // tìm kiếm sinh viên theo ID
            Student student = FindByID(ID);
            if (student != null)
            {
                IsDeleted = StudentList.Remove(student);
            }
            return IsDeleted;
        }
        public void Display(List<Student> StudentList, DataGridView dtgv)
        {
            dtgv.Rows.Clear();

            // hien thi danh sach sinh vien
            if (StudentList != null && StudentList.Count > 0)
            {
                foreach (Student student in StudentList)
                {
                    // Thêm dữ liệu của sinh viên vào DataGridView
                    dtgv.Rows.Add(student.ID, student.Name, student.Sex, student.Age,
                        student.MathPoint, student.PhysicPoint, student.ChemistryPoint, student.GPA, student.Achie);
                }
            }
        }
        public List<Student> getStudentList()
        {
            return StudentList;
        }
    }

}
