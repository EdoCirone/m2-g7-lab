using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario
{

   // public OGGETTIINVENTARIO pozionecura = OGGETTIINVENTARIO.POZIONECURA;
    
    public OGGETTIINVENTARIO[] inventario ;
    public Rooms room = new Rooms();
    public int numeropozionecura = 0;

    public Player player;

    public bool HoLaPozione()
    {
        if ( numeropozionecura != 0)
        {
            return true;
        }

        return false;

    }

}
