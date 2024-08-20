using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_Console
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

        private int GenerateID()
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
        public void AddStudent()
        {
            // Khởi tạo một sinh viên mới
            Student student = new Student();
            student.ID = GenerateID();
            Console.Write("Enter student's name: ");
            student.Name = Convert.ToString(Console.ReadLine());

            Console.Write("Enter student's gender: ");
            student.Sex = Convert.ToString(Console.ReadLine());

            Console.Write("Enter student's age: ");
            student.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter math point: ");
            student.MathPoint = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter physic point: ");
            student.PhysicPoint = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter chemistry point: ");
            student.ChemistryPoint = Convert.ToDouble(Console.ReadLine());

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
        public void UpdateStudent(int ID)
        {
            // Tìm kiếm sinh viên trong danh sách ListSinhVien
            Student student = FindByID(ID);
            // Nếu sinh viên tồn tại thì cập nhập thông tin sinh viên
            if (student != null)
            {
                Console.Write("Nhap ten sinh vien: ");
                string name = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật tên
                if (name != null && name.Length > 0)
                {
                    student.Name = name;
                }

                Console.Write("Nhap gioi tinh sinh vien: ");
                // Nếu không nhập gì thì không cập nhật giới tính
                string sex = Convert.ToString(Console.ReadLine());
                if (sex != null && sex.Length > 0)
                {
                    student.Sex = sex;
                }

                Console.Write("Nhap tuoi sinh vien: ");
                string ageStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật tuổi
                if (ageStr != null && ageStr.Length > 0)
                {
                    student.Age = Convert.ToInt32(ageStr);
                }

                Console.Write("Nhap diem toan: ");
                string diemToanStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm toán
                if (diemToanStr != null && diemToanStr.Length > 0)
                {
                    student.MathPoint = Convert.ToDouble(diemToanStr);
                }

                Console.Write("Nhap diem ly: ");
                string diemLyStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm lý
                if (diemLyStr != null && diemLyStr.Length > 0)
                {
                    student.PhysicPoint = Convert.ToDouble(diemLyStr);
                }

                Console.Write("Nhap diem hoa: ");
                string diemHoaStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm hóa
                if (diemHoaStr != null && diemHoaStr.Length > 0)
                {
                    student.ChemistryPoint = Convert.ToDouble(diemHoaStr);
                }

                CalculateGPA(student);
                CalculateAchie(student);
            }
            else
            {
                Console.WriteLine("Sinh vien co ID = {0} khong ton tai.", ID);
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
        public void Display(List<Student> StudentList)
        {
            // hien thi tieu de cot
            Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
                  "ID", "Name", "Gender", "Age", "Toan", "Ly", "Hoa", "Diem TB", "Hoc Luc");
            // hien thi danh sach sinh vien
            if (StudentList != null && StudentList.Count > 0)
            {
                foreach (Student student in StudentList)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
                                      student.ID, student.Name, student.Sex, student.Age, student.MathPoint, student.PhysicPoint, student.ChemistryPoint,
                                      student.GPA, student.Achie);
                }
            }
            Console.WriteLine();
        }
        public List<Student> getStudentList()
        {
            return StudentList;
        }
    }

}
