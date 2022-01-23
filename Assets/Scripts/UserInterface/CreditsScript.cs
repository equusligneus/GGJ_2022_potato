using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class CreditsScript : MonoBehaviour
{
    public MainMenuScript main;
    private UIDocument document;

    // Start is called before the first frame update
    void Awake()
    {
        document = GetComponent<UIDocument>();
        SetUIActive(false);
    }

	private void OnEnable()
	{
        var backToMain = document.rootVisualElement.Q<Button>("btn_main");
        if (backToMain != default)
            backToMain.clicked += BackToMain_Clicked;
    }

	private void BackToMain_Clicked()
	{
        if (!main)
            return;

        main.SetUIActive(true);
        SetUIActive(false);
	}

    public void SetUIActive(bool _active)
    {
        gameObject.SetActive(_active);
        //document.rootVisualElement.visible = _active;
        //if(_active)
        //    document.rootVisualElement.BringToFront();
    }

}
