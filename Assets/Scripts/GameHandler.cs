using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
	public static GameHandler Instance;
	public List<Cone> SelectedCones = new List<Cone>();
	public List<Level> Levels = new List<Level>();
	public Level CurrentLevel;
	public void SelectedCone(Cone cone)
	{
		SelectedCones.Add(cone);
	}

	private void Awake()
	{
		Instance = this;
		StartLevel(Levels[0]);
	}
	private void StartLevel(Level levelStart)
	{
		CurrentLevel = levelStart;
		foreach (var level in Levels)
		{

			if (level != levelStart) 
			{
				level.gameObject.SetActive(false);
			}
			levelStart.gameObject.SetActive(true);
		}
	}

	private void NextLevel()
	{

	}

	public void BreakLevel()
	{
		foreach (var Cones in CurrentLevel.Cones)
		{
			foreach (var cell in Cones.Cells)
			{
				cell.Restart();
			}
		}
	}
}
