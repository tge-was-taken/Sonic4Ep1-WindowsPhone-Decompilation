using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Xna.Framework.Input.Touch
{
    public static class TouchPanel
    {
        public static TouchCollection GetState() => new TouchCollection();
    }

    public class TouchCollection
    {
        public int Count => 0;

        public TouchLocation this[int index]
        {
            get => new TouchLocation();
        }
    }

    public class TouchLocation
    {
        public TouchLocationState? State => 0;
        public int Id => 0;
        public Vector2 Position => new Vector2();
    }

    public enum TouchLocationState
    {
    }
}
