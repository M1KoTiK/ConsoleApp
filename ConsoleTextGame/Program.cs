using ConsoleTextGame;
using ConsoleTextGame.Converters;

var gm = new GameMenu("Выберите вариант",new List<GameMenuItem>()
{
    new GameMenuItem("1","Выбор1",()=>{ }),
    new GameMenuItem("2","Выбор2",()=>{ })
});

gm.ElementAction.Invoke();

