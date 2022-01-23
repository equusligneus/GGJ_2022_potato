using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InGameMenu : InGameUI_Menu_Base
{
	public RuntimeBool requirePauseRef;
	public RuntimeGameState gameStateRef;

	protected override void SetupCallbacks()
	{
		base.SetupCallbacks();
		SetButtonCallback("btn_resume", OnResume);
		SetButtonCallback("btn_menu", OnBackToMenu);
		SetButtonCallback("btn_quit", OnQuit);

		if (requirePauseRef)
		{
			requirePauseRef.OnValueChanged += RequirePauseRef_OnValueChanged;
			RequirePauseRef_OnValueChanged(requirePauseRef.Value);
		}
		else
		{
			SetUIActive(false);
		}
	}

	protected override void CleanUpCallbacks()
	{
		base.CleanUpCallbacks();

		if (requirePauseRef)
			requirePauseRef.OnValueChanged -= RequirePauseRef_OnValueChanged;
	}

	protected override void Close()
	{
		if (requirePauseRef)
			requirePauseRef.SetValue(false);
		else
			SetUIActive(false);
	}
	private void RequirePauseRef_OnValueChanged(bool _value)
	{
		SetUIActive(_value);
	}

	private void OnResume()
	{
		if (requirePauseRef)
			requirePauseRef.SetValue(false);
	}

	private void OnBackToMenu()
	{
		if (gameStateRef)
			gameStateRef.SetValue(GameState.MainMenu);

		if (requirePauseRef)
			requirePauseRef.SetValue(false);
	}

	private void OnQuit()
	{
		if (gameStateRef)
			gameStateRef.SetValue(GameState.Quitting);

		if (requirePauseRef)
			requirePauseRef.SetValue(false);
	}

	private void SetButtonCallback(string _name, System.Action _callback)
	{
		var button = document.rootVisualElement.Q<Button>(_name);
		if (button == default)
			return;

		button.clicked += _callback;
	}
}
