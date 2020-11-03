using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class lvlScript : MonoBehaviour
{
    
    [SerializeField] int breakableBlocks;


    SceneLoader sceneLoader;
    
    
       public void CountBreakableBlocks()
    {
        
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
    }
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    private void Update()
    {
        if (breakableBlocks <= 0)
            sceneLoader.NextSceneLoad();
            

    }


}
