namespace TrackerUI
{
    partial class EndedTournamentsForm
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
            this.EndedTournamentsListBox = new System.Windows.Forms.ListBox();
            this.showTournamentBu = new System.Windows.Forms.Button();
            this.DeleteSElectedTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EndedTournamentsListBox
            // 
            this.EndedTournamentsListBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.EndedTournamentsListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndedTournamentsListBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.EndedTournamentsListBox.FormattingEnabled = true;
            this.EndedTournamentsListBox.ItemHeight = 21;
            this.EndedTournamentsListBox.Location = new System.Drawing.Point(12, 12);
            this.EndedTournamentsListBox.Name = "EndedTournamentsListBox";
            this.EndedTournamentsListBox.Size = new System.Drawing.Size(523, 382);
            this.EndedTournamentsListBox.TabIndex = 0;
            // 
            // showTournamentBu
            // 
            this.showTournamentBu.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showTournamentBu.Location = new System.Drawing.Point(541, 180);
            this.showTournamentBu.Name = "showTournamentBu";
            this.showTournamentBu.Size = new System.Drawing.Size(147, 69);
            this.showTournamentBu.TabIndex = 1;
            this.showTournamentBu.Text = "Show Tournament";
            this.showTournamentBu.UseVisualStyleBackColor = true;
            this.showTournamentBu.Click += new System.EventHandler(this.showTournamentBu_Click);
            // 
            // DeleteSElectedTournamentButton
            // 
            this.DeleteSElectedTournamentButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSElectedTournamentButton.Location = new System.Drawing.Point(541, 325);
            this.DeleteSElectedTournamentButton.Name = "DeleteSElectedTournamentButton";
            this.DeleteSElectedTournamentButton.Size = new System.Drawing.Size(147, 69);
            this.DeleteSElectedTournamentButton.TabIndex = 2;
            this.DeleteSElectedTournamentButton.Text = "Delete Tournament";
            this.DeleteSElectedTournamentButton.UseVisualStyleBackColor = true;
            this.DeleteSElectedTournamentButton.Click += new System.EventHandler(this.DeleteSElectedTournamentButton_Click);
            // 
            // EndedTournamentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 416);
            this.Controls.Add(this.DeleteSElectedTournamentButton);
            this.Controls.Add(this.showTournamentBu);
            this.Controls.Add(this.EndedTournamentsListBox);
            this.Name = "EndedTournamentsForm";
            this.Text = "EndedTournamentsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox EndedTournamentsListBox;
        private System.Windows.Forms.Button showTournamentBu;
        private System.Windows.Forms.Button DeleteSElectedTournamentButton;
    }
}