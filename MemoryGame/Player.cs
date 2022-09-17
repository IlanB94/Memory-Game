using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryGame
{
    internal class Player
    {
        internal string m_PlayerName;
        internal int m_PlayerScore;

        public Player(string i_PlayerName)
        {
            m_PlayerName = i_PlayerName;
            m_PlayerScore = 0;
        }

        public string PlayerName
        {
            get
            {
                return m_PlayerName;
            }
            set
            {
                if (value == " ")
                {
                    throw new Exception("You enter ivalid input ! try agai");
                }
                else
                {
                    m_PlayerName = value;

                }
            }
        }

        public int UserScore
        {
            get
            {
                return m_PlayerScore;
            }
            set
            {
                m_PlayerScore = value;
            }
        }

        internal void RaiseScore()
        {
            m_PlayerScore++;
        }

        public string printPlayerDetails()
        {
            string m_playerName = Convert.ToString(this.PlayerName);
            return "Player name is " + m_playerName.ToString();
        }

        public static bool operator ==(Player p1, Player p2)
        {
            return p1.UserScore == p2.UserScore;
        }
        public static bool operator !=(Player p1, Player p2)
        {
            return p1.UserScore != p2.UserScore;
        }

    }
}
