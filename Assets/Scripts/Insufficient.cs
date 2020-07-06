using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Insufficient : MonoBehaviour
{
    public void insufficient_balance(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Standalone");
        //Application.Quit();
   }

   public void onGameComplete()
   {
       #if !UNITY_EDITOR
			Application.Quit();
		#endif
         foreach (GameObject ob in Object.FindObjectsOfType<GameObject>()) {
             Destroy(ob);
         }
         variable.tiles_bought.Clear();
         variable.Player1.Clear();
    //    Application.Quit();
    //TODO: When done and clicked,play again once the scene loads then there are issues of land permits
    //and placement.Please check!
        SceneManager.LoadScene("Standalone");
   }
}
