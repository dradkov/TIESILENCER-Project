namespace TheTieSilincer.Core.Managers
{
    using System;
    using TheTieSilincer.EventArguments;
    using TheTieSilincer.Interfaces;
    using TheTieSilincer.Models;
    using TheTieSilincer.Support;

    public class PlayerManager : IPlayerManager
    {
        public event PlayerPositionChangeEventHandler SendPlayerPosition;

        public Player Player { get; private set; }
        private Position[] directions;
        private Position nextDirection;
        private ConsoleKeyInfo userDirection;
        private int movement;
        private bool shooting;
        private int currentWeapon = 0;
        private int score;

        public int Score
        {
            get
            {
                return this.score;
            }
            private set
            {
                this.score = value;
            }
        }
       

        public PlayerManager()
        {
            this.score = 0;

            this.AddDirections();
        }

        private void AddDirections()
        {
            directions = new Position[]
           {
               new Position(0,1), // moving right
                new Position( 0,-1), // moving left
                new Position( 1,0), // moving down
                new Position(-1,0), // moving up
           };
        }

        public void UpdateScore(object sender, NewDestroyShipEventArgs args)
        {
            this.score += args.Points;
        }

        private void OnPositionChange(PlayerPositionChangeEventArgs args)
        {
            SendPlayerPosition?.Invoke(this, args);
        }

        public void OnBulletCollision(object sender, ShipCollisionEventArgs args)
        {
            if (args.Ship.ShipType == this.Player.Ship.ShipType)
            {
                this.Player.Ship.Armor-=100;

                if (this.Player.Ship.Armor < 0)
                {

                    Console.WriteLine("game Over!");

                    Console.WriteLine(this.score);

                    GameService.SaveResultToDb(this.Score);

                    Environment.Exit(0);
                }
            }
        }

        public void CreatePlayer(IShip ship)
        {
            this.Player = new Player(ship);
        }

        public void Update()
        {
            this.ReadPlayerInput();
            this.Player.Ship.NextDirection = nextDirection;
            this.Player.Ship.Update();
            this.OnPositionChange(new PlayerPositionChangeEventArgs(this.Player.Ship.Position));
        }

        public void Draw()
        {
            this.Player.Ship.Draw();

            this.DrawScore();
        }

        public void DrawScore()
        {
            Console.SetCursorPosition(Console.WindowWidth - 6, 0);
            Console.Write("Health");
            Console.SetCursorPosition(Console.WindowWidth - 6, 1);
            Console.Write(this.Player.Ship.Armor);



            Console.SetCursorPosition(Console.WindowWidth - 6, 2);
            Console.Write("Score");
            Console.SetCursorPosition(Console.WindowWidth - 6, 3);
            Console.Write(this.score);



        }

        public void Clear()
        {
            this.Player.Ship.Clear();
        }

        private void ReadPlayerInput()
        {
            shooting = false;

            while (Console.KeyAvailable)
            {
                userDirection = Console.ReadKey(true);

                if (userDirection.Key == ConsoleKey.RightArrow)
                {
                    movement = 0;
                }
                else if (userDirection.Key == ConsoleKey.LeftArrow)
                {
                    movement = 1;
                }
                else if (userDirection.Key == ConsoleKey.DownArrow)
                {
                    movement = 2;
                }
                else if (userDirection.Key == ConsoleKey.UpArrow)
                {
                    movement = 3;
                }
                if (userDirection.Key == ConsoleKey.Spacebar)
                {
                    shooting = true;
                }
                if (userDirection.Key == ConsoleKey.V)
                {
                    currentWeapon = currentWeapon == 0 ? currentWeapon = 1 : currentWeapon = 0;
                }

                nextDirection = directions[movement];
            }

            if (shooting)
            {
                var currWeapon = this.Player.Ship.Weapons[currentWeapon];

                currWeapon.AddBullets(
                    new Position(this.Player.Ship.Position.X + 2,
                    this.Player.Ship.Position.Y + 1));

                currWeapon.AddBullets(
                    new Position(this.Player.Ship.Position.X + 2,
                   this.Player.Ship.Position.Y + 7));
            }
        }
    }
}