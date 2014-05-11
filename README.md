Char Invaders
==========

> <b>TODO list</b>

> * [ ] Powerup - shoot all
> * [ ] Powerup - x3 points
> * [x] Powerup - slowdown
> * [ ] Change sound effects
> * [ ] Add nice icon
> * [ ] Add kind of a boss ?
> * [x] Refactor rest of the code
> * [x] Change visual appearnce of in-game buttons
> * [x] Add HowTo play?
> * [x] Try to optimize the game???
> * [x] Add Documentation
> * [x] Test and change game level logic 
> * [x] Replace labels with graphics - Enemies.cs
> * [x] Refactor menu code
> * [x] Change visual apperance of menus

Опис на играта
------------
- - -
###Цел на играта
При стартување на играта се дадени три кули и почнуваат да паѓаат метеори во кои се содржи буква. Целта во играта е да се уништат метеорите пред тие да можат да срушат една од кулите. Уништувањето на метеорите се врши со кликнување на соодветната буква од тастатура. 

Како се зголемува нивото на играта така и метеорите паѓаат побргу и почесто се појавуваат. Поените кои се добиваат зависат од нивото на играта, исто така за погрешно внесена буква се одземаат x3 од поените кои се добиваат за погодок.

[`Screenshot ingame`]


### Кратко упатство
При стартување на играта се појавува мени со неколку опции:

`[Screenshot start]`

Играта се стартува со клик на копчето`Play`. 

Можеме да ја видиме листата на играчи со најмногу поени преку клик на `High Score`.

Во главната форма се наоѓаат две копчиња за подесување на звукот во играта и музиката во главната форма.

Во делот `How To Play` е дадено кратко упатство на англиски јазик за тоа како се игра играта и во делот `Credits` се сите кои учествувале во изработка на играта. Преку клик на `Exit` се исклучува играта.

`[Screenshot settings]`

Решение на проблемот
------------
##Механика на играта
Главната механика на играта е поделена во неколку класи:

###Enemy
Преку ова класа е претставен метеорот, за исцртување се користени функциите `DrawImage` и `DrawString`, искористен е и посебен метод за движење. За да нема трепкање формата за играта користи `DoubleBuffer`

###Game
Во ова класа е сместена целата логика на играта. Искористени се неколку тајмер контроли за движење на буквите, нивно појавување и цртање на ласерот од кулата до метеорот. Ова класа има референца од `FormGame` преку која се прикажуваат промените на екранот. Метеорите и кулите се чуваат во листи

```
public List<Enemy> Enemies { get; set; }
public List<Char> CharPool { get; set; }
```

###Canon
Бидејќи кулите се статични, за нивна репрезентација е искористен `ImageView`, при што позадината им е транспарентна.

###GameLevel
Во ова класа се одредува брзината со која ќе паѓаат буквите и на колку време ќе се појавуваат. Од ова класа се менува нивото на играта преку повикување на методот `levelUp`

###SoundCollection
Во ова класа се сместени сите звуци во играта и се користат преку повикување на ова класа

##Зачувување на податоци
Играта ги чува највисоките резултати преку **серијализација**. Резултaтот се чуваат во класата `ScoreItem`, а во класата `HighScores` се наоѓа листа од резултати. Датотеката со резултати е зачувана во фолдерот `%AppData%` со име `HighScoresCharInvaders.hs` и е со атрибут *hidden* 
Запишување во ова датотека се вржи по секој резултат кој влегува во топ 5 листата преку следниот метод

```
private static void BinarySerializeScores(HighScores HS)
{
    string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
	
	using (FileStream str = File.Open(path + "\\HighScoresCharInvaders.hs", FileMode.OpenOrCreate))
	{
		File.SetAttributes(path + "\\HighScoresCharInvaders.hs", File.GetAttributes(path + "\\HighScoresCharInvaders.hs") | FileAttributes.Hidden);
		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(str, HS);
	}
}
```
Читањето се врши при стартување на играта при што се користат неколку try-catch блокови со цел да се избегне паѓање на играта во делот со читање на податоци
```
private static HighScores BinaryDeserializeScores()
{
    string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
	HighScores HS = null;
	try
	{

		using (FileStream str = File.OpenRead(path + "\\HighScoresCharInvaders.hs"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			try
			{
				HS = (HighScores)bf.Deserialize(str);
			}
			catch (Exception)
			{
				return new HighScores();
			}
		}

		return HS;
	}
	catch (FileNotFoundException)
	{
		return new HighScores();
	}

}
```

[`Screenshot High Score`]

##Мени
Останатите делови од менито се имплементирани во посебни форми при што сите чуваат референца од главното мени со цел да можат да се вратат назад. Се отваараат и затвараат со користење на методи `Hide()` и `Show()`

##Имплементација на дел од функции
Во играта постои функција која опрделува на која позиција ќе се појави новата буква, таа се користи со цел да не се поклопат две букви и бара позиција каде нема да има поклопување се користи и помошна функција која за дадени координати одредува дали е валидна позиција
```
private int findValidSpawn()
{
    int left = 0;
	bool found = false;
	int count = 0;
	while (!found && count < 20)
	{
		left = Random.Next((int)(TheForm.Width * 0.05), (int)(TheForm.Width * 0.9));
		found = true;
		foreach (Enemy enemy in Enemies)
		{
			if (checkInvalidSpawn(left, enemy))
			{
				found = false;
			}
		}
		count++;
	}
	return left;
}
```
При рушење на кулата се избира кула која е најблиску до буквата преку следната функција
```
private Canon ClosestCannon(Enemy enemy)
{
    int min = int.MaxValue;
    Canon minCannon = null;
    foreach (Canon cannon in Cannons)
    {
        if (Math.Abs(cannon.Left - enemy.Left) < min)
        {
            min = Math.Abs(cannon.Left - enemy.Left);
            minCannon = cannon;
        }
    }
    return minCannon;
}
```

`[Screenshot ingame Retro Theme]`
