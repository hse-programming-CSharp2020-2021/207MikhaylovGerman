using System;

namespace ClassWork
{
    class PlayIsStartedEvemtArgs : EventArgs
    {

    }

    class BandMaster
    {
        public event EventHandler<PlayIsStartedEvemtArgs> PlayIsStartedEvent;


        private void StartPlay(int number)
        {
        }
    }
    abstract class OrchestraPlayer
    {
        public string Name { get; set; }

        public OrchestraPlayer(string name)
        {
            Name = name;
        }
        public OrchestraPlayer()
        {
        }

        public abstract void PlayIsStartedEventHandler(object sender, PlayIsStartedEvemtArgs e);
           
    }

    class Violinist : OrchestraPlayer
    {
        public override void PlayIsStartedEventHandler(object sender, PlayIsStartedEvemtArgs e)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            _ = new Violinist() { Name = "dwdwd" };
        }
    }
}
