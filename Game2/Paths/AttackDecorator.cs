using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Robot_House_Touhou_Game
{
    public abstract class AttackDecorator : Attacks //we want this to inherit from attacks, where attacks is the current 'DecoratorAttacks' 
    {                                                        //however this isn't working at the moment as there is a bug with the List in each
        public Attacks Attack;                      //attack that I wasn't able to fix 
    }
}
