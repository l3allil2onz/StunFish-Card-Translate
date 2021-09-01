using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour
{
    public static PageController instance;
    public GameObject pageWaitingPoint;
    public Animator typeCardPageAnim,cardPageAnim, videoPageAnim, banlistPageAnim, banlistCardTypePageAnim;
    public List<GameObject> page = new List<GameObject>();
    public int selectedCardIndex;

    private void Awake()
    {
        instance = this;
        //  เก็บทุกหน้ามาเป็น GameObject
        foreach(Transform pageTransform in transform)
        {
            page.Add(pageTransform.gameObject);
        }
    }
    private void Start()
    {
        //  ปิดทุกหน้ายกเว้นหน้าMainMenu (index ที่ 2) เมื่อเปิดแอพ
        for(int index = 2; index < page.Count; index++)
        {
            if (index > 2)
            {
                page[index].transform.gameObject.SetActive(false);
            }
        }
    }
}
