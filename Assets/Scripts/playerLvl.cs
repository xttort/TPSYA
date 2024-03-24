using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerLvl : MonoBehaviour
{
    public RectTransform expValRectTrans;
    public TextMeshProUGUI lvlText;
    public List<playerProgressLine> levels;

    private float _expcurrval = 0;
    private float _exptargval = 100;

    private int _expcurrlvl = 1;
    void Start()
    {
        setLvl(_expcurrlvl);
        DrawUI();
    }

    // Update is called once per frame
    void Update()
    {
        DrawUI();
        //AddExp(Time.deltaTime*100);
    }

    public void AddExp(float value)
    {
        _expcurrval += value;
        if (_expcurrval >= _exptargval)
        {
            _expcurrval = 0;
            setLvl(_expcurrlvl + 1);
            lvlText.text = _expcurrlvl.ToString();
        }
    }

    private void DrawUI()
    {
        //expValRectTrans
        expValRectTrans.anchorMax = new Vector2(_expcurrval / _exptargval, 1);
    }

    void setLvl(int lvl)
    {
        _expcurrlvl = lvl;

        var currLvl = levels[lvl - 1];
        _exptargval = currLvl.expForNextLvl;
        GetComponent<bulletCaster>().dmg = currLvl.bulletDmg;

        var granCaster = GetComponent<GrenadeCaster>();
        granCaster.dmg = currLvl.granadeDmg;

        if (currLvl.granadeDmg <= 0)
            granCaster.enabled = false;
        else
            granCaster.enabled = true;
    }
}
