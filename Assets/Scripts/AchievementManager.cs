using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class AchievementManager : MonoBehaviour {

	private static AchievementManager _instance = null;

	public static AchievementManager Instance {
		get {
			return _instance;
		}
	}

	public GameObject achievementPanel;
	public Text achievementText, unlockedContentText;
	public float transitionSpeed = 1f;
	public float timeToDispAchv = 4f;

	private Queue<long> coroutineIDs;

	void Awake() {
		if(_instance == null) {
			_instance = this;
			DontDestroyOnLoad(_instance);
		} else if(_instance != this) {
			Destroy(this.gameObject);
		}

		coroutineIDs = new Queue<long>();
	}

	public void AchievementUnlock(string thingToUnlock, string achievementName, string descOfUnlockedContent) {
		// Check whether to achieve
		if(SaveLoadManager.Instance.gameData.unlockedAchievements.Contains(achievementName))
			return;
		else
			SaveLoadManager.Instance.gameData.unlockedAchievements.Add(achievementName);
		StartCoroutine(AchvOp(thingToUnlock, achievementName, descOfUnlockedContent));
	}

	IEnumerator AchvOp(string thingToUnlock, string achievementName, string descOfUnlockedContent) {
		// Enqueue achievement
		long coroutineID = DateTime.Now.Ticks;
		coroutineIDs.Enqueue(coroutineID);

		while(coroutineIDs.Peek() != coroutineID)
			yield return null;

		if(thingToUnlock != null && !SaveLoadManager.Instance.gameData.unlockedContent.Contains(thingToUnlock))
			SaveLoadManager.Instance.gameData.unlockedContent.Add(thingToUnlock);

		// Set achievement panel datarr
		achievementText.text = achievementName;
		unlockedContentText.text = descOfUnlockedContent;

		// Display achievement
		achievementPanel.SetActive(true);

		yield return new WaitForSecondsRealtime(timeToDispAchv);

		achievementPanel.SetActive(false);

		coroutineIDs.Dequeue();
	}
}