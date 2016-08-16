using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {	

	public GameObject hideMe;
	public GameObject hideMe2;

	void start() 
	{
		if(hideMe != null) hideMe.SetActive(false);
		if(hideMe2 != null) hideMe2.SetActive(false);
	}

	public void ChangeToScene(string scene) {
		Application.LoadLevel(scene);
	}
}