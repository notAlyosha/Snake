using System.Numerics;
using Raylib_cs;

/*Snake Definition*/

/*==================================================================*/


enum Direction
{
    Up,
    Down,
    Right,
    Left
}

/*==================================================================*/

public class Snake
{   private int squareSize;
    private int limX;
    private int limY;
    private Color headColor;
    private Color taleColor;

    public int Length = 2;
    public Vector2[] head;


    private Direction dir = Direction.Down;

/*==================================================================*/

    public Snake(int width, int heigth, int square, Color headColor, Color taleColor)
    {
        this.limX = width / square;
        this.limY = width / square;
        
        this.squareSize = square;

        this.headColor = headColor;
        this.taleColor = taleColor;

        head = new Vector2[(width / squareSize ) * (heigth / squareSize)];
        head[0].X = 2;
        head[0].Y = 2;
    }

    private void OutOfBounds()
    {
        if(head[0].X < 0)      { head[0].X = limX; return; }
        if(head[0].X >= limX)   { head[0].X = 0; return; }
        
        if(head[0].Y < 0)      { head[0].Y = limY; return; }
        if(head[0].Y >= limY)   { head[0].Y = 0; return; }
        
    }

    public bool SnakeEatHisSelf()
    {
        for(int counter = 1; counter <= Length; counter += 1)
        {
            if((int)head[0].X == (int)head[counter].X && (int)head[0].Y == (int)head[counter].Y) { return true; }
        }
        return false;
    }
    public void DrawAll()
    {
        for(int counter = 1; counter  < Length; counter += 1)
        {
            Raylib.DrawRectangle((int)head[counter].X * squareSize, (int)head[counter].Y * squareSize, squareSize - 1, squareSize - 1, taleColor);

        }
        Raylib.DrawRectangle((int)head[0].X * squareSize, (int)head[0].Y * squareSize, squareSize - 1, squareSize - 1, headColor);

    }

    public void ChangeDirection()
    {
        if(Raylib.GetKeyPressed == null) { return; }

        if(Raylib.IsKeyPressed(KeyboardKey.KEY_UP) && dir != Direction.Down)     { dir = Direction.Up;    return;    }
        if(Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN) && dir != Direction.Up )    { dir = Direction.Down;  return;    }
        if(Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT) && dir != Direction.Right ) { dir = Direction.Left;  return;    }
        if(Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT) && dir != Direction.Left ) { dir = Direction.Right; return;    }

    }

    /*Эта функция должна переместить все елементы змейки на их новую позицию*/
    /*Второй элемент становится на место первого, третий на место второго и т.д до последнего*/
    private void ChangeSnakeElementsPosition()
    {
        for(int counter = Length;  counter > 0; counter -= 1)
        {
            head[counter].X = head[counter - 1].X;
            head[counter].Y = head[counter - 1].Y;
        }
    }

    public void HeadDir()
    {
        OutOfBounds();
        ChangeSnakeElementsPosition();

        if(dir == Direction.Up)     {head[0].Y -= 1; return; }
        if(dir == Direction.Down)   {head[0].Y += 1; return; }
        if(dir == Direction.Left)   {head[0].X -= 1; return; }
        if(dir == Direction.Right)  {head[0].X += 1; return; }
    

    }    
    
    public bool snakeCrushedIntoWall(Vector2[] pos)
    {
        for(int counter = 0; counter < pos.Length; counter = counter + 1)
        {
            if(head[0].X == pos[counter].X && head[0].Y == pos[counter].Y) { return true; }
        }
        return false;

    }

    public bool SnakeIncrement(Vector2 pos)
    {
        if(pos.X == head[0].X && pos.Y == head[0].Y) { Length += 1; return true; }
        return false;
    }

    public bool SnakeDecrement(Vector2 pos)
    {
        if(pos.X == head[0].X && pos.Y == head[0].Y) { Length -= 1; return true; }

        return false;
    }

    
}