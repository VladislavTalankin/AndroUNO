using UnityEngine;

public class ChangeValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int last = GameObject.Find("GameProcess").GetComponent<GameStart>().PlayedCards.Count - 1;
        gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameProcess").GetComponent<GameStart>().PlayedCards[last].GetComponent<Transform>().Find("FrontCard").GetComponent<SpriteRenderer>().sprite;
        gameObject.transform.Find("BackgroundPlayedCard").GetComponent<SpriteRenderer>().color = GameObject.Find("GameProcess").GetComponent<GameStart>().PlayedCards[last].GetComponent<Transform>().Find("BackgroundCard").GetComponent<SpriteRenderer>().color;
    }
}
