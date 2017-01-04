using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Character
    {
        #region Properties
        public String Name { get; private set; }
        #endregion

        #region Constructors
        public Character(String PlayerName)
        {
            this.Name = PlayerName;
        }
        #endregion
    }
}
