using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameFarmer.GameClasses
{
    [Serializable]
    class Carrot : Plant
    {

        public Carrot(FieldCell fieldCellParent)
        {
            Random random = new Random();
            parent = fieldCellParent;

            sowedRectangle = new Rectangle(160, 106, 28, 28);
            grownRectangle = new Rectangle(160, 224, 28, 30);

            tickTimer = new Timer();

            tickTimer.Tick += this.parent.OnTimedEvent;
            tickTimer.Interval = random.Next(3000, 5500);
            tickTimer.Enabled = false;
        }

        public override void Dispose()
        {
            tickTimer.Dispose();
        }
    }
}
