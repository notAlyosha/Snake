using Raylib_cs;    

public class Game
{
/* All game constants */
/*==================================================================*/
    private  int Width = 600;
    private  int Heigth = 600;
    private  int squareSize = 20;
    private  int speedOfSnake = 110;
    private  bool gameOver = false;

/*==================================================================*/

    

    public Game()
    {
        Raylib.InitWindow(Width, Heigth, "Snake!");

    }
    
    public Game(int width, int heigth, int square, int speedOfSnake)
    {
        this.Width = width;
        this.Heigth = heigth;
        this.squareSize = square;
        this.speedOfSnake = speedOfSnake;
        Raylib.InitWindow(Width, Heigth, "Snake!");
    
    }

    public void GameCycle()
    {
        Field game          = new Field(Width, Heigth, squareSize);
        
        Snake head          = new Snake(Width, Heigth, squareSize, Color.DARKBLUE, Color.BLUE);

        Apple healthApple   = new Apple(Width, Heigth, squareSize, Color.RED);

        Apple poisonedApple = new Apple(Width, Heigth, squareSize, Color.YELLOW);

        Wall wall           = new Wall(Width, Heigth, squareSize, Color.DARKGRAY);


        Raylib.InitAudioDevice();
        Raylib_cs.Music mus = Raylib.LoadMusicStream("AudioData/Music/MainTheme.mp3");


        Raylib.PlayMusicStream(mus);

        Raylib.SetTargetFPS(25);


        while(!gameOver && !Raylib.WindowShouldClose())
        {
            Raylib.UpdateMusicStream(mus); 
            Raylib.PlayMusicStream(mus);
            //Draw all content
            Raylib.BeginDrawing();

            game.Clear(Color.WHITE);

            game.DrawLines();

            wall.DrawWall();

            head.HeadDir();
            head.ChangeDirection();
            head.DrawAll();


            healthApple.DrawApple();
            poisonedApple.DrawApple();

            Raylib.EndDrawing();

            

            if(head.SnakeIncrement(healthApple.Item) == true)   { healthApple.NewApple(); }
            
            if(head.SnakeDecrement(poisonedApple.Item) == true) { poisonedApple.NewApple(); }




            gameOver = head.SnakeEatHisSelf() || head.snakeCrushedIntoWall(wall.wall);


        }

        Raylib.CloseWindow();
        Raylib.CloseAudioDevice();
    }   

}