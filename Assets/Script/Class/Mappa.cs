using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

public class Mappa
{

    List<Rooms> mappa = new List<Rooms>();

    public void InseriscoStanzaInMappa( Rooms room )
    {

        mappa.Add(room);
        //Debug.Log("� stata aggiunta una nuova stanza: " + room.GetTipo());
        //Debug.Log("la tua mappa � fatta cos� " +  mappa.Count);

    }

    public void MostraMappa()
    {
        for( int i = 0; i < mappa.Count; i++)
        {

         Debug.Log( "La mia stanza � di  Tipo: " + mappa[i].GetTipo() + " ed � la numero " + i); 

        }

    }
}
