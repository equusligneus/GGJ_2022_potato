using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class PostGameStateWatcher : MonoBehaviour
{
    public RuntimeGameState gameStateRef;

	[TextArea(2, 5)]
	public string winning;

	[TextArea(2, 5)]
	public string losing;

	// Start is called before the first frame update
	void Start()
    {
		var label = GetComponent<UIDocument>().rootVisualElement.Q<Label>("txt_postgame");

		if(gameStateRef && label != default)
		{
			switch (gameStateRef.Value)
			{
				case GameState.Invalid:
				case GameState.Running:
					break;
				case GameState.Winning:
					label.text = winning;
					break;
				case GameState.MainMenu:
				case GameState.Quitting:
					label.text = losing;
					break;
				default:
					break;
			}
		}
		StartCoroutine(SwitchRoutine(gameStateRef.Value));
    }

	private IEnumerator SwitchRoutine(GameState _gameState)
	{
		yield return new WaitForSeconds(10f);

		switch (_gameState)
		{
			case GameState.Invalid:
			case GameState.Running:
			case GameState.Winning:
			case GameState.MainMenu:
				SceneManager.LoadScene(0);
				break;
			case GameState.Quitting:
#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
				break;
			default:
				break;
		}
	}
}
