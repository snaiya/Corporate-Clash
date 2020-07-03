using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using DentedPixel;

public class Animation : MonoBehaviour
{
    // public GameObject bar;
    // private Vector3 screenBounds;
    
    public GameObject consumer;
    public GameObject[] animation_consumer = new GameObject[15];
    public Text timer;
    public Vector3[] position_of_consumer = new Vector3[15];
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        //Bottom of Luxury-right diagonal
        position_of_consumer[6] = new Vector3(10.7f,-15.5f,-1.22861f);
        //Bottom of Luxury - left diagonal
        position_of_consumer[7] = new Vector3(-21.60f,-15.9303f,-1.22861f);
        

        
        for(int i =0;i<8;i++)
        {
            GameObject c = Instantiate(consumer) as GameObject;
            c.transform.position = position_of_consumer[i];
            animation_consumer[i]=c;
            
        }
        
        
    }
  
    // Update is called once per frame
    
    public float time= 10.0f;
    
    void Update()
    {
        time -= Time.deltaTime;
        timer.text = time.ToString("0");
        // animate_bar();
        
        //Debug.Log(time);
        
        if(time<=0){
            enabled = false;
            //Score report
        }
       
        

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

                Vector3 p5 = new Vector3();
                p5 = animation_consumer[5].GetComponent<Transform>().position;
                p5 = Diagonal_Animation_right(p5,24f,17.5f,10.7f,33.33f);    
                animation_consumer[5].GetComponent<Transform>().position=p5;

                Vector3 p6 = new Vector3();
                p6 = animation_consumer[6].GetComponent<Transform>().position;
                p6 = Diagonal_Animation(p6,27.5f,-37.0f,10.7f,-15.5f);    
                animation_consumer[6].GetComponent<Transform>().position=p6;

                Vector3 p7 = new Vector3();
                p7 = animation_consumer[7].GetComponent<Transform>().position;
                p7 = Diagonal_Animation_right(p7,-21.60f,-36.0f,-38.0f,-15.9303f);    
                animation_consumer[7].GetComponent<Transform>().position=p7;
    }
    int flag =0;
    public Vector3 Horizontal_animation(Vector3 v,float xmax,float xmin)
    {
                
                float temp = v.x;
                // Debug.Log(deb);
                //Debug.Log(xmax);
                //Debug.Log(xmin);
                if(v.x<=xmax && flag==0 )
                    v.x = v.x + 0.5f;
                if((temp-v.x)==0 && flag ==0)
                {
                    //Debug.Log("Flag switched from 0 to 1");
                    flag = 1;
                    v.x = v.x - 0.5f;
                }
                if(v.x>=xmin && flag ==1)
                {
                    
                    v.x = v.x - 0.5f;
                }
                if((temp-v.x) == 0 && flag ==1)
                {
                    //Debug.Log("Switched from 1 to 0");
                    flag = 0;
                    v.x = v.x + 0.5f;
                }
                
                // Debug.Log(deb);
                //Debug.Log(v);
                
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

        int flag_r = 0;

    public Vector3 Diagonal_Animation_right(Vector3 v,float xmax,float ymin,float xmin,float ymax)
    {
        float temp_x = v.x;
        float temp_y = v.y;

        if(v.x<= xmax && v.y<=ymax && flag_r ==0){
            v.x = v.x + 0.5f;
            v.y = v.y + 0.5f;
        }

        if(temp_x - v.x ==0 && temp_y - v.y ==0 && flag_r ==0){
            flag_r  = 1;
            v.x = v.x - 0.5f;
            v.y = v.y - 0.5f;
        }
        
        if(v.x>=xmin && v.y>=ymin && flag_r ==1){
            v.x = v.x - 0.5f;
            v.y = v.y - 0.5f;
        }

         if(temp_x - v.x ==0 && temp_y - v.y ==0 && flag_r ==1){
            flag_r  = 0;
            v.x = v.x + 0.5f;
            v.y = v.y + 0.5f;
        }

        
        return v;

    }

    }

