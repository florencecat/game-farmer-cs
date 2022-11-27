using System;
using Farmer.Resources;
using System.Drawing;

namespace GameFarmer.GameClasses
{
    [Serializable]
    class HarvestBarn : InteractiveObject
    {
        public HarvestBarn(Gamefield gamefieldP)
        {
            intObjSprite = Sprite.buildings;

            intObjPos.X = 575;
            intObjPos.Y = 245;

            height = 190;
            width = 150;

            contourRectangle = new Rectangle(intObjPos.X, intObjPos.Y - 25, 112, 124);
            spriteRectangle = new Rectangle(60, 32, 112, 124);

            gamefield = gamefieldP;
        }

        public override void InteractionChecking(Rectangle playerRectangle, int state)
        {
            if (contourRectangle.IntersectsWith(playerRectangle) == true && state == 4)
                gamefield.UpdateScore(this, gamefield.player.messageHandler("growths", 0));
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(intObjSprite, intObjPos.X, intObjPos.Y, spriteRectangle, GraphicsUnit.Pixel);
        }
    }
}
