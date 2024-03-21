using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ExitTrigger : MonoBehaviour
{

    private void OnTriggerEnter( Collider collider )
    {

        if( collider.gameObject.tag == "Player" )
        {

            GetComponent<CharacterPuzzleManager>().complete = true;

        }
        
    }

}
