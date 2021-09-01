using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownFilter : MonoBehaviour
{
    public Dropdown selfDropdown;
    private void Start()
    {
        int childCount = transform.childCount;
        selfDropdown = transform.GetChild(childCount - 1).GetComponent<Dropdown>();
    }
}
