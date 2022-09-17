using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryGame
{
    internal class Board
    {
        private int m_NumberOfRows;
        private int m_NumberOfColumn;
        private int m_TotalBoardSize;
        private char[] m_RandomCharArray;

        private Cell[] m_Cells;

        public Board(int i_Rows, int i_Columns)
        {
            m_NumberOfRows = i_Rows;
            m_NumberOfColumn = i_Columns;
            m_TotalBoardSize = i_Rows * i_Columns;

            m_RandomCharArray = RandomizeArrayValueMaker(m_NumberOfRows, m_NumberOfColumn);

            m_Cells = new Cell[(i_Rows * i_Columns)];

            fillCellsValue();
        }

        private void fillCellsValue()
        {
            bool[] checkIfRandomValueIsAvailable = new bool[m_TotalBoardSize];

            int counterFilledCells = 0;
            int GetFreeRandomValue = 0;

            Random GenerateRandomValue = new Random();


            while (counterFilledCells != checkIfRandomValueIsAvailable.Length)
            {
                GetFreeRandomValue = GenerateRandomValue.Next(0, m_TotalBoardSize);

                if (checkIfRandomValueIsAvailable[GetFreeRandomValue] == false)
                {
                    checkIfRandomValueIsAvailable[GetFreeRandomValue] = true;

                    m_Cells[counterFilledCells] = new Cell(m_RandomCharArray[GetFreeRandomValue]);

                    counterFilledCells++;
                }
            }
        }

        public int BoardRows
        {
            get
            {
                return m_NumberOfRows;
            }
            set
            {
                m_NumberOfRows = value;
            }
        }

        public int BoardColumns
        {
            get
            {
                return m_NumberOfColumn;
            }
            set
            {
                m_NumberOfColumn = value;
            }

        }

        private char[] RandomizeArrayValueMaker(int i_Rows, int i_Columns)
        {
            int totalNumberOfChars = (i_Rows * i_Columns);
            int pickedValue = 0;

            int currectPlaceOfTheLoop = 0;
            int inputIndex = 0;

            double theRandomValue = 0;

            Random randomValue = new Random();

            char[] arrayOfChosenCharacters = new char[totalNumberOfChars * 2];
            char[] chackIfPickedAgain = new char[totalNumberOfChars];


            while (currectPlaceOfTheLoop < totalNumberOfChars)
            {
                bool checkIfCantContinue = false;
                bool checkIfDuplicate = false;

                theRandomValue = randomValue.NextDouble();
                if (theRandomValue > 0.5)
                {
                    pickedValue = randomValue.Next(65, 91);
                }
                else
                {
                    pickedValue = randomValue.Next(97, 123);
                }

                char pickedLetter = Convert.ToChar(pickedValue);

                for (int i = 0; i < chackIfPickedAgain.Length; i++)
                {
                    if (chackIfPickedAgain[i] == pickedLetter)
                    {
                        checkIfDuplicate = true;
                        checkIfCantContinue = true;
                        break;
                    }
                }

                if (checkIfDuplicate == false)
                {
                    arrayOfChosenCharacters[inputIndex] = pickedLetter;
                    arrayOfChosenCharacters[inputIndex + 1] = pickedLetter;

                    inputIndex = inputIndex + 2;
                }

                if (checkIfCantContinue == false)
                {
                    currectPlaceOfTheLoop++;
                }
            }
            return arrayOfChosenCharacters;
        }

        public void PrintBoard()
        {
            String charIndex = "ABCDEF";
            int printingArrayIndex = 0;

            for (int i = 0; i < (m_NumberOfRows + 1) * 2; i++)
            {
                for (int j = 0; j < m_NumberOfColumn + 1; j++)
                {
                    if (i == 0 && j != 0)
                    {
                        System.Console.Write("  " + charIndex[j - 1] + " ");
                    }
                    else
                    {
                        if (j == 0 && i % 2 == 0 && i != 0)
                        {
                            System.Console.Write((i / 2));
                        }
                        else
                        {
                            if (i % 2 == 0 && i != 0)
                            {
                                if (m_Cells[printingArrayIndex].IfFindMatch == false)
                                {

                                    if (m_Cells[printingArrayIndex].IfPickedByUser == true)
                                    {
                                        System.Console.Write(" | " + m_Cells[printingArrayIndex].charInCell);
                                        printingArrayIndex++;
                                    }
                                    else
                                    {
                                        System.Console.Write(" |  ");
                                        printingArrayIndex++;
                                    }
                                }
                                else
                                {
                                    System.Console.Write(" | " + m_Cells[printingArrayIndex].charInCell);
                                    printingArrayIndex++;
                                }

                                if (j == m_NumberOfColumn)
                                {
                                    System.Console.Write(" |");
                                }
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    System.Console.Write("  ");
                                }
                                else
                                {
                                    System.Console.Write("====");
                                }
                            }
                        }
                    }

                }

                System.Console.WriteLine();
            }
        }

        public void PrintFullBoard()
        {
            String charIndex = "ABCDEF";
            int printingArrayIndex = 0;

            for (int i = 0; i < (m_NumberOfRows + 1) * 2; i++)
            {
                for (int j = 0; j < m_NumberOfColumn + 1; j++)
                {
                    if (i == 0 && j != 0)
                    {
                        System.Console.Write("  " + charIndex[j - 1] + " ");
                    }
                    else
                    {
                        if (j == 0 && i % 2 == 0 && i != 0)
                        {
                            System.Console.Write((i / 2));
                        }
                        else
                        {
                            if (i % 2 == 0 && i != 0)
                            {
                                if (m_Cells[printingArrayIndex].IfFindMatch == false)
                                {

                                    if (m_Cells[printingArrayIndex].IfPickedByUser == false)
                                    {
                                        System.Console.Write(" | " + m_Cells[printingArrayIndex].charInCell);
                                        printingArrayIndex++;
                                    }
                                    else
                                    {
                                        System.Console.Write(" |  ");
                                        printingArrayIndex++;
                                    }
                                }
                                else
                                {
                                    System.Console.Write(" | " + m_Cells[printingArrayIndex].charInCell);
                                    printingArrayIndex++;
                                }

                                if (j == m_NumberOfColumn)
                                {
                                    System.Console.Write(" |");
                                }
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    System.Console.Write("  ");
                                }
                                else
                                {
                                    System.Console.Write("====");
                                }
                            }
                        }
                    }

                }

                System.Console.WriteLine();
            }
        }

        public Cell[] getCellArray
        {
            get
            {
                return m_Cells;
            }
            set
            {
                m_Cells = value;
            }
        }


    }
}
