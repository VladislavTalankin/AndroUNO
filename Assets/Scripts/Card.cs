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
            GameObject Child = gameObject.transform.Find("FrontCard").gameObject;
            Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/card_mask");
            switch (value)
            {
                case TypeOrNumber.Zero: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.One: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Two: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Three: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Four: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Five: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Six: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Seven: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Eight: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Nine: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Pass: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Reverse: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Plus2: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Joker: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;
                case TypeOrNumber.Plus4: Child.GetComponent<SpriteRenderer>().sprite = sprites[(int)value]; break;

            }
            type = value;
        }
    }

}
