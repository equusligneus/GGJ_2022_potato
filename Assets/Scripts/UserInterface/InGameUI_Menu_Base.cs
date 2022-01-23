using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class InGameUI_Menu_Base : MonoBehaviour
{
	[SerializeField] protected RuntimeBool menuOpenRef;
	[SerializeField] protected InputActionAsset input;
	protected UIDocument document;

	// Start is called before the first frame update
	protected virtual void Start()
	{
		SetupReferences();
		SetupCallbacks();
	}

	protected virtual void OnDestroy()
	{
		CleanUpCallbacks();
	}

	protected virtual void SetupReferences()
	{
		document = GetComponent<UIDocument>();
	}

	protected virtual void SetupCallbacks()	{	}

	protected virtual void CleanUpCallbacks(){	}

	private void Close_performed(InputAction.CallbackContext obj)
		=> Close();


	protected virtual void Close()
		=> SetUIActive(false);

	protected virtual void SetUIActive(bool _active)
	{
		if (menuOpenRef)
			menuOpenRef.SetValue(_active);

		var close = GetAction("Cancel");
		if (close != default)
		{
			if (_active)
				close.performed += Close_performed;
			else
				close.performed -= Close_performed;
		}

		document.rootVisualElement.visible = _active;
	}

	protected InputAction GetAction(string _name)
	{
		if (input == default)
			return default;

		var uiMap = input.FindActionMap("UI");
		if (uiMap == default)
			return default;

		return uiMap.FindAction(_name);
	}
}
