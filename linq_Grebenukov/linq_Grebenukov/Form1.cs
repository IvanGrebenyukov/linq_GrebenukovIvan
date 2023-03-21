using linq_Grebenukov;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace linq_Grebenukov
{
    public partial class Form1 : Form
    {
        bool test_button = false;
        private List<Person> people;
        List<Department> department = new List<Department>();

        private List<Employ> employes = new List<Employ>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            people = new List<Person>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(test_button == false) 
            {
                test_button = true;
                button2.Visible= false;
                button1.Text = "Вернуться в меню";
                groupBox1.Visible = true;
                string filePath = "DataPeople.txt";
                listBox1.Items.Clear();
                people.Clear();
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(' ');
                        string lastName = parts[0];
                        string firstName = parts[1];
                        string middleName = parts[2];
                        int age = int.Parse(parts[3]);
                        int weight = int.Parse(parts[4]);
                        Person person = new Person(lastName, firstName, middleName, age, weight);
                        people.Add(person);
                        listBox1.Items.Add(line);
                    }
                }
                else
                {
                    MessageBox.Show("Файл не найден");
                }
            }
            else
            {
                test_button = false;
                button2.Visible = true;
                button1.Text = "Задание 1";
                groupBox1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (test_button == false)
            {
                test_button = true;
                button1.Visible = false;
                button2.Text = "Вернуться в меню";
                groupBox2.Visible = true;
                listBox2.Items.Clear();
                department.Clear();
                employes.Clear();
                department.Add(new Department() { Name = "Отдел закупок", Reg = "Германия" });
                department.Add(new Department() { Name = "Отдел продаж", Reg = "Испания"});
                department.Add(new Department() { Name = "Отдел маркетинга", Reg = "Иран"});
                employes.Add(new Employ() { Name = "Иванов", Department = "Отдел закупок"});
                employes.Add(new Employ() { Name = "Петров", Department = "Отдел закупок"});
                employes.Add(new Employ() { Name = "Сидоров", Department = "Отдел продаж"});
                employes.Add(new Employ() { Name = "Лямин", Department = "Отдел продаж"});
                employes.Add(new Employ() { Name = "Сидоренко", Department = "Отдел маркетинга"});
                employes.Add(new Employ() { Name = "Кривоносов", Department = "Отдел продаж"});
                var query = from emp in employes
                            join dep in department on emp.Department equals dep.Name
                            group emp by dep into depGroup
                            select new
                            {
                                Department = depGroup.Key.Name,
                                Employees = depGroup.Select(emp => emp.Name)
                            };

                foreach (var group in query)
                {
                    listBox2.Items.Add(group.Department);
                    foreach (var emp in group.Employees)
                    {
                        listBox2.Items.Add("   " + emp);
                    }
                }

            }
            else
            {
                test_button = false;
                button1.Visible = true;
                button2.Text = "Задание 2";
                groupBox2.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Person> youngPeople = new List<Person>();
            youngPeople.Clear();
            listBox1.Items.Clear();
            youngPeople = people.Where(people => people.Age < 40).ToList();
            foreach (Person person in youngPeople)
            {
                listBox1.Items.Add(person);
            }

        }
       

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var result = from employ in employes
                         join dep in department on employ.Department equals dep.Name
                         where dep.Reg.StartsWith("И")
                         select new { employ.Name, dep.Reg };

            foreach (var item in result)
            {
                listBox2.Items.Add(item.Name + " - " + item.Reg);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}