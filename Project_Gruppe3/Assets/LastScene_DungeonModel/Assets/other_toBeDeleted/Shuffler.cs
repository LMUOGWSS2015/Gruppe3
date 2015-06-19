using System;
using System.Collections;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	public class Shuffler
	{
		public Shuffler (){}

		/// <summary>
		/// Shuffles the contents of a list
		/// </summary>
		/// <param name="listToShuffle">The list to shuffle</param>
		/// <param name="numberOfTimesToShuffle">How many times to shuffle the list
		/// by default this is 5 times</param>
		public static List<T> Shuffle<T>(List<T> listToShuffle) {
			System.Random _rnd = new System.Random ();
			//make a new list of the wanted type
			List<T> newList = new List<T> ();			
			int numberOfTimesToShuffle = 3;
			//for each time we want to shuffle
			for (int i = 0; i < numberOfTimesToShuffle; i++) {
				
				//while there are still items in our list
				while (listToShuffle.Count > 0) {
					//get a random number within the list
					int index = _rnd.Next (listToShuffle.Count);
					
					//add the item at that position to the new list
					newList.Add (listToShuffle [index]);
					
					//and remove it from the old list
					listToShuffle.RemoveAt (index);
				}
				
				//then copy all the items back in the old list again
				listToShuffle.AddRange (newList);
				
				//and clear the new list
				//to make ready for next shuffling
				newList.Clear ();
			}
			return listToShuffle;
		}
	}
}

