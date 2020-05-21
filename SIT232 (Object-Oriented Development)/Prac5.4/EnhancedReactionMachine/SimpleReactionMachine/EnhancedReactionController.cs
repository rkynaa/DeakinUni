using System;
namespace SimpleReactionMachine
{   
    
    /* Enhanced Controller Requirement
    1. If after inserting the coin the player fails to press Go/Stop within ten seconds, the game is over.
    2. If the player presses the Go/Stop button during the waiting period, the game is aborted, and the
        average value is not displayed. Once again, no reward for cheating!
    3. If the player presses the Go/Stop button while the machine is displaying a reaction‐time value, the
        machine immediately moves on to the next game (or shows the average time) without waiting for the
        full three seconds of display time.
    4. If the player presses the Go/Stop button while the machine is displaying the average time, the game is
        immediately over.
    */



    class EnhancedReactionController : IController
    {   
        IGui aGui;
        IRandom aRnd;
        string appState = "";
        bool validCoinDetected = false;
        int timeResponse = 0;
        int pushWaitTimer = 1000; // ten seconds
        int waitPlay = 300; // three seconds
        int[] resTime = {0,0,0,0};
        int curResTime = 0;
        int nPlay = 0;

        public EnhancedReactionController()
        {
        }

       //Connect controller to gui
        //(This method will be called before any other methods)
        public void Connect(IGui gui, IRandom rng){
            this.aGui = gui;
            this.aRnd = rng;
            Init();
        }

        //Called to initialise the controller
        public void Init(){
            appState = "idle";
            //this.aGui.SetDisplay("\n                  insert Coin                     ");
        }

        //Called whenever a coin is inserted into the machine
        public void CoinInserted(){
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
        public void GoStopPressed()
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
        public void Tick(){

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
        public void WaitTimeActivated(){
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

        public void DisplayTimeLeft(int TimeLeft){
            //this.aGui.Init();
            int timeInSec = (int)TimeLeft / 100; //time in second
            this.aGui.SetDisplay("Time Left: "+timeInSec+" second(s)");
            this.aGui.SetDisplay("\n         Press Enter Before time's up    ");
        }

        public void DisplayReactionTime(int timeRes){
            //this.aGui.Init();
            this.aGui.SetDisplay("Current Time : "+timeRes+"      ");
            this.aGui.SetDisplay("\n         Press Enter to response         ");
        }

        public void resetResponseTime(){
            for (int i = 0; i < resTime.Length; i ++){
                resTime[i] = 0;
            }
            nPlay = 0;
        }

        public double getAverageTime(){
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

        public void DisplayTimeLeftToPlay(int TimeLeft){
            //this.aGui.Init();
            int timeInSec = (int)TimeLeft / 100; //time in second
            this.aGui.SetDisplay("Wait to Play : "+timeInSec+" second(s)");
            this.aGui.SetDisplay("\n     Average Time "+getAverageTime()+" , response time : "+curResTime);
        }

        public void DisplayGameOver(){
            this.aGui.SetDisplay("GAME OVER                  ");
            this.aGui.SetDisplay("\n              Insert Coin !            ");
        }

        public void WaitPlayActivated(){
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