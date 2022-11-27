
namespace GameFarmer
{
    partial class Farmer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Farmer));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OpenQuicksaveDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveQuicksaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PlayerScore = new System.Windows.Forms.ToolStripStatusLabel();
            this.SeedsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.HarvestedPlantsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlayerState = new System.Windows.Forms.ToolStripStatusLabel();
            this.SeedType = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SaveLoadButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.HelpButton = new System.Windows.Forms.ToolStripButton();
            this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(768, 481);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // OpenQuicksaveDialog
            // 
            this.OpenQuicksaveDialog.DefaultExt = "bin";
            this.OpenQuicksaveDialog.FileName = "quicksave";
            this.OpenQuicksaveDialog.Filter = "Binary files (*.bin)|*.bin";
            // 
            // SaveQuicksaveDialog
            // 
            this.SaveQuicksaveDialog.DefaultExt = "bin";
            this.SaveQuicksaveDialog.FileName = "quicksave";
            this.SaveQuicksaveDialog.Filter = "Binary files (*.bin)|*.bin";
            this.SaveQuicksaveDialog.RestoreDirectory = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayerScore,
            this.SeedsCount,
            this.HarvestedPlantsCount,
            this.PlayerState,
            this.SeedType});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(768, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PlayerScore
            // 
            this.PlayerScore.Name = "PlayerScore";
            this.PlayerScore.Size = new System.Drawing.Size(118, 17);
            this.PlayerScore.Text = "toolStripStatusLabel1";
            // 
            // SeedsCount
            // 
            this.SeedsCount.Name = "SeedsCount";
            this.SeedsCount.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.SeedsCount.Size = new System.Drawing.Size(148, 17);
            this.SeedsCount.Text = "toolStripStatusLabel2";
            // 
            // HarvestedPlantsCount
            // 
            this.HarvestedPlantsCount.Name = "HarvestedPlantsCount";
            this.HarvestedPlantsCount.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.HarvestedPlantsCount.Size = new System.Drawing.Size(148, 17);
            this.HarvestedPlantsCount.Text = "toolStripStatusLabel3";
            // 
            // PlayerState
            // 
            this.PlayerState.Name = "PlayerState";
            this.PlayerState.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.PlayerState.Size = new System.Drawing.Size(148, 17);
            this.PlayerState.Text = "toolStripStatusLabel4";
            // 
            // SeedType
            // 
            this.SeedType.Name = "SeedType";
            this.SeedType.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.SeedType.Size = new System.Drawing.Size(148, 17);
            this.SeedType.Text = "toolStripStatusLabel5";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveLoadButton,
            this.HelpButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(768, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SaveLoadButton
            // 
            this.SaveLoadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveLoadButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.SaveLoadButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveLoadButton.Image")));
            this.SaveLoadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveLoadButton.Name = "SaveLoadButton";
            this.SaveLoadButton.Size = new System.Drawing.Size(49, 22);
            this.SaveLoadButton.Text = "Файл";
            // 
            // HelpButton
            // 
            this.HelpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HelpButton.Image = ((System.Drawing.Image)(resources.GetObject("HelpButton.Image")));
            this.HelpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(60, 22);
            this.HelpButton.Text = "Помощь";
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // LoadToolStripMenuItem
            // 
            this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            this.LoadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.LoadToolStripMenuItem.Text = "Загрузить";
            this.LoadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitToolStripMenuItem.Text = "Выйти";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // Farmer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 481);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Farmer";
            this.Text = "Farmer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog OpenQuicksaveDialog;
        private System.Windows.Forms.SaveFileDialog SaveQuicksaveDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel PlayerScore;
        private System.Windows.Forms.ToolStripStatusLabel SeedsCount;
        private System.Windows.Forms.ToolStripStatusLabel HarvestedPlantsCount;
        private System.Windows.Forms.ToolStripStatusLabel PlayerState;
        private System.Windows.Forms.ToolStripStatusLabel SeedType;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton SaveLoadButton;
        private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton HelpButton;
    }
}

