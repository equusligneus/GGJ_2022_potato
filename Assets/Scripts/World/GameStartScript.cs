using UnityEngine;

public class GameStartScript : MonoBehaviour
{
    public RuntimeLevel levelRef;
    public Level startLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (levelRef)
            levelRef.SetValue(startLevel);
    }
}
