using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player : MonoBehaviour {
	private int xp;
	public Text LevelText;
	private int level = 1;

	public void AddXP(int increase) {
		xp += increase;
		
		if (xp % 100 == 0 && level<100) { // Level up if passes 100
			level++;
		}
		UpdateText();
		Save();
	}

	public void Save()
	{
		PlayerPrefs.SetInt("XP", xp);
		PlayerPrefs.SetInt("Level", level);
	}

	public void Load()
	{
		if (PlayerPrefs.HasKey("XP"))
		{
			xp = PlayerPrefs.GetInt("XP");
			level = PlayerPrefs.GetInt("Level");
			UpdateText();
		}
	}

	private void UpdateText()
	{
		LevelText.text = level.ToString();
	}
}
