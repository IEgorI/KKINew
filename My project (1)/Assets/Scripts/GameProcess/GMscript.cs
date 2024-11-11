using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GMscript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool turn;

    public TextMesh Txt;
    public TextMesh eTxt;
    string text;
    int startTime = 16;
    int curTime=16;


    public CardBase cardbase;
    public GameObject Card_1;
    public GameObject Card_2;
    int[,] cell = new int[,]
    {
        {0, 0, 0, 0 },
        {0, 0, 0, 0 },
        {0, 0, 0, 0 },
        {0, 0, 0, 0 }


    };
    int[,] ecell = new int[,]
   {
        {0, 0, 0, 0 },
        {0, 0, 0, 0 },
        {0, 0, 0, 0 },
        {0, 0, 0, 0 }


   };

    void Start()
    {
        turn = (Random.value > 0.5); //происходит выбор 1 хода
        deal();
        deal2();
        if (turn) StartCoroutine(Timer()); //первый ход главного героя
        else StartCoroutine(eTimer()); //первый ход врага
        Debug.Log(cardbase.CardName[0]);
    }

    IEnumerator Timer() //таймер главного героя
    {
        tChange();
        yield return new WaitForSecondsRealtime (1);
        if (curTime > 0 && turn)
        {
            StartCoroutine(Timer());
        }
        else
        {
            Txt.text = "";
            curTime = 16;
            if (Move_card.dragged==true)
            {
                Move_card.comeback();
            }
            turn=false;
            StartCoroutine(eTimer()); //переход таймера на врага
        }
       
    }
    IEnumerator eTimer() //таймер врага
    {
        etChange();
        yield return new WaitForSecondsRealtime(1);
        if (curTime > 0 && !turn)
        {
            StartCoroutine(eTimer());
        }
        else
        {
            eTxt.text = "";
            curTime = 16;
            if (Move_card.dragged == true)
            {
                Move_card.comeback();
            }
            turn = true;
            StartCoroutine(Timer()); //переход таймера на главного героя
        }

    }
    void tChange()  //происходит смена текста на таймере главного героя
    {
        --curTime;
        text=curTime.ToString();
        Txt.text = text;
        
    }
    void etChange() //происходит смена текста на таймере врага
    {
        --curTime;
        text = curTime.ToString();
        eTxt.text = text;

    }

    void deal() //раздача карт для главного героя
    {
        GameObject[] card = new GameObject[] { Card_1, Card_2 };
        for (int i = 0; i < 4; i++)
        {
            if (cell [i, 0] == 0)
            {
                int number = Random.Range(0, 2);
                GameObject go = Instantiate(card[number]) as GameObject;
                go.transform.parent = GameObject.Find("c"+i.ToString()+"0").transform;
                go.transform.localPosition = Vector3.zero;
                go.layer = 9; //половина поля для главного героя
                cell[i, 0] = 1;
            }
        }
    }
    void deal2() //раздача карт для врага
    {
        GameObject[] card = new GameObject[] { Card_1, Card_2 };
        for (int i = 0; i < 4; i++)
        {
            if (ecell[i, 0] == 0)
            {
                int number = Random.Range(0, 2);
                GameObject go = Instantiate(card[number]) as GameObject;
                go.transform.parent = GameObject.Find("e" + i.ToString() + "0").transform;
                go.transform.localPosition = Vector3.zero;
                go.layer = 10; //половина поля для врага
                ecell[i, 0] = 1;
            }
        }
    }
}
