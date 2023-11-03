using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Doublerer
    {
        public int Current { get; set; }
        public int Target { get; set; }

        public Doublerer(int min, int max) 
        {
            StartGame(min, max);
        }

        public void StartGame(int min, int max)
        {
            var rand = new Random();
            Target = rand.Next(min, max + 1);
            Current = rand.Next(0, Target);
        }

        public void Multi()
        {
            Current *= 2;
        }

        public void Add()
        {
            Current++;
        }

        private GameState CheckLose()
        {
            if (Current > Target)
            {
                return GameState.Lose;
            }
            return GameState.Running;
        }

        private GameState CheckWin()
        {
            if (Current == Target)
            {
                return GameState.Win;
            }
            return GameState.Running;
        }

        public GameState GetGameState()
        {
            GameState state;
            state = GameState.Running;
            state = CheckWin();
            if (state == GameState.Win)
            {
                return state;
            }
            state = CheckLose();
            if (state == GameState.Lose) 
            {
                return state;
            }
            return state;
        }
    }
}
