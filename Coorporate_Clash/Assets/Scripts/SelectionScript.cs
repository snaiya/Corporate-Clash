using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SelectionScript : MonoBehaviour
{

    // public Transform spawnpos;
    public GameObject prefab;

    // Start is called before the first frame update
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
      
        //  Converting Mouse Pos to 2D (vector2) World Pos
         if(Input.GetMouseButtonDown(0)){
            
            Vector2 raycastposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(raycastposition,Vector2.zero);

            if(hit.collider != null){
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    GameObject building=Instantiate(prefab,new Vector2(hit.point.x,hit.point.y), Quaternion.identity) as GameObject;
                }
        
         }   
    
    }

}
  
