using TMPro;
using UnityEngine;

public class EconomyManager : Singleton<EconomyManager>
{
    private TMP_Text tMP_Text;
    private int currentGold = 0;
    const string COIN_AMOUNT_TEXT = "Gold Amount Text";

    public void UpdateCurrentGold()
    {
        currentGold += 1;
        if (tMP_Text == null)
        {
            tMP_Text = GameObject.Find(COIN_AMOUNT_TEXT).GetComponent<TMP_Text>();
        }
        tMP_Text.text = currentGold.ToString("D3");
    }
}
