using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MB_GameTemplate
{
    public static class KeyboardHandler
    {
        public static KeyboardState KB;

        public static void UpdateKeyboard() { KB = Keyboard.GetState(); }
    }
}
