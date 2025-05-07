using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player
{


    public string Name;
    public int experience;
    public int agility = 5;

    private int attack = 5;
    private bool morto;
    private int precision = 1;
    public int livello;
    public int vita = 100;

    public ACTION action = new ACTION();
    public MOVIMENTO movimento = new MOVIMENTO();

    public bool incombattimento;

    public bool CheckMorte()
    {
        if ( vita == 0 )
        { return true; }
        else if ( vita < 0 )
        {
            vita = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetPrecision()
    {
        return precision;
    }

    public int GetVita()
    {
        return vita;
    }

    public int GetAttack()
    {
        return attack;
    }



    public void IncrementaLivello()
    {
        if (experience > 100)
        {
            livello++;
            attack += 1;
            precision += 1;
            agility += 1;
            experience = 0;
            Debug.Log("Complimenti" + Name + "sei salito di livello! ore sei livello " + livello);
        }

    }



}
/* ESERCIZIO 3 public class Player
{


    public string Name;
    private int Score;

    public int GetPunteggio(Player p)
    {
        return p.Score;
    }

    public void SetPunteggio(Player player, int score)
    {
        if (score < 0)
    {

        score = 0;

    }
        player.Score = score;
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
}



public class Player ESERCIZIO 2
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
