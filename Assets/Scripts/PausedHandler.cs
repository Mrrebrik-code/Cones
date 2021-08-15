using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedHandler : MonoBehaviour
{
	public static PausedHandler Instance;
	[SerializeField] private GameObject _mapLevels;

	private void Awake()
	{
		Instance = this;
	}
	public void OpenMapLevels()
	{
		_mapLevels.SetActive(true);
	}
	public void CloseMapLevels()
	{
		_mapLevels.SetActive(false);
	}
}
