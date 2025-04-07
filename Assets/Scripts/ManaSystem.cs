using System;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    public MagicStartPosition magicStartPosition;
   //tarvitaan pelaajan mana arvo
   [SerializeField] int mana = 6;
   [SerializeField] int minMana = 0;
   [SerializeField] int minusMana = 1;

    private void Update()
    {
        MANA();
    }
    private void MANA()
    {
        if (mana <= minMana)
        {
            magicStartPosition = null;
        }
        if (mana == minusMana)
        {
            mana -= minusMana;
        }
    }
   //funktio joka käsittelee pelaajan manaa
}
