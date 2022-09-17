using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace MemoryGame
{
    internal class GameManager
    {

        private Player m_Player1;
        private Player m_Player2;

        private Board m_GameBoard;
        private Cell[] m_CurrectGameCellArray;

        private bool m_Player1Turn;
        private bool m_Winner;
        private bool m_PlayAgain;
        private bool m_FoundAMatch;

        private int m_TotalBoardSize;
        private int m_GameCulomnSize;
        private int m_GameRowSize;

        private int m_CurrectTurnColumn;
        private int m_RcurrectTurnRow;

        private int m_CounterOfMatchedCards;

        private String m_CheckForCurrectInput;


        public GameManager()
        {
            nameAndOpponentMethod();

            m_Player1Turn = false;
            m_Winner = false;
            m_FoundAMatch = false;
            m_PlayAgain = true;

            m_CounterOfMatchedCards = 0;

            gameProcess();
        }


        private void gameProcess()
        {
            do
            {
                Ex02.ConsoleUtils.Screen.Clear();
                settingBoardSize();
                m_CurrectGameCellArray = m_GameBoard.getCellArray;

                if (startingPlayerTurn() < 0.5)
                {
                    m_Player1Turn = true;
                }
                else
                {
                    m_Player1Turn = false;
                }

                m_GameBoard.PrintBoard();
                while (m_Winner == false)
                {
                    if (m_Player1Turn == true)
                    {
                        do
                        {
                            cardsPick(m_Player1, m_Player2);

                            if (m_CounterOfMatchedCards == m_TotalBoardSize / 2)
                            {
                                m_Winner = true;
                                break;
                            }
                        }
                        while (m_FoundAMatch == true);


                        m_Player1Turn = false;
                    }
                    else
                    {
                        do
                        {
                            cardsPick(m_Player2, m_Player1);

                            if (m_CounterOfMatchedCards == m_TotalBoardSize / 2)
                            {
                                m_Winner = true;
                                break;
                            }
                        }
                        while (m_FoundAMatch == true);


                        m_Player1Turn = true;
                    }
                }

                if (m_Player1.UserScore == m_Player2.UserScore)
                {
                    System.Console.WriteLine("Tie!!");

                    System.Console.WriteLine("Do you want to play again? y/n or Y/N");
                    String againInput = System.Console.ReadLine();
                    m_PlayAgain = checkIfWantToPlayAgain(againInput);
                }
                else
                {
                    if (m_Player1.UserScore > m_Player2.UserScore)
                    {
                        System.Console.WriteLine(m_Player1.PlayerName + " Won the game!!");

                        System.Console.WriteLine("Do you want to play again? y/n or Y/N");
                        String againInput = System.Console.ReadLine();
                        m_PlayAgain = checkIfWantToPlayAgain(againInput);
                    }
                    else
                    {
                        System.Console.WriteLine(m_Player2.PlayerName + " Won the game!!");
                        System.Console.WriteLine("Do you want to play again? y/n or Y/N");
                        String againInput = System.Console.ReadLine();
                        m_PlayAgain = checkIfWantToPlayAgain(againInput);
                    }
                }
            }
            while (m_PlayAgain == true);



        }

        private void nameAndOpponentMethod()
        {
            String opponentChoice = "";
            String player1Name = "";
            String player2Name = "";

            System.Console.WriteLine("Please Enter m_player1 name:");
            player1Name = System.Console.ReadLine();
            m_Player1 = new Player(player1Name);

            System.Console.WriteLine("To play against PC choose 1, for PVP choose 2:");
            opponentChoice = System.Console.ReadLine();



            while (opponentChoice != "1" && opponentChoice != "2")
            {
                System.Console.WriteLine("Invalid input, try again.");
                System.Console.WriteLine("To play against PC choose 1, for PVP choose 2:");
                opponentChoice = System.Console.ReadLine();
            }

            if (opponentChoice == "1")
            {
                m_Player2 = new Player("PC");
            }
            else
            {
                System.Console.WriteLine("Please Enter m_player2 name:");
                player2Name = System.Console.ReadLine();
                m_Player2 = new Player(player2Name);
            }
        }

        private void settingBoardSize()
        {
            String columnSize = "";
            String rowSize = "";


            System.Console.WriteLine("Please Enter the size between 4-6 of the row");
            rowSize = System.Console.ReadLine();

            while (rowSize != "4" && rowSize != "5" && rowSize != "6")
            {
                System.Console.WriteLine("invalid input, try again");
                System.Console.WriteLine("Please Enter the size between 4-6 of the row");
                rowSize = System.Console.ReadLine();
            }

            System.Console.WriteLine("Please Enter the size between 4-6 of the column");
            System.Console.WriteLine("Note! - if you choice 5 in the row, you cant choice it again!");
            columnSize = System.Console.ReadLine();

            if (rowSize == "5")
            {
                while (columnSize != "4" && columnSize != "6")
                {
                    System.Console.WriteLine("invalid input, try again");
                    System.Console.WriteLine("Please Enter the size between 4 or 6 of the column");
                    columnSize = System.Console.ReadLine();
                }
            }
            else
            {
                while (columnSize != "4" && columnSize != "5" && columnSize != "6")
                {
                    System.Console.WriteLine("invalid input, try again");
                    System.Console.WriteLine("Please Enter the size between 4 or 6 of the column");
                    columnSize = System.Console.ReadLine();
                }
            }

            m_GameRowSize = int.Parse(rowSize);
            m_GameCulomnSize = int.Parse(columnSize);
            m_TotalBoardSize = int.Parse(rowSize) * int.Parse(columnSize);

            m_GameBoard = new Board(int.Parse(rowSize), int.Parse(columnSize));
        }

        private double startingPlayerTurn()
        {
            Random random = new Random();
            double pickedValue = random.NextDouble();
            return pickedValue;
        }

        private void checkIfCurrctCellInput()
        {
            bool canContinue = false;

            while (canContinue == false)
            {

                UserColumnChoice();
                userRowChoice();

                int cellLocationOnTheArray = m_CurrectTurnColumn + (m_GameCulomnSize * (m_RcurrectTurnRow - 1));

                if (m_CurrectGameCellArray[cellLocationOnTheArray].IfFindMatch == false && m_CurrectGameCellArray[cellLocationOnTheArray].IfPickedByUser == false)
                {
                    canContinue = true;
                }
                else
                {
                    Console.WriteLine("you entered a picked card, pick a new card");
                    m_CheckForCurrectInput = System.Console.ReadLine();
                }
            }
        }

        private void UserColumnChoice()
        {
            String checkMaxBoardSize = "ABCDEF";

            int columns = 0;
            bool flag = false;
            // $G$ CSS-999 (0) Bad practice, just use while (!flag).
            while (!flag)
            {
                char ch = m_CheckForCurrectInput[0];

                if ((ch >= 'A' && ch <= checkMaxBoardSize[m_GameCulomnSize - 1]) && checkValidInputLength(m_CheckForCurrectInput))
                {

                    switch (ch)
                    {
                        case 'A':
                            flag = true;
                            columns = 0;
                            break;
                        case 'B':
                            flag = true;
                            columns = 1;
                            break;
                        case 'C':
                            flag = true;
                            columns = 2;
                            break;
                        case 'D':
                            flag = true;
                            columns = 3;
                            break;
                        case 'E':
                            flag = true;
                            columns = 4;
                            break;
                        case 'F':
                            flag = true;
                            columns = 5;
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
                else
                {
                    flag = false;

                    System.Console.WriteLine("invalide culomn, try again.");
                    System.Console.WriteLine("try enter the letter again");
                    m_CheckForCurrectInput = System.Console.ReadLine();

                    userRowChoice();

                }
            }

            m_CurrectTurnColumn = columns;
        }
        private void userRowChoice()
        {

            bool flag = false;
            char inputOfTheNumberFromthrString = m_CheckForCurrectInput[1];
            int theInputInIntFormat = 0;

            while (inputOfTheNumberFromthrString < '0' && inputOfTheNumberFromthrString > '9' || flag == false || checkValidInputLength(m_CheckForCurrectInput))
            {
                inputOfTheNumberFromthrString = m_CheckForCurrectInput[1];

                if ((int)Char.GetNumericValue(inputOfTheNumberFromthrString) <= m_GameRowSize && (int)Char.GetNumericValue(inputOfTheNumberFromthrString) != 0)
                {
                    theInputInIntFormat = (int)Char.GetNumericValue(inputOfTheNumberFromthrString);
                    flag = true;
                    break;
                }
                else
                {
                    System.Console.WriteLine("invalide Row, try again.");
                    System.Console.WriteLine("try enter the Row again");
                    m_CheckForCurrectInput = System.Console.ReadLine();

                    UserColumnChoice();
                }
            }
            m_RcurrectTurnRow = theInputInIntFormat;
        }

        private bool checkValidInputLength(String str)
        {
            while (m_CheckForCurrectInput.Length > 2)
            {
                System.Console.WriteLine("invalide input, try again.");
                System.Console.WriteLine("Enter column letter and row number like (A2):");
                m_CheckForCurrectInput = System.Console.ReadLine();

            }

            return true;
        }


        private void cardsPick(Player i_CurrectPlayerTurn, Player i_OtherPlayer)
        {
            int firstLocationPicked = 0;
            int secondLocationPicked = 0;

            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(i_CurrectPlayerTurn.PlayerName + " score is:" + i_CurrectPlayerTurn.UserScore);
            Console.WriteLine(i_OtherPlayer.PlayerName + " score is:" + i_OtherPlayer.UserScore);

            m_GameBoard.PrintBoard();

            Console.WriteLine(i_CurrectPlayerTurn.PlayerName + " enter the first card you want to pick (like this: A2):");
            m_CheckForCurrectInput = System.Console.ReadLine();
            checkIfPressQ(m_CheckForCurrectInput);
            checkIfCurrctCellInput();

            firstLocationPicked = m_CurrectTurnColumn + (m_GameCulomnSize * (m_RcurrectTurnRow - 1));
            m_CurrectGameCellArray[firstLocationPicked].IfPickedByUser = true;

            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(i_CurrectPlayerTurn.PlayerName + " score is:" + i_CurrectPlayerTurn.UserScore);
            Console.WriteLine(i_OtherPlayer.PlayerName + " score is:" + i_OtherPlayer.UserScore);
            m_GameBoard.PrintBoard();

            Console.WriteLine("enter the second card you want to pick (like this: A2):");
            m_CheckForCurrectInput = System.Console.ReadLine();
            checkIfPressQ(m_CheckForCurrectInput);
            checkIfCurrctCellInput();

            secondLocationPicked = m_CurrectTurnColumn + (m_GameCulomnSize * (m_RcurrectTurnRow - 1));
            m_CurrectGameCellArray[secondLocationPicked].IfPickedByUser = true;

            Ex02.ConsoleUtils.Screen.Clear();
            m_GameBoard.PrintBoard();

            if (m_CurrectGameCellArray[firstLocationPicked].charInCell == m_CurrectGameCellArray[secondLocationPicked].charInCell)
            {
                m_CurrectGameCellArray[firstLocationPicked].IfFindMatch = true;
                m_CurrectGameCellArray[secondLocationPicked].IfFindMatch = true;

                i_CurrectPlayerTurn.RaiseScore();
                m_CounterOfMatchedCards++;
                m_FoundAMatch = true;
            }
            else
            {
                Console.WriteLine("2 seconds delay");
                System.Threading.Thread.Sleep(2000);

                m_CurrectGameCellArray[firstLocationPicked].IfPickedByUser = false;
                m_CurrectGameCellArray[secondLocationPicked].IfPickedByUser = false;
                m_FoundAMatch = false;
            }

            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine(i_CurrectPlayerTurn.PlayerName + " score is:" + i_CurrectPlayerTurn.UserScore);
            Console.WriteLine(i_OtherPlayer.PlayerName + " score is:" + i_OtherPlayer.UserScore);

            m_GameBoard.PrintBoard();

        }

        private bool checkIfWantToPlayAgain(String i_UserInput)
        {
            bool flag = true;

            while (i_UserInput.Length > 1 && (i_UserInput[0] != 'y' || i_UserInput[0] != 'Y' || i_UserInput[0] != 'n' || i_UserInput[0] != 'N'))
            {
                System.Console.WriteLine("wrong input, try again");
                System.Console.WriteLine("Do you want to play again? y/n or Y/N");
                i_UserInput = System.Console.ReadLine();
            }

            if (i_UserInput[0] == 'n' || i_UserInput[0] == 'N')
            {
                flag = false;
            }
            else
            {
                flag = true;
                gameDataReset();
            }

            return flag;
        }

        private void gameDataReset()
        {
            m_Player1.UserScore = 0;
            m_Player2.UserScore = 0;

            m_CounterOfMatchedCards = 0;

            m_Winner = false;
        }

        private void checkIfPressQ(String i_UserInput)
        {
            if (i_UserInput[0] == 'Q' && i_UserInput.Length == 1)
            {
                Environment.Exit(0);
            }
        }

    }
}
