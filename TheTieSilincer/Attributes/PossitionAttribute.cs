using System;

namespace TheTieSilincer.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class PossitionAttribute : Attribute
    {
        private int currentPossition;

        public PossitionAttribute(int currentPossition)
        {
            this.currentPossition = currentPossition;
        }

        public int CurrentPossition
        {
            get { return this.currentPossition; }
            private set { this.currentPossition = value; }
        }
    }
}
