using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class SignPopUpScript : MonoBehaviour
{
    public RuntimeString currentTextRef;

    private UIDocument doc;
    private Label label;

    // Start is called before the first frame update
    void Start()
    {
        doc = GetComponent<UIDocument>();
        label = doc.rootVisualElement.Q<Label>("txt_sign");

        if (currentTextRef)
        {
            currentTextRef.OnValueChanged += CurrentTextRef_OnValueChanged;
            CurrentTextRef_OnValueChanged(currentTextRef.Value);
        }
        else
            SetUIEnabled(false);
    }

	private void CurrentTextRef_OnValueChanged(string _value)
	{
        SetUIEnabled(!string.IsNullOrEmpty(_value));
        if (label != default)
		{
            Debug.LogFormat("Signpost label text: {0}, new text: {1}", label.text, _value);
            label.text = _value;
		}
	}

    private void SetUIEnabled(bool _value)
	{
        doc.rootVisualElement.visible = _value;
        //doc.enabled = ;
    }

}
