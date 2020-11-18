using System;
using System.Text;

namespace AmongUs
{
    class Game
    {
        private PlayerColors _playerColor;
        private Rooms _currentRoom;
        private int _roomNumber;
        private int _roomBlockSize = 12;
        private int _roomSize;
        private int _roomColumn1;
        private int _roomColumn2;
        private int _statusBlock;

        public void StartGame() 
        {
            Console.ResetColor();
            Console.Clear();
            DrawRooms();

            GetPlayerColor();
            DisplayPlayerStatus();
            ShowPlayerColors();

            _currentRoom = Rooms.cafeteria;
            //_currentRoom = Rooms.upperengines;
            GetRoomInfo();
            
        }

        public void DisplayPlayerStatus()
        {
            Console.SetCursorPosition(_statusBlock+2, 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Player Color: ");
            Console.ForegroundColor = (ConsoleColor)_playerColor;
            Console.Write(" " + _playerColor);
        }

        public void ShowPlayerColors()
        {
           int x = 0; 
           foreach (PlayerColors color in Enum.GetValues(typeof(PlayerColors)))
           {
               Console.SetCursorPosition(_statusBlock+2, 5+x);               
               Console.ForegroundColor = (ConsoleColor)color;
               Console.WriteLine(color);
               x += 1;
           }
        }

        public void DrawRooms()
        {
            Console.Clear();            
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            _roomSize = (_roomBlockSize * 3) + 4;
            _roomColumn1 = ((_roomSize-4)/3) + 2;
            _roomColumn2 = (_roomColumn1*2) - 1;
            Console.SetWindowSize(_roomColumn1, _roomColumn2);
            BuildWall();
        }

        public void BuildWall()
        {            
            for (int i = 1; i < _roomSize+1; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                // Draw outter boxes
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(_roomSize, i);
                Console.Write("#");
                Console.SetCursorPosition(i, _roomSize);
                Console.Write("#");   

                // Draw inner boxes
                Console.SetCursorPosition(_roomColumn1, i);
                Console.Write("#");
                Console.SetCursorPosition(i, _roomColumn1);
                Console.Write("#");            
                Console.SetCursorPosition(_roomColumn2, i);
                Console.Write("#");
                Console.SetCursorPosition(i, _roomColumn2);
                Console.Write("#");                             
            }
  
            Console.WriteLine("");
            BuildStatusBlock();
        }

        public void BuildStatusBlock()
        {            
           // Draw status block top and bottom border
           _statusBlock = _roomSize + 10;
           Console.ForegroundColor = ConsoleColor.White;
           Console.BackgroundColor = ConsoleColor.Black;

           for (int i = 1; i < _statusBlock+1; i++)
           {
               Console.SetCursorPosition(i+_statusBlock, 1);
               Console.Write("#");
               Console.SetCursorPosition(i+_statusBlock, 12);
               Console.Write("#");
           }
        
           // Draw status block left and right border
           for (int i = 1; i < 13; i++)
           {
               Console.SetCursorPosition(_statusBlock, i);
               Console.Write("#");
               Console.SetCursorPosition(_statusBlock*2, i);
               Console.Write("#");
           }
           
        }

        public void GetPlayerColor()
        {
            // Gets random color from list to start
            var max = Enum.GetValues(typeof(PlayerColors)).Length;
            _playerColor = (PlayerColors)new Random().Next(0, max - 1);
        }

        public void GetRoomInfo() 
        {
            Console.SetCursorPosition(_statusBlock+2, 4);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
           _roomNumber = (int) _currentRoom;
           Console.WriteLine("Current Room: " + _currentRoom + " " + _roomNumber);
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
       upperengines,
       cafeteria,
       weapons,
       lowerengines,
       admin,
       navigation,
       electrical,
       storage,
       shields
    }
 
}