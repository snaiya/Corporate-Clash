using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
	//public static bool created = false;
	BuildingCreate b1 = new BuildingCreate();
    void Awake ()
	{
     if (!variable.created)
     {
		 Debug.Log("AWAKE1");
         DontDestroyOnLoad(this.gameObject);
         variable.created = true;
     }
     
     else
     {
		 Debug.Log("AWAKE2");
         Destroy(this.gameObject);
		 //BuildingCreate.Start_Second();
		 //BuildingCreate b1 = new BuildingCreate();
            b1.Start_Second();
     }
	}
	
	

	
	void Start()
    {
		//BuildingCreate b1 = new BuildingCreate();
		//b1.SecondStart();
		
        
    }

    // Update is called once per frame
    void Update()
    {
	
		 //BuildingCreate b1 = new BuildingCreate();
         b1.Update_Second();
     
		
        
    }
}

