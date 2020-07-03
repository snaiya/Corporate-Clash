using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class salesreport : MonoBehaviour
{
	public static Dictionary<string, int> Luxury_BuildingType_Count = new Dictionary<string, int>() { { "Building_F", 0 }, { "Building_G", 0 } };
	public static Dictionary<string, int> Alleyway_BuildingType_Count = new Dictionary<string, int>() { { "Building_F", 0 }, { "Building_G", 0 } };
	public static Dictionary<string, int> Street_BuildingType_Count = new Dictionary<string, int>() { { "Building_F", 0 }, { "Building_G", 0 } };

	public static Dictionary<string, int> SellingPrice = new Dictionary<string, int>(){{"Luxury_F", 20},
	{"Luxury_G", 18}, {"Alleyway_G", 12}, {"Alleyway_F", 15}, {"Street_G", 7}, {"Street_F", 9}};

	// FETCH THIS DICTIONARY FOR SALESREPORT
	public static Dictionary<string, int> NetProfit = new Dictionary<string, int>(){{"Luxury_F", 0},
	{"Luxury_G", 0}, {"Alleyway_G", 0}, {"Alleyway_F", 0}, {"Street_G", 0}, {"Street_F", 0}};
	public static int total_profit = 0;

	// Start is called before the first frame update
	void Start()
	{

	}
	

	public static void countBuildingTypes()
	{

		foreach (KeyValuePair<string, Dictionary<string, List<string>>> i in variable.BuildingDict)
		{

			int f_count = 0;
			int g_count = 0;
			foreach (KeyValuePair<string, List<string>> j in i.Value)
			{
				
				if (j.Key == "f")
				{
					f_count = j.Value.Count;
				}
				if (j.Key == "g")
				{
					g_count = j.Value.Count;
				}
				
			}
			if (i.Key == "Luxury")
			{
				Luxury_BuildingType_Count["Building_F"] = f_count;
				Luxury_BuildingType_Count["Building_G"] = g_count;

			}
			else if (i.Key == "Alleyway")
			{
				Alleyway_BuildingType_Count["Building_F"] = f_count;
				Alleyway_BuildingType_Count["Building_G"] = g_count;
			}
			else
			{
				Street_BuildingType_Count["Building_F"] = f_count;
				Street_BuildingType_Count["Building_G"] = g_count;
			}
		}
		calculateProfitLuxury();
		calculateProfitAlleyway();
		calculateProfitStreet();

	}


	// cluster 0 buys the most expensive one (from f)
	// cluster 1 buys the cheapest (from g)
	public static void calculateProfitLuxury()
	{
		int[] no_of_bots = new int[] { 0, 0 };

		int temp_profit_f = 0, temp_profit_g = 0;
		foreach (KeyValuePair<int, int> i in variable.Luxury_cluster)
		{
			no_of_bots[i.Key] = i.Value;
		}
		temp_profit_f = no_of_bots[0] * Luxury_BuildingType_Count["Building_F"] * SellingPrice["Luxury_F"];
		NetProfit["Luxury_F"] = temp_profit_f;
		temp_profit_g = no_of_bots[1] * Luxury_BuildingType_Count["Building_G"] * SellingPrice["Luxury_G"];
		NetProfit["Luxury_G"] = temp_profit_g;
		total_profit += temp_profit_f + temp_profit_g;
		

	}
	
	public static void calculateProfitAlleyway()
	{
		int[] no_of_bots = new int[] { 0, 0 };
		int temp_profit_f = 0, temp_profit_g = 0;
		foreach (KeyValuePair<int, int> i in variable.Alleyway_cluster)
		{
			no_of_bots[i.Key] = i.Value;
		}
		temp_profit_f = no_of_bots[0] * Alleyway_BuildingType_Count["Building_F"] * SellingPrice["Alleyway_F"];
		NetProfit["Alleyway_F"] = temp_profit_f;
		temp_profit_g = no_of_bots[1] * Alleyway_BuildingType_Count["Building_G"] * SellingPrice["Alleyway_G"];
		NetProfit["Alleyway_G"] = temp_profit_g;
		total_profit += temp_profit_f + temp_profit_g;
	
	}
	
	public static void calculateProfitStreet()
	{
		int[] no_of_bots = new int[] { 0, 0 };
		int temp_profit_f = 0, temp_profit_g = 0;
		foreach (KeyValuePair<int, int> i in variable.Street_cluster)
		{
			no_of_bots[i.Key] = i.Value;
		}
		temp_profit_f = no_of_bots[0] * Street_BuildingType_Count["Building_F"] * SellingPrice["Street_F"];
		NetProfit["Street_F"] = temp_profit_f;
		temp_profit_g = no_of_bots[1] * Street_BuildingType_Count["Building_G"] * SellingPrice["Street_G"];
		NetProfit["Street_G"] = temp_profit_g;
		total_profit += temp_profit_f + temp_profit_g;
		
	}

		public void nextRound()
	{
		SceneManager.LoadScene("Board");
	}
	

}
