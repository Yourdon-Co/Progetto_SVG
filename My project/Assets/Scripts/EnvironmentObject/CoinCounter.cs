using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    //mettere privata quando si implementa UI il public serve per vedere se raccoglie veramente
    //poichè compare su unity
    public int numberCoin=0;

    public void addCoin()
    {
        numberCoin++;
    }


}
