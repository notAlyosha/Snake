using Raylib_cs;

/*==================================================================*/
/*Определение окна*/

public class Field 
{
    /*Поля окна*/
    private int Width;      //Ширина окна
    private int Heigth;     //Высота окна
    private int squareSize; //Размер квадрата

    private Color gridColor; //Цвет сеточки на поле

/*==================================================================*/

    /*Конструктор класса*/
    public Field(int width, int heigth, int square)
    {
        this.Width = width;
        this.Heigth = heigth;
        this.squareSize = square;
    }

    public Field(int width, int heigth, int square, Color forGrid)
    {
        this.Width = width;
        this.Heigth = heigth;
        this.squareSize = square;
        this.gridColor = forGrid;
    }


    /*Отрисовка сеточки*/
    public void DrawLines()
    {
        
        for(int PosX = 0; PosX < Width; PosX += squareSize)
        {
            Raylib.DrawLine(PosX, 0, PosX, Heigth, Color.DARKGREEN);
            Raylib.DrawLine(0, PosX, Width, PosX, Color.DARKGREEN);   
        }


    }

    public void DrawLines(Color color)
    {
        
        for(int PosX = 0; PosX < Width; PosX += squareSize)
        {
            Raylib.DrawLine(PosX, 0, PosX, Heigth, color);
            Raylib.DrawLine(0, PosX, Width, PosX, color);   
        }


    }



    public void Clear(Color color)
    {
        Raylib.ClearBackground(color);
    }
    
}