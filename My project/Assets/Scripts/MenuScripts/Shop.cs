using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int money = 1000;
    public Text moneyText;
    public Text buys; // �������
    // ���� ����� ������� ��������� �������� ������� � ���������
    public void addItem(string item)
    {
        moneyText.text = money.ToString();
        buys.text += "\n" + item;
    }
}
