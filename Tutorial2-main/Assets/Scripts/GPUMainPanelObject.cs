using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPUMainPanelObject : MonoBehaviour
{
    public GPUData data;
    public float Damage;
    public float Temperature;
    public string tear;
    [SerializeField] Text damageTxt;

    public Animator anim;
    private void Start()
    {
        switch (data.GP)
        {
            case "1050 TI":
                anim.SetBool("gtx1050", true);
                break;
            case "Graphics 1":
                anim.SetBool("intel1", true);
                break;
            case "X":
                anim.SetBool("intelX", true);
                break;
            case "RED":
                anim.SetBool("intelRed", true);
                break;
            case "RTX 2060 Super":
                anim.SetBool("rtx2060", true);
                break;
            case "RTX 3090":
                anim.SetBool("rtx3090", true);
                break;
            case "RTX 4000":
                anim.SetBool("rtx4000", true);
                break;
            case "RX 570":
                anim.SetBool("rx570", true);
                break;
            case "RX 590":
                anim.SetBool("rx590", true);
                break;
            case "RX 5600":
                anim.SetBool("rx5600", true);
                break;
            case "RX 6700XT":
                anim.SetBool("rx6700", true);
                break;
            case "RX 6900":
                anim.SetBool("rx6900", true);
                break;
            case "Predator":
                anim.SetBool("predator", true);
                break;
            case "RTX 5000":
                anim.SetBool("rtx5000", true);
                break;
            case "RX 9000":
                anim.SetBool("rx9000", true);
                break;
        }
    }

    private void Update()
    {
       
    }
    bool ok = true;
    public void UpdateValues()
    {
        damageTxt.text = Damage.ToString("0") + "%";
        if (Damage < 1f) { if (ok) { FindObjectOfType<AudioManager>().PlayAudio(4); anim.enabled = false; Damage = 0f; damageTxt.text = "0%"; ok = false; } }
        if (Damage < 35f) { damageTxt.color = Color.red; gameObject.transform.GetChild(2).GetComponent<ParticleSystem>().Play(); }
        if (Damage >= 35f && Damage <= 60f) { damageTxt.color = Color.yellow; }
        if (Damage > 60f) { damageTxt.color = Color.green; }
        GetComponent<Image>().sprite = data.sprite;
        
    }
}
