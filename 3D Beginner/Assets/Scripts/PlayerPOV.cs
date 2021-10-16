using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPOV : MonoBehaviour
{
    public GameEnding gameEnding;

    bool ghostWithinRange=false;
    GameObject ghost;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            //https://answers.unity.com/questions/278355/how-can-i-access-a-colliders-gameobject-in-script.html
            ghost = other.gameObject;
            
            gameEnding.InstructionsTrue();
            ghostWithinRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            ghost = null;
            gameEnding.InstructionsFalse();
            ghostWithinRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ghostWithinRange)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(ghost);
                ghost = null;
                gameEnding.InstructionsFalse();
                ghostWithinRange = false;
                gameEnding.incrementCaptured();
            }
        }
    }
}
