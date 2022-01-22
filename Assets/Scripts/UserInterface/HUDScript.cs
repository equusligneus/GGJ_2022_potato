using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class HUDScript : MonoBehaviour
{
    public RuntimeInt potatoCountRef;
    private Label potatoLabel;

    // Start is called before the first frame update
    void Start()
    {
        var doc = GetComponent<UIDocument>();

        potatoLabel = doc.rootVisualElement.Q<Label>("txt_potatoes");
		if (potatoCountRef)
		{
			potatoCountRef.OnValueChanged += PotatoCountRef_OnValueChanged;
            PotatoCountRef_OnValueChanged(potatoCountRef.Value);
		}
    }

	private void OnDestroy()
	{
		if (potatoCountRef)
			potatoCountRef.OnValueChanged -= PotatoCountRef_OnValueChanged;
	}

	private void PotatoCountRef_OnValueChanged(int _value)
	{
        if (potatoLabel != default)
            potatoLabel.text = "" + potatoCountRef.Value;
	}
}
