using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    class Program
    {
        static void Main( string[] args )
        {
            using ( var game = new Sonic4Ep1() )
            {
                game.Run();
            }
        }
    }
}
