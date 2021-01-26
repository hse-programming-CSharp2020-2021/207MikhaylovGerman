using System;



namespace Task05
{
    class VoteEventArgs : EventArgs
    {
        public string Question { get; set; }
        public int VoteFor { get; set; }
        public int VoteAgainst { get; set; }
        public int VoteAbstained { get; set; }
    }

    class ElectoralComission
    {
        public event EventHandler<VoteEventArgs> onVote;

        public VoteEventArgs Vote(string question)
        {
            VoteEventArgs voteEventArgs = new VoteEventArgs();
            Console.WriteLine(question);
            voteEventArgs.Question = question;
            onVote(this, voteEventArgs);
            return voteEventArgs;
        }
    }

    class Voter
    {
        static Random random = new Random();
        public void VoterHandler(object sender, VoteEventArgs e)
        {
            int num = random.Next(0, 3);
            if (num == 0)
                e.VoteFor++;
            else if (num == 1)
                e.VoteAgainst++;
            else
                e.VoteAbstained++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ElectoralComission electoralComission = new ElectoralComission();
            int n = 10;
            Voter[] voters = new Voter[n];
            for (int i = 0; i < n; i++)
            {
                voters[i] = new Voter();
                electoralComission.onVote += voters[i].VoterHandler;
            }
            VoteEventArgs voteEventArgs = electoralComission.Vote("???");
            Console.WriteLine(voteEventArgs.VoteFor);
            Console.WriteLine(voteEventArgs.VoteAgainst);
            Console.WriteLine(voteEventArgs.VoteAbstained);
        }
    }
}