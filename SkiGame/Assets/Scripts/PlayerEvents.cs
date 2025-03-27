using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void OnHit(); //delegate type
    public static event OnHit onHitEvent; //type function as an event

    public static void CallOnHitEvent() 
    {
        if (onHitEvent != null)
            onHitEvent();
    }
}
