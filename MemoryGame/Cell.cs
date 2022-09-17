using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryGame
{
    public class Cell
    {
        private char m_CharInCell;
        private bool m_IsMatched;
        private bool m_IsPicked;

        public Cell(char i_charInCell)
        {
            m_CharInCell = i_charInCell;
            m_IsMatched = false;
            m_IsPicked = false;
        }

        public char charInCell
        {
            get
            {
                return m_CharInCell;
            }
            set
            {
                m_CharInCell = value;
            }
        }

        public bool IfFindMatch
        {
            get
            {
                return m_IsMatched;
            }
            set
            {
                m_IsMatched = value;
            }
        }


        public bool IfPickedByUser
        {
            get
            {
                return m_IsPicked;
            }
            set
            {
                m_IsPicked = value;
            }
        }
    }
}