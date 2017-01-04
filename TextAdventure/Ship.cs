using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Ship
    {
        #region Properties
        public Character Captain;
        public string Name;

        public bool IsDead = false;

        public int MaxShieldHP = 100;
        public int MaxHullHP = 100;

        public int CurrentShieldHP = 100;
        public int CurrentHullHP = 100;
        #endregion

        #region Constructors
        public Ship(Character ShipCaptain, string ShipName)
        {
            this.Captain = ShipCaptain;
            this.Name = ShipName;
        }
        #endregion

        #region Methods
        public void DamageShip(int Damage)
        {
            // if enough shields to consume all damage
            if (this.CurrentShieldHP >= Damage)
            {
                this.CurrentShieldHP -= Damage;
                return;
            }
            
            int DamageAfterShields = this.CurrentShieldHP - Damage;
            this.CurrentShieldHP = 0; // all shields drained
            // if not enough hull for remaining damage
            if (this.CurrentHullHP <= DamageAfterShields)
            {
                // dead
                Console.WriteLine(this.Captain.Name + "'s Ship, " + this.Name + " was destroyed!");
                this.IsDead = true;
                this.CurrentHullHP = 0;
                return;
            }

            this.CurrentHullHP -= DamageAfterShields;
        }

        private bool IsMissingShields()
        {
            if (this.CurrentShieldHP < this.MaxShieldHP)
            {
                return true;
            }
            return false;
        }

        private bool IsMissingHull()
        {
            if (this.CurrentHullHP < this.MaxHullHP)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
