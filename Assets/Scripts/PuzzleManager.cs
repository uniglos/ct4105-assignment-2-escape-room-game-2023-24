using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> puzzleNames;

    public TextMeshProUGUI combinationLock;

    private string lockCode;

    void Start()
    {

        if( combinationLock )
        {

            lockCode = combinationLock.text;

            combinationLock.text = "";

        }

        createPuzzleList();

    }
    
    public void createPuzzleList()
    {

        foreach( string puzzle in puzzleNames)
        {

            if( !PlayerPrefs.HasKey( puzzle ) )
            {

                PlayerPrefs.SetString( puzzle, "" );

            }
            
        }

        checkPuzzleStatus();

    }

    public void checkPuzzleStatus()
    {

        int numberOfPuzzlesComplete = 0;

        foreach( string puzzle in puzzleNames)
        {

            var status = "Incomplete";

            if( PlayerPrefs.GetString( puzzle ) != "" )
            {

                status = "Complete";

                numberOfPuzzlesComplete++;
                
            }
            
            print( "Puzzle: " + puzzle + " is: " + status);

        }
    
        if( combinationLock )
        {
            
            combinationLock.text = lockCode.Substring( 0, numberOfPuzzlesComplete );

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deletePlayerPrefs()
    {

        PlayerPrefs.DeleteAll();

        print( "PlayerPrefs deleted." );

    }

}
