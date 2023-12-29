using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailValue.Text;
                p.CellphoneNumber = phoneValue.Text;

                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(p);
                }
            }
            else
            {
                MessageBox.Show("Введены некорректные данные, пожалуйста проверьте введенные данные");
            }
        }

        private bool ValidateForm()
        {
            bool flag = true;

            if (firstNameValue.Text.Length == 0)
                flag = false;
            if (lastNameValue.Text.Length == 0)
                flag = false;
            if (emailValue.Text.Length == 0 || !emailValue.Text.Contains('@'))
                flag = false;
            if (phoneValue.Text.Length == 0)
                flag = false;   

            return flag;
        }
    }
}
