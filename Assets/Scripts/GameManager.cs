using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager _instance = null;

	public static GameManager Instance {
		get {
			return _instance;
		}
	}

	private float timeScore = 0f;
	private float _rdr = 1f;

	public float RelativeDifficultyRate {
		get {
			return _rdr;
		}
	}
		
	// Relative difficulty increases by 50% every minute
	public float rdrIncPerMin = 0.5f;


	void Awake() {
		if(_instance == null) {
			_instance = this;
			DontDestroyOnLoad(_instance);
		} else if(_instance != this) {
			Destroy(this.gameObject);
		}

		Initialize();
		//StartCoroutine(UpdateDebugger(1f));
	}

	public void Initialize() {
		timeScore = 0f;
		_rdr = 1f;
	}
	
	// Update is called once per frame
	void Update() {
		timeScore += Time.deltaTime;
		_rdr += Time.deltaTime * (rdrIncPerMin / 60f) * _rdr; 
	}

	IEnumerator UpdateDebugger(float timeStep) {
		while(true) {
			Debug.Log("Timescore: " + timeScore + " RDR: " + RelativeDifficultyRate);
			yield return new WaitForSecondsRealtime(timeStep);
		}
	}
}
