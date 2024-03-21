using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{

    private int[] result;

    public int[] correctCombination;

    public Animator objectToTrigger;

    public string nameOfTriggerParameter;

    // Start is called before the first frame update
    void Start()
    {
        
        result = new int[] { 1, 1, 1 };

        correctCombination = new int[] { 3, 7, 9 };

        LockRotate.Rotated += CheckResults;

    }

    private void CheckResults( string wheelName, int number )
    {

        switch( wheelName )
        {

            case "Wheel_1":

                result[0] = number;
            
            break;

             case "Wheel_2":

                result[1] = number;
            
            break;

             case "Wheel_3":

                result[2] = number;
            
            break;

        }

        if( result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2] )
        {

            //Debug.Log( "Opened" );

           objectToTrigger.SetTrigger( nameOfTriggerParameter );

        }

    }

    private void OnDestroy()
    {
        
        LockRotate.Rotated -= CheckResults;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
