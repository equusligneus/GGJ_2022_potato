using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateWatcher : MonoBehaviour
{
	[SerializeField] private Level myLevel;
	[SerializeField] private RuntimeLevel currentLevel;
	[SerializeField] private RuntimeWorld currentWorld;

	[SerializeField] private List<Behaviour> defaultEnabledComponents;
	[SerializeField] private List<Behaviour> alternativeEnabledComponents;

	public event Action<World> OnWorldChange;
	public event Action<Level> OnLevelChange;
	public bool IsInLevel
		=> currentLevel && currentLevel.Equals(myLevel);

	public World CurrentWorld
		=> (IsInLevel && currentWorld) ? currentWorld.Value : World.Invalid;


	public void Start()
	{
		if (currentWorld != default)
			currentWorld.OnValueChanged += CurrentWorld_OnValueChanged;

		if (currentLevel != default)
		{
			currentLevel.OnValueChanged += CurrentLevel_OnValueChanged;
			CurrentLevel_OnValueChanged(currentLevel.Value);
		}
	}

	public void OnDestroy()
	{
		if (currentLevel != default)
			currentLevel.OnValueChanged -= CurrentLevel_OnValueChanged;

		if (currentWorld != default)
			currentWorld.OnValueChanged -= CurrentWorld_OnValueChanged;
	}

	private void CurrentWorld_OnValueChanged(World _value)
		=> Trigger(CurrentWorld);

	private void CurrentLevel_OnValueChanged(Level _value)
	{
		if (OnLevelChange != default)
			OnLevelChange(_value);
		Trigger(CurrentWorld);
	}

	private void Trigger(World _value)
	{
		foreach (var behaviour in defaultEnabledComponents)
		{
			if (behaviour)
				behaviour.enabled = _value == World.Default;
		}

		foreach (var behaviour in alternativeEnabledComponents)
		{
			if (behaviour)
				behaviour.enabled = _value == World.Alternative;
		}

		if (OnWorldChange != default)
			OnWorldChange(_value);
	}
}