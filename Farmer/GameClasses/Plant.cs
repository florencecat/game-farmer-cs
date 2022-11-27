using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameFarmer.GameClasses
{
    [Serializable]
    class Plant : IDisposable
    {
        public int offsetS, offsetG;
        public FieldCell parent;

        [NonSerialized]
        protected Timer tickTimer;

        protected Bitmap sprite;
        public Rectangle sowedRectangle, grownRectangle;

        public virtual void Dispose() {  }

        public void TimerStart()
        {
            tickTimer.Enabled = true;
        }
    }
}
