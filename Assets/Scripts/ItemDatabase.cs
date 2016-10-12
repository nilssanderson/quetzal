using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;

public class ItemDatabase : MonoBehaviour {

	// Variables
	private List<Item> database = new List<Item>();
	private JsonData itemData;


	// Functions
	void Start() {
		itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
		ConstructItemDatabase();

		Debug.Log(FetchItemByID(0).Description);
	}

	// Return item by ID
	public Item FetchItemByID(int _id) {
		// Loop through each database item
		for (int i = 0; i < database.Count; i++) {
			if (database[i].ID == _id) {
				return database[i];
			}
		}
		return null;
	}

	void ConstructItemDatabase() {
		// Loop through each database item
		for (int i = 0; i < itemData.Count; i++) {
			database.Add(
				new Item(
					(int)itemData[i]["id"],
					itemData[i]["title"].ToString(),
					(int)itemData[i]["value"],
					(int)itemData[i]["stats"]["power"],
					(int)itemData[i]["stats"]["defense"],
					(int)itemData[i]["stats"]["vitality"],
					itemData[i]["description"].ToString(),
					(bool)itemData[i]["stackable"],
					(int)itemData[i]["rarity"],
					itemData[i]["slug"].ToString()
				)
			);
		}
	}
}

// Hold all properties for item
public class Item {

	// Variables
	public int ID { get; set; }
	public string Title { get; set; }
	public int Value { get; set; }
	public int Power { get; set; }
	public int Defense { get; set; }
	public int Vitality { get; set; }
	public string Description { get; set; }
	public bool Stackable { get; set; }
	public int Rarity { get; set; }
	public string Slug { get; set; }


	// Functions
	public Item(int _id, string _title, int _value, int _power, int _defense, int _vitality, string _description, bool _stackable, int _rarity, string _slug) {
		this.ID = _id;
		this.Title = _title;
		this.Value = _value;
		this.Power = _power;
		this.Defense = _defense;
		this.Vitality = _vitality;
		this.Description = _description;
		this.Stackable = _stackable;
		this.Rarity = _rarity;
		this.Slug = _slug;
	}

	// Empty Item
	public Item() {
		this.ID = -1;
	}

}