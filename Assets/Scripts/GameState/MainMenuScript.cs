using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class MainMenuScript : MonoBehaviour
{
    public InputActionAsset inputs;
    private UIDocument document;
    // Start is called before the first frame update
    void Start()
    {
        if (inputs)
            inputs.Enable();

        document = GetComponent<UIDocument>();
        var start = document.rootVisualElement.Q<Button>("btn_start");
        if(start != default)
			start.clicked += Start_clicked;

        var quit = document.rootVisualElement.Q<Button>("btn_quit");
        if(quit != default)
			quit.clicked += Quit_clicked;
    }

	private void Quit_clicked()
	{
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
	}

	private void Start_clicked()
	{
        SceneManager.LoadScene(1);
	}
}
