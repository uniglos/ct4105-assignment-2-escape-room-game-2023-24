using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DragMatchingObjectManager: MonoBehaviour
{

    [SerializeField]
    int totalNumberOfObjectsToMatch = 4;
    
    public int objectsMatched = 0;

    public string nameOfPuzzle, escapeRoomGameScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if( objectsMatched == totalNumberOfObjectsToMatch )
        {

            PlayerPrefs.SetInt( "Score", PlayerPrefs.GetInt( "Score" ) + 1 );

            PlayerPrefs.SetString( nameOfPuzzle, "Complete" );

            PlayerPrefs.Save();

            SceneManager.LoadScene( escapeRoomGameScene );  

        }
        
    }

}