using System;
using System.Timers;

namespace SimpleReactionMachine
{
    class EnhancedReactionMachine
    {
        const string TOP_LEFT_JOINT = "┌";
        const string TOP_RIGHT_JOINT = "┐";
        const string BOTTOM_LEFT_JOINT = "└";
        const string BOTTOM_RIGHT_JOINT = "┘";
        const string TOP_JOINT = "┬";
        const string BOTTOM_JOINT = "┴";
        const string LEFT_JOINT = "├";
        const string JOINT = "┼";
        const string RIGHT_JOINT = "┤";
        const char HORIZONTAL_LINE = '─';
        const char PADDING = ' ';
        const string VERTICAL_LINE = "│";

        static private IController contoller;
        static private IGui gui;

        static void Main(string[] args)
        {
            

            // Create a time for Tick event
            Timer timer = new Timer(10);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;

            // Connect GUI with the Controller and vice versa
            contoller = new MyController();
            gui = new Gui();
            gui.Connect(contoller);
            contoller.Connect(gui, new RandomGenerator());

            //Reset the GUI
            gui.Init();
            // Start the timer
            timer.Enabled = true;

            // Run the menu
            bool quitePressed = false;
            while (!quitePressed)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        contoller.GoStopPressed();
                        break;
                    case ConsoleKey.Spacebar:
                        contoller.CoinInserted();
                        break;
                    case ConsoleKey.Escape:
                        quitePressed = true;
                        break;
                }
            }
        }

        // This event occurs every 10 msec
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            contoller.Tick();
        }

        // Internal implementation of Random Generator
        private class RandomGenerator : IRandom
        {
            Random rnd = new Random(100);

            public int GetRandom(int from, int to)
            {
                return rnd.Next(from) + to;
            }
        }

        // Internal implementation of GUI
        private class Gui : IGui
        {
            private IController controller;
            public void Connect(IController controller)
            {
                this.controller = controller;
            }

            public void Init()
            {
                Console.Clear();
                // Make a menu
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0}{1}{2}", TOP_LEFT_JOINT, new string(HORIZONTAL_LINE, 50), TOP_RIGHT_JOINT);
                Console.WriteLine("{0}{1}{2}", VERTICAL_LINE, new string(' ', 50), VERTICAL_LINE);
                Console.WriteLine("{0}{1}{2}", VERTICAL_LINE, new string(' ', 50), VERTICAL_LINE);
                Console.WriteLine("{0}{1}{2}", VERTICAL_LINE, new string(' ', 50), VERTICAL_LINE);
                Console.WriteLine("{0}{1}{2}", LEFT_JOINT, new string(HORIZONTAL_LINE, 50), RIGHT_JOINT);
                Console.WriteLine("{0}{1}{2}", VERTICAL_LINE, new string(' ', 50), VERTICAL_LINE);
                Console.WriteLine("{0}{1}{2}", VERTICAL_LINE, new string(' ', 50), VERTICAL_LINE);
                Console.WriteLine("{0}{1}{2}", VERTICAL_LINE, new string(' ', 50), VERTICAL_LINE);
                Console.WriteLine("{0}{1}{2}", VERTICAL_LINE, new string(' ', 50), VERTICAL_LINE);
                Console.WriteLine("{0}{1}{2}", VERTICAL_LINE, new string(' ', 50), VERTICAL_LINE);
                Console.WriteLine("{0}{1}{2}", BOTTOM_LEFT_JOINT, new string(HORIZONTAL_LINE, 50), BOTTOM_RIGHT_JOINT);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(5, 6);
                Console.Write("{0,-20}", "- For Insert Coin press SPACE");
                Console.SetCursorPosition(5, 7);
                Console.Write("{0,-20}", "- For Go/Stop action press ENTER");
                Console.SetCursorPosition(5, 8);
                Console.Write("{0,-20}", "- For Exit press ESC");

                SetDisplay("Insert Coin!");
            }

            public void SetDisplay(string text)
            {
                PrintUserInterface(text);
            }

            private void PrintUserInterface(string text)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(15, 2);
                Console.Write("{0,-20}", text);
                Console.SetCursorPosition(0, 10);
            }
        }
                                     
        private class MyController : EnhancedReactionController
        {
            public override void Connect(IGui gui, IRandom rng)
            {
                this.aGui = gui;
                this.aRnd = rng;
                Init();
            }

            //Called to initialise the controller
            public override void Init(){
                appState = "idle";
                //this.aGui.SetDisplay("\n                  insert Coin                     ");
            }

            //Called whenever a coin is inserted into the machine
            public override void CoinInserted(){
                if (appState == "idle"){
                    this.aGui.SetDisplay("\n            (Press ENTER to Play)                ");
                    validCoinDetected = true;
                    if (validCoinDetected){
                        appState = "push_wait";
                    }else{
                        appState = "coin_failed";
                    }
                }
            }

            //Called whenever the go/stop button is pressed
            public  override void GoStopPressed()
            {
                switch (appState)
                {
                    case "push_wait":
                        appState = "play";
                        pushWaitTimer = 1000;
                        waitPlay = 300;
                        break;

                    case "play":
                        int maxTime = this.aRnd.GetRandom(1, 10);
                        curResTime = (int)timeResponse / 100; //get time in second

                        nPlay ++;
                        resTime[nPlay] = curResTime;

                        if (curResTime  <  maxTime){
                            appState = "wait_play";
                            timeResponse = 0;
                        }else{
                            this.aGui.SetDisplay("\n                  Game Over!                          ");
                            appState = "idle";
                            timeResponse = 0;
                            //this.aGui.Init();
                            DisplayGameOver();
                            resetResponseTime();
                        }
                        break;
                    
                    case "wait_play":
                        this.aGui.SetDisplay("\n                  Game Over!                          ");
                        appState = "idle";
                        timeResponse = 0;
                        DisplayGameOver();
                        resetResponseTime();   
                        break;

                    default:
                        break;
                }

            }

            //Called to deliver a TICK to the controller
            public override void Tick(){

                switch (appState)
                {
                    case "play":
                        timeResponse++;
                        DisplayReactionTime(timeResponse);
                        break;

                    case "push_wait":
                        WaitTimeActivated();
                        break;
                    
                    case "wait_play":
                        WaitPlayActivated();
                        break;
                    
                    case "over":
                        DisplayGameOver();
                        appState = "idle";
                        break;             

                } 
            }

            //wait for button press after insert coins if exceed 10 seconds game over
            public override void WaitTimeActivated(){
                if (pushWaitTimer > 0){
                    pushWaitTimer --;
                    DisplayTimeLeft(pushWaitTimer);
                }else{
                    appState = "over";
                    //DisplayGameOver();
                    pushWaitTimer = 1000;
                    resetResponseTime();
                }
            }

            public override void DisplayTimeLeft(int TimeLeft){
                //this.aGui.Init();
                int timeInSec = (int)TimeLeft / 100; //time in second
                this.aGui.SetDisplay("Time Left: "+timeInSec+" second(s)");
                this.aGui.SetDisplay("\n         Press Enter Before time's up    ");
            }

            public override void DisplayReactionTime(int timeRes){
                //this.aGui.Init();
                this.aGui.SetDisplay("Current Time : "+timeRes+"      ");
                this.aGui.SetDisplay("\n         Press Enter to response         ");
            }

            public override void resetResponseTime(){
                for (int i = 0; i < resTime.Length; i ++){
                    resTime[i] = 0;
                }
                nPlay = 0;
            }

            public override double getAverageTime(){
                int n = 0;
                int tRes = 0;
                for (int i = 0; i< resTime.Length; i++){
                    if (resTime[i] > 0){
                        n++;
                        tRes = tRes + resTime[i];
                    }
                }
            return tRes / n;
            }

            public  override void DisplayTimeLeftToPlay(int TimeLeft){
                //this.aGui.Init();
                int timeInSec = (int)TimeLeft / 100; //time in second
                this.aGui.SetDisplay("Wait to Play : "+timeInSec+" second(s)");
                this.aGui.SetDisplay("\n     Average Time "+getAverageTime()+" , response time : "+curResTime);
            }

            public override void DisplayGameOver(){
                this.aGui.SetDisplay("GAME OVER                  ");
                this.aGui.SetDisplay("\n              Insert Coin !            ");
            }

            public  override void WaitPlayActivated(){
                if (waitPlay > 0){
                    waitPlay --;
                    DisplayTimeLeftToPlay(waitPlay);
                }else{
                    if (nPlay < resTime.Length-1){
                        appState = "push_wait";
                        waitPlay = 300;
                    }else{
                        appState = "over";
                    }
                    
                }
            }
        }
    }
}