using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] float[] percentages;
    [SerializeField] Scene[] scenes;

    void Update()
    {
        
    }

    //private int GetRandomSpawn()
    //{
    //    float random = Random.Range(0f, 1f);
    //    float numForAdding = 0;
    //    float total = 0;
    //    for (int i = 0; i < percentages.Length; i++)
    //    {
    //        total += percentages[ii];
    //    }

    //    for (int i = 0; i < scenes.Length; i++)
    //    {
    //        if (percentages[i] / total + numForAdding >= random)
    //        {
    //            return
    //        }
    //    }
    //}

    public void LoadScene()
    {
        
    }
}
