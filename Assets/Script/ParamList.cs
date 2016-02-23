using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Common;

public class ParamList : MonoBehaviour {
	public List<PlayerParam> playerList;
	public List<PlayerParam> enemyList;
	private int partyNum = 6;
	private int EnemyNum = 4;
	// Use this for initialization
	void Awake () {

		playerList = new List<PlayerParam> ();
		enemyList = new List<PlayerParam> ();
		for (int i = 0; i < partyNum; i++) {
			playerList.Add (new PlayerParam());
			playerList [i].Name = ("Player" + i);
			playerList [i].Hp = (1000 * i);
			playerList [i].Level = 1;
			playerList [i].MaxHp = (1000 * i);
			playerList [i].Fuel = (2* i);
			playerList [i].Maxfuel = (2*i);
			playerList [i].Bullet = (2*i); 
			playerList [i].Maxbullet = (2*i);
			playerList [i].Exp = (50*i);
			playerList [i].BattoleExp = 100*i;
			playerList [i].Defense = (2*i);
			playerList [i].Avoidance = (2*i);
			playerList [i].Speed = (2*i);
			playerList [i].LongPower = (500*i);
			playerList [i].MiddlePower = (220*i);
			playerList [i].ShortPower = (230*i);
			playerList [i].ShieldPower = (2*i);
			playerList [i].Sphit = (2*i);
			playerList [i].SearchEnemy = (2*i);
			playerList [i].Luck = (2*i);
			playerList[i].EnemyDamage = 0;

			playerList [i].IseEemy = false;
			playerList [i].EquipmentList = new List<Equipment>();
			if (i == 0) {

				playerList [i].EquipmentList.Add (new Equipment ());
				playerList [i].EquipmentList [0].Name = @"Drone";
				playerList [i].EquipmentList [0].Power = 10;
				playerList [i].EquipmentList [0].Type = EquipmentType.Drone;

				playerList [i].EquipmentList.Add (new Equipment ());
				playerList [i].EquipmentList [1].Name = @"Sky";
				playerList [i].EquipmentList [1].Power = 20;
				playerList [i].EquipmentList [1].Type = EquipmentType.Sky;

				playerList [i].EquipmentList.Add (new Equipment ());
				playerList [i].EquipmentList [2].Name = @"Spider";
				playerList [i].EquipmentList [2].Power = 30;
				playerList [i].EquipmentList [2].Type = EquipmentType.Spider;
			}
		}
		for (int i = 0; i <EnemyNum; i++) {
			enemyList.Add (new PlayerParam());
			enemyList [i].Name = ("KATUO" + i);
			enemyList [i].Hp = (1000 * i);
			enemyList [i].MaxHp = (1000 * i);
			enemyList [i].Fuel = (2* i);
			enemyList [i].Maxfuel = (2*i);
			enemyList [i].Bullet = (2*i); 
			enemyList [i].Maxbullet = (2*i);
			enemyList [i].Exp = (2*i);
			enemyList [i].BattoleExp = 0;
			enemyList [i].Defense = (2*i);
			enemyList [i].Avoidance = (2*i);
			enemyList [i].Speed = (2*i);
			enemyList [i].LongPower = (200*i);
			enemyList [i].MiddlePower = (200*i);
			enemyList [i].ShortPower = (200*i);
			enemyList [i].ShieldPower = (2*i);
			enemyList [i].Sphit = (2*i);
			enemyList [i].SearchEnemy = (2*i);
			enemyList [i].Luck = (2*i);

			enemyList [i].IseEemy = true;
			enemyList [i].EquipmentList = new List<Equipment>();
			if (i == 0) {

				enemyList [i].EquipmentList.Add(new Equipment ());
				enemyList [i].EquipmentList [0].Name = @"Drone";
				enemyList [i].EquipmentList [0].Power = 10;
				enemyList [i].EquipmentList [0].Type = EquipmentType.Drone;

				enemyList [i].EquipmentList.Add(new Equipment ());
				enemyList [i].EquipmentList [1].Name = @"Sky";
				enemyList [i].EquipmentList [1].Power = 20;
				enemyList [i].EquipmentList [1].Type = EquipmentType.Sky;

				enemyList [i].EquipmentList.Add(new Equipment ());
				enemyList [i].EquipmentList [2].Name = @"Spider";
				enemyList [i].EquipmentList [2].Power = 30;
				enemyList [i].EquipmentList [2].Type = EquipmentType.Spider;
			}
		}
			
	}

	public void ExpDate(){
		for (int i = 0; i < playerList.Count; i++) {
			playerList [i].Level = (playerList [i].Exp / 100)+1;
		}
	}
}
		
