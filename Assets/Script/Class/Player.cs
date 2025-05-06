using UnityEngine;

public class Player
{


    public string Name;
    private int Score;

    public int GetPunteggio(Player p)
    {
        return p.Score;
    }

    public void SetPunteggio(Player player, int score)
    {
        player.Score = score;
        if (score < 0) score = 0;
    }

    public static int Incrementapunteggio(Player p)
    {

        p.Score = p.Score + 10;
        return p.Score;
    }

    public static void Stampapunteggio(Player p)
    {
        Debug.Log(" il mio nome è " + p.Name + " e il punteggio è " + p.Score);
    }




/*public class Player ESERCIZIO 2
{


    public string Name;
    public int Score;
    
    public static int Incrementapunteggio(Player p)
    {

        p.Score = p.Score + 10;
        return p.Score;
    }

    public static void Stampapunteggio(Player p)
    {
        Debug.Log(" il mio nome è " + p.Name + " e il punteggio è " + p.Score);
    }



}

/*public class Player ESERCIZIO 01
{


    public string Name;
    public int Score;

    public static void Stampapunteggio(Player p)
    {
        Debug.Log(" il mio nome è " + p.Name + " e il punteggio è " + p.Score);
    }



}*/
