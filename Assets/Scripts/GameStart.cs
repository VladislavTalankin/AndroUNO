using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject ComputerCard;
    public GameObject PreCard;
    List<GameObject> SortedCards = new List<GameObject>();
    List<GameObject> PlayersHand = new List<GameObject>();
    List<GameObject> ComputersHand = new List<GameObject>();
    List<GameObject> ComputerHandVisual = new List<GameObject>();
    public List<GameObject> PlayedCards = new List<GameObject>();

    void firststep(Card.Colors color)
    {
        for (int i = 0; i <= 14; i++)
        {
            SortedCards.Add(Instantiate(PreCard));
            if (i == 13 || i == 14) SortedCards[SortedCards.Count - 1].GetComponent<Card>().Setup(Card.Colors.Black, (Card.TypeOrNumber)i);
            else SortedCards[SortedCards.Count - 1].GetComponent<Card>().Setup(color, (Card.TypeOrNumber)i);
            SortedCards[SortedCards.Count - 1].name = SortedCards[SortedCards.Count - 1].GetComponent<Card>().Color.ToString() + SortedCards[SortedCards.Count - 1].GetComponent<Card>().Type.ToString();
        }
    }

    void secondstep(Card.Colors color)
    {
        for (int i = 1; i <= 12; i++)
        {
            SortedCards.Add(Instantiate(PreCard));
            SortedCards[SortedCards.Count - 1].GetComponent<Card>().Setup(color, (Card.TypeOrNumber)i);
            SortedCards[SortedCards.Count - 1].name = SortedCards[SortedCards.Count - 1].GetComponent<Card>().Color.ToString() + SortedCards[SortedCards.Count - 1].GetComponent<Card>().Type.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("ColourMenu").GetComponent<Canvas>().enabled = false;

        firststep(Card.Colors.Red);
        firststep(Card.Colors.Orange);
        firststep(Card.Colors.Green);
        firststep(Card.Colors.Blue);

        secondstep(Card.Colors.Red);
        secondstep(Card.Colors.Orange);
        secondstep(Card.Colors.Green);
        secondstep(Card.Colors.Blue);

        SortedCards = SortedCards.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < 7; i++) //раздаем карты игрокам
        {
            PlayersHand.Add(SortedCards[i]);
            SortedCards.Remove(SortedCards[i]);
            ComputersHand.Add(SortedCards[i]);
            SortedCards.Remove(SortedCards[i]);
        }

        PlayedCards.Add(SortedCards[SortedCards.Count - 1]); //разыгрываем первую карту
        SortedCards.Remove(SortedCards[SortedCards.Count - 1]);

        while (PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Color == Card.Colors.Black)
        {
            PlayedCards.Add(SortedCards[SortedCards.Count - 1]);
            SortedCards.Remove(SortedCards[SortedCards.Count - 1]);
        }

        UpdateHand(PlayersHand);
        UpdateComputersHand(ComputersHand);
    }

    private double f(float x)
    {
        return -0.03 * Mathf.Pow(x, 2) - 5;
    }

    private double fproiz(double x)
    {
        return -0.06 * x;
    }

    private double Zrot(double x0)
    {
        return Mathf.Atan((float)(1 / (-1 * fproiz(x0))));
    }

    void UpdateHand(List<GameObject> PlayersHand)
    {
        float i = -6;
        float h = Mathf.Abs(i) / PlayersHand.Count;
        foreach (GameObject PlayCard in PlayersHand)
        {
            if (i == 0)
            {
                PlayCard.transform.position = new Vector2(0, -5);
                PlayCard.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                PlayCard.transform.position = new Vector2(i, (float)f(i));
                PlayCard.transform.rotation = Quaternion.Euler(0, 0, (float)Zrot(i) * Mathf.Rad2Deg - 90);
            }
            i += 2*h;
        }
        foreach (GameObject PlayCard in PlayersHand)
        {
            PlayCard.SetActive(false);
        }
        foreach (GameObject PlayCard in PlayersHand)
        {
            PlayCard.SetActive(true);
        }
    }
    void UpdateComputersHand(List<GameObject> ComputersHand)
    {
        float i = -6;
        float h = Mathf.Abs(i) / ComputersHand.Count;
        foreach (GameObject ComCard in ComputerHandVisual)
        {
            Destroy(ComCard);
        }
        ComputerHandVisual.Clear();
        foreach (GameObject ComCard in ComputersHand)
        {
            if (i != 0)
            {
                ComputerHandVisual.Add(Instantiate(ComputerCard, new Vector2(i, -1*(float)f(i)), Quaternion.Euler(0,0, -1*(float)Zrot(i) * Mathf.Rad2Deg - 90)));
            }
            else
            {
                ComputerHandVisual.Add(Instantiate(ComputerCard, new Vector2(i, 5), Quaternion.Euler(0, 0, 0)));
            }
            i += 2*h;
        }
    }
    void GiveCards(ref List<GameObject> Hand, Card.TypeOrNumber TypeOrNumber)
    {
        if(TypeOrNumber == Card.TypeOrNumber.Plus2)
        {
            Hand.Add(SortedCards[SortedCards.Count - 1]);
            SortedCards.RemoveAt(SortedCards.Count - 1);
            Hand.Add(SortedCards[SortedCards.Count - 1]);
            SortedCards.RemoveAt(SortedCards.Count - 1);
        }
        if(TypeOrNumber == Card.TypeOrNumber.Plus4)
        {
            Hand.Add(SortedCards[SortedCards.Count - 1]);
            SortedCards.RemoveAt(SortedCards.Count - 1);
            Hand.Add(SortedCards[SortedCards.Count - 1]);
            SortedCards.RemoveAt(SortedCards.Count - 1);
            Hand.Add(SortedCards[SortedCards.Count - 1]);
            SortedCards.RemoveAt(SortedCards.Count - 1);
            Hand.Add(SortedCards[SortedCards.Count - 1]);
            SortedCards.RemoveAt(SortedCards.Count - 1);
        }
    }
    public void turn(GameObject playingcard, ref bool GoesBack)
    {
        if (playingcard.GetComponent<Card>().Type == PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Type
            || playingcard.GetComponent<Card>().Color == PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Color
            || playingcard.GetComponent<Card>().Color == Card.Colors.Black)
        {
            if (playingcard.GetComponent<Card>().Type == Card.TypeOrNumber.Plus2)
            {
                GiveCards(ref ComputersHand, Card.TypeOrNumber.Plus2);
                UpdateComputersHand(ComputersHand);
            }
            if (playingcard.GetComponent<Card>().Type == Card.TypeOrNumber.Plus4)
            {
                GiveCards(ref ComputersHand, Card.TypeOrNumber.Plus4);
                UpdateComputersHand(ComputersHand);
            }
            PlayedCards.Add(playingcard);
            PlayersHand.Remove(playingcard);
            UpdateHand(PlayersHand);
            playingcard.transform.position = new Vector3(20, 0, 20);
            if (PlayersHand.Count == 0)
            {
                SceneManager.LoadScene("Victory");
                return;
            }
            if (PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Color == Card.Colors.Black)
            {
                GameObject.Find("ColourMenu").GetComponent<Canvas>().enabled = true;
                return;
            }
            if (playingcard.GetComponent<Card>().Type == Card.TypeOrNumber.Pass || playingcard.GetComponent<Card>().Type == Card.TypeOrNumber.Reverse)
            {
                return;
            }
            else AIturn();
        }
        else
        {
            GoesBack = true;
            return;
        }
    }
    public void TakeCard()
    {
        if (SortedCards.Count == 0)
        {
            SceneManager.LoadScene("Lose");
            return;
        }
        PlayersHand.Add(SortedCards[SortedCards.Count - 1]);
        SortedCards.RemoveAt(SortedCards.Count - 1);
        UpdateHand(PlayersHand);
        AIturn();
    }
    public void AIturn()
    {
        foreach (GameObject choosencard in ComputersHand)
        {
            if (choosencard.GetComponent<Card>().Type == PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Type
            || choosencard.GetComponent<Card>().Color == PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Color
            || choosencard.GetComponent<Card>().Color == Card.Colors.Black)
            {
                if (choosencard.GetComponent<Card>().Type == Card.TypeOrNumber.Plus2)
                {
                    GiveCards(ref PlayersHand, Card.TypeOrNumber.Plus2);
                    UpdateHand(PlayersHand);
                }
                if (choosencard.GetComponent<Card>().Type == Card.TypeOrNumber.Plus4)
                {
                    GiveCards(ref PlayersHand, Card.TypeOrNumber.Plus4);
                    UpdateHand(PlayersHand);
                }
                PlayedCards.Add(choosencard);
                ComputersHand.Remove(choosencard);
                UpdateComputersHand(ComputersHand);
                if(PlayedCards[PlayedCards.Count-1].GetComponent<Card>().Color == Card.Colors.Black)
                {
                    int randomcolor = Random.Range(0, 4);
                    switch (randomcolor)
                    {
                        case 0: PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Color = Card.Colors.Red; break;
                        case 1: PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Color = Card.Colors.Orange; break; 
                        case 2: PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Color = Card.Colors.Green; break;
                        case 3: PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Color = Card.Colors.Blue; break;
                    }
                }
                if (ComputersHand.Count == 0)
                {
                    SceneManager.LoadScene("Lose");
                    return;
                }
                if (SortedCards.Count == 0)
                {
                    SceneManager.LoadScene("Lose");
                    return;
                }
                if (choosencard.GetComponent<Card>().Type == Card.TypeOrNumber.Pass || choosencard.GetComponent<Card>().Type == Card.TypeOrNumber.Reverse) { }
                else return;
            }
        }
        ComputersHand.Add(SortedCards[SortedCards.Count - 1]);
        SortedCards.RemoveAt(SortedCards.Count - 1);
        UpdateComputersHand(ComputersHand);
    }

    public void redbutton()
    {
        GameObject.Find("ColourMenu").GetComponent<Canvas>().enabled = false;
        PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Color = Card.Colors.Red;
        AIturn();
    }

    public void orangebutton()
    {
        GameObject.Find("ColourMenu").GetComponent<Canvas>().enabled = false;
        PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Color = Card.Colors.Orange;
        AIturn();
    }
    public void greenbutton()
    {
        GameObject.Find("ColourMenu").GetComponent<Canvas>().enabled = false;
        PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Color = Card.Colors.Green;
        AIturn();
    }

    public void bluebutton()
    {
        GameObject.Find("ColourMenu").GetComponent<Canvas>().enabled = false;
        PlayedCards[PlayedCards.Count - 1].GetComponent<Card>().Color = Card.Colors.Blue;
        AIturn();
    }

}


