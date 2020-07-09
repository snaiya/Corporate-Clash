using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimationCounter : MonoBehaviour
{
    public Slider slider;
    public GameObject consumer;
    public GameObject[] animation_consumer = new GameObject[15];
    public Text progress;
    public Vector3[] position_of_consumer = new Vector3[15];
	public GameObject DecisionWon;
    public GameObject DecisionLost;
    public GameObject WonPlayAgain;
    public GameObject LossPlayAgain;
	GameObject salesreportpanel;
	public GameObject nobalance;
    bool winflag=false;
    bool lossflag=false;
    GameObject salesreportui;
    //GameObject nextroundbutton;
	
    void checkBuilding()
    {
        if (variable.Luxury_building.Count == 0 && variable.Alleyway_building.Count == 0 && variable.Street_building.Count==0)
        {
            if(variable.money < 50)
            {
                // lost because no balance to buy any building. irrespective of the round no
                // thus show new screen stating the same and quit the game
                nobalance.SetActive(true);
            }
        }
    }

    public void lastButton()
    {
        Application.Quit();
    }
    void Start()
    {
        salesreportui = GameObject.Find("SalesReportUI");
        salesreportpanel = GameObject.Find("SalesReportPanel");

        salesreportui.SetActive(false);
        DecisionWon.SetActive(false);
        DecisionLost.SetActive(false);
        WonPlayAgain.SetActive(false);
        LossPlayAgain.SetActive(false);
        nobalance.SetActive(false);

        checkBuilding();

        clusters c1 = new clusters();
        c1.assign_bots_to_area();

        variable.updateBuildingCount();

        salesreport.countBuildingTypes();

        if(salesreport.total_profit >= 2000 && variable.round <=14){
            // win scene here and remove application.quit from here
            
            winflag=true;
            salesreportpanel.SetActive(false);
            DecisionWon.SetActive(true);
            WonPlayAgain.SetActive(true);
        }
        else if(variable.round >14){
            // Lose scene here and remove application.quit from here

            lossflag=true;
            salesreportpanel.SetActive(false);
            DecisionLost.SetActive(true);
            LossPlayAgain.SetActive(true);
        }

        
         //nextroundbutton = GameObject.Find("NextRoundButton");
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
        //Bottom of Luxury-right diagonal
        position_of_consumer[6] = new Vector3(10.7f,-15.5f,-1.22861f);
        //Bottom of Luxury - left diagonal
        position_of_consumer[7] = new Vector3(-21.60f,-15.9303f,-1.22861f);
        

        progress.text = "Consumer Purchasing";

        
        for(int i =0;i<8;i++)
        {
            GameObject c = Instantiate(consumer) as GameObject;
            c.transform.position = position_of_consumer[i];
            animation_consumer[i]=c;
        }
    }

    void populateSalesReport()
    {
        GameObject luxury_f = GameObject.Find("Luxury_F");
        luxury_f.GetComponent<TextMeshProUGUI>().text = salesreport.NetProfit["Luxury_F"].ToString();
        
        GameObject luxury_g = GameObject.Find("Luxury_G");
        luxury_g.GetComponent<TextMeshProUGUI>().text = salesreport.NetProfit["Luxury_G"].ToString();
        
        GameObject alleyway_f = GameObject.Find("Alleyway_F");
        alleyway_f.GetComponent<TextMeshProUGUI>().text = salesreport.NetProfit["Alleyway_F"].ToString();
        
        GameObject alleyway_g = GameObject.Find("Alleyway_G");
        alleyway_g.GetComponent<TextMeshProUGUI>().text = salesreport.NetProfit["Alleyway_G"].ToString();
        
        GameObject street_f = GameObject.Find("Street_F");
        street_f.GetComponent<TextMeshProUGUI>().text = salesreport.NetProfit["Street_F"].ToString();
        
        GameObject street_g = GameObject.Find("Street_G");
        street_g.GetComponent<TextMeshProUGUI>().text = salesreport.NetProfit["Street_G"].ToString();
        
        GameObject netprofit = GameObject.Find("Netprofit");
        netprofit.GetComponent<TextMeshProUGUI>().text = salesreport.total_profit.ToString();
        
        variable.money = variable.money + salesreport.total_profit;
        GameObject balance = GameObject.Find("Totalbalance");
        balance.GetComponent<TextMeshProUGUI>().text = (variable.money).ToString();
        
    }
    
    // private void spawnProgressBar()
    // {
    //     slider.value += 0.0017f;        
    // }
    
    // Update is called once per frame
    float time= 3;

    void Update()
    {
        time -= Time.deltaTime;
        
        if(time<=0)
        {
            
            // slider.gameObject.SetActive(false);
            progress.text = "Consumer Purchase Done";
            enabled = false;
            // slider.enabled = false;
        
            //Score report
     
            salesreportui.SetActive(true);
            if(winflag==false && lossflag==false)
            	populateSalesReport();
        }

        // if(time>0)
        // {
        //     spawnProgressBar();
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
        
        if(v.x<=xmax && flag==0 )
        {
            v.x ++;
        }
        if((temp-v.x)==0 && flag ==0)
        {
            flag = 1;
            v.x--;
        }
        if(v.x>=xmin && flag ==1)
        {
            v.x--;
        }
        if((temp-v.x) == 0 && flag ==1)
        {
            flag = 0;
            v.x++;
        }

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

        if(v.x<= xmax && v.y<=ymax && flag_r ==0)
        {
            v.x = v.x + 0.75f;
            v.y = v.y + 0.75f;
        }

        if(temp_x - v.x ==0 && temp_y - v.y ==0 && flag_r ==0){
            flag_r  = 1;
            v.x = v.x - 0.75f;
            v.y = v.y - 0.75f;
        }
        
        if(v.x>=xmin && v.y>=ymin && flag_r ==1){
            v.x = v.x - 0.75f;
            v.y = v.y - 0.75f;
        }

         if(temp_x - v.x ==0 && temp_y - v.y ==0 && flag_r ==1){
            flag_r  = 0;
            v.x = v.x + 0.75f;
            v.y = v.y + 0.75f;
        }
        
        return v;
    } 
}


