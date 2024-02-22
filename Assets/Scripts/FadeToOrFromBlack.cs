using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeToOrFromBlack : MonoBehaviour
{
    
    [HideInInspector]
    public bool _fadeToBlack = false;

    public GameObject _blackOutSquare;
    
    public void fadeToBlack( float fadeSpeed = 1, int waitBeforeFade = 2, int waitAfterFade = 2, string nextSceneToLoad = "" )
    {

        _fadeToBlack = true;

        StartCoroutine( FadeBlackOutSquare( _fadeToBlack, fadeSpeed, waitBeforeFade, waitAfterFade, nextSceneToLoad ) );

    }
    public void fadeFromBlack( float fadeSpeed = 1, int waitBeforeFade = 2, int waitAfterFade = 2, string nextSceneToLoad = "" )
    {
        
        _fadeToBlack = false;

        StartCoroutine( FadeBlackOutSquare( _fadeToBlack, fadeSpeed, waitBeforeFade, waitAfterFade, nextSceneToLoad ) );
        
    }    

    public IEnumerator FadeBlackOutSquare( bool fadeToBlack, float fadeSpeed, int waitBeforeFade, int waitAfterFade, string nextSceneToLoad )
    {

        if( _blackOutSquare != null )
        {

            Color objectColour = _blackOutSquare.GetComponent<Image>().color;

            float fadeAmount;

            if( fadeToBlack )
            {

                _blackOutSquare.GetComponent<Image>().raycastTarget = true;

                yield return new WaitForSeconds( waitBeforeFade );

                while( _blackOutSquare.GetComponent<Image>().color.a < 1 )
                {

                    fadeAmount = objectColour.a + (fadeSpeed * Time.deltaTime );

                    objectColour = new Color( objectColour.r, objectColour.g, objectColour.b, fadeAmount );

                    _blackOutSquare.GetComponent<Image>().color = objectColour;

                    yield return null;

                }

            } else {

                _blackOutSquare.GetComponent<Image>().raycastTarget = true;

                yield return new WaitForSeconds( waitBeforeFade );

                while( _blackOutSquare.GetComponent<Image>().color.a > 0 )
                {

                    fadeAmount = objectColour.a - (fadeSpeed * Time.deltaTime );

                    objectColour = new Color( objectColour.r, objectColour.g, objectColour.b, fadeAmount );

                    _blackOutSquare.GetComponent<Image>().color = objectColour;

                    yield return null;

                }

                _blackOutSquare.GetComponent<Image>().raycastTarget = false;

            }
            
            yield return new WaitForSeconds( waitAfterFade );

            SceneManager.LoadScene( nextSceneToLoad );

        }

    }

}
