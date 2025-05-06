using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMonoscript : MonoBehaviour
{
   public Player player;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = new Player();
            player.Name = "antonio";
            player.Score = 22;
            Player.Stampapunteggio(player);
        }
        else
        {
            Debug.Log("Serve un personaggio");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
