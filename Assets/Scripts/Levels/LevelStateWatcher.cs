using UnityEngine;

public class LevelStateWatcher : MonoBehaviour
{
	[SerializeField] private Level myLevel;
	[SerializeField] private RuntimeLevel currentLevel;
	[SerializeField] private RuntimeWorld currentWorld;
	[SerializeField] private Animator myAnimator;

	public bool IsInLevel
		=> currentLevel != default && currentLevel.Equals(myLevel);

	public World CurrentWorld
		=> (IsInLevel && currentWorld != default) ? currentWorld.Value : World.Invalid;


	public void OnStart()
	{
		if(currentLevel != default)
			currentLevel.OnValueChanged += CurrentLevel_OnValueChanged;

		if(currentWorld != default)
			currentWorld.OnValueChanged += CurrentWorld_OnValueChanged;
	}

	public void OnDestroy()
	{
		if (currentLevel != default)
			currentLevel.OnValueChanged -= CurrentLevel_OnValueChanged;

		if (currentWorld != default)
			currentWorld.OnValueChanged -= CurrentWorld_OnValueChanged;
	}

	private void CurrentWorld_OnValueChanged(World _value)
		=> SetAnimValues(CurrentWorld);

	private void CurrentLevel_OnValueChanged(Level _value)
		=> SetAnimValues(CurrentWorld);

	private void SetAnimValues(World _value)
	{
		if (_value == World.Invalid)
			return;

		// do animator stuff here!!!
	}
}