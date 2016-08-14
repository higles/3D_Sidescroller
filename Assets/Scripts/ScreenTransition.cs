using UnityEngine;
using System.Collections;

public class ScreenTransition : MonoBehaviour {

	GameObject mainMenu;
	GameObject settingsMenu;

	// Use this for initialization
	void Start () 
	{
		mainMenu = GameObject.FindGameObjectWithTag("Main Menu Tag");
		settingsMenu = GameObject.FindGameObjectWithTag("Settings Menu Tag");

		mainMenu.SetActive(true);
		settingsMenu.SetActive(false);
	}
	
	public void transitionToSettings ()
	{
		mainMenu.SetActive(false);
		settingsMenu.SetActive(true);

	}

	public void transitionToMainMenu ()
	{
		mainMenu.SetActive(true);
		settingsMenu.SetActive(false);
	}
}
