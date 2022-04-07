using System.Numerics;
using Raylib_cs;

public class Wall
{
    public Vector2[] wall;
    private int width;
    private int heigth;
    private int squareSize;
    private Color wallColor;

    public Wall(int Width, int Heigth, int squareSize, Color wallColor)
    {
        this.width      = Width;
        this.heigth     = Heigth;
        this.squareSize = squareSize;
        this.wallColor  = wallColor;

        wall            = new Vector2[6];


        wall[0].X = 3;
        wall[0].Y = 3;
        wall[1].X = 3;
        wall[1].Y = 4;
        wall[2].X = 4;
        wall[2].Y = 3;

        wall[3].X = 30 - 4;
        wall[3].Y = 30 - 4;
        wall[4].X = 30 - 4;
        wall[4].Y = 30 - 5;
        wall[5].X = 30 - 5;
        wall[5].Y = 30 - 4;
    }

    public void DrawWall()
    {
        for(int x = 0; x < wall.Length; x += 1)
        {
            Raylib.DrawRectangle((int)wall[x].X * squareSize, (int)wall[x].Y * squareSize, squareSize - 1, squareSize - 1, wallColor);
        }      
    }




}