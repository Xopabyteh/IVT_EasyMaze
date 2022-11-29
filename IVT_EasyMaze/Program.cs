// ReSharper disable CommentTypo
using IVT_EasyMaze;

var consoleHelper = new ConsoleHelper();

//Po každém pohnutí překleslete celou konzoli novou verzí šachovnice. (1 bod)
var drawService = new DrawService();
//Na začátku si budu moct zvolit jak velká šachovnice to bude (včerně různého počtu řádků a sloupců) (3 bod)
int width =  consoleHelper.ReadValuePrompt("Enter width");
int height = consoleHelper.ReadValuePrompt("Enter height");
//Udělejte si 2D-pole jako šachovnici.  (1 body)
var scene = new int[width,height];

//Pamatujte si svoji pozici na šachovnici. (1 body
var playerPos = new Int2(width/2, height/2);
var fpsSleep = TimeSpan.FromSeconds(1d / 30d);
Console.Clear();
Console.CursorVisible = false;

//Použití Console.ReadKey() místo Console.ReadLine() (3 bod)
var inputService = new InputService();
while (true)
{
    for (var x = 0; x < scene.GetLength(0); x++)
    for (var y = 0; y < scene.GetLength(1); y++)
    {
        var tile = scene[x, y];

        //Každé číslo končící na jinou číslici vypište jinou barvou, Takže třeba 11 a 1 budou vypsané stejnou barvou. (2 bod)
        drawService.DrawTile(tile,new Int2(x,y));
    }

    var inputQueue = inputService.ReadQueue();
    var playerMove = new Int2(0,0);
    foreach (var keyInfo in inputQueue)
    {
        switch (keyInfo.Key)
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                playerMove = new Int2(0, -1);
                break;
            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                playerMove = new Int2(0, 1);
                break;
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                playerMove = new Int2(-1, 0);
                break;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                playerMove = new Int2(1, 0);
                break;
        }
    }

    var nextPlayerPos = playerPos + playerMove;

    //Ošetřete, aby nebylo možné vypadnout z šachovnice (aby program nespadl). (3 body)
    if (playerPos != nextPlayerPos &&
        nextPlayerPos.X >= 0 && nextPlayerPos.X < width &&
        nextPlayerPos.Y >= 0 && nextPlayerPos.Y < height)
    {
        playerPos = nextPlayerPos;
        scene[playerPos.X, playerPos.Y]++;
    }

    //Pozice na šachovnici bude znázorněna změnou pozadí (2 bod)
    //Když se někam pohnete, tak se k danému políčku přičte 1. (2 body)
    drawService.DrawPlayer(scene[playerPos.X,playerPos.Y],playerPos);
    Thread.Sleep(fpsSleep);
}
