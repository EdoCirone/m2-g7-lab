using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsercizioDiCarlo

{
    int salute = 20;

   public int GetSalute()
    {
        return salute;
    }

   public void SetSalute()
    {
        salute += 20;

        Debug.Log("stampa salute" +  salute);
    }

}
