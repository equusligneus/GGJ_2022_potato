using UnityEngine;

public class GameStartScript : MonoBehaviour
{
    public RuntimeLevel levelRef;
    public RuntimeGameState gameStateRef;
    public Level startLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (levelRef)
            levelRef.SetValue(startLevel);

        if (gameStateRef)
            gameStateRef.SetValue(GameState.Running);
    }
}
