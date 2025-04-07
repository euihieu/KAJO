using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class MagicStartPosition : MonoBehaviour
{
   [SerializeField] private Slider ManaBAr;//lisätty taika häiveiden lisäykseen
   [SerializeField] GameObject PickUP;//lisätty taika häiveiden lisäykseen
   [SerializeField] int plusMana = 2;//lisätty taika häiveiden lisäykseen
   [SerializeField] int mana = 6;//lisätty taika häiveiden lisäykseen
   [SerializeField] int minMana = 0;//lisätty taika häiveiden lisäykseen
   [SerializeField] int minusMana = 1;//lisätty taika häiveiden lisäykseen
   [SerializeField] int maxMana = 6;//lisätty taika häiveiden lisäykseen
    [SerializeField] GameObject MagicBall;
    [SerializeField] Transform ballPositon;
    [SerializeField] float MagicLifeCycle = 4f;
    // kyseinen objekti ja sen Vector koordinaatit + kierre.
    void Update()
    {
      MagicLocation();
      MagicBarUpdater();

      if (mana >= maxMana) //lisätty taika häiveiden lisäykseen
        {
          mana = maxMana;
        }
    }
    

    void MagicLocation() 
    {
      if (Input.GetMouseButtonDown(1) && mana > 0) //lisätty Manan laskemiseen
      {
        GameObject magicBall = Instantiate(MagicBall,ballPositon.position, ballPositon.rotation);
        Destroy(magicBall, MagicLifeCycle) ;
        mana -= minusMana;
        MagicBarUpdater();
        // tässä lisäämme vielä "instantiaten" eli käskyn jopa koskee vain "Klooneja" koska sijoitamme sen omaksi GameObjectiksi. 
        // eli jättää alkuperäisen GameObjectin rauhaan ilman että tuhoaa sitä
        // tämä takaa alku peräisen toimivuuden ajastimen ulkopuolella

        //lisätty taika häiveiden lisäykseen
      }
    }
    // lisätty taika häiveiden lisäykseen 
      private void OnTriggerEnter2D(Collider2D collision)
      {
        if (collision.CompareTag("pickUp"))
         {
           mana += plusMana;
           MagicBarUpdater();
           Destroy(collision.gameObject);
         }
      }
      private void MagicBarUpdater()
    {
        if (ManaBAr != null)
        {
            ManaBAr.value = (int)mana;  // Päivitetään UI:n terveyspalkki
        }
    }
 }   
