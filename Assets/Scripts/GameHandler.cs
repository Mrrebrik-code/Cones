using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
	public static GameHandler Instance;
	public List<Cone> SelectedCones = new List<Cone>();
	public void SelectedCone(Cone cone)
	{
		SelectedCones.Add(cone);
	}

	private void Awake()
	{
		Instance = this;
	}
	private void StartLevel()
	{

	}

	private void NextLevel()
	{

	}

	private void BreakLevel()
	{

	}
}
