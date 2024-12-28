using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumixEngine
{
    /// <summary>
    /// Represents the time state of a game
    /// </summary>
    public class GameTime
    {
        /// <summary>
        /// The total time elapsed since the start of the app
        /// </summary>
        public TimeSpan TotalGameTime { get; set; }

        /// <summary>
        /// The time elapsed since the last Update call
        /// </summary>
        public TimeSpan ElapsedGameTime { get; set; }

        /// <summary>
        /// Creates an instance of GameTime
        /// </summary>
        /// <param name="totalGameTime">Total time the game has been running</param>
        /// <param name="elapsedGameTime">How much time since the last update call</param>
        public GameTime(TimeSpan totalGameTime, TimeSpan elapsedGameTime)
        {
            TotalGameTime = totalGameTime;
            ElapsedGameTime = elapsedGameTime;
        }
    }
}
