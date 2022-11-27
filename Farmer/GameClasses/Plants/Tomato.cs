using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameFarmer.GameClasses
{
    [Serializable]
    class Tomato : Plant
    {
        public Tomato(FieldCell fieldCellParent)
        {
            Random random = new Random();
            parent = fieldCellParent;

            offsetS = 10; 
            offsetG = 15;

            sowedRectangle = new Rectangle(896, 420, 28, 28);
            grownRectangle = new Rectangle(897, 537, 30, 36);

            tickTimer = new Timer();

            tickTimer.Tick += this.parent.OnTimedEvent;
            tickTimer.Interval = random.Next(5000, 8000);
            tickTimer.Enabled = false;
        }

        public override void Dispose()
        {
            tickTimer.Dispose();
        }
    }
}
