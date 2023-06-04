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
            }
        } 
    }
}





