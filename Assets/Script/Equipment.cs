using UnityEngine;
using System.Collections;
using Common;


/*
[System.Serializable]
public class EquipmentData
{
	public int equipmentType;
	public string name;
	public int power;

	public EquipmentData(string name, int power, int equipmentType)
	{
		this.name = name;
		this.power = power;
		this.equipmentType = equipmentType;
	}

}
*/
/*
	public string Name { get; set;}
	public int Power{ get; set;}
	public int EquipmentType{ get; set;}
	*/


//public class Equipment : MonoBehaviour{
public class Equipment{

	//public EquipmentData[] equipmentData;
	/*
	enum EquipmentType {
		Drone,
		Sky,
		Spider
	};
	*/

	//装備タイプ 仮
	private EquipmentType type;
	//private int equipmentType;
	private string name;
	private int power;
	/*
	public Equipment(string name, int power, EquipmentType type){
		this.name = name;
		this.power = power;
		this.type = type;
		Debug.Log ("Equipment作成:"+name+" "+this.name);
	}
*/



	public string Name { get; set;}
	public int Power{ get; set;}
	public EquipmentType Type{ get; set;}




}
