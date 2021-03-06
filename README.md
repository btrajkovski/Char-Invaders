Char Invaders
==========



##Опис на играта
----

###Цел на играта
При стартување на играта се дадени три топови и почнуваат да паѓаат метеори во кои се содржи буква. Целта во играта е да се уништат метеорите пред тие да можат да срушат еден од топовите. Уништувањето на метеорите се врши со кликнување на соодветната буква од тастатура. 

Како се зголемува нивото на играта така и метеорите паѓаат побргу и почесто се појавуваат. Поените кои се добиваат зависат од нивото на играта, исто така за погрешно внесена буква се одземаат x3 од поените кои се добиваат за погодок.

![Gameplay screenshot](http://i.imgur.com/5ksu91m.png)


### Кратко упатство

####Контроли и објаснувања
> A-Z - уништување на метеори

> Space - паузирање на играта(играта автоматски се паузира кога не е во фокус)

Во играта постојат три типа на бонус кои се разликуваат по бојата
> **Slower** - кога ке се погоди ова комета сите комети се движат поспоро во времетраење од 5 секунди

> **5x Bonus** - ова комета дава пет пати повеќе поени во споредба со нормалните

> **Destroyer** - кога ке се погоди ова комета ги уништува сите комети кои се видливи на екранот


При стартување на играта се појавува мени со неколку опции:

![Screenshot start](http://i.imgur.com/omFytzM.png)

Играта се стартува со клик на копчето`Play`. 

Можеме да ја видиме листата на играчи со најмногу поени преку клик на `Score`.

Преку делот `Settings` може да се подесува јачината на звукот во играта и музиката која оди во позадина

Во делот `How To Play` е дадено кратко упатство на англиски јазик за тоа како се игра играта и во делот `Credits` се сите кои учествувале во изработка на играта. Преку клик на `Exit` се исклучува играта.

![Screenshot settings](http://i.imgur.com/jt6N6x5.png)

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
public List<Cannon> Cannons { get; set; }
```

###Cannon
Преку оваа класа се направени топовите, оваа класа користи `DrawImage` за нивни исцртување.

###GameLevel
Во ова класа се одредува брзината со која ќе паѓаат буквите и на колку време ќе се појавуваат. Од ова класа се менува нивото на играта преку повикување на методот `levelUp`

###SoundCollection
Сите звуци во играта се сместени во оваа класа. Звуците се направени со помош на класата `WMPLib` со цел да може да се менува јачината и да може да има повеќе од еден звук кој ќе е пуштен истовремено.

###Explosion
Анимацијата за експлозијата е направена преку ова класа. Во ова класа се наоѓаат повеќе слики и преку нивно менување е добиена анимацијата. 

###GameBackground
Во оваа класа се чуваат сите позадини кои се користат во играта и се менуваат со повикување на методот `NextImage` од оваа класа, исто така со менување на поздината се менуваат и боите на лабелите кои исто така се чуваат во овааа класа. 

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

![Screenshot High Score](http://i.imgur.com/QOVR3Vg.png)

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

![Screenshot credits](http://i.imgur.com/3DLpY26.png)
