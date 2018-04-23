using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace SortAndSearch_LookUpEdit
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserList users = new UserList();
            users.Add(new User("Bill", "b", 20));
            users.Add(new User("Jeck", "j", 14));
            users.Add(new User("Stan", "s", 18));
            users.Add(new User("Bruce", "b", 29));
            users.Add(new User("Stanny", "s", 18));

            SortAndSearchLookUpEdit sortAndSearchLookUpEdit = new SortAndSearchLookUpEdit();
            sortAndSearchLookUpEdit.Bounds = new Rectangle(10, 50, 100, 20);
            sortAndSearchLookUpEdit.Properties.DataSource = users;
            sortAndSearchLookUpEdit.Properties.DisplayMember = "Name";
            sortAndSearchLookUpEdit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            Controls.Add(sortAndSearchLookUpEdit);
        }
    }

    class User
    {
        string name;
        string login;
        int age;
        public User(string name, string login, int age)
        {
            this.name = name;
            this.login = login;
            this.age = age;
        }
        public string Name { get { return name; } set { name = value; } }
        public string Login { get { return login; } set { name = login; } }
        public int Age { get { return age; } set { age = value; } }
    }
    class UserList : ArrayList { }
}