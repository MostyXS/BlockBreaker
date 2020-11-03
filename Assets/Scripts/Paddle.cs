using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float ScreenWidthInUnits=16f;
    [SerializeField] float minX=1f;
    [SerializeField] float maxX = 15f;

    GameStatus game;
    Ball ball;

    // Start is called before the first frame update
    
    void Start()
    {
        game = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    public void Update()
    {
        MousePaddlePos();
    }

    private void MousePaddlePos()
    {
        
        Debug.Log(Input.mousePosition.x / Screen.width * ScreenWidthInUnits);
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);

        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if (game.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        }
    }

}
