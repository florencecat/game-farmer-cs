using System;
using System.Drawing;
using Farmer.Resources;
using System.Timers;

namespace GameFarmer.GameClasses
{
    [Serializable]
    class FieldCell : InteractiveObject
    {
        Rectangle cellRectangle;
        bool planted, watered, grown;

        Plant plant;

        //Pen fieldCellPen;

        public event eventMessage messageHandlerFC;
        
        public Rectangle CellRectangle { get => cellRectangle; }
        
        public FieldCell(int x, int y, Gamefield gamefield)
        {
            intObjPos.X = x;
            intObjPos.Y = y;
            cellRectangle = new Rectangle(intObjPos.X, intObjPos.Y, 30, 30);
            spriteRectangle = new Rectangle(1, 294, 28, 28);
            //contourRectangle = new Rectangle(fieldCellPos.X - 10, fieldCellPos.Y - 10, 50, 50);

            planted = false;
            watered = false;
            grown = false;

            intObjSprite = Sprite.crops;

            plant = null;

            this.gamefield = gamefield;

            gamefield.player.OnInteractionQuestionFC += this.InteractionChecking;
            messageHandlerFC += gamefield.player.messageHandler;
        }

        public override void Draw(Graphics graphics) // improved
        {
            graphics.DrawImage(intObjSprite, intObjPos.X, intObjPos.Y, spriteRectangle, GraphicsUnit.Pixel);

            if (planted == true && watered == true)
                graphics.DrawImage(intObjSprite, intObjPos.X, intObjPos.Y - plant.offsetS, plant.sowedRectangle, GraphicsUnit.Pixel);
            if (grown == true)
                graphics.DrawImage(intObjSprite, intObjPos.X, intObjPos.Y - plant.offsetG, plant.grownRectangle, GraphicsUnit.Pixel);
        }

        public override void InteractionChecking(Rectangle playerRectangle, int state)
        {
            switch (state)
            {
                case 0:
                    {
                        if (cellRectangle.IntersectsWith(playerRectangle) == true && grown == true)
                        {
                            Random growthsResult = new Random();

                            grown = false;
                            watered = false;
                            planted = false;

                            messageHandlerFC("growths", growthsResult.Next(1,3));

                            plant.Dispose();

                            if (Farmer.ActiveForm != null)
                                Farmer.ActiveForm.Refresh();
                        }
                        break;
                    }
                case 2:
                    {
                        if (cellRectangle.IntersectsWith(playerRectangle) == true)
                        {
                            watered = true;
                        }
                        break;
                    }
                case 3:
                    {
                        if (cellRectangle.IntersectsWith(playerRectangle) == true && !planted)
                        {
                            planted = true;

                            switch (messageHandlerFC("seeds", -2))
                            {
                                case 0:
                                    {
                                        plant = new Carrot(this);

                                        break;
                                    }
                                case 1:
                                    {
                                        plant = new Tomato(this);

                                        break;
                                    }
                                case 2:
                                    {
                                        plant = new Corn(this);

                                        break;
                                    }
                            }

                            messageHandlerFC("seeds", -1);
                        }
                        break;
                    }
            }

            if (planted == true && watered == true)
                plant.TimerStart();
        }

        public void OnTimedEvent(Object sender, EventArgs e)
        {
            grown = true;

            if (Farmer.ActiveForm != null)
                Farmer.ActiveForm.Refresh();
        }
    }
}
