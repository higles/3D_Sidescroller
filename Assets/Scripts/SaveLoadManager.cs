using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadManager : MonoBehaviour {
	private static SaveLoadManager _instance = null;

	public static SaveLoadManager Instance {
		get {
			return _instance;
		}
	}

	[HideInInspector] public GameData gameData;
	public string saveFile = "game_save_1";
	private string postString = ".hpsf";

	void Awake() {
		if(_instance == null) {
			_instance = this;
			DontDestroyOnLoad(_instance);
		} else if(_instance != this) {
			Destroy(this.gameObject);
		}
		Load();	
	}

	void Start() {
		if(gameData.unlockedAchievements == null)
			gameData.unlockedAchievements = new List<string>();
	}

	//Save data
	public void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/" + saveFile + postString);
		bf.Serialize(file, gameData);
		file.Close();
	}

	//Load data
	public void Load() {
		if(File.Exists(Application.persistentDataPath + "/" + saveFile + postString)) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/" + saveFile + postString, FileMode.Open);
			gameData = (GameData)bf.Deserialize(file);
			file.Close();
		} else {
			// Load defaults here if no file exists
		}
	}
}

// A serializable class for data
[Serializable]
public class GameData {
	public List<Game> games = new List<Game>();
	public List<string> unlockedAchievements = new List<string>();
	public List<string> unlockedContent = new List<string>();
	public int credits;

	public float masterVol;
	public float musicVol;
	public float sfxVol;
}


[Serializable]
public struct Game {
	public string plane;
	public int score;

	public Game(string plane, int finalScore) {
		this.plane = plane;
		score = finalScore;
	}
}