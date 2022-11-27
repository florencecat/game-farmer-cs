using System;
using Farmer.Resources;
using System.Drawing;

namespace GameFarmer.GameClasses
{
    [Serializable]
    class SeedBarn : InteractiveObject
    {
        public SeedBarn(Gamefield gamefieldP)
        {
            intObjSprite = Sprite.buildings;

            intObjPos.X = 45;
            intObjPos.Y = 245;

            height = 96; // 100 312 
            width = 128; // 230 300

            contourRectangle = new Rectangle(intObjPos.X, intObjPos.Y - 20, 100, 150);
            spriteRectangle = new Rectangle(50, 160, 115, 150);

            gamefield = gamefieldP;
        }

        public override void InteractionChecking(Rectangle playerRectangle, int state)
        {
            if (contourRectangle.IntersectsWith(playerRectangle) == true && state == 0)
                gamefield.player.messageHandler("seeds", 1);
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawImage(intObjSprite, intObjPos.X, intObjPos.Y, spriteRectangle, GraphicsUnit.Pixel);
        }
    }
}
