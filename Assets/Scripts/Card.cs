using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum Colors { Red, Orange, Green, Blue, Black };
    private Colors color;
    public enum TypeOrNumber { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Pass, Reverse, Plus2, Joker, Plus4 };
    private TypeOrNumber type;

    public void Setup (Colors color, TypeOrNumber type)
    {
        Color = color;
        Type = type;
    }

    public void Setup(Colors color)
    {
        Color = color;
    }

    public void Setup(TypeOrNumber type)
    {
        Type = type;
    }

    public Colors Color
    {
        get
        {
            return color;
        }

        set
        {
            GameObject Child = gameObject.transform.Find("BackgroundCard").gameObject;
            switch (value)
            {
                case Colors.Red: Child.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1); break;
                case Colors.Orange: Child.GetComponent<SpriteRenderer>().color = new Color(1, 0.725f, 0, 1); break;
                case Colors.Green: Child.GetComponent<SpriteRenderer>().color = new Color(0.15f, 0.725f, 0.086f, 1); break;
                case Colors.Blue: Child.GetComponent<SpriteRenderer>().color = new Color(0, 0.5f, 1, 1); break;
                case Colors.Black: Child.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1); break;
            }
            color = value;
        }
    }

    public TypeOrNumber Type
    {
        get
        {
            return type;
        }

        set
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/card_mask");
            switch (value)
            {
                case TypeOrNumber.Zero: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.One: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Two: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Three: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Four: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Five: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Six: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Seven: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Eight: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Nine: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Pass: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Reverse: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Plus2: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Joker: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Plus4: gameObject.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;

            }
            type = value;
        }
    }

}
