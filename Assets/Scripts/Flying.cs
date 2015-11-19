using UnityEngine;
using System.Collections;

public class Flying : MonoBehaviour
{
    public GameObject player;


    void Start()
    {
        Flying2();
    }


    public void Flying2()
    {
        player.GetComponent<CharacterController>().enabled = false;
        //Insert code to start animation here.
    }

    public void Landed2()
    {
        player.GetComponent<CharacterController>().enabled = true;
    }
}
