using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMoleculesBank : MonoBehaviour
{
	[SerializeField] private Text _textCountMoleculesBank;
	[SerializeField] private Text _textCountMoleculesReward;
	private void Awake()
    {
        MoleculesBank.OnChangedMoleculesAction += UpdateMoleculesCount;
    }

	private void UpdateMoleculesCount(int count)
	{
		_textCountMoleculesBank.text = count.ToString();
	}
}
