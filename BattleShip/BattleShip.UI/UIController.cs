using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI;
using BattleShip.BLL;

namespace BattleShip.UI
{
    public class UIController
    {
        public UserMaintainer WorkFlow;

        public string GetPlayerName()
        {
            Console.WriteLine("Please enter your name:");
            string playerName = string.Empty;
            do
            {
                playerName = Console.ReadLine();
                Console.Clear();
            } while (!ValidatePLayerName(playerName));
            return playerName;
        }

        public bool ValidatePLayerName(string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                Console.WriteLine("Don't leave your name empty, provide a name please");
                GetPlayerName();
            }
            return true;
        }


        public bool ValidatePlayResponse()
        {
            Console.WriteLine("Would you like to play battleship? Y or N");
            string userDecision = Console.ReadLine();
            if (userDecision.StartsWith("Y") || userDecision.StartsWith("y"))
            {
                Console.WriteLine("Welcome Child");
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetValidInput()
        {
            string coordinateInput = null;
            do
            {
                coordinateInput = Console.ReadLine();
                if (CoordinateTranslator.CoordinateLengthValidation(coordinateInput) == false)
                {
                    Console.WriteLine("Your coordinate must be between 2 and 3 characters");
                }
                else if (CoordinateTranslator.CheckForCoorLetter(coordinateInput) == false)
                {
                    Console.WriteLine("You need to choose a letter between a and j");
                }
                else if (CoordinateTranslator.NumberCheck(coordinateInput) == false)
                {
                    Console.WriteLine("You need to provide a number between 1 and 10");
                }
            } while (!CoordinateTranslator.CoordinateLengthValidation(coordinateInput) || !CoordinateTranslator.CheckForCoorLetter(coordinateInput) || !CoordinateTranslator.NumberCheck(coordinateInput));
            return coordinateInput;
        }

        public bool StartGame()
        {
            if (ValidatePlayResponse() == true)
            {
                Console.WriteLine("Welcome to BattleShip, you shall surely lose!");
                string playerOneName = GetPlayerName();
                string playerTwoName = GetPlayerName();
                WorkFlow = new UserMaintainer(playerOneName, playerTwoName);
                Setup(WorkFlow.CurrentBoard);
                WorkFlow.ToggleUserName();
                Setup(WorkFlow.CurrentBoard);

                while (FireShot(WorkFlow.CurrentBoard).ShotStatus != ShotStatus.Victory)
                {
                    Console.Clear();
                    WorkFlow.ToggleUserName();
                }
            }
            return false;
        }

        private void Setup(Board board)
        {
            foreach (ShipType ship in Enum.GetValues(typeof(ShipType)))
            {
                PlaceShip(board, ship);
            }
        }

        private void PlaceShip(Board whichBoard, ShipType ship)
        {
            ShipPlacement placeShip;
            do
            {
                Console.WriteLine();
                DrawShipsFromBoard(whichBoard);
                Console.WriteLine("Please place your ships {0}", WorkFlow.CurrentPlayer.PlayerName);
                Console.WriteLine("Enter a coordinate to place your ship: {0}", ship);
                PlaceShipRequest shipPlacement = new PlaceShipRequest();
                shipPlacement.Coordinate = CoordinateTranslator.Translate(GetValidInput());
                shipPlacement.ShipType = ship;
                shipPlacement.Direction = ShipDirectionPlacement();
                placeShip = whichBoard.PlaceShip(shipPlacement);
                Console.Clear();
            } while (ValidShipPlacement(placeShip));
        }

        public bool ValidShipPlacement(ShipPlacement currentPlacement)
        {
            if (currentPlacement == ShipPlacement.Ok)
            {
                return false;
            }
            else if (currentPlacement == ShipPlacement.NotEnoughSpace)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You do not have enough room to place that ship there");
                Console.ResetColor();
            }
            else if (currentPlacement == ShipPlacement.Overlap)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You placement is overlapping with another ship");
                Console.ResetColor();
            }
            return true;
        }

        public ShipDirection ShipDirectionPlacement()
        {
            string shipDirectionChoice;
            do
            {
                Console.WriteLine("Which direction would you like to place your ship?");
                shipDirectionChoice = Console.ReadLine();
                Console.Clear();
            } while (ShipPlacementValidation(shipDirectionChoice) != ShipDirection.Down && ShipPlacementValidation(shipDirectionChoice) != ShipDirection.Up && ShipPlacementValidation(shipDirectionChoice) != ShipDirection.Left && ShipPlacementValidation(shipDirectionChoice) != ShipDirection.Right);

            return ShipPlacementValidation(shipDirectionChoice);
        }

