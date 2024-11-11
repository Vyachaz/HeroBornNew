using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    
    public Transform camTransform;
    public Transform lightTransform;
    public GameObject directionLight;
    // Start is called before the first frame update
    void Start()
    {
      // // directionLight = GameObject.Find("Directional Light");
      //  Debug.Log(directionLight);
      //  lightTransform = directionLight.GetComponent<Transform>();
      //  Debug.Log(lightTransform.localPosition);
      //
      //  camTransform = this.GetComponent<Transform>();
      //  Debug.Log(camTransform.localPosition);
      //  Debug.Log(camTransform.localRotation);
      //
      //  Character hero = new Character();
      //  hero.PrintStatusInfo();
      //  //hero.Reset();
      //
      //  Character heroine = new Character("Masha");
      //  heroine.PrintStatusInfo();
      //
      //  Weapon huntingBow = new Weapon("Hunting Bow", 105);
      //  huntingBow.PrintWeaponStats();
      //
      //  Weapon varBow = huntingBow;
      //
      //  varBow.name = "Sports Bow";
      //  varBow.damage = 90;
      //
      //
      //  varBow.PrintWeaponStats();
      //
      //  Paladin knight = new Paladin("I AM", huntingBow);
      //  knight.PrintStatusInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
