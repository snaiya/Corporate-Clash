using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{
    public GameObject my_obj;
    public GameObject temp_obj;
	public List<GameObject> temp_tile = new List<GameObject>();

    System.Random r = new System.Random();
    // Start is called before the first frame update
	/*void Awake()
	{
		if(variable.spawn)
		{
			DestroyImmediate(gameObject);
		}
		variable.spawn = true;
	}*/
	
	public static bool created = false;
    void Awake ()
	{
     if (!created)
     {
         DontDestroyOnLoad(this.gameObject);
         created = true;
     }
     
     else
     {
         Destroy(this.gameObject);
     }
	}
	
   
    public void New()
    {
    //temp_obj = GameObject.Find("myvar");
    //var = temp_obj.GetComponent<variable>();
    string [] areaType = new string[]{"Luxury", "Alleyway", "Street"};
    int [] tileCount = new int[]{24, 44, 72};
    int [] tileAssign = new int[] {4, 6, 8};
    //variable hunny = new variable();   
    for (int i = 0; i < 3; i++)
    {
    my_obj = GameObject.Find(areaType[i]);
    
    int limit = tileCount[i];
    
    for (int x = 0; x < limit; x++)
	{
		if (!variable.tile_assign.Contains(my_obj.transform.GetChild(x).gameObject))
		{
		variable.mylist.Add(my_obj.transform.GetChild(x).gameObject);
    }
	}
       randomizeTile(tileAssign[i]);
	   
	   if(variable.Mapping.ContainsKey(areaType[i]))
	   {
			variable.Mapping[areaType[i]].AddRange(variable.mylist);
	   }
	   else
	   {
		   variable.Mapping.Add(areaType[i], variable.mylist);
	   }   
		   
       variable.mylist.Clear();
	}
    
    
    }

     public void randomizeTile(int limit)
       {
        while (temp_tile.Count < limit)
        {
			//Debug.Log(temp_tile.Count + "Raunaq");
        int index = r.Next(0, variable.mylist.Count);
            if (!variable.tile_assign.Contains(variable.mylist[index]))
            {
                variable.tile_assign.Add(variable.mylist[index]);
				temp_tile.Add(variable.mylist[index]);

            }

        }
        printTile(limit);
        temp_tile.Clear();
    }
        
        

        public void printTile(int x)
        {
            string s = "";


        for (int i = 0; i < variable.tile_assign.Count; i++)
            {
                
                if(x == 4)
                {
                    s = "Luxury";
                }
                else if(x == 6)
                {    
                    s = "Alleyway";
                }
                else
                {
                    s = "Street";
                }
                GameObject temp = variable.tile_assign[i];
				//DontDestroyy.DontDestroyChildOnLoad(temp);
                if (i % 2 == 0)
                {
                variable.p1.Add(temp);
                
                temp.GetComponent<SpriteRenderer>().color = Color.red;


                }
                else 
                {
                variable.p2.Add(temp);
                
                temp.GetComponent<SpriteRenderer>().color = Color.blue;
 
                }
            }
			if(variable.Player1.ContainsKey(s))
			{
				variable.Player1[s].AddRange(variable.p1);
			}
			else
			{
					
				variable.Player1.Add(s,variable.p1);
			}
			
			if(variable.Player2.ContainsKey(s)){
			variable.Player2[s].AddRange(variable.p2);}
				else
				{
					
				variable.Player2[s] = variable.p2;
			}
			
            

        }

        

        // foreach (GameObject i in variable.tile_assign)
        // {
        //     SpriteRenderer sr = i.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        //     i.GetComponent<SpriteRenderer>().color = Color.red;

        //     i.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
        //     Debug.Log(i);

        // }
    

    // Update is called once per frame
    void Update()
    {

    }
}