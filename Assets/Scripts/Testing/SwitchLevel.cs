using UnityEngine;

public class SwitchLevel : MonoBehaviour
{
	[SerializeField] RuntimeLevel currentLevel;

	private void OnGUI()
	{
		string lvl = (currentLevel != default ? currentLevel.Value : Level.Invalid).ToString();

		if (currentLevel == default)
			return;

		Rect area = new Rect(5, 110, 195, 150);
		GUI.Box(area, "");

		GUILayout.BeginArea(area);

		GUILayout.Box(string.Format("Current Level: {0}", lvl));

		if (GUILayout.Button("Invalid"))
			currentLevel.SetValue(Level.Invalid);

		if (GUILayout.Button("Level 1"))
			currentLevel.SetValue(Level.Level1);

		if (GUILayout.Button("Level 2"))
			currentLevel.SetValue(Level.Level2);

		if (GUILayout.Button("Level 3"))
			currentLevel.SetValue(Level.Level3);

		if (GUILayout.Button("Level 4"))
			currentLevel.SetValue(Level.Level4);

		GUILayout.EndArea();
	}
}
