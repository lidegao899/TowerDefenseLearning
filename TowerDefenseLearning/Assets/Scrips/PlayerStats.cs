using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;

    public int startMoney = 400;

    public static int Lives;
    public int startLives = 0;

    public static int Rounds = 0;

    // Start is called before the first frame update
    private void Start()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }
}