using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using AdminstrationAPI;

namespace schoolHRMangement
{
   
    class ControlInput : Form
    {
        Label headLine, subHeadLine, Emp_Id, Emp_Name,Emp_Type, Emp_Salary, Emp_Count, Emp_Total, lbl_Count, lbl_Total;
        TextBox txt_Id, txt_name, txt_salary;
        ComboBox CBEmp_Type;
        Button btn_Add, btn_Remove;

        public List<IEmployee> employees = new List<IEmployee>();
        public ControlInput()
        {
            this.Size = new Size(700, 500);
            this.Font = new Font(FontFamily.GenericSerif, 10);
            this.Text = "School HR ";

            // headLine= subHeadLine= Emp_Id= Emp_Name= Emp_Salary= Emp_Count= Emp_Total= Count= Total = new Label();

            //first head line
            headLine = new Label();
            headLine.Location = new Point(20, 10);
            headLine.Font = new Font(FontFamily.GenericMonospace, 13);
            headLine.AutoSize = true;
            headLine.Text = "Add Employee";

            //second head line
            subHeadLine = new Label();
            subHeadLine.Location = new Point(50, 80);
            subHeadLine.Font = new Font(FontFamily.GenericMonospace, 13);
            subHeadLine.AutoSize = true;
            subHeadLine.Text = "Employee Information";

            // ID 
            Emp_Id = new Label();
            Emp_Id.Location = new Point(30, 120);
            Emp_Id.AutoSize = true;
            Emp_Id.Text = "Employee ID";

            txt_Id = new TextBox();
            txt_Id.Location = new Point(140, 120);
            txt_Id.BorderStyle = BorderStyle.FixedSingle;

            // Name
            Emp_Name = new Label();
            Emp_Name.Location = new Point(30, 150);
            Emp_Name.AutoSize = true;
            Emp_Name.Text = "Employee Name ";

            txt_name = new TextBox();
            txt_name.Location = new Point(140, 150);
            txt_name.BorderStyle = BorderStyle.FixedSingle;
            txt_name.Width = 160;

            //Type
            Emp_Type = new Label();
            Emp_Type.Location = new Point(30, 180);
            Emp_Type.AutoSize = true;
            Emp_Type.Text = "Employee Type ";

            CBEmp_Type = new ComboBox();
            CBEmp_Type.Location = new Point(140, 180);
            CBEmp_Type.Items.AddRange(Enum.GetNames(typeof(EmployeeType)));
            CBEmp_Type.SelectedIndex = 0;

            //salary
            Emp_Salary = new Label();
            Emp_Salary.Location = new Point(30, 210);
            Emp_Salary.AutoSize = true;
            Emp_Salary.Text = "Employee Salary ";

            txt_salary = new TextBox();
            txt_salary.BorderStyle = BorderStyle.FixedSingle;
            txt_salary.Location = new Point(140, 210);

            //Button Add
            btn_Add = new Button();
            btn_Add.Location = new Point(400, 250);
            btn_Add.AutoSize = true;
            btn_Add.FlatStyle = FlatStyle.Popup;
            btn_Add.Text = "Add ";
            btn_Add.Click += delegate { setData();
                
                lbl_Total.Text = employees.Sum(e => e.Salary).ToString();
            };




            //button Remove
            btn_Remove = new Button();
            btn_Remove.Location = new Point(480, 250);
            btn_Remove.AutoSize = true;
            btn_Remove.FlatStyle = FlatStyle.Popup;
            btn_Remove.Text = "Remove ";
            btn_Remove.Click += delegate
            {
                if(employees.Count==0)
                {
                    MessageBox.Show("Stop Stupid there is no one to be deleted");
                }
               else
                {
                    employees.RemoveAt(0);
                    lbl_Total.Text = employees.Sum(e => e.Salary).ToString();
                    lbl_Count.Text = employees.Count.ToString();
                }
            };

            //employee count la
            Emp_Count = new Label();
            Emp_Count.Location = new Point(100, 300);
            Emp_Count.AutoSize = true;
            Emp_Count.Text = "Employee Count : ";

            lbl_Count = new Label();
            lbl_Count.Location = new Point(210, 300);
            lbl_Count.AutoSize = true;
            lbl_Count.Text = "0";

            //Employee total salary
            Emp_Total = new Label();
            Emp_Total.Location = new Point(100, 350);
            Emp_Total.AutoSize = true;
            Emp_Total.Text = " Total Salary : ";

            lbl_Total = new Label();
            lbl_Total.Location = new Point(200, 350);
            lbl_Total.AutoSize = true;
            lbl_Total.Text = "0";

            //mythode of Add

            void setData()
            {
                try
                {
                    if (txt_Id.Text == null || txt_name.Text == null || txt_salary.Text == null||CBEmp_Type.Text==null)
                    {
                        MessageBox.Show("con not leave Empty Fileds");

                    }
                    else
                    {
                        EmployeeType emp = (EmployeeType)Enum.Parse(typeof(EmployeeType), CBEmp_Type.SelectedItem.ToString());

                        IEmployee headm = EmployeeFactor.GetEmployeeInstanase(emp, int.Parse(txt_Id.Text), txt_name.Text, decimal.Parse(txt_salary.Text));
                        employees.Add(headm);
                        lbl_Count.Text = (employees.Count).ToString();
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            this.Controls.Add(headLine);
            this.Controls.Add(subHeadLine);
            this.Controls.Add(Emp_Id);
            this.Controls.Add(txt_Id);
            this.Controls.Add(Emp_Name);
            this.Controls.Add(txt_name);
            this.Controls.Add(Emp_Type);
            this.Controls.Add(CBEmp_Type);
            this.Controls.Add(Emp_Salary);
            this.Controls.Add(txt_salary);
            this.Controls.Add(btn_Remove);
            this.Controls.Add(btn_Add);
            this.Controls.Add(Emp_Count);
            this.Controls.Add(lbl_Count);
            this.Controls.Add(Emp_Total);
            this.Controls.Add(lbl_Total);
        }

    }
}
