using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject rifle;
    [SerializeField] GameObject uzi;

    public enum Weapons { Pistol, Shotgun, Rifle, Uzi};
    Weapons weapon;
    
    int level = 0;
    public void LevelUp()
    {
        level += 1;
        //if (level <= 4)
        //{
        //    switch (level)
        //    {
        //        case 1:
        //            ChooseWeapon(Weapons.Pistol);
        //            break;
        //        case 2:
        //            ChooseWeapon(Weapons.Shotgun);
        //            break;
        //        case 3:
        //            ChooseWeapon(Weapons.Rifle);
        //            break;
        //        case 4:
        //            ChooseWeapon(Weapons.Uzi);
        //            break;
        //        default:
        //            print("Для этого уровня нет оружия");
        //            break;
        //    }
        //}
        if (level > 4)
        {
            level = 4;
        }
        switch (level)
        {
            case 1:
                ChooseWeapon(Weapons.Pistol);
                break;
            case 2:
                ChooseWeapon(Weapons.Shotgun);
                break;
            case 3:
                ChooseWeapon(Weapons.Rifle);
                break;
            case 4:
                ChooseWeapon(Weapons.Uzi);
                break;
            default:
                print("Для этого уровня нет оружия");
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        LevelUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChooseWeapon(Weapons.Pistol);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChooseWeapon(Weapons.Shotgun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChooseWeapon(Weapons.Rifle);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChooseWeapon(Weapons.Uzi);
        }
        if (Input.GetMouseButton(0))
        {
            switch (weapon) 
            {
                case Weapons.Pistol:
                    pistol.GetComponent<Gun>().Shoot();
                    break;
                case Weapons.Shotgun:
                    shotgun.GetComponent<Gun>().Shoot();
                    break;
                case Weapons.Rifle:
                    rifle.GetComponent<Gun>().Shoot();
                    break;
                case Weapons.Uzi:
                    rifle.GetComponent<Gun>().Shoot();
                    break;
            }
        }
    }
    public void ChooseWeapon(Weapons weapon)
    {
        this.weapon = weapon;
        switch (weapon)
        {
            case Weapons.Pistol:
                pistol.SetActive(true);
                shotgun.SetActive(false);
                rifle.SetActive(false);
                uzi.SetActive(false);
                break;
            case Weapons.Shotgun:
                pistol.SetActive(false);
                shotgun.SetActive(true);
                rifle.SetActive(false);
                uzi.SetActive(false);
                break;
            case Weapons.Rifle:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                rifle.SetActive(true);
                uzi.SetActive(false);
                break;
            case Weapons.Uzi:
                pistol.SetActive(false);
                shotgun.SetActive(false);
                rifle.SetActive(false);
                uzi.SetActive(true);
                break;
        }
    }

}
