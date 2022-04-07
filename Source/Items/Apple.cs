using System.Numerics;
using Raylib_cs;


/*==================================================================*/


public class Apple
{
    public Vector2 Item;
    private int limX;
    private int limY;
    private int squareSize;
    private Color appleColor;

/*==================================================================*/
    
    Random rnd = new Random();

    public Apple(int width, int heigth, int square, Color appleColor)
    {
        this.limX       = width / square;
        this.limY       = heigth / square;
        this.squareSize = square;
        this.appleColor = appleColor;

        Item.X = rnd.Next(1, limX);
        Item.Y = rnd.Next(1, limY);
    }

    public void DrawApple()
    {
        Raylib.DrawRectangle((int)Item.X * squareSize, (int)Item.Y * squareSize, squareSize - 1, squareSize - 1, appleColor);
    }

    public void NewApple()
    {       
        Item.X = rnd.Next(1, limX);
        Item.Y = rnd.Next(1, limY);   
    }
}