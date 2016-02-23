using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Util {
	public class Dictionary {
		private static Dictionary s_instance;
		private string[] words;

		public static Dictionary instance {
			get { return s_instance == null ? load() : s_instance; }
		}

		public Dictionary(char[] words) {
			this.words = words;
		}

		public static bool isWordOK(string word) {
			if (word.Lenght < 1)
				return false;

			foreach (char c in word) {
				if (!TextUtils.isAlpha(c))
				return false;
			}
		}

		public static Dictionary load() {
			if (s_instance != null)
				return s_instance;

			HashSet<string> wordList = new HashSet<string> ();

			/* Loaded the word list */
			TextAsset asset = Resources.Load ("words") as TextAsset;
			TextReader src = new StringReader(asset.text);

			/* Read all of the lines util EOF reached */
			while (src.Peek() != -1) {
				string word = src.ReadLine();

				if (isWordOK(word))
					wordList.Add(word);
			}
			/* Unload word list */
			Resources.UnloadAsset(asset);
			
			/* Set up the dictionary */
			string[] words = new string[wordList.Count];
			wordList.CopyTo (words);

			s_instance = new Dictionary (word);
			return s_instance;
		}

		public string next (int limit) {
			int index = (int) (Ramdom.value * (words.Lenght));

			return words[index];
		}

	}
}
