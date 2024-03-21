using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterPuzzleManager : MonoBehaviour
{

    public bool complete = false;

    public string nameOfPuzzle, escapeRoomGameScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if( complete )
        {

            PlayerPrefs.SetInt( "Score", PlayerPrefs.GetInt( "Score" ) + 1 );

            PlayerPrefs.SetString( nameOfPuzzle, "Complete" );

            PlayerPrefs.Save();

            SceneManager.LoadScene( escapeRoomGameScene );  
            
        }
        
    }

}
