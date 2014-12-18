using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour 
{
    public int deckSize = 1;
    List<GameObject> cardDeck;

    int numberOfRows = 4;

    float cardWidth = 1f;
    float cardHeight = 1.5f;
    //float 

	void FixedUpdate () 
    {
	    if (cardDeck == null || cardDeck.Count != deckSize)
        {
            CreateDeck();
        }
	}

    public void PositionDeck()
    {
        Vector2 position = new Vector2(0f, 0f);
        for (int i = 0; i < cardDeck.Count; i++)
        {
            int numberOfColumns = cardDeck.Count / numberOfRows;
            int extras = cardDeck.Count % numberOfRows;
            Debug.Log("# rows: " + numberOfRows + " # columns: " + numberOfColumns + " # extras: " + extras);
            if (extras > 0) numberOfColumns++;

            //position.x = ;

            cardDeck[i].gameObject.transform.position = position;

        }
    }

    public void CreateDeck()
    {
        if (cardDeck == null)
        {
            cardDeck = new List<GameObject>();
            for (int i = 0; i < deckSize; i++)
            {
                cardDeck.Add(Instantiate(Resources.Load("Card", typeof(GameObject))) as GameObject);
                cardDeck[i].name = i + "Card";
            }
        }
        else if (cardDeck.Count < deckSize)
        {
            for (int i = cardDeck.Count; i < deckSize; i++)
            {
                cardDeck.Add(Instantiate(Resources.Load("Card", typeof(GameObject))) as GameObject);
                cardDeck[i].name = i + "Card";
            }
        }
        PositionDeck();
    }
}
