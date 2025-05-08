using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesoro
{
    OGGETTIINVENTARIO oggettotesoro;
    int numerooggetti;
    
    Inventario inventario;
    public void SetTesoro()
    {

        oggettotesoro = (OGGETTIINVENTARIO) Random.Range(0, 1);
        numerooggetti = Random.Range(0, 2);

        if (oggettotesoro == OGGETTIINVENTARIO.MONETE)
        {

            numerooggetti = numerooggetti * 100;

        }

        Debug.Log("Hai trovato un tesoro con dentro " + numerooggetti + " " + oggettotesoro);  

    }
}
