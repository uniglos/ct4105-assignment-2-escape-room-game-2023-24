using UnityEngine;

public class DragMatchingObject: MonoBehaviour
{
    [SerializeField]
    private GameObject objectToDrag;

    [SerializeField]
    private GameObject dropTarget;

    private Vector3 initialPosition;

    private Vector2 mousePosition;

    private float deltaX, deltaY;

    private bool locked;

    // Start is called before the first frame update
    void Start()
    {
        

        initialPosition = objectToDrag.transform.position;

        GetComponent<BoxCollider2D>().size = new Vector2( GetComponent<RectTransform>().rect.width, GetComponent<RectTransform>().rect.height ) ;

        GetComponent<BoxCollider2D>().offset = new Vector2( GetComponent<RectTransform>().rect.width / 2, -GetComponent<RectTransform>().rect.height / 2 ) ;

    }
    
    private void OnMouseDown() 
    {

        if( !locked )
        {

            deltaX = Camera.main.ScreenToWorldPoint( Input.mousePosition ).x - objectToDrag.transform.position.x;
            
            deltaY = Camera.main.ScreenToWorldPoint( Input.mousePosition ).y - objectToDrag.transform.position.y;

        }   
    
    }

    private void OnMouseDrag()
    {
        
        if( !locked )
        {

            mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );

            objectToDrag.transform.position = new Vector3( mousePosition.x - deltaX, mousePosition.y - deltaY, initialPosition.z );

        }

    }

    private void OnMouseUp()
    {
        
        if( Mathf.Abs( objectToDrag.transform.position.x - dropTarget.transform.position.x ) <= 0.5f &&
            Mathf.Abs( objectToDrag.transform.position.y - dropTarget.transform.position.y) <= 0.5f)
        {
            
            objectToDrag.transform.position = new Vector3( dropTarget.transform.position.x, dropTarget.transform.position.y, initialPosition.z );
            
            Destroy( dropTarget );

            locked = true;

            GameObject.Find("DragMatchingObjectManager").GetComponent<DragMatchingObjectManager>().objectsMatched++;

        } else {

            objectToDrag.transform.position = new Vector3( initialPosition.x, initialPosition.y, initialPosition.z );

        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

}