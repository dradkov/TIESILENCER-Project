using System.Collections.Generic;
using TheTieSilincer.Enums;
using TheTieSilincer.Models.Weapons;

namespace TheTieSilincer.Models
{
    public abstract class Ship : GameObject
    {

        public Ship(List<Weapon> weapons = null)
        {
            this.Weapons = weapons;
        }

        public ShipType ShipType { get; protected set; }

        public List<Weapon> Weapons { get; protected set; }

        public int Armor { get; set; }

        public int CollisionAOE { get; protected set; }

      // public void DrawBullets() => this.Weapons.ForEach(v=> v.DrawBullets());
      //
      // public void UpdateBullets() => this.Weapons.ForEach(v=> v.UpdateBullets());
      //
      // public void ClearBullets() => this.Weapons.ForEach(v=>v.ClearBullets());

        public virtual bool IsAlive()
        {
            if(this.Armor > 0)
            {
                return true;
            }

            return false;
        }


    }
}
