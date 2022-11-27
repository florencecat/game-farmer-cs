using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using GameFarmer.GameClasses;

namespace GameFarmer
{
    [Serializable]
    public partial class Farmer : Form
    {
        Gamefield gamefield;
        BinaryFormatter binaryFormatter;
        Stream fileStream;

        public delegate int getObjectData(string message, int value);

        public event getObjectData getPlayerData;

        public Farmer()
        {
            InitializeComponent();

            gamefield = new Gamefield();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            foreach (InteractiveObject intObj in gamefield.intObjAppearance)
            {
                gamefield.player.OnCollisionQuestion += intObj.StepChecking;
                gamefield.player.OnInteractionQuestionIO += intObj.InteractionChecking;
            }

            binaryFormatter = new BinaryFormatter();
            fileStream = null;

            getPlayerData += gamefield.player.messageHandler;

            gamefield.player.CreateObjectMessage += gamefield.CreateFC;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    {
                        SaveLoadFunction(true);

                        break;
                    }
                case Keys.F9:
                    {
                        SaveLoadFunction(false);

                        break;
                    }
                default:
                    {
                        gamefield.player.KeyChecking(e);

                        break;
                    }
            }

            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            gamefield.Draw(e.Graphics);

            string tmp = ((Player.State)getPlayerData("state", -1)).ToString();

            PlayerScore.Text = "Счёт: " + gamefield.PlayerScore.ToString();
            SeedsCount.Text = "Семяна: " + gamefield.player.messageHandler("seeds", 0).ToString();
            PlayerState.Text = "Инструмент: " + ((Player.State)gamefield.player.messageHandler("state", -1)).ToString();
            HarvestedPlantsCount.Text = "Плоды: " + gamefield.player.messageHandler("growths", -1).ToString();
            SeedType.Text = "Сажаю " + ((Player.Seed)gamefield.player.messageHandler("seeds", -2)).ToString();

        }

        private void SaveLoadFunction(bool state)
        {
            string quicksaveName;

            switch (state)
            {
                case true:
                    {
                        if (SaveQuicksaveDialog.ShowDialog() == DialogResult.Cancel)
                            return;

                        quicksaveName = SaveQuicksaveDialog.FileName;

                        fileStream = new FileStream(quicksaveName, FileMode.Create, FileAccess.Write, FileShare.None);
                        binaryFormatter.Serialize(fileStream, gamefield);
                        fileStream.Close();

                        fileStream = null;

                        break;
                    }
                case false:
                    {
                        if (OpenQuicksaveDialog.ShowDialog() == DialogResult.Cancel)
                            return;

                        quicksaveName = OpenQuicksaveDialog.FileName;

                        fileStream = new FileStream(quicksaveName, FileMode.Open, FileAccess.Read, FileShare.Read);
                        gamefield = (Gamefield)binaryFormatter.Deserialize(fileStream);
                        fileStream.Close();

                        break;
                    }
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("Вы точно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Farmer.ActiveForm.Dispose();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLoadFunction(true);
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveLoadFunction(false);
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Помощь пока не написана", "Справка", MessageBoxButtons.OK);
        }
    }
}
