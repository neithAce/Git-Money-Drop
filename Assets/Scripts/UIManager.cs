using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI difficultyText;

    void Update()
    {
        if (GameManager.instance != null)
        {
            moneyText.text = "" +  GameManager.instance.money;
            healthText.text = "" + GameManager.instance.hp;
            difficultyText.text = "Difficulty x" + GameManager.instance.speedLevel;
        }
    }
}
