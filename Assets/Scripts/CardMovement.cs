using UnityEngine;

public class CardMovement : MonoBehaviour
{
    Vector2 prepos;
    bool GoesBack = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GoesBack)
        {
            transform.position = Vector3.Lerp(transform.position, prepos, 0.2f);
        }
    }
    private void OnMouseDown()
    {
        GoesBack = false;
        prepos = transform.position;
    }
    void OnMouseDrag()
    {
        Vector3 newposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        newposition = Camera.main.ScreenToWorldPoint(newposition);
        newposition.z = 0;
        gameObject.transform.position = newposition;
    }
    void OnMouseUp()
    {
        if (gameObject.transform.position.x >= -2 && gameObject.transform.position.y >= -3 && gameObject.transform.position.x <= 2 && gameObject.transform.position.y <= 3)
        {
            GameObject.Find("GameProcess").GetComponent<GameStart>().turn(gameObject, prepos);
        }
        else GoesBack = true;
    }
}
