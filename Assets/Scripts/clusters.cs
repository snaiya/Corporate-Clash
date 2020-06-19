//consumer cluster script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clusters : MonoBehaviour
{
    public int no_of_bots = 50;
    public int no_of_clusters = 4;

    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void assign_bots_to_area()
    {
        List<int> bots_picked = new List<int>();

        string[] areaType = new string[] { "Luxury", "Alleyway", "Street" };

        double[] footfall_prob = { 0.5, 0.3, 0.2 };

        for (int i = 0; i < 3; i++)
        {
            int footfall = System.Convert.ToInt32(footfall_prob[i] * no_of_bots);

            assign_bots(areaType[i], footfall, bots_picked);
        }
        assign_clusters();
    }

    public void assign_bots(string area, int footfall, List<int> bots_picked)
    {
        //for every area
        List<int> temp_bots = new List<int>();

        while (temp_bots.Count < footfall)
        {
            int random_bot = random.Next(0, no_of_bots);
            if (!bots_picked.Contains(random_bot))
            {
                bots_picked.Add(random_bot);
                temp_bots.Add(random_bot);
            }
        }

        variable.Land.Add(area, temp_bots);
    }

    public void assign_clusters() 
    {
		foreach (KeyValuePair<string, List<int>> kvp in variable.Land)
        {
            //bots which belong to which cluster in a particular area
            Dictionary<int, List<int>> cluster_in_area = new Dictionary<int, List<int>>();

            int k;
            
            foreach (int botid in kvp.Value) 
            {
                k = botid%no_of_clusters;

                if (cluster_in_area.ContainsKey(k))
                {
                    cluster_in_area[k].Add(botid);
                }
                else
                {
                    cluster_in_area.Add(k, new List<int> {botid});
                }
            }

            
            if (kvp.Key=="Luxury")
            {
                foreach (KeyValuePair<int, List<int>> kvpi in cluster_in_area)
                {
                    int count = 0;
                
                    foreach (int botid in kvpi.Value) 
                    {
                        count++;
                    }
                    variable.Luxury_cluster.Add(kvpi.Key, count);
                }
            }

            
            if (kvp.Key=="Alleyway")
            {
                foreach (KeyValuePair<int, List<int>> kvpi in cluster_in_area)
                {
                    int count = 0;
                
                    foreach (int botid in kvpi.Value) 
                    {
                        count++;
                    }
                    variable.Alleyway_cluster.Add(kvpi.Key, count);
                }
            }


            if (kvp.Key=="Street")
            {
                foreach (KeyValuePair<int, List<int>> kvpi in cluster_in_area)
                {
                    int count = 0;
                
                    foreach (int botid in kvpi.Value) 
                    {
                        count++;
                    }
                    variable.Street_cluster.Add(kvpi.Key, count);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}