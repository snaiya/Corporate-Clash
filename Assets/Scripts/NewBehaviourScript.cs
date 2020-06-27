using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // private Vector3 screenBounds;
    
    public GameObject consumer;
    public GameObject[] animation_consumer = new GameObject[15];

    public Vector3[] position_of_consumer = new Vector3[15];
    public float time=3.0f;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject board = GameObject.Find("Tiles");
        // for(int i =0 ; i<15;i++){
        //      GameObject c = Instantiate(consumer) as GameObject;
        //      animation_consumer[i]=c;
        //      c.transform.position = new Vector2(Random.Range(-45.0f,40.0f),Random.Range(-39.0f,33.0f));
        //      var boxCollider1 = (BoxCollider2D) c.AddComponent<BoxCollider2D>();
        //      var rigidbody =  (Rigidbody2D) c.AddComponent<Rigidbody2D>();
        //      rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        // }
        //Leftmost horizontal
        position_of_consumer[0] = new Vector3(-54.40446f,3.530338f,-1.22861f);
        //Rightmost horizontal
        position_of_consumer[1] = new Vector3(21.0f,2f,-1.22861f);
        //Below of top Alleyway horizontal
        position_of_consumer[2] = new Vector3(-23.60f,15.9303f,-1.22861f);
        //Above ,bottom Alleyway horizontal
        position_of_consumer[3] = new Vector3(-23.60f,-15.9303f,-1.22861f);
        //Left side of Alleyway
        position_of_consumer[4] = new Vector3(-24.6044f,16.9303f,-1.22861f);

        position_of_consumer[5] = new Vector3(10.7f,17.5f,-1.22861f);
        // position_of_consumer[5] = new Vector3(0.5955334f,3.530338f,-1.22861f);

        


        for(int i =0 ;i<6;i++)
        {
            GameObject c = Instantiate(consumer) as GameObject;
            c.transform.position = position_of_consumer[i];
            animation_consumer[i]=c;
        }
        
        // GameObject c1 = Instantiate(consumer) as GameObject;
        // Vector3 p = new Vector3();
        // p = animation_consumer[0].GetComponent<Transform>().position; 
        // Debug.Log(p.x);

    }
    private void spawnConsumer(){
       

    }
    // Update is called once per frame
    void Update()
    {
        // time -= Time.deltaTime;
       
        //     for(int i=0;i<animation_consumer.Length;i++)
        //  {
        //      //Debug.Log(animation_consumer[i]);
        //      Vector3 p = new Vector3();
        //      p = animation_consumer[i].GetComponent<Transform>().position;
        //     // p.x ++;
        //     // p.y ++;
        //     // float clampX=Mathf.Clamp(p.x, -45.0f, 30.0f);
        //     // float clampY=Mathf.Clamp(p.y, -39.0f, 20.0f);
 
        

        //     if(p.x<30.0f)
        //         p.x ++;
             
        //      if(p.y<20.0f)
        //         p.y ++; 
             
                
        //      animation_consumer[i].GetComponent<Transform>().position=p;
        //  }
        // for(int i=0;i<4;i++)
        // {
        //     Vector3 p = new Vector3();
        //     p = animation_consumer[i].GetComponent<Transform>().position;
        //     p = Horizontal_animation(p,p.x+14.0f,p.x);
        //     //if(i==0)
        //         //Debug.Log(p.x);
        //     animation_consumer[i].GetComponent<Transform>().position=p;
        
        // }

                Vector3 p = new Vector3();
                p = animation_consumer[0].GetComponent<Transform>().position;
              
                //Left to right (leftmost )

                p =Horizontal_animation(p,-41.00447f,-54.40446f);
                animation_consumer[0].GetComponent<Transform>().position=p;
                //(Rightmost)
                 Vector3 p1 = new Vector3();
                 p1 = animation_consumer[1].GetComponent<Transform>().position;
                 p1 = Horizontal_animation(p1,56.0f,21.0f);    
                 animation_consumer[1].GetComponent<Transform>().position=p1;

                // // Debug.Log(p.x);
                // // if(p.y <=3.530338f)
                // //     p.y ++;
                // //Luxury top
                Vector3 p2 = new Vector3();
                p2 = animation_consumer[2].GetComponent<Transform>().position;
                p2 = Horizontal_animation(p2,3.45f,-23.60f);    
                animation_consumer[2].GetComponent<Transform>().position=p2;
                

                // //Luxury below
                Vector3 p3 = new Vector3();
                p3 = animation_consumer[3].GetComponent<Transform>().position;
                p3 = Horizontal_animation(p3,3.45f,-23.60f);    
                animation_consumer[3].GetComponent<Transform>().position=p3;

                //Alleyway top-left-diagonal

                Vector3 p4 = new Vector3();
                p4 = animation_consumer[4].GetComponent<Transform>().position;
                p4 = Diagonal_Animation(p4,-24.6044f,16.9303f,-39.30f,29.53034f);    
                animation_consumer[4].GetComponent<Transform>().position=p4;
                
         
    }
    int flag =0;
    public Vector3 Horizontal_animation(Vector3 v,float xmax,float xmin)
    {
                
                float temp = v.x;
                // Debug.Log(deb);
                Debug.Log(xmax);
                Debug.Log(xmin);
                if(v.x<=xmax && flag==0 )
                    v.x ++;
                if((temp-v.x)==0 && flag ==0)
                {
                    Debug.Log("Flag switched from 0 to 1");
                    flag = 1;
                    v.x--;
                }
                if(v.x>=xmin && flag ==1)
                {
                    v.x--;
                }
                if((temp-v.x) == 0 && flag ==1)
                {
                    Debug.Log("Switched from 1 to 0");
                    flag = 0;
                    v.x++;
                }
                
                // Debug.Log(deb);
                Debug.Log(v);
                
                return v;
    }
    int flag_d = 0;

    public Vector3 Diagonal_Animation(Vector3 v,float xmax,float ymin,float xmin,float ymax)
    {
        float temp_x = v.x;
        float temp_y = v.y;

        if(v.x>= xmin && v.y<=ymax && flag_d ==0){
            v.x = v.x - 0.5f;
            v.y = v.y + 0.5f;
        }

        if(temp_x - v.x ==0 && temp_y - v.y ==0 && flag_d ==0){
            flag_d  = 1;
            v.x = v.x + 0.5f;
            v.y = v.y - 0.5f;
        }
        
        if(v.x<=xmax && v.y>=ymin && flag_d ==1){
            v.x = v.x + 0.5f;
            v.y = v.y - 0.5f;
        }

         if(temp_x - v.x ==0 && temp_y - v.y ==0 && flag_d ==1){
            flag_d  = 0;
            v.x = v.x + 0.5f;
            v.y = v.y - 0.5f;
        }

        
        return v;

    }
}

