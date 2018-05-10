using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMainMenu : MonoBehaviour {

	public MasterVolumeController master;
	
	public void SaveGame()
		{
		
			master.Save();
		}

		public void LoadGame()
		{
			if (PlayerPrefs.HasKey("MusicMute"))
			{
				master.Load();
			}
		}
}
