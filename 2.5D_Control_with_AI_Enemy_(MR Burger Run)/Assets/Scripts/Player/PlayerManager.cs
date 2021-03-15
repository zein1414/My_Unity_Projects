using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    public TextMeshProUGUI burgerNum;

    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        burgerNum.text = "burger: "+PlayerManager.numberOfCoins.ToString();
        healthBar.value = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().health;
    }
}
