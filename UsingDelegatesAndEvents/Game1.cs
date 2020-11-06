using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace UsingDelegatesAndEvents
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public delegate void PrintDelegate(string msg);
        private delegate int SortDelegate(int x, int y);

        public void Display(string x)
        {
            System.Diagnostics.Debug.WriteLine(x);
        }
        public void DisplayVerbose(string x)
        {
            System.Diagnostics.Debug.WriteLine("This is a " + x);
        }
        public void Process(List<string> list, PrintDelegate del)
        {
            foreach(string s in list)
                del(s);
        }
        protected override void Initialize()
        {
            PrintDelegate p = new PrintDelegate(Display);
            p("Hello world!");

          //  Process(list, p);

            /*
             
                Q. How can we pass a function as a parameter to another function?
                A. In C++ we have...
                        1. Pointers to functions
                        2. Functors
                        3. STL Library (e.g. function, binary_function)
                        4. Templated class function<>
                    
                   In C# we have...
                        1. Delegate
                            2. Predicate
                            3. Action

                What is a delegate?
                    - A data type
                    - A reference type (refers to an object/function in RAM/call stack)
             */






            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
