using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    private static List<Button> menuButton = new List<Button>();

    private void Awake()
    {
        instance = this;
        foreach (Transform button in transform)
        {
            menuButton.Add(button.GetComponent<Button>());
        }

    }
    private void MainPageOperations(int num)
    {
        //  ไล่index ตั้งแต่ page ที่มี index 3ขึ้นไป (หน้าCardType) จนถึงตัวสุดท้าย
        for (int index = 3;index < PageController.instance.page.Count; index++)
        {
            //  ถ้าค่าที่รับมาเพื่อสั่งงานให้เปิดหน้า ตรงกันกับ ค่าที่วนอยู่ใน index รอบนั้น ให้หน้านั้นเปิด
            //  แต่ตัวที่เหลือ ที่มีค่าไม่ตรง ให้ปิดทุกหน้า
            if (num == index)
            {
                PageController.instance.page[index].gameObject.SetActive(true);
            }
            else if (num == 4)
            {
                PageController.instance.page[3].gameObject.SetActive(true);
            }
            else if (num == 5)
            {
                PageController.instance.page[3].gameObject.SetActive(true);
                PageController.instance.page[4].gameObject.SetActive(true);
            }
            else if (num == 6)
            {
                PageController.instance.page[3].gameObject.SetActive(true);
                PageController.instance.page[4].gameObject.SetActive(true);
            }
            else if(num == 9)
            {
                PageController.instance.page[8].gameObject.SetActive(true);
            }
            else
            {
                PageController.instance.page[index].gameObject.SetActive(false);
            }
        }
    }
    private void SeparateOperationsByNumber(int num)
    {
        //  เช็คว่าตัวเลขที่รับมา มันเกินจำนวนหน้า ที่มีไหม
        //  ถ้าเกิน ไม่ทำงาน พร้อมแจ้งขึ้น Console
        //  ถ้าไม่ ทำงานปกติ
        if (num > PageController.instance.page.Count)
        {
            print("ตัวเลขที่คุณส่งมีค่าเกินกว่า index ในตัวแปร page มี กรุณาใส่ให้น้อยกว่าเดิม");
        }
        else
        {
            MainPageOperations(num);
        }
    }

    //  การทำงานของปุ่ม
    public void CardType()
    {
        SeparateOperationsByNumber(3);
    }
    public void Card()
    {
        SeparateOperationsByNumber(4);
    }
    public void CardDescription()
    {
        SeparateOperationsByNumber(5);
    }
    public void CardFilter()
    {
        SeparateOperationsByNumber(6);
    }
    public void Video()
    {
        SeparateOperationsByNumber(7);
    }
    public void BanlistCardType()
    {
        SeparateOperationsByNumber(8);
    }
    public void Banlist()
    {
        SeparateOperationsByNumber(9);
    }
}
