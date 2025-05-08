using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario
{

    public List<Pozioni> inventarioPozioni = new List<Pozioni>();
    public List<Armi> inventarioArmi = new List<Armi>();

    Pozioni pozione = new Pozioni();

    public void PrendiPozione(Pozioni pozione)
    {
        inventarioPozioni.Add(pozione);
    }

    //public bool TrovaPozioniCura( out List<Pozioni> pozionisenzaCura)
    //{
    //    var pozioniCura = new List<Pozioni>();

    //    foreach (Pozioni p in inventarioPozioni)
    //    {
    //        if (p.tipo == TIPODIPOZIONI.CURA)
    //        {

    //            pozioniCura.Add(pozione);

    //        }

    //    }

    //    if (pozioniCura.Count != 0)
    //    {
           
    //    }
    //    else
    //    {
    //        return false;
    //    }

       

       
   // }


}
