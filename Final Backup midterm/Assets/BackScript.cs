using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackScript : MonoBehaviour
{
	public void PlayMenu()
	{
		UnityEngine.Debug.Log("We are going to main scene");
		UnityEngine.SceneManagement.SceneManager.LoadScene("Standalone");
	}
}
