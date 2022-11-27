using System.Drawing;
using Farmer.Resources;
using System;
using System.Windows.Forms;

namespace GameFarmer.GameClasses
{
    [Serializable]
    class Gamefield
    {
        int playerScore, requiredScore;

        public Player player;
        public InteractiveObject[] intObjAppearance;
        public InteractiveObject[] intObjFieldCells;

        public readonly Rectangle gameArea;
        Bitmap background;

        public int PlayerScore
        {
            get => playerScore;
        }

        public Gamefield()
        {
            playerScore = 190;
            requiredScore = 200;

            player = new Player(this);
            intObjAppearance = new InteractiveObject[2];
            intObjFieldCells = new InteractiveObject[16];

            intObjAppearance[0] = new SeedBarn(this);
            intObjAppearance[1] = new HarvestBarn(this);

            gameArea = new Rectangle(0, 275, 784, 186);
            //gameAreaPen = new Pen(Color.Black, 2);

            for (int i = 0; i < 2; i++)
                intObjFieldCells[i] = null;

            background = Sprite.background_1;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(background, 0, -135, 800, 600);

           foreach (InteractiveObject intObj in intObjAppearance)
                intObj.Draw(graphics);

            foreach (InteractiveObject intObj in intObjFieldCells)
                if (intObj != null)
                    intObj.Draw(graphics);

            this.player.draw(graphics);
        }

        public bool CreateFC(Rectangle objectRectangle)
        {
            try
            {
                foreach (FieldCell intObj in intObjFieldCells)
                {
                    if (intObj != null && intObj.CellRectangle.IntersectsWith(objectRectangle))
                        return false;
                }

                intObjFieldCells[Array.IndexOf(intObjFieldCells, null)] = new FieldCell(player.PlayerPos.X - 16, player.PlayerPos.Y - 16, this);
            }
            catch
            { }

            return true;
        }

        public void UpdateScore(object sender, int value)
        {
            if (sender is HarvestBarn)
                playerScore += value * 10;

            if (playerScore >= requiredScore)
            {
                DialogResult result;

                result = MessageBox.Show("Вы победили! Продолжите играть?", "Победа! Набрано очков: " + playerScore.ToString(), MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    requiredScore = 1000;
                else
                    Farmer.ActiveForm.Dispose();
            }
        }
    }
}
