using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
public void onGameComplete()

   {
      //   Application.Quit();
       //#if !UNITY_EDITOR
		// 	Application.Quit();
		// #endif
         foreach (GameObject ob in Object.FindObjectsOfType<GameObject>()) {
             Destroy(ob);
         }
         variable.tiles_bought.Clear();
         variable.Player1.Clear();
         variable.Land.Clear();
         variable.Luxury_cluster.Clear();
         variable.Alleyway_cluster.Clear();
         variable.Street_cluster.Clear();
         variable.tiles_in_area.Clear();
         variable.tile_assign.Clear();
         variable.money=1000;
         variable.round=0;
         variable.location_check.Clear();
         variable.Alleyway_building.Clear();
         variable.Luxury_building.Clear();
         variable.Street_building.Clear();
         variable.BuildingDict.Clear();
         salesreport.Luxury_BuildingType_Count.Clear();
         salesreport.Alleyway_BuildingType_Count.Clear();
         salesreport.Street_BuildingType_Count.Clear();
         salesreport.NetProfit.Clear();
         variable.total_profit = 0;
//   //   //    Application.Quit();
//   //   //TODO: When done and clicked,play again once the scene loads then there are issues of land permits
//   //   //and placement.Please check!
         SceneManager.LoadScene("Standalone");
        
   }
}