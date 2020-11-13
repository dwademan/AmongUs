using System;
using System.Text;

namespace AmongUs
{
    class Game
    {
        private PlayerColors _playerColor;
        private Rooms _currentRoom;
        private int _roomNumber;
        private int _roomHeight = 49;
        private int _roomWidth = 49;
        private int x = 3;

        public void StartGame() 
        {
            Console.ResetColor();
            Console.Clear();

            GetPlayerColor();
            Console.SetCursorPosition(2, 2);
            Console.ForegroundColor = (ConsoleColor)_playerColor;
            Console.WriteLine("Start " + _playerColor);
            Console.ResetColor();

            _currentRoom = Rooms.cafeteria;
            GetRoomInfo();

            _currentRoom = Rooms.admin;
            GetRoomInfo();

            DrawRooms();
            //Colors();
            
        }

        public void Colors()
        {
           Console.Clear();

           foreach (PlayerColors color in Enum.GetValues(typeof(PlayerColors)))
           {              
              Console.ForegroundColor = (ConsoleColor)color;
              Console.WriteLine(color);
           }

        }

        public void DrawRooms()
        {            
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetWindowSize(_roomWidth, _roomHeight);
            BuildWall();
        }

        public void BuildWall()
        {            
            for (int i = 0; i < _roomWidth; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;

                // Draw outter boxes
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(0, i);
                Console.Write("#");
                Console.SetCursorPosition(_roomWidth, i);
                Console.Write("#");
                Console.SetCursorPosition(i, _roomHeight);
                Console.Write("#");   

                // Draw inner boxes
                Console.SetCursorPosition(16, i);
                Console.Write("#");
                Console.SetCursorPosition(i, 16);
                Console.Write("#");            
                Console.SetCursorPosition(32, i);
                Console.Write("#");
                Console.SetCursorPosition(i, 32);
                Console.Write("#");                             
            }

            for (int i = 0; i < _roomWidth+1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(i);
                Console.SetCursorPosition(i, 0);
                Console.Write(i);                
            }

            Console.WriteLine("");
        }

        public void GetPlayerColor()
        {
            // Gets random color from list to start
            var max = Enum.GetValues(typeof(PlayerColors)).Length;
            _playerColor = (PlayerColors)new Random().Next(0, max - 1);
        }

        public void GetRoomInfo() 
        {
            Console.WriteLine(" ");
            Console.SetCursorPosition(x, x);
           _roomNumber = (int) _currentRoom;
           Console.WriteLine("You are in " + _currentRoom + ": " + _roomNumber);
           x +=1;
        }
    }

    public enum PlayerColors {
       Blue,
       Cyan,
       Gray,
       Green,
       Magenta,
       Red,
       Yellow
    } 

    public enum Rooms {
       cafeteria,
       weapons,
       navigation,
       shields,
       storage,
       admin,
       electrical,
       lowerengines,
       upperengines
    }
 
}