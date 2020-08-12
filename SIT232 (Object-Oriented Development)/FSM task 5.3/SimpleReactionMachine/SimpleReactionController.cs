using System;
namespace SimpleReactionMachine
{   
    
    class SimpleReactionController : IController
    {   
        public IGui aGui;
        public IRandom aRnd;
        public string appState = "";
        bool validCoinDetected = false;
        public double timeResponse = 0;
        public SimpleReactionController()
        {
        }

       //Connect controller to gui
        //(This method will be called before any other methods)
        public virtual void Connect(IGui gui, IRandom rng){
            this.aGui = gui;
            this.aRnd = rng;
            Init();
        }

        //Called to initialise the controller
        public virtual void Init(){
            appState = "idle";
            this.aGui.SetDisplay("\n                  insert Coin                     ");
        }

        //Called whenever a coin is inserted into the machine
        public virtual void CoinInserted(){
            if (appState == "idle"){
                 this.aGui.SetDisplay("\n            (Press ENTER to Play)                ");
                 validCoinDetected = true;
                if (validCoinDetected){
                    appState = "coin_ok";
                }else{
                    appState = "coin_failed";
                }
            }
        }

        //Called whenever the go/stop button is pressed
        public virtual void GoStopPressed()
        {
            switch (appState)
            {
                case "coin_ok":
                    this.aGui.Init();
                    appState = "play";
                    break;

                case "play":
                    int maxTime = this.aRnd.GetRandom(1, 10);
                    int resTime = (int)timeResponse / 100; //get time in second
                    if (resTime  <  maxTime){
                         this.aGui.SetDisplay("\n     Max Time "+maxTime+" , current time response : "+resTime);
                         timeResponse = 0;
                    }else{
                         this.aGui.SetDisplay("\n                  Game Over!                          ");
                         appState = "idle";
                         timeResponse = 0;
                         this.aGui.Init();
                    }
                    break;

                default:
                    break;
            }

        }

        //Called to deliver a TICK to the controller
        public virtual void Tick(){
            if (appState == "play"){
                timeResponse ++;
                this.aGui.SetDisplay("Current Time : "+timeResponse);
            }      
        }
    }
}