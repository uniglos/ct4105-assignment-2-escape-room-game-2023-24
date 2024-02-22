using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class CameraLocations {

	public GameObject _cameraLocation;
	
}

public class ObjectsManager : MonoBehaviour
{

    [HideInInspector]
    public string _currentAction = "";
    
    public GameObject _messageBox;

    public GameObject _lookAt;

    public GameObject _open;

    public GameObject _close;

    public GameObject _investigate;

    public CameraLocations[] _cameraLocations = new CameraLocations[100];

    public List<GameObject> _collectedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
  
        hideActions();

    }

    // Update is called once per frame
    void Update()
    {


    }

    
    public void hideActions()
    {

       GameObject[] _actions = GameObject.FindGameObjectsWithTag( "Action" );
 
        foreach( GameObject _go in _actions )
        {

            _go.SetActive( false );

        }

    }

    public void enableActions()
    {
        if( _lookAt )
        {

            _lookAt.SetActive( true );

            _lookAt.GetComponent<Button>().interactable = true;

        }

        if( _open )
        {

            _open.SetActive( true );

            _open.GetComponent<Button>().interactable = true;

        }

        if( _close )
        {

            _close.SetActive( true );

            _close.GetComponent<Button>().interactable = true;

        }

        if(_investigate)
        {

            _investigate.SetActive( true );

            _investigate.GetComponent<Button>().interactable = true;

        }
    }

    public void disableActions( Button button )
    {
        if( _lookAt )
        {

            _lookAt.GetComponent<Button>().interactable = false;

        }

        if( _open )
        {

            _open.GetComponent<Button>().interactable = false;

        }

        if( _close )
        {  

            _close.GetComponent<Button>().interactable = false;

        }

        if( _investigate )
        {

            _investigate.GetComponent<Button>().interactable = false;

        }

        if( button != null )
        {

            _currentAction = button.name;

            print( _currentAction );

        }

    }

}