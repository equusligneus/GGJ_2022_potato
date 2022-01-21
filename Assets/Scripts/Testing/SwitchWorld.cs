using UnityEngine;

public class SwitchWorld : MonoBehaviour
{
	[SerializeField] RuntimeWorld currentWorld;

	private void OnGUI()
	{
		string wrld = (currentWorld != default ? currentWorld.Value : World.Invalid).ToString();

		if (currentWorld == default)
			return;

		Rect area = new Rect(5, 5, 195, 100);
		GUI.Box(area, "");

		GUILayout.BeginArea(area);

		GUILayout.Box(string.Format("Current Level: {0}", wrld));

		if (GUILayout.Button("Set Invalid"))
			currentWorld.SetValue(World.Invalid);

		if (GUILayout.Button("Set Default"))
			currentWorld.SetValue(World.Default);

		if (GUILayout.Button("Set Alternate"))
			currentWorld.SetValue(World.Alternative);

		GUILayout.EndArea();
	}
}
