using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour {

	// Public method to restart scene when Restart button is clicked
	public void RestartScene()
	{
		SceneManager.LoadScene ("Scene01");
	}
}
