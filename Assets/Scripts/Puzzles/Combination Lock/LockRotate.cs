using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LockRotate : MonoBehaviour
{

    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;
    private int numberShown;

    // Start is called before the first frame update
    void Start()
    {

        coroutineAllowed = true;

        numberShown = 1;
        
    }

    private void OnMouseDown()
    {
        
        if( coroutineAllowed )
        {

            StartCoroutine( "RotateWheel" );

        }

    }

    private IEnumerator RotateWheel()
    {

        coroutineAllowed = false;

        for( int i = 0; i <= 9; i ++ )
        {

            transform.Rotate( 0f, 0f, -4f);

            yield return new WaitForSeconds( 0.01f );

        }

        coroutineAllowed = true;

        numberShown += 1;

        if ( numberShown > 9 )
        {

            numberShown = 1;

        }

        Rotated( name, numberShown );

        //print( name + ": " + numberShown );

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
