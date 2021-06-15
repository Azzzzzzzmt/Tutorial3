using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelection : MonoBehaviour
{
    public int state;
    public Image[] img;
    public Text[] txt;
    public Image[] back;

    public Sprite[] sprites1;
    public Sprite[] sprites2;
    public Sprite[] spritesBack;
    private void Start()
    {
        ChangeState(0);
    }
    public void ChangeState(int to)
    {
        state = to;
        if(state == 0)
        {
            img[0].sprite = sprites1[1];
            txt[0].color = Color.black;
            back[0].sprite = spritesBack[1];

            img[1].sprite = sprites2[0];
            txt[1].color = Color.white;
            back[1].sprite = spritesBack[0];
        }
        if(state == 1)
        {
            img[0].sprite = sprites1[0];
            txt[0].color = Color.white;
            back[0].sprite = spritesBack[0];

            img[1].sprite = sprites2[1];
            txt[1].color = Color.black;
            back[1].sprite = spritesBack[1];
        }
    }
}
