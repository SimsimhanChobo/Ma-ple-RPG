using UnityEngine;

public class UGUIManager : MonoBehaviour
{
    public GameObject Logo;
    public Canvas canvas1;
    public Canvas canvas2;
    public Canvas canvas3;
    public Canvas canvas4;
    public Canvas canvas5;
    public Canvas canvas6;
    public Canvas canvas7;
    public Canvas canvas8;
    public Canvas canvas9;
    public Canvas canvas10;
    public Canvas canvas11;

    void Update()
    {
        if (GameManager.MainMenu)
            Logo.SetActive(true);
        else
            Logo.SetActive(false);

        canvas1.scaleFactor = GameManager.GUISize;
        canvas2.scaleFactor = GameManager.GUISize;
        canvas3.scaleFactor = GameManager.GUISize;
        //canvas4.scaleFactor = GameManager.GUISize;
        canvas5.scaleFactor = GameManager.GUISize;
        //canvas6.scaleFactor = GameManager.GUISize;
        canvas7.scaleFactor = GameManager.GUISize;
        canvas8.scaleFactor = GameManager.GUISize;
        canvas9.scaleFactor = GameManager.GUISize;
        canvas10.scaleFactor = GameManager.GUISize;
        canvas11.scaleFactor = GameManager.GUISize;
    }
}
