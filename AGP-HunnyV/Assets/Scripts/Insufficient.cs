using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Insufficient : MonoBehaviour
{
  public GameObject Insufficient_balance;

  public Text RoundNo;

   void Start()
   {
      RoundNo.text = "ROUND NO :" + variable.round+1;
   } 
   public void onGameComplete()

   {
    Insufficient_balance = GameObject.Find("Insufficient");
    Insufficient_balance.SetActive(false);
       //#if !UNITY_EDITOR
		// 	Application.Quit();
		// #endif
  //        foreach (GameObject ob in Object.FindObjectsOfType<GameObject>()) {
  //            Destroy(ob);
  //        }
  //        variable.tiles_bought.Clear();
  //        variable.Player1.Clear();
  //   //    Application.Quit();
  //   //TODO: When done and clicked,play again once the scene loads then there are issues of land permits
  //   //and placement.Please check!
  //       SceneManager.LoadScene("Standalone");
   }
}
