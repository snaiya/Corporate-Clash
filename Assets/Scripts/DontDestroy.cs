using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
   
       void Awake()
    {
       
        GameObject[] objs = GameObject.FindGameObjectsWithTag("building");
         for(int i=0; i<2;i++){
             DontDestroyOnLoad(objs[i].gameObject);
         }
        

    }
   
}
