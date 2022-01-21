using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitch : MonoBehaviour
{
    [SerializeField] Level targetLevel;
    [SerializeField] RuntimeLevel currentLevel;

	private void OnTriggerEnter(Collider other)
	{
		// do fun stuff here

		if (currentLevel != default)
			currentLevel.SetValue(targetLevel);
	}
}
