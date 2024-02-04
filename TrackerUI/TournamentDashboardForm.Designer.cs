namespace TrackerUI
{
    partial class TournamentDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createTeamLabel = new System.Windows.Forms.Label();
            this.loadExistingTournamentDropDown = new System.Windows.Forms.ComboBox();
            this.loadExistingTournamentLabel = new System.Windows.Forms.Label();
            this.loadTournamentButton = new System.Windows.Forms.Button();
            this.createTournamentButton = new System.Windows.Forms.Button();
            this.DeleteSelectedTournButton = new System.Windows.Forms.Button();
            this.ShowEndedTournButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createTeamLabel
            // 
            this.createTeamLabel.AutoSize = true;
            this.createTeamLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTeamLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.createTeamLabel.Location = new System.Drawing.Point(120, 45);
            this.createTeamLabel.Name = "createTeamLabel";
            this.createTeamLabel.Size = new System.Drawing.Size(353, 45);
            this.createTeamLabel.TabIndex = 5;
            this.createTeamLabel.Text = "Tournament Dashboard";
            // 
            // loadExistingTournamentDropDown
            // 
            this.loadExistingTournamentDropDown.FormattingEnabled = true;
            this.loadExistingTournamentDropDown.Location = new System.Drawing.Point(101, 163);
            this.loadExistingTournamentDropDown.Name = "loadExistingTournamentDropDown";
            this.loadExistingTournamentDropDown.Size = new System.Drawing.Size(391, 38);
            this.loadExistingTournamentDropDown.TabIndex = 18;
            // 
            // loadExistingTournamentLabel
            // 
            this.loadExistingTournamentLabel.AutoSize = true;
            this.loadExistingTournamentLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadExistingTournamentLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.loadExistingTournamentLabel.Location = new System.Drawing.Point(135, 123);
            this.loadExistingTournamentLabel.Name = "loadExistingTournamentLabel";
            this.loadExistingTournamentLabel.Size = new System.Drawing.Size(322, 37);
            this.loadExistingTournamentLabel.TabIndex = 17;
            this.loadExistingTournamentLabel.Text = "Load Existing Tournament";
            // 
            // loadTournamentButton
            // 
            this.loadTournamentButton.BackColor = System.Drawing.SystemColors.Control;
            this.loadTournamentButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.loadTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.loadTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.loadTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadTournamentButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadTournamentButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.loadTournamentButton.Location = new System.Drawing.Point(195, 207);
            this.loadTournamentButton.Name = "loadTournamentButton";
            this.loadTournamentButton.Size = new System.Drawing.Size(202, 41);
            this.loadTournamentButton.TabIndex = 19;
            this.loadTournamentButton.Text = "Load Tournament";
            this.loadTournamentButton.UseVisualStyleBackColor = false;
            this.loadTournamentButton.Click += new System.EventHandler(this.loadTournamentButton_Click);
            // 
            // createTournamentButton
            // 
            this.createTournamentButton.BackColor = System.Drawing.SystemColors.Control;
            this.createTournamentButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.createTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.createTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.createTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTournamentButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTournamentButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.createTournamentButton.Location = new System.Drawing.Point(172, 284);
            this.createTournamentButton.Name = "createTournamentButton";
            this.createTournamentButton.Size = new System.Drawing.Size(249, 57);
            this.createTournamentButton.TabIndex = 22;
            this.createTournamentButton.Text = "Create Tournament";
            this.createTournamentButton.UseVisualStyleBackColor = false;
            this.createTournamentButton.Click += new System.EventHandler(this.createTournamentButton_Click);
            // 
            // DeleteSelectedTournButton
            // 
            this.DeleteSelectedTournButton.BackColor = System.Drawing.SystemColors.Control;
            this.DeleteSelectedTournButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.DeleteSelectedTournButton.FlatAppearance.BorderSize = 2;
            this.DeleteSelectedTournButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.DeleteSelectedTournButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.DeleteSelectedTournButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteSelectedTournButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSelectedTournButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.DeleteSelectedTournButton.Location = new System.Drawing.Point(498, 163);
            this.DeleteSelectedTournButton.Name = "DeleteSelectedTournButton";
            this.DeleteSelectedTournButton.Size = new System.Drawing.Size(135, 85);
            this.DeleteSelectedTournButton.TabIndex = 23;
            this.DeleteSelectedTournButton.Text = "Delete Selected";
            this.DeleteSelectedTournButton.UseVisualStyleBackColor = false;
            this.DeleteSelectedTournButton.Click += new System.EventHandler(this.DeleteSelectedTournButton_Click);
            // 
            // ShowEndedTournButton
            // 
            this.ShowEndedTournButton.BackColor = System.Drawing.Color.LightGray;
            this.ShowEndedTournButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.ShowEndedTournButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ShowEndedTournButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ShowEndedTournButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShowEndedTournButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowEndedTournButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ShowEndedTournButton.Location = new System.Drawing.Point(460, 284);
            this.ShowEndedTournButton.Name = "ShowEndedTournButton";
            this.ShowEndedTournButton.Size = new System.Drawing.Size(173, 79);
            this.ShowEndedTournButton.TabIndex = 24;
            this.ShowEndedTournButton.Text = "Show Ended Tournaments";
            this.ShowEndedTournButton.UseVisualStyleBackColor = false;
            this.ShowEndedTournButton.Click += new System.EventHandler(this.ShowEndedTournButton_Click);
            // 
            // TournamentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 386);
            this.Controls.Add(this.ShowEndedTournButton);
            this.Controls.Add(this.DeleteSelectedTournButton);
            this.Controls.Add(this.createTournamentButton);
            this.Controls.Add(this.loadTournamentButton);
            this.Controls.Add(this.loadExistingTournamentDropDown);
            this.Controls.Add(this.loadExistingTournamentLabel);
            this.Controls.Add(this.createTeamLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "TournamentDashboardForm";
            this.Text = "Tournament Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label createTeamLabel;
        private System.Windows.Forms.ComboBox loadExistingTournamentDropDown;
        private System.Windows.Forms.Label loadExistingTournamentLabel;
        private System.Windows.Forms.Button loadTournamentButton;
        private System.Windows.Forms.Button createTournamentButton;
        private System.Windows.Forms.Button DeleteSelectedTournButton;
        private System.Windows.Forms.Button ShowEndedTournButton;
    }
}