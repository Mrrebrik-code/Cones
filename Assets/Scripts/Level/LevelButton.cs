using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
	public int LevelId;
	public Color ColorNoActive;

	public void SetLevel()
	{
		GameHandler.Instance.StartLevel(GameHandler.Instance.Levels[LevelId - 1]);
		PausedHandler.Instance.CloseMapLevels();
	}
}
