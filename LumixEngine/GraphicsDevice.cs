using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace LumixEngine
{
    /// <summary>
    /// Manages the internal renderer
    /// </summary>
    public class GraphicsDevice
    {
        internal nint renderer;

        /// <summary>
        /// Creates a graphics device
        /// </summary>
        /// <param name="window">The window to use</param>
        public GraphicsDevice(GameWindow window)
        {
            renderer = window.renderer;
        }

        /// <summary>
        /// Clear the screen to the specified color
        /// </summary>
        /// <param name="color">The color</param>
        public void Clear(Color color)
        {
            SDL_SetRenderDrawColor(renderer, color.R, color.G, color.B, color.A);
            SDL_RenderClear(renderer);
        }

        /// <summary>
        /// Presents the drawn content to the screen
        /// </summary>
        public void Present()
        {
            SDL_RenderPresent(renderer);
        }
    }
}
