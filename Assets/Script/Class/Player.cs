using UnityEngine;

public class Player
{


    public string Name;
    public int Score;
    
   public static void Stampapunteggio( Player p)
    {
        Debug.Log( " il mio nome � "+  p.Name + "e il punteggio � "+ p.Score);
    }
    
 
}
