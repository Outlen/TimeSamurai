using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditions : MonoBehaviour
{
    public GameWin gameWin;
    public int artifactNum;

    // Start is called before the first frame update
    void Start()
    {
        artifactNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (artifactNum == 6)
        {
            gameWin.Setup();
        }
    }


}
