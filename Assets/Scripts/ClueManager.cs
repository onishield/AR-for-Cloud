﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class ClueManager : MonoBehaviour {

	public List<Clue> MurderItemList = new List<Clue> ();
	public List<Clue> MurderCharacterList = new List<Clue> ();
	public List<Clue> RobberyItemList = new List<Clue> ();
	public List<Clue> RobberyCharacterList = new List<Clue> ();
	public List<Clue> DrugItemList = new List<Clue> ();
	public List<Clue> DrugCharacterList = new List<Clue> ();
//	public Dictionary<string, Clue> clues = new Dictionary<string, Clue> ();

	// Use this for initialization
	void Awake() {

//		Clue c1 = new Clue("Combatknife","item");
//		Clue c2 = new Clue("Pistol","item");
//		Clue c3 = new Clue("Drug","item");
//
//		clues.Add ("Murder", c1);
//		clues.Add ("Murder1", c2);
//		clues.Add ("Drug", c3);
//		Clue d = clues ["Pistol"];
//		string d = clues["Drug"].type;
//		print (d);

//		ReadClueInformation ("Item","Robbery", "Assets/Texts/Robbery/Item/detail.txt", RobberyItemList);
//		ReadClueInformation ("Item","Murder", "Assets/Texts/Murder/Item/detail.txt", MurderItemList);
//		ReadClueInformation ("Item","Drug", "Assets/Texts/Drug/Item/detail.txt", DrugItemList);
//		ReadClueInformation ("Character","Robbery", "Assets/Texts/Robbery/Character/detail.txt", RobberyCharacterList);
//		ReadClueInformation ("Character","Murder", "Assets/Texts/Murder/Character/detail.txt", MurderCharacterList);
//		ReadClueInformation ("Character","Drug", "Assets/Texts/Drug/Character/detail.txt", DrugCharacterList);

//		print ("Item"+RobberyItemList.Count + "," + MurderItemList.Count + "," + DrugItemList.Count);
//		print ("Character"+RobberyCharacterList.Count + "," + MurderCharacterList.Count + "," + DrugCharacterList.Count); 

		MakeList ("Item","Robbery", RobberyItemList);
		MakeList ("Item","Murder", MurderItemList);
		MakeList ("Item","Drug", DrugItemList);
		MakeList ("Character","Robbery", RobberyCharacterList);
		MakeList ("Character","Murder", MurderCharacterList);
		MakeList ("Character","Drug", DrugCharacterList);

//		Clue tmp =  MurderItemList[2];
//		print (tmp);
//		Instantiate (tmp.model);

//		Clue temp = null;
//		if (clues.TryGetValue ("Footprint", out temp)) {
//			print (temp.name);
//			Instantiate (temp.model);
//		} else {
//			print ("No Key Found.");
//		}
	}


	// Update is called once per frame
	void Update () {
		
	}

	public void ReadClueInformation(string type, string tag, string path, List<Clue> list){
		string[] lines = System.IO.File.ReadAllLines (path);
		for (int i = 0; i < lines.Length;)
		{
			Clue preset = new Clue();
			preset.tag = tag;
			Debug.Log(preset.tag);
			preset.name = lines[i++];
			Debug.Log(preset.name);
			preset.type = lines[i++];
			Debug.Log(preset.type);
			preset.description = lines[i++];
			Debug.Log(preset.description);
			preset.model = Resources.Load<GameObject> ("CluesPrefabs/"+tag+"/"+type+"/"+preset.name);
			Debug.Log(preset.model);
			list.Add (preset);
//			clues.Add ("i" + type + i,preset);

		}
	}

	public void MakeList(string type, string tag, List<Clue> list){
		TextAsset asset = Resources.Load("CluesPrefabs/"+tag+"/"+type+"/detail") as TextAsset;
//		Debug.Log(asset);

//--------------------------------------------------------- for windows ----------------------------------------------------------------------------
		var textAsset = asset.text.Split (new string[] { "\r\n"},System.StringSplitOptions.None);
//--------------------------------------------------------- for mac --------------------------------------------------------------------------------
//		var textAsset = asset.text.Split (new char[] {'\n'});

		for (int i = 0; i < textAsset.Length;){
			Clue preset = new Clue();
			preset.tag = tag;
			preset.name = textAsset[i++];
//			Debug.Log(preset.name+" : "+preset.name.Length);
//			Debug.Log(preset.name[0]);
//			Debug.Log(preset.name[1]);
//			Debug.Log(preset.name[2]);
			preset.type = textAsset[i++];
//			Debug.Log(preset.type);
			preset.description = textAsset[i++];
//			Debug.Log(preset.description);
			preset.model = Resources.Load<GameObject> ("CluesPrefabs/"+tag+"/"+type+"/"+preset.name);
//			Debug.Log(preset.model);
			preset.info = textAsset[i++];
//			Debug.Log(preset.info+" : "+preset.info.Length);
			list.Add (preset);
		}
	}
}
