using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class SignPopUpScript : InGameUI_Menu_Base
{
	public RuntimeString currentTextRef;
	private Label label;
	private Button closeButton;

	protected override void SetupReferences()
	{
		base.SetupReferences();
		label = document.rootVisualElement.Q<Label>("txt_sign");
		closeButton = document.rootVisualElement.Q<Button>("btn_close");
	}

	protected override void SetupCallbacks()
	{
		base.SetupCallbacks();
		if (closeButton != default)
			closeButton.clicked += CloseButton_Clicked;

		if (currentTextRef)
		{
			currentTextRef.OnValueChanged += CurrentTextRef_OnValueChanged;
			CurrentTextRef_OnValueChanged(currentTextRef.Value);
		}
		else
		{
			SetUIActive(false);
		}
	}

	protected override void CleanUpCallbacks()
	{
		base.CleanUpCallbacks();

		if (currentTextRef)
			currentTextRef.OnValueChanged -= CurrentTextRef_OnValueChanged;
	}
	protected override void Close()
	{
		if (currentTextRef)
			currentTextRef.SetValue("");
		else
			SetUIActive(false);
	}

	private void CloseButton_Clicked()
		=> Close();


	private void CurrentTextRef_OnValueChanged(string _value)
	{
		SetUIActive(!string.IsNullOrEmpty(_value));
		if (label != default)
			label.text = _value;
	}
}
