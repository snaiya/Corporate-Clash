using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample : MonoBehaviour
{
    public GameObject my_obj;
    public GameObject temp_obj;
    public List<GameObject> mylist = new List<GameObject>();
    public List<GameObject> tile_assign = new List<GameObject>();
    public List<GameObject> p1 = new List<GameObject>();
    public List<GameObject> p2 = new List<GameObject>();
    System.Random r = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void  New()
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
    mylist.Add(my_obj.transform.GetChild(x).gameObject);
        }
        randomizeTile(mylist, tileAssign[i]);
            variable.Mapping.Add(areaType[i], mylist);
            mylist.Clear();

    }
    
    //return hunny.Mapping;
    }

        public void randomizeTile(List<GameObject> mylist, int limit)
        {
        while (tile_assign.Count < limit)
        {
        int index = r.Next(0, mylist.Count);
            if (!tile_assign.Contains(mylist[index]))
            {
                tile_assign.Add(mylist[index]);

            }

        }
        printTile(tile_assign, limit);
            tile_assign.Clear();
    }
        
        
        //Player 1 - Red
        //Player 2 - Blue
        public void printTile(List<GameObject> tile_assign, int x)
        {
            string s = "";


        for (int i = 0; i < tile_assign.Count; i++)
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
                GameObject temp = tile_assign[i];
                if (i % 2 == 0)
                {
                p1.Add(temp);
                
                temp.GetComponent<SpriteRenderer>().color = Color.red;


                }
                else 
                {
                p2.Add(temp);
                
                temp.GetComponent<SpriteRenderer>().color = Color.blue;
 
                }
            }
            variable.Player1.Add(s, p1);
            variable.Player2.Add(s, p2);

        }

        

        /*foreach (GameObject i in tile_assign)
        {
            //SpriteRenderer sr = i.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
            //i.GetComponent<SpriteRenderer>().color = Color.red;

            i.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log(i);

        }*/



    

    // Update is called once per frame
    void Update()
    {

    }
}