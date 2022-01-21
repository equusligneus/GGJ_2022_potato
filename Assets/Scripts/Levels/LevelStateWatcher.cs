using UnityEngine;

public class LevelStateWatcher : MonoBehaviour
{
	[SerializeField] private Level myLevel;
	[SerializeField] private RuntimeLevel currentLevel;
	[SerializeField] private RuntimeWorld currentWorld;

	public bool IsInLevel
		=> currentLevel != default && currentLevel.Equals(myLevel);

	public World CurrentWorld
		=> (IsInLevel && currentWorld != default) ? currentWorld.Value : World.Invalid;
}