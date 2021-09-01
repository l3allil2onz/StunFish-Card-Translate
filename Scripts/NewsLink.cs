using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsLink : MonoBehaviour
{
    public void OpenBSNewsLink()
    {
        Application.OpenURL("https://www.facebook.com/bsthaicard/");
    }
    public void OpenRBNewsLink()
    {
        Application.OpenURL("https://www.facebook.com/groups/457127531571099/");
    }
    public void OpenKiwiNewsLink()
    {
        Application.OpenURL("https://www.facebook.com/alienkiwicardshop/");
    }

    public void Video1()
    {
        Application.OpenURL("https://drive.google.com/file/d/1ileFXgsZQ328F-Z1X1u-BKfXAe_Lvm0U/view?usp=sharing");
    }
    public void Video2()
    {
        Application.OpenURL("https://drive.google.com/file/d/1waS3TGiQtZaX3zIRKZQZX2GjA82M_T5D/view?usp=sharing");
    }
    public void Video3()
    {
        Application.OpenURL("https://drive.google.com/file/d/1PewzI-EE2Kav4RO79nr-Iyk5--2xOco3/view?usp=sharing");
    }
}
