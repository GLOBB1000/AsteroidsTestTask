using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saves
{
    public static class SavingSystem
    {
        private const string hingScore = "Score";

        public static void Save(float score)
        {
            var savedData = PlayerPrefs.GetFloat(hingScore);

            if(savedData < score)
            {
                PlayerPrefs.SetFloat(hingScore, score);
            }
        }

        public static float GetScore()
        {
            return PlayerPrefs.GetFloat(hingScore);
        }
    }
}

