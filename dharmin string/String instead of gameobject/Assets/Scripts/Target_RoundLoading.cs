using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_RoundLoading : MonoBehaviour
{
	public void start_building(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Board");
   }
}
