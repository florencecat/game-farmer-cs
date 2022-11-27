using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameFarmer.GameClasses
{
    [Serializable]
    class Corn : Plant
    {
        public Corn(FieldCell fieldCellParent)
        {
            Random random = new Random();
            parent = fieldCellParent;

            offsetS = 20;
            offsetG = 42;

            sowedRectangle = new Rectangle(996, 24, 25, 41);
            grownRectangle = new Rectangle(992, 193, 32, 62);

            tickTimer = new Timer();

            tickTimer.Tick += this.parent.OnTimedEvent;
            tickTimer.Interval = random.Next(15000, 20000);
            tickTimer.Enabled = false;
        }

        public override void Dispose()
        {
            tickTimer.Dispose();
        }
    }
}
