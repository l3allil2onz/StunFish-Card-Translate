using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoPage : MonoBehaviour
{
    public static VideoPage instance;
    public List<GameObject> childs = new List<GameObject>();
    public List<Button> menuPanelBtn = new List<Button>();
    public List<GameObject> selectedGuideline = new List<GameObject>();

    private void Awake()
    {
        instance = this;
        foreach (Transform rect in transform)
        {
            childs.Add(rect.gameObject);
        }
    }

    void Start()
    {
        selectedGuideline[0].SetActive(true);
        selectedGuideline[1].SetActive(false);
        childs[childs.Count - 2].SetActive(true);
        childs[childs.Count - 1].SetActive(false);
    }
}
