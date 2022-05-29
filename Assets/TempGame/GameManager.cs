using TempGame;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameContext context;

    private void Awake()
    {
        context = new GameContext();
    }
}
