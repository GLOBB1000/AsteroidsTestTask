using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class SceneManagerUtility : MonoBehaviour
    {
        public void SetScene(int index)
        {
            SceneManager.LoadScene(index);
        }
    }

}
