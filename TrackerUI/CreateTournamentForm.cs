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
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        List<TeamModel> availableTeams = GlobalConfig.Connections[0].GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel> ();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        private void WireUpLists()
        {
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";

            
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)selectTeamDropDown.SelectedItem;

            if (t != null)
            {
                selectedTeams.Add(t);
                availableTeams.Remove(t);

                WireUpLists();
            }
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            CreatePrizeForm frm = new CreatePrizeForm(this);
            frm.ShowDialog();
        }

        public void PrizeComplete(PrizeModel model)
        {
            selectedPrizes.Add(model);
            WireUpLists();
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            WireUpLists();
        }

        private void createNewTeamLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);
            frm.ShowDialog();
        }

        private void removeSelectedTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = (TeamModel)tournamentTeamsListBox.SelectedItem;

            if (t != null)
            {
                selectedTeams.Remove(t);
                availableTeams.Add(t);

                WireUpLists();
            }
        }

        private void removeSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)prizesListBox.SelectedItem;

            if (p != null)
            {
                selectedPrizes.Remove(p);

                WireUpLists();
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = new TournamentModel();
            //Validate Data
            if (ValidateForm())
            {
                
                tm.TournamentName = tournamentNameValue.Text;
                tm.Entryfee = int.Parse(EntryFeeValue.Text);

                tm.Prizes = selectedPrizes;
                tm.EnteredTeams = selectedTeams;
                // Wire up all the matchups
                TournamentLogic.CreateRounds(tm);

                // Create Tournament entry, all of the prizes entries and all of the team entries
                GlobalConfig.Connections[0].CreateTournament(tm);

                MessageBox.Show($"Турнир успешно создан", "Tournament created",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                
            }
            PrepareTournamentForm();
        }

        private void PrepareTournamentForm()
        {
            tournamentNameValue.Text = "";
            EntryFeeValue.Text = "";
            availableTeams = GlobalConfig.Connections[0].GetTeam_All();
            selectedTeams = new List<TeamModel>();
            selectedPrizes = new List<PrizeModel>();
            WireUpLists();
        }

        private bool ValidateForm()
        {
            if (tournamentNameValue.Text == null || tournamentNameValue.Text == "")
            {
                MessageBox.Show($"Название турнира не должно быть пустым", "Invalid Tournament name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (!ValidateTournamentName(tournamentNameValue.Text))
            {
                MessageBox.Show($"Название турнира не должно содержать символов: '\\ | / ? $'",
                "Invalid Tournament name",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                this.tournamentNameValue.Text = "";
            }
            if (tournamentTeamsListBox == null || tournamentTeamsListBox.Items.Count == 0)
            {
                MessageBox.Show($"Выберите команды для турнира",
                    "Invalid Teams",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            decimal fee = 0;
            bool feeAcceptable = decimal.TryParse(EntryFeeValue.Text, out fee);
            if (!feeAcceptable)
            {
                MessageBox.Show($"Введен неверный формат Entry Fee, пожалуйста введите число",
                    "Invalid Entry Fee",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool ValidateTournamentName(string tMName)
        {
            if (tMName.Contains('|') ||
                tMName.Contains('$') ||
                tMName.Contains(',') ||
                tMName.Contains('/') ||
                tMName.Contains('\\'))
                return false;
            return true;
        }
    }
}
