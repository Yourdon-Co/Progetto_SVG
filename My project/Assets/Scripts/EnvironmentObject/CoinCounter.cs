using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    //mettere privata quando si implementa UI il public serve per vedere se raccoglie veramente
    //poichè compare su unity
    public int numberCoin = 0;
    [SerializeField]
    private TextMeshProUGUI coinText;

    public void addCoin()
    {
        numberCoin++;

    }

    public void DisplayCoin()
    {
        coinText.text = "Coins: " + numberCoin.ToString();
    }


}
