using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraswitch : MonoBehaviour
{
    public bool sand = true;
    public Transform player;
    public Transform Camera;

    public float PosX;
    public float PosY;
    public Rect map1Bounds = new Rect(-136, -99.6f, 272, 195.6f);
    public Rect map2Bounds = new Rect(-135, -316, 270, 201);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        PosX = player.transform.position.x;
        PosY = player.transform.position.y;
        if (Input.GetKeyDown(KeyCode.Tab))
    {
        Vector2 newPosition;
        if (sand == false)
    {
        sand = true;
        newPosition = new Vector2(Random.Range(map1Bounds.xMin, map1Bounds.xMax), Random.Range(map1Bounds.yMin, map1Bounds.yMax));
    }
    else           
    {
        sand = false;
        newPosition = new Vector2(Random.Range(map2Bounds.xMin, map2Bounds.xMax), Random.Range(map2Bounds.yMin, map2Bounds.yMax));
    }
    
    player.transform.position = newPosition;
    Camera.transform.position = newPosition;
}
        /*
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            if (sand == false)
            {
                sand = true;
                player.transform.position = new Vector2(PosX, PosY + 214.6f);
                Camera.transform.position = new Vector2(PosX, PosY + 214.6f);


            }
            else           
            {
                sand = false;
                player.transform.position = new Vector2(PosX, PosY - 214.6f);
                Camera.transform.position = new Vector2(PosX, PosY - 214.6f);

            }
        }*/
    }
}





