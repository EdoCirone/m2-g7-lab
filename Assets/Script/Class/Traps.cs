using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps
{
    private int punteggiotrappola;
    private int dannotrappola;
    private ELEMENTI elementotrappola;

    Player player;

    public void SetTrap()
    {

        punteggiotrappola = Random.Range(4, 10);
        elementotrappola = (ELEMENTI)Random.Range(0, 4);


        if (punteggiotrappola < 6)
        {
            Debug.Log("Trappola facile");
            dannotrappola = 1;
        }

        else if (punteggiotrappola > 8)
        {
            Debug.Log("Trappola difficile");
            dannotrappola = 3;

        }
        else
        {
            Debug.Log("Trappola media");
            dannotrappola = 2;

        }
    }

    public int Getdannotrappola()
    {
        return dannotrappola;
    }

    public int Getpunteggiotrappola()
    {
        return punteggiotrappola;
    }
}