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
    public partial class TournamentDashboardForm : Form
    {
        List<TournamentModel> tournaments = GlobalConfig.Connections[0].GetActiveTournaments(GlobalConfig.Connections[0].GetTournament_All());
        public TournamentDashboardForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        private void WireUpLists()
        {
            loadExistingTournamentDropDown.DataSource = null;
            tournaments = GlobalConfig.Connections[0].GetActiveTournaments(GlobalConfig.Connections[0].GetTournament_All());
            loadExistingTournamentDropDown.DataSource = tournaments;
            loadExistingTournamentDropDown.DisplayMember = "TournamentName";
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            CreateTournamentForm frm = new CreateTournamentForm();
            frm.TournamentCreated += TournamentCreated;
            frm.Show();
        }

        private void loadTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)loadExistingTournamentDropDown.SelectedItem;
            if (tm != null)
            {
                TournamentViewerForm frm = new TournamentViewerForm(tm);
                tm.OnTournamentComplete += TournamentCompleted;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Турнир не валидный", "Invalid data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TournamentCompleted(object sender, DateTime e)
        {
            WireUpLists();
        }

        private void TournamentCreated(object sender, EventArgs e)
        {
            WireUpLists();
        }

        private void DeleteSelectedTournButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)loadExistingTournamentDropDown.SelectedItem;
            if (tm != null)
            {
                GlobalConfig.Connections[0].DeleteTournament(tm);
            }
            WireUpLists();
        }

        private void ShowEndedTournButton_Click(object sender, EventArgs e)
        {
            var frm = new EndedTournamentsForm();
            frm.Show();
        }
    }
}
