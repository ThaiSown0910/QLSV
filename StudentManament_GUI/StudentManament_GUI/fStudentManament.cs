using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManament_GUI
{
    public partial class fStudentManament : Form
    {
        private Student student = new Student();
        private System.Windows.Forms.Timer timerHideMessage;
        private String checkStat = "";
        private bool checkValue = false;
        private int idUpdateChecked = 0;

        public fStudentManament()
        {
            InitializeComponent();
            initDataGridViewColumns();
            this.WindowState = FormWindowState.Maximized;

            // Khởi tạo Timer và cấu hình
            timerHideMessage = new System.Windows.Forms.Timer();
            timerHideMessage.Interval = 3000; // Thời gian chờ (3 giây)
            timerHideMessage.Tick += TimerHideMessage_Tick;

        }

        private void fStudentManament_Load(object sender, EventArgs e)
        {
            loadNewForm();
            checkStat = "";
        }

        private void TimerHideMessage_Tick(object sender, EventArgs e)
        {
            // Ẩn thông báo và dừng Timer
            if (checkStat == "remove")
            {
                errorLabel.Visible = false;
                //textBoxMain.Text = "";
                panel5.Visible = false;
            } else
            {
                checkSubmitLb.Visible = false;
            }
            timerHideMessage.Stop();
        }

        void loadNewForm()
        {
            HeaderNewForm.Visible = false;
            panelFunctionMain.Visible = false;
            panel5.Visible = false;
            headerLabel.Text = "PLEASE SELECT AN OPTION";
            headerLabel.Location = new Point(40, 0);
        }
        void loadAddStudent()
        {
            HeaderNewForm.Visible = false;
            panelFunctionMain.Visible = false;
            panel5.Visible = true;
            panel5.Location = new Point(0, 45);
            headerLabel.Text = "ADD NEW STUDENT";
            headerLabel.Location = new Point(65, 0);
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = true;
            panel9.Visible = true;
            panel10.Visible = true;
            panel11.Visible = true;
            label1.Text = "Fullname:";
            label2.Text = "Gender:";
            label4.Text = "Age:";
            label3.Text = "Math:";
            label6.Text = "Physic:";
            label5.Text = "Chemistry:";
            checkSubmitLb.Text = "";
            nameErLb.Text = "";
            ageErLb.Text = "";
            mathErLb.Text = "";
            PhysicErLb.Text = "";
            ChemistryErlb.Text = "";
            checkStat = "";
        }

        

        void loadUpdate()
        {
            panelFunctionMain.Visible = true;
            headerLabel.Location = new Point(70, 0);
            headerLabel.Text = "UPDATE STUDENT";
            errorLabel.Text = "Enter student ID to find.";
            errorLabel.ForeColor = Color.Green;
            panel5.Location = new Point(377, 100);
            panel5.Visible = false;
            checkStat = "update";
            button2.Text = "Show";
            checkValue = false;
        }

        void loadRemove()
        {
            checkStat = "remove";
            panel5.Visible = false;
            headerLabel.Text = "REMOVE STUDENT";
            panelFunctionMain.Visible = true;
            errorLabel.Text = "Enter student ID to find.";
            errorLabel.ForeColor = Color.Green;
            button2.Text = "Remove";
            HeaderNewForm.Text = "";
        }


        private void removeStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadRemove();
        }


        void initDataGridViewColumns()
        {
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Gender", "Gender");
            dataGridView1.Columns.Add("Age", "Age");
            dataGridView1.Columns.Add("MathPoint", "Math");
            dataGridView1.Columns.Add("PhysicPoint", "Physic");
            dataGridView1.Columns.Add("ChemistryPoint", "Chemistry");
            dataGridView1.Columns.Add("GPA", "GPA");
            dataGridView1.Columns.Add("Achiement", "Achiement");
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fStudentManament_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Do you want to log out?","Message cancle",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void fStudentManament_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadAddStudent();
        }

        private void updateStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadUpdate();
        }

        private bool HasLetters(string text)
        {
            return text.Any(char.IsLetter);
        }

        void clearTextBoxAddStudent()
        {
            nameTb.Clear();
            maleRadio.Checked = false;
            femaleRadio.Checked = false;
            otherRadio.Checked = false;
            ageTb.Clear();
            mathTb.Clear();
            physicTb.Clear();
            chemistryTb.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkStat == "update")
            {
                if (nameTb.TextLength == 0 || ageTb.TextLength == 0 || mathTb.TextLength == 0 || physicTb.TextLength == 0 || chemistryTb.TextLength == 0)
                {
                    checkSubmitLb.Text = "Require, please fill all.";
                    checkSubmitLb.ForeColor = Color.Red;
                }
                else if (nameTb.Text.Any(char.IsDigit) || ageTb.Text.Any(char.IsLetter) || (!int.TryParse(ageTb.Text, out int age) || age < 3 || age > 100) || mathTb.Text.Any(char.IsLetter) || (!double.TryParse(mathTb.Text, out double math) || math < 0 || math > 10) || physicTb.Text.Any(char.IsLetter) || (!double.TryParse(physicTb.Text, out double physic) || physic < 0 || physic > 10) || chemistryTb.Text.Any(char.IsLetter) || (!double.TryParse(chemistryTb.Text, out double chem) || chem < 0 || chem > 10))
                {
                    checkSubmitLb.Text = "Error form, please try again.";
                    checkSubmitLb.ForeColor = Color.Red;
                }
                else
                {
                    String sexTb = "";
                    if (maleRadio.Checked)
                    {
                        sexTb = maleRadio.Text;
                    }
                    else if (femaleRadio.Checked)
                    {
                        sexTb = femaleRadio.Text;
                    }
                    else if (otherRadio.Checked)
                    {
                        sexTb = otherRadio.Text;
                    }
                    else
                    {
                        sexTb = "NULL";
                    }
                    student.UpdateStudent(int.Parse(textBoxMain.Text), nameTb.Text, sexTb, int.Parse(ageTb.Text), double.Parse(mathTb.Text), double.Parse(physicTb.Text), double.Parse(chemistryTb.Text));
                    clearTextBoxAddStudent();
                    textBoxMain.Text = "";
                    checkSubmitLb.Text = "Update student is complete";
                    checkSubmitLb.ForeColor = Color.Green;
                    checkSubmitLb.Visible = true;
                    timerHideMessage.Start();
                    idUpdateChecked = 0;
                }
            } else
            {
                if (nameTb.TextLength == 0 || ageTb.TextLength == 0 || mathTb.TextLength == 0 || physicTb.TextLength == 0 || chemistryTb.TextLength == 0)
                {
                    checkSubmitLb.Text = "Require, please fill all.";
                    checkSubmitLb.ForeColor = Color.Red;
                }
                else if (nameTb.Text.Any(char.IsDigit) || ageTb.Text.Any(char.IsLetter) || (!int.TryParse(ageTb.Text, out int age) || age < 3 || age > 100) || mathTb.Text.Any(char.IsLetter) || (!double.TryParse(mathTb.Text, out double math) || math < 0 || math > 10) || physicTb.Text.Any(char.IsLetter) || (!double.TryParse(physicTb.Text, out double physic) || physic < 0 || physic > 10) || chemistryTb.Text.Any(char.IsLetter) || (!double.TryParse(chemistryTb.Text, out double chem) || chem < 0 || chem > 10))
                {
                    checkSubmitLb.Text = "Error form, please try again.";
                    checkSubmitLb.ForeColor = Color.Red;
                }
                else
                {
                    String sexTb = "";
                    if (maleRadio.Checked)
                    {
                        sexTb = maleRadio.Text;
                    }
                    else if (femaleRadio.Checked)
                    {
                        sexTb = femaleRadio.Text;
                    }
                    else if (otherRadio.Checked)
                    {
                        sexTb = otherRadio.Text;
                    }
                    else
                    {
                        sexTb = "NULL";
                    }
                    student.AddStudent(nameTb.Text, sexTb, int.Parse(ageTb.Text), double.Parse(mathTb.Text), double.Parse(physicTb.Text), double.Parse(chemistryTb.Text));
                    clearTextBoxAddStudent();
                    checkSubmitLb.Text = "Add student complete";
                    checkSubmitLb.ForeColor = Color.Green;
                    checkSubmitLb.Visible = true;
                    timerHideMessage.Start();
                }
            }
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            DisplayStudentList(student.getStudentList());
        }

        public void DisplayStudentList(List<Student> students)
        {
            dataGridView1.Rows.Clear();
            foreach (Student student in students)
            {
                dataGridView1.Rows.Add(student.ID, student.Name, student.Sex, student.Age,
                  student.MathPoint, student.PhysicPoint, student.ChemistryPoint, student.GPA, student.Achie);
            }
        }

        private void textBoxMain_TextChanged_1(object sender, EventArgs e)
        {
            if (HasLetters(textBoxMain.Text))
            {
                errorLabel.ForeColor = Color.Red;
                errorLabel.Text = "ID cant has character, please try again";
                checkValue = false;
            }
            else if (textBoxMain.Text == "")
            {
                errorLabel.Text = "Enter student ID to find.";
                errorLabel.ForeColor = Color.Green;
                checkValue = false;
            }
            else if (student.FindByID(int.Parse(textBoxMain.Text)) == null)
            {
                errorLabel.Text = "Cant found student " + int.Parse(textBoxMain.Text) + " in list";
                errorLabel.ForeColor = Color.Red;
                checkValue = false;
            }
            else if (student.FindByID(int.Parse(textBoxMain.Text)) != null)
            {
                errorLabel.Text = "Found student " + int.Parse(textBoxMain.Text) + " in list";
                errorLabel.ForeColor = Color.Green;
                checkValue = true;
            }
            else
            {
                errorLabel.ForeColor = Color.Gray;
                errorLabel.Text = "Finding...";
                checkValue = false;
            }
        }

        private void textBoxMain_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                // Ngăn việc xóa dữ liệu khi nhấn Ctrl + Backspace
                e.SuppressKeyPress = true;
            }
            string newText = textBoxMain.Text;

            // Nếu người dùng nhấn nút Backspace (phím Delete), hãy xóa ký tự cuối cùng
            if (e.KeyCode == Keys.Back && newText.Length > 0)
            {
                newText = newText.Substring(0, newText.Length - 1);
            }

            // Nếu số ký tự mới vượt quá 5, ngăn việc nhập và hiển thị thông báo lỗi trong errorLabel
            if (e.KeyCode == Keys.Space || newText.Length >= 5)
            {
                e.SuppressKeyPress = true;
                errorLabel.Text = "Must < 6 characters and not space.";
                errorLabel.ForeColor = Color.Red;
            }
        }

        private void ageTb_TextChanged(object sender, EventArgs e)
        {
            if (ageTb.Text != "")
            {
                if (!double.TryParse(ageTb.Text, out double age))
                {
                    ageErLb.Text = "Age must be a valid number.";
                    ageErLb.ForeColor = Color.Red;
                }
                else if (age < 3 || age > 100)
                {
                    ageErLb.Text = "Student's age must be between 3 and 100.";
                    ageErLb.ForeColor = Color.Red;
                }
                else
                {
                    ageErLb.Text = ""; // Xóa thông báo lỗi nếu giá trị hợp lệ
                }
            } else
            {
                ageErLb.Text = "";
            }
        }

        private void nameTb_TextChanged(object sender, EventArgs e)
        {
            if (nameTb.Text.Any(char.IsDigit))
            {
                nameErLb.Text = "Name cannot contain numbers.";
                nameErLb.ForeColor = Color.Red;
            }
            else
            {
                nameErLb.Text = ""; // Xóa thông báo lỗi nếu giá trị hợp lệ
            }
        }

        private void mathTb_TextChanged(object sender, EventArgs e)
        {
            if (mathTb.Text != "")
            {
                if (!double.TryParse(mathTb.Text, out double age))
                {
                    mathErLb.Text = "Point must be a valid number.";
                    mathErLb.ForeColor = Color.Red;
                }
                else if (age < 0 || age > 10)
                {
                    mathErLb.Text = "Point must be between 0 and 10.";
                    mathErLb.ForeColor = Color.Red;
                }
                else
                {
                    mathErLb.Text = ""; // Xóa thông báo lỗi nếu giá trị hợp lệ
                }
            } else
            {
                mathErLb.Text = "";
            }
        }

        private void physicTb_TextChanged(object sender, EventArgs e)
        {
            if (physicTb.Text != "")
            {
                if (!double.TryParse(physicTb.Text, out double age))
                {
                    PhysicErLb.Text = "Point must be a valid number.";
                    PhysicErLb.ForeColor = Color.Red;
                }
                else if (age < 0 || age > 10)
                {
                    PhysicErLb.Text = "Point must be between 0 and 10.";
                    PhysicErLb.ForeColor = Color.Red;
                }
                else
                {
                    PhysicErLb.Text = ""; // Xóa thông báo lỗi nếu giá trị hợp lệ
                }
            } else
            {
                PhysicErLb.Text = "";
            }
        }

        private void chemistryTb_TextChanged(object sender, EventArgs e)
        {
            if (chemistryTb.Text != "")
            {
                if (!double.TryParse(chemistryTb.Text, out double age))
                {
                    ChemistryErlb.Text = "Point must be a valid number.";
                    ChemistryErlb.ForeColor = Color.Red;
                }
                else if (age < 0 || age > 10)
                {
                    ChemistryErlb.Text = "Point must be between 0 and 10.";
                    ChemistryErlb.ForeColor = Color.Red;
                }
                else
                {
                    ChemistryErlb.Text = ""; // Xóa thông báo lỗi nếu giá trị hợp lệ
                }
            } else
            {
                ChemistryErlb.Text = "";
            }
        }

        private void nameTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                // Ngăn việc xóa dữ liệu khi nhấn Ctrl + Backspace
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1.PerformClick();
            }
        }

        private void ageTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                // Ngăn việc xóa dữ liệu khi nhấn Ctrl + Backspace
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1.PerformClick();
            }
        }

        private void mathTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                // Ngăn việc xóa dữ liệu khi nhấn Ctrl + Backspace
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1.PerformClick();
            }
        }

        private void physicTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                // Ngăn việc xóa dữ liệu khi nhấn Ctrl + Backspace
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1.PerformClick();
            }
        }

        private void chemistryTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                // Ngăn việc xóa dữ liệu khi nhấn Ctrl + Backspace
                e.SuppressKeyPress = true;
            } else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkValue == true && checkStat == "update")
            {
                idUpdateChecked = int.Parse(textBoxMain.Text);
                HeaderNewForm.Visible = true;
                HeaderNewForm.Text = "New infomation: ";
                HeaderNewForm.Location = new Point(11, 122);
                panel5.Visible = true;
                panel5.Location = new Point(0, 140);
                nameErLb.Text = "";
                ageErLb.Text = "";
                mathErLb.Text = "";
                PhysicErLb.Text = "";
                ChemistryErlb.Text = "";
                checkSubmitLb.Text = "";
            } else if (checkValue == true && checkStat == "remove")
            {
                student.DeleteById(int.Parse(textBoxMain.Text));
                errorLabel.Text = "Remove student complete";
                checkSubmitLb.Visible = true;
                timerHideMessage.Start();
            }
        }

        private void SortStudentByGPADescending()
        {
            List<Student> sortedStudents = student.getStudentList().OrderByDescending(s => s.GPA).ToList();
            DisplayStudentList(sortedStudents);
        }
        private void SortStudentByGPAAscending()
        {
            List<Student> sortedStudents = student.getStudentList().OrderBy(s => s.GPA).ToList();
            DisplayStudentList(sortedStudents);
        }

        private void ascendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortStudentByGPAAscending();
        }

        private void descendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortStudentByGPADescending();
        }

        private void SortStudentByNameDescending()
        {
            List<Student> sortedStudents = student.getStudentList().OrderByDescending(s => s.Name).ToList();
            DisplayStudentList(sortedStudents);
        }
        private void SortStudentByNameAscending()
        {
            List<Student> sortedStudents = student.getStudentList().OrderBy(s => s.Name).ToList();
            DisplayStudentList(sortedStudents);
        }

        private void aToZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortStudentByNameAscending();
        }

        private void zToAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SortStudentByNameDescending();
        }

       private void SortStudentByIdDescending()
        {
            List<Student> sortedStudents = student.getStudentList().OrderByDescending(s => s.ID).ToList();
            DisplayStudentList(sortedStudents);
        }

        private void SortStudentByIdAscending()
        {
            List<Student> sortedStudents = student.getStudentList().OrderBy(s => s.ID).ToList();
            DisplayStudentList(sortedStudents);
        }

        private void ascendingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SortStudentByIdAscending();
        }

        private void descendingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SortStudentByIdDescending();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
