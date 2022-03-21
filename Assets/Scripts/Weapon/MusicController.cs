using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController:MonoBehaviour
{
		public static MusicController _instance;
		public Dictionary<string,AudioClip> AudioHub;
		public AudioClip[] Clips;
		public string takeout;
		public string Draw;
		public string Shoot;
		public string snowwalk;
		public string DrawBow;
		public string Boaridle,BoarAttack,BoarDead,BoarAlert;
		void Awake ()
		{
            _instance = this;

		}

 
		public AudioClip GetAudioClip(string name)
		{
			foreach (var item in Clips)
			{
				if(item.name == name)
				return item;
			}
			return null;
			
		}
 

}

