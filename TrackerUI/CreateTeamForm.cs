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
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connections[0].GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        ITeamRequester callingForm;

        public CreateTeamForm(ITeamRequester caller)
        {
            InitializeComponent();

            callingForm = caller;

            WireUpLists();
        }

        /// <summary>
        /// Refresh the GUI by the data in datasources
        /// </summary>
        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;
            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMemberListBox.DataSource = null;
            teamMemberListBox.DataSource = selectedTeamMembers;
            teamMemberListBox.DisplayMember = "FullName";

        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidatePersonForm())
            {
                PersonModel p = new PersonModel();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.EmailAddress = emailValue.Text;
                p.CellphoneNumber = phoneValue.Text;

                //p = GlobalConfig.Connections.CreatePerson(p);
                GlobalConfig.Connections[0].CreatePerson(p);
                availableTeamMembers.Add(p);

                WireUpLists();

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                phoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("Введены некорректные данные, пожалуйста проверьте введенные данные");
            }
        }

        private bool ValidatePersonForm()
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

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMemberListBox.SelectedItem;

            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            string validation = ValidateTeam();
            if (validation == "")
            {
                TeamModel t = new TeamModel();
                t.TeamName = teamNameValue.Text;
                t.TeamMembers = selectedTeamMembers;

                GlobalConfig.Connections[0].CreateTeam(t);

                callingForm.TeamComplete(t);
                this.Close();
            }
            else
            {
                MessageBox.Show(validation, "Error value", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.teamNameValue.Text = "";

                availableTeamMembers = GlobalConfig.Connections[0].GetPerson_All();
                selectedTeamMembers = new List<PersonModel>();
                WireUpLists();
            }
        }

        private string ValidateTeam()
        {
            string output = "";
            if (teamNameValue.Text.Length == 0 ||
                teamNameValue.Text.Contains('\\'))
            {
                output = "Enter a correct Team name (it hasn't to contain '\\' symbol";
            }
            else if (teamMemberListBox.Items.Count == 0)
            {
                output = "Team has to contain at least 1 member";
            }
            return output;
        }
    }
}
