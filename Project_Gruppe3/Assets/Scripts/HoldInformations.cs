using UnityEngine;
using System.Collections;

public static class HoldInformations {
	
	#region Variables (public)

	public static int level = 1;
	public static int lifes = 1;
	public static int scores = 0;

	#endregion


	#region Methods

	// GETTER + SETTER FOR LIFE
	public static void SetLife (int setLife){
		lifes = setLife;
	}
	
	
	public static int GetLife (){
		return lifes;
	}
	

	// GETTER + SETTER FOR LEVEL
	public static void SetLevel (int setLevel){
		level = setLevel;
	}
	
	
	public static int GetLevel (){
		return level;
	}

	
	// GETTER + SETTER FOR SCORES
	public static void SetScore (int setScore){
		scores = setScore;
	}
	
	
	public static int GetScore (){
		return scores;
	}

	#endregion
}
