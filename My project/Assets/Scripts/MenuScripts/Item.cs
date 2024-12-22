using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int cost;
    public string itemName;
    // ����� ���������� �������
    public void buy()
    {
        // ���� ����� ����������
        if (GetComponentInParent<Shop>().money >= cost)
        {
            // �������� �� ������ ����� ����� ��������� �������
            GetComponentInParent<Shop>().money -= cost;
            GetComponentInParent<Shop>().addItem(itemName);
        }
    }
}
