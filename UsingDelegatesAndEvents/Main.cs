using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace UsingDelegatesAndEvents
{
    public struct Bike
    {
        string make;
        int gears;
        float price;
      
        public string Make { get => make; set => make = value; }
        public int Gears { get => gears; set => gears = value; }
        public float Price { get => price; set => price = value; }

        public Bike(string make, int gears, float price) : this()
        {
            Make = make;
            Gears = gears;
            Price = price;
        }
    }

    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public delegate void PrintDelegate(string msg);
        public delegate int SortDelegate(int x, int y);
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

        public delegate int SortComparatorDelegate(Bike a, Bike b);
        public int SortByGears(Bike a, Bike b)
        {
            return a.Gears - b.Gears;
        }
        public int SortByPrice(Bike a, Bike b)
        {
            return (int)(a.Price - b.Price);
        }
        public void Sort(List<Bike> list, SortComparatorDelegate sorter)
        {
            //list.Sort(sorter);
            //bubble sort
        //    for ()
        //        for ()
        //            if (sorter(list[j], list[j + 1] < 0))
        //                swap(list[j], list[j + 1]);
        }              
        public bool isOdd(int x)
        {
            return x % 2 == 1;
        }
        public void doSomething(int a, bool b, char c, Predicate<int> pred)
        {
            pred(a);
        }

        //C# this is Action, C++ this is a procedure
        public void RingBell(float freq, int duration)
        {
            System.Diagnostics.Debug.WriteLine("Bell is ringing...");
        }

        public void Transform<E>(List<E> list, Predicate<E> pred, Action<E> transform)
        {

        }

        public bool DisplayAge(string name, int age)
        {
            System.Diagnostics.Debug.WriteLine(name + ", " + age);
            return true;
        }

        protected override void Initialize()
        {
            /*

              Q. How can we pass a function as a parameter to another function?
              A. In C++ we have...
                      1. Pointers to functions
                      2. Functors
                      3. STL Library (e.g. function, binary_function)
                      4. Lambda functions

                 In C# we have...
                      1. Delegate
                      2. Predicate
                      3. Action
                      4. Function

              What is a delegate?
                  - A data type
                  - A reference type (refers to an object/function in RAM/call stack)
           */

            /******************** Demo Delegate ********************/
            //instanciating and initializing a Delegate
            PrintDelegate p = new PrintDelegate(Display);
            //invoking a Delegate
            p("Hello world!");

            /******************** Demo Predicate & Action ********************/
            //instanciating and initializing a Predicate and an Action
            Predicate<int> myPred = isOdd;
            Action<float, int> myBellPred = RingBell;

            //invoking a Predicate and an Action
            myPred(31);
            myBellPred(25, 100);

            /******************** Demo Func ********************/
            //to do...
            Func<string, int, bool> myFunc = DisplayAge;
            myFunc("mary", 22);

            Func<Dictionary<string, int>, List<Bike>, bool> myComplexFunc;

            base.Initialize();
    }

        public void ShowAllAges(List<string> names, List<int> ages, Func<string, int, bool> func)
        {

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
