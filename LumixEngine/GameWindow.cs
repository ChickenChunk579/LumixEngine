using LumixEngine.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace LumixEngine
{
    /// <summary>
    /// Holds the window state, and manages events
    /// </summary>
    public class GameWindow
    {
        internal IntPtr window;
        internal IntPtr renderer;

        public bool Running { get; private set; } = true;

        /// <summary>
        /// Represents the game's window, created with SDL2
        /// </summary>
        /// <param name="title">The windows title</param>
        /// <param name="size">The size of the window in pixels</param>
        /// <param name="fullscreen">Toggles fullscreen</param>
        public GameWindow(string title, Vec2<int> size, bool fullscreen)
        {
            SDL_CreateWindowAndRenderer(size.X, size.Y, fullscreen ? SDL_WindowFlags.SDL_WINDOW_FULLSCREEN : 0, out window, out renderer);
        }

        public void ProcessEvents()
        {
            SDL_Event evnt;

            while (SDL_PollEvent(out evnt) != 0)
            {
                switch(evnt.type)
                {
                    case SDL_EventType.SDL_QUIT:
                        Running = false;
                        break;
                }
            }
        }
    }
}