        public ShipDirection ShipPlacementValidation(string input)
        {
            if (input.StartsWith("d") || input.StartsWith("D"))
            {
                return ShipDirection.Down;
            }
            else if (input.StartsWith("u") || input.StartsWith("U"))
            {
                return ShipDirection.Up;
            }
            else if (input.StartsWith("l") || input.StartsWith("L"))
            {
                return ShipDirection.Left;
            }
            else if (input.StartsWith("r") || input.StartsWith("R"))
            {
                return ShipDirection.Right;
            }
            else
            {
                Console.WriteLine("You do not wish to play correctly? I will choose for you!");
                Console.ReadKey();
            }
            return ShipDirection.Down;
        }

        public void DrawShipsFromBoard(Board board)
        {
            for (int i = 1; i < 10; i++)
            {
                if (i == 1)
                {
                    Console.Write("    1 ");
                }
                Console.Write("  {0} ", 1 + i);
            }
            Console.WriteLine();
            string letters = "ABCDEFGHIJ";
            for (int x = 0; x < 10; x++)
            {
                Console.WriteLine("  -----------------------------------------");
                Console.Write("{0} ", letters[x]);

                for (int y = 0; y < 11; y++)
                {
                    string shipSpot = "X";
                    Coordinate currentCoordinate = new Coordinate(x + 1, y + 1);
                    if (CheckForShip(board, currentCoordinate) == true)
                    {
                        Console.Write("| {0} ", shipSpot);
                    }
                    else
                    {
                        Console.Write("|   ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  -----------------------------------------");
            Console.WriteLine();
        }

        private FireShotResponse FireShot(Board whichBoard)
        {
            DrawBoardWithHitOrMiss(whichBoard);
            Console.WriteLine("Take a shot at victory {0}! Enter a coordinate:", WorkFlow.OtherPlayer.PlayerName);
            FireShotResponse fireShotResponse;
            do
            {
                fireShotResponse = whichBoard.FireShot(CoordinateTranslator.Translate(GetValidInput()));
                Console.Clear();
                DrawBoardWithHitOrMiss(whichBoard);
            } while (DisplayFireShotResponse(fireShotResponse.ShotStatus, fireShotResponse) == false);
            
            Console.ReadKey();
            Console.Clear();

            return fireShotResponse;
        }

        public bool CheckForShip(Board board, Coordinate coordinate)
        {
            foreach (Ship ship in board.Ships)
            {
                if (ship != null)
                {
                    if (ship.BoardPositions.Contains(coordinate))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void DrawBoardWithHitOrMiss(Board board)
        {
            for (int i = 1; i < 10; i++)
            {
                if (i == 1)
                {
                    Console.Write("    1 ");
                }
                Console.Write("  {0} ", 1 + i);
            }
            Console.WriteLine();
            string letters = "ABCDEFGHIJ";
            for (int x = 0; x < 10; x++)
            {
                Console.WriteLine("  -----------------------------------------");
                Console.Write("{0} ", letters[x]);

                for (int y = 0; y < 11; y++)
                {
                    string shipSpot = "H";
                    string shipShot = "M";
                    Coordinate shot = new Coordinate(x + 1, y + 1);
                    if (board.ShotHistory.ContainsKey(shot))
                    {
                        switch (board.ShotHistory[shot])
                        {
                            case ShotHistory.Hit:
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(" {0} ", shipSpot);
                                Console.ResetColor();
                                break;
                            case ShotHistory.Miss:
                                Console.Write("|");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(" {0} ", shipShot);
                                Console.ResetColor();
                                break;
                            case ShotHistory.Unknown:
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.Write("|   ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  -----------------------------------------");
            Console.WriteLine();
        }

        public bool DisplayFireShotResponse(ShotStatus currentShot, FireShotResponse shotResponse)
        {
            if (currentShot == ShotStatus.Invalid)
            {
                Console.WriteLine("Your coordinate is invalid");
                return false;
            }
            else if (currentShot == ShotStatus.Duplicate)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("You have already fired at that coordinate {0} \nplease enter another coordinate:", WorkFlow.OtherPlayer.PlayerName);
                Console.ResetColor();
                return false;
            }
            else if (currentShot == ShotStatus.Miss)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You have missed!");
                Console.ResetColor();
                return true;
            }
            else if (currentShot == ShotStatus.Hit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have landed at hit!!");
                Console.ResetColor();
                return true;
            }
            else if (currentShot == ShotStatus.HitAndSunk)
            {
                Console.WriteLine("You have hit and sunk the {0}!", shotResponse.ShipImpacted);
                return true;
            }
            else if (currentShot == ShotStatus.Victory)
            {
                Console.WriteLine("VICTORY!!!");
                Console.ReadKey();
                StartGame();
            }
            return true;
        }
    }
}
