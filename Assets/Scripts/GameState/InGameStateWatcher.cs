using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameStateWatcher : MonoBehaviour
{
    public RuntimeGameState gameStateRef;

    // Start is called before the first frame update
    void Start()
    {
        if(gameStateRef)
			gameStateRef.OnValueChanged += GameStateRef_OnValueChanged;
    }

	private void OnDestroy()
	{
		if (gameStateRef)
			gameStateRef.OnValueChanged -= GameStateRef_OnValueChanged;
	}

	private void GameStateRef_OnValueChanged(GameState _value)
	{
		if (!gameStateRef)
			return;

		var val = gameStateRef.Value;
		switch (val)
		{
			case GameState.Invalid:
			case GameState.Running:
				break;
			case GameState.Winning:
			case GameState.MainMenu:
			case GameState.Quitting:
				SceneManager.LoadScene(2);
				break;
			default:
				break;
		}
	}
}
