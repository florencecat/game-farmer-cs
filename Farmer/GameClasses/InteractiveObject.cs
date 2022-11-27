using System;
using System.Drawing;

namespace GameFarmer.GameClasses
{
    [Serializable]
    class InteractiveObject
    {
        protected Rectangle spriteRectangle, contourRectangle;
        protected Point intObjPos;
        protected Bitmap intObjSprite;

        protected Gamefield gamefield;

        protected int height, width;

        public delegate int eventMessage(string eventWord, int value);

        public virtual void Draw(Graphics graphics) // base
        {
            contourRectangle = new Rectangle(intObjPos.X, intObjPos.Y, width, height);

            graphics.DrawImage(intObjSprite, intObjPos.X, intObjPos.Y, width, height);
        }

        public void StepChecking(Rectangle playerRectangle)
        {
            if (contourRectangle.IntersectsWith(playerRectangle) == false)
            {
                gamefield.player.messageHandler("stepPermission", 1);
            }
            else
            {
                gamefield.player.messageHandler("stepPermission", 0);
            }
        }

        public virtual void InteractionChecking(Rectangle playerRectangle, int state)
        {
            
        }
    }
}
