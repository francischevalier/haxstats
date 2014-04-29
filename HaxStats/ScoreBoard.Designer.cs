namespace HaxStats
{
    partial class ScoreBoard
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.switchTeamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.periodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.defineGameZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeOnAttackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetChronosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.topmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchTeamsToolStripMenuItem,
            this.scoreToolStripMenuItem,
            this.periodToolStripMenuItem,
            this.toolStripSeparator3,
            this.defineGameZoneToolStripMenuItem,
            this.timeOnAttackToolStripMenuItem,
            this.resetChronosToolStripMenuItem,
            this.toolStripSeparator1,
            this.topmostToolStripMenuItem,
            this.resetScoreToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 236);
            // 
            // switchTeamsToolStripMenuItem
            // 
            this.switchTeamsToolStripMenuItem.Name = "switchTeamsToolStripMenuItem";
            this.switchTeamsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.switchTeamsToolStripMenuItem.Text = "Switch teams";
            this.switchTeamsToolStripMenuItem.Click += new System.EventHandler(this.switchTeamsToolStripMenuItem_Click);
            // 
            // periodToolStripMenuItem
            // 
            this.periodToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem});
            this.periodToolStripMenuItem.Name = "periodToolStripMenuItem";
            this.periodToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.periodToolStripMenuItem.Text = "Period";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listToolStripMenuItem.Items.AddRange(new object[] {
            "Pregame",
            "First half",
            "Second half",
            "Overtime"});
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(100, 23);
            this.listToolStripMenuItem.Text = "Pregame";
            this.listToolStripMenuItem.SelectedIndexChanged += new System.EventHandler(this.listToolStripMenuItem_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(166, 6);
            // 
            // defineGameZoneToolStripMenuItem
            // 
            this.defineGameZoneToolStripMenuItem.Name = "defineGameZoneToolStripMenuItem";
            this.defineGameZoneToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.defineGameZoneToolStripMenuItem.Text = "Define game zone";
            this.defineGameZoneToolStripMenuItem.Click += new System.EventHandler(this.defineGameZoneToolStripMenuItem_Click);
            // 
            // timeOnAttackToolStripMenuItem
            // 
            this.timeOnAttackToolStripMenuItem.Name = "timeOnAttackToolStripMenuItem";
            this.timeOnAttackToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.timeOnAttackToolStripMenuItem.Text = "Time on Attack";
            this.timeOnAttackToolStripMenuItem.Click += new System.EventHandler(this.timeOnAttackToolStripMenuItem_Click);
            // 
            // resetChronosToolStripMenuItem
            // 
            this.resetChronosToolStripMenuItem.Name = "resetChronosToolStripMenuItem";
            this.resetChronosToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.resetChronosToolStripMenuItem.Text = "Reset chronos";
            this.resetChronosToolStripMenuItem.Click += new System.EventHandler(this.resetChronosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // topmostToolStripMenuItem
            // 
            this.topmostToolStripMenuItem.Checked = true;
            this.topmostToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topmostToolStripMenuItem.Name = "topmostToolStripMenuItem";
            this.topmostToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.topmostToolStripMenuItem.Text = "Topmost";
            this.topmostToolStripMenuItem.Click += new System.EventHandler(this.topmostToolStripMenuItem_Click);
            // 
            // resetScoreToolStripMenuItem
            // 
            this.resetScoreToolStripMenuItem.Name = "resetScoreToolStripMenuItem";
            this.resetScoreToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.resetScoreToolStripMenuItem.Text = "Reinitialize";
            this.resetScoreToolStripMenuItem.Click += new System.EventHandler(this.reinitializeToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // scoreToolStripMenuItem
            // 
            this.scoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.editToolStripMenuItem});
            this.scoreToolStripMenuItem.Name = "scoreToolStripMenuItem";
            this.scoreToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.scoreToolStripMenuItem.Text = "Score";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // ScoreBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(350, 38);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScoreBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.TopMost = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form3_Paint);
            this.DoubleClick += new System.EventHandler(this.Form3_DoubleClick);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScoreBoard_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form3_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form3_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form3_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem switchTeamsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem topmostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defineGameZoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeOnAttackToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem resetChronosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem periodToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;


    }
}