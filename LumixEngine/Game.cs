using LumixEngine.Math;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace LumixEngine
{
    /// <summary>
    /// Represents the game state, and manages the game loop and the window
    /// </summary>
    public class Game
    {
        public GameWindow Window { get; private set; }
        public GraphicsDevice GraphicsDevice { get; set; }

        public Game()
        {
            SDL_Init(SDL_INIT_VIDEO);

            Window = new GameWindow("Lumix App", new Vec2<int>(1280, 720), false);
            GraphicsDevice = new GraphicsDevice(Window);
        }

        /// <summary>
        /// Called once at the start of the game, used to initialize state
        /// </summary>
        protected virtual void Initialize()
        {

        }

        /// <summary>
        /// Called after Initialize, when the content manager is setup and ready to load content
        /// </summary>
        protected virtual void LoadContent()
        {

        }

        /// <summary>
        /// Called at the end of the game, to free leftover content
        /// </summary>
        protected virtual void UnloadContent()
        {
            SDL_Quit();
        }

        /// <summary>
        /// Called every frame
        /// </summary>
        /// <param name="time">The game's time state</param>
        protected virtual void Update(GameTime time)
        {

        }

        /// <summary>
        /// Draw things here
        /// </summary>
        /// <param name="time">The game's time state</param>
        protected virtual void Draw(GameTime time)
        {

        }

        internal void RunDesktop()
        {
            Initialize();
            LoadContent();

            DateTime start = DateTime.Now;
            DateTime lastUpdate = DateTime.Now;

            while (Window.Running)
            {
                GameTime gameTime = new GameTime(new TimeSpan(start.Ticks - DateTime.Now.Ticks), new TimeSpan(lastUpdate.Ticks - DateTime.Now.Ticks));

                Window.ProcessEvents();
                Update(gameTime);
                Draw(gameTime);
            }
        }


        private bool _firstRun = true;
        private DateTime wasmStart = DateTime.Now;
        private DateTime wasmLastUpdate = DateTime.Now;
        /// <summary>
        /// Entrypoint for WebAssembly builds
        /// !!! HOW TO USE !!!
        /// Import a setMainLoop function from JS using requestAnimationFrame, and use that with this function
        /// </summary>
        public void RunWebAssembly()
        {
            try
            {
                if (_firstRun)
                {
                    Console.WriteLine("Running on WASM");
                    _firstRun = false;

                    Initialize();
                    LoadContent();
                } else
                {
                    GameTime gameTime = new GameTime(new TimeSpan(wasmStart.Ticks - DateTime.Now.Ticks), new TimeSpan(wasmLastUpdate.Ticks - DateTime.Now.Ticks));

                    Window.ProcessEvents();
                    Update(gameTime);
                    Draw(gameTime);

                    wasmLastUpdate = DateTime.Now;
                }
            } catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Runs the game
        /// </summary>
        /// <param name="platform">Specifies which run configuration should be used</param>
        public void Run(Platform platform)
        {
            switch (platform)
            {
                case Platform.Desktop:
                    RunDesktop();
                    break;
                default:
                    Console.WriteLine("Unsupported platform: " + platform.ToString());
                    break;
            }
        }
    }
}
