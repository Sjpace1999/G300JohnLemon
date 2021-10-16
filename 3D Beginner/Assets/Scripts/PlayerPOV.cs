using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPOV : MonoBehaviour
{
    public GameEnding gameEnding;

    bool ghostWithinRange=false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
            gameEnding.InstructionsTrue();
            ghostWithinRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ghost"))
        {
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

            }
        }
    }
}
