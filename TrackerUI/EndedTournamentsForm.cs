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
    public partial class EndedTournamentsForm : Form
    {
        List<TournamentModel> allTournaments = GlobalConfig.Connections[0].GetInactiveTournaments(GlobalConfig.Connections[0].GetTournament_All());

        public EndedTournamentsForm()
        {
            InitializeComponent();

            WireUpTournamentsListBox();
        }

        private void WireUpTournamentsListBox()
        {
            EndedTournamentsListBox.DataSource = null;
            allTournaments = GlobalConfig.Connections[0].GetInactiveTournaments(GlobalConfig.Connections[0].GetTournament_All());
            EndedTournamentsListBox.DataSource = allTournaments;
            EndedTournamentsListBox.DisplayMember = "TournamentName";
        }

        private void showTournamentBu_Click(object sender, EventArgs e)
        {
            TournamentModel tournament = (TournamentModel)EndedTournamentsListBox.SelectedItem;
            var frm = new TournamentViewerForm(tournament);
            frm.Show();
        }

        private void DeleteSElectedTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)EndedTournamentsListBox.SelectedItem;
            if (tm != null)
            {
                GlobalConfig.Connections[0].DeleteTournament(tm);
            }
            WireUpTournamentsListBox();
        }
    }
}
