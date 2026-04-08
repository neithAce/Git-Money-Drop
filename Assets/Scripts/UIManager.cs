using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI healthText;

    void Update()
    {
        if (GameManager.instance != null)
        {
            moneyText.text = "Money: " + GameManager.instance.money;
            healthText.text = "HP: " + GameManager.instance.hp;
        }
    }
}
