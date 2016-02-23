using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Common;

public class PlayerParam   {
	private string name;
	private int level;
	private int hp;
	private int maxHp;
	private int fuel;
	private int maxfuel;
	private int bullet;
	private int maxbullet;
	private int exp;
	private int battoleExp;
	private int defense;
	private int avoidance;
	private int speed;
	private int longPower;
	private int middlePower;
	private int shortPower;
	private int shieldPower;
	private int sphit;
	private int searchEnemy;
	private int luck;

	private int enemyDamage;

	private List<Equipment> equipmentLis;
	public bool iseEemy;




	public string Name{ get; set;}
	public int Hp { get; set;}
	public int Level{ get; set;}
	public int MaxHp{ get; set;}
	public int Fuel{ get; set;}
	public int Maxfuel{ get; set;}
	public int Bullet{ get; set;}
	public int Maxbullet{ get; set;}
	public int Exp{ get; set;}
	public int BattoleExp{ get; set;}
	public int Defense { get; set;}
	public int Avoidance{ get; set;}
	public int Speed{ get; set;}
	public int LongPower{ get; set;}
	public int MiddlePower{ get; set;}
	public int ShortPower{ get; set;}
	public int ShieldPower{ get; set;}
	public int Sphit{ get; set;}
	public int SearchEnemy{ get; set;}
	public int Luck{ get; set;}

	public int EnemyDamage{ get; set;}


	//0219hayashi追加
	public List<Equipment> EquipmentList{get; set;}
	//0222hayashi追加
	public bool IseEemy{ get; set;}
}
