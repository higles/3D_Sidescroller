using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	private static MusicManager instance = null;

	public static MusicManager Instace { get { return instance; } }

	void Awake()
	{
		if(instance == null)
		{
			Destroy(instance);
		}
		else if(instance == this)
		{
			DontDestroyOnLoad(instance);
		}

	}
}