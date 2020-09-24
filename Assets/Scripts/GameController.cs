using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int Life = 3;

    public static void DecreaseLife()
    {
        Life--;
        Debug.Log(Life);
    }
}