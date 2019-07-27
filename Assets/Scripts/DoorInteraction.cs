using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : Interaction
{
    public string connectedScene;

    public override void InteractWithObject()
    {
        OpenDoor();
    }

    void OpenDoor()
    {
        SceneManager.LoadScene(connectedScene, LoadSceneMode.Single);
    }
}
