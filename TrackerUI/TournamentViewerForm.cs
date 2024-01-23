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
    public partial class TournamentViewerForm : Form
    { 
        private TournamentModel tournament;
        List<int> rounds = new List<int>();
        List<MatchupModel> selectedMatchups = new List<MatchupModel>();
        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

            WireUpRoundsLists();
            WireUpMatchupsLists();

            LoadFormData();

            LoadRounds();
        }

        private void LoadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        private void WireUpRoundsLists()
        {
            roundDropDown.DataSource = null;
            roundDropDown.DataSource = rounds;
        }

        private void WireUpMatchupsLists()
        {
            matchupListBox.DataSource = null;
            matchupListBox.DataSource = selectedMatchups;
            matchupListBox.DisplayMember = "DisplayName";
        }

        private void LoadRounds()
        {
            rounds = new List<int>() { 1 }; // Initialize by 1 as base num of round
            int currRound = 1;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currRound)
                {
                    currRound = matchups.First().MatchupRound;
                    rounds.Add(currRound);
                }
            }
            WireUpRoundsLists();
        }

        private void roundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups();
        }

        /// <summary>
        /// Load all the matchups in the particular round from storage
        /// </summary>
        private void LoadMatchups()
        {
            int round = (int)roundDropDown.SelectedItem;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    selectedMatchups.Clear();
                    foreach (MatchupModel matchup in matchups)
                    {
                        // if unplayed box is checked then we need to show only matchups
                        // where we haven't winner yet
                        // else if unplayed box is unchacked we need to add all the mathups to the list
                        if (!unplayedOnlyCheckBox.Checked || matchup.Winner == null)
                        {
                            selectedMatchups.Add(matchup);
                        }
                    }
                }
            }
            WireUpMatchupsLists();
        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup();   
        }

        private void LoadMatchup() // load all the data inside one matchup
        {
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;

            // Because when we chosed new round we've upgrade data sources - set null to them at first
            // and at this moment matchupListBox_SelectedIndexChanged has got an event automatically
            // but we've our matchups as null at the moment
            if (m != null)
            {
                scoreButton.Enabled = true;
                for (int i = 0; i < m.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (m.Entries[0].TeamCompeting != null)
                        {
                            teamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                            teamOneScoreValue.Text = m.Entries[0].Score.ToString();
                            teamOneScoreValue.ReadOnly = false;

                            teamTwoName.Text = "<bye>";
                            teamTwoScoreValue.Text = "0";
                            teamTwoScoreValue.ReadOnly = true;
                        }
                        else
                        {
                            teamOneName.Text = "Not Yet Set";
                            teamOneScoreValue.Text = "0";
                            teamTwoScoreValue.ReadOnly = true;
                        }
                    }
                    if (i == 1)
                    {
                        if (m.Entries[1].TeamCompeting != null)
                        {
                            teamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;
                            teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                            teamTwoScoreValue.ReadOnly = false;
                        }
                        else
                        {
                            teamTwoName.Text = "Not Yet Set";
                            teamTwoScoreValue.Text = "0";
                            teamTwoScoreValue.ReadOnly = true;
                        }
                    }
                } 
            }
            else
            {
                teamOneName.Text = "Not Yet Set";
                teamTwoName.Text = "Not Yet Set";

                teamOneScoreValue.Text = "0";
                teamOneScoreValue.ReadOnly = true;
                teamTwoScoreValue.Text = "0";
                teamTwoScoreValue.ReadOnly = true;
                scoreButton.Enabled = false;
            }
        }

        private void unplayedOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups();
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            MatchupModel sm = (MatchupModel)matchupListBox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            for (int i = 0; i < sm.Entries.Count; i++)
            {
                if (sm != null)
                {
                    if (i == 0)
                    {
                        // if teamCompeting is null then score area is ReadOnly
                        if (sm.Entries[0].TeamCompeting != null) 
                        {
                            bool scoreValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);
                            if (scoreValid)
                            {
                                sm.Entries[0].Score = teamOneScore;
                            }
                            else
                            {
                                MessageBox.Show($"Введите числовое значение для команды {teamOneName.Text}",
                                    "Score Validation Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                teamOneScoreValue.Text = "";
                                return;
                            } 
                        }
                    }
                    if (i == 1)
                    {
                        if (sm.Entries[1].TeamCompeting != null)
                        {
                            bool ScoreValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);
                            if (ScoreValid)
                            {
                                sm.Entries[1].Score = teamTwoScore;
                            }
                            else
                            {
                                MessageBox.Show($"Введите числовое значение для команды {teamTwoName.Text}",
                                    "Score Validation Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                teamTwoScoreValue.Text = "";
                                return;
                            } 
                        }
                    }
                }
            }
            if (teamOneScore > teamTwoScore)
            {
                sm.Winner = sm.Entries[0].TeamCompeting;
            }
            else if (teamTwoScore > teamOneScore)
            {
                sm.Winner = sm.Entries[1].TeamCompeting;
            }
            else
            {
                MessageBox.Show("Program hasn't handle tie games yet",
                    "Tie games",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            foreach (List<MatchupModel> round in tournament.Rounds)
            {
                foreach (MatchupModel rMatchup in round)
                {
                    foreach (MatchupEntryModel mEntry in rMatchup.Entries)
                    {
                        if (mEntry.ParentMatchup != null)
                        {
                            if (mEntry.ParentMatchup.Id == sm.Id)
                            {
                                mEntry.TeamCompeting = sm.Winner;
                                GlobalConfig.Connections[0].UpdateMatchup(rMatchup);
                            } 
                        }
                    }
                }
            }

            LoadMatchups();

            GlobalConfig.Connections[0].UpdateMatchup(sm);
        }

        // TODO - Create separate form which will show the entire tournament Graphic
    }
}
