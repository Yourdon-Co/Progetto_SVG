using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour

{
    public GameObject shield;
    
    // Start is called before the first frame update

    public void ActiveShield()
    {
        shield.SetActive(true);
    }
}
