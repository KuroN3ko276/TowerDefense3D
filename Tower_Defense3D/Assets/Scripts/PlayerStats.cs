using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
    }

}