using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{   //config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    
    [SerializeField] Sprite[] hitSprites;
    //cached reference
    lvlScript lvl;

    //state variables
    [SerializeField] int timesHit; // TODO only serialized for Debug purposes
    private void Start()
    {
        
        lvl = FindObjectOfType<lvlScript>();
        if (tag == "Breakable")
        lvl.CountBreakableBlocks();
    }
   



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        
            timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
                DestroyBlock();
            else
        {
            ShowNextHitSprite();
            
        }
        

    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        
        if (hitSprites[spriteIndex] != null)
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else
            Debug.LogError("Block is missing from array"+gameObject.name);
        
    }

    private void DestroyBlock()
    {
        TriggerSparklesVFX();
        PlayBlockBreakSFX();
        lvl.BlockDestroyed();
        Destroy(gameObject);
    }

    private void PlayBlockBreakSFX()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position,transform.rotation);
        Destroy(sparkles, 2f);
    }

}


