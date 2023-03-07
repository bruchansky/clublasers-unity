using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClubLaserCombo
{
    public Vector3 initTranslation; // initial laser position (laser is following y axe)
    public Vector3 initAngle; // initial laser angle 
    public Vector3 incrRotation; // laser rotation at each step
    public int incrBeforeSwitchDirection; // number of increments before changing side (0 = disabled)
}

public class ClubLaser : MonoBehaviour
{
    public int laserBPM = 10;  // speed of the laser
    public ClubLaserCombo[] laserCombos;

    private Vector3 originalParentPosition;
    private Vector3 originalParentAngle;
    private int currentBeat = 0;
    private int currentCombo = 0;
    private int mirrorBeat = 0;

    void Start()
    {
        originalParentPosition = transform.parent.transform.localPosition;
        originalParentAngle = transform.parent.transform.localEulerAngles;
        InitiateCombo(0);
    }

    void InitiateCombo(int comboNumber)
    {
        mirrorBeat = 0;
        // reset positions and angles
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        transform.parent.transform.localEulerAngles = originalParentAngle;
        transform.parent.transform.localPosition = originalParentPosition;

        // define incremental rotations and translations
        transform.Rotate(laserCombos[comboNumber].initAngle, Space.Self);
        transform.Translate(laserCombos[comboNumber].initTranslation, Space.Self);
        if (laserCombos[comboNumber].incrBeforeSwitchDirection > 0) transform.parent.transform.Rotate(-laserCombos[comboNumber].incrRotation * laserCombos[comboNumber].incrBeforeSwitchDirection, Space.Self);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentBeat < (50 * 60) / (laserBPM)) currentBeat++; // 50 fixedUpdate per seconds
        else {
            // switches combo randomly
            int changeCombo = Random.Range(0, 100);
            if (changeCombo > 95) 
            {
                int oldCombo = currentCombo;
                currentCombo = Random.Range(0, laserCombos.Length);
                if (oldCombo != currentCombo) InitiateCombo(currentCombo);
            }
            else
            {
                // changes direction if mirror is set
                if (laserCombos[currentCombo].incrBeforeSwitchDirection > 0)
                {
                    if (mirrorBeat == 1 + laserCombos[currentCombo].incrBeforeSwitchDirection * 2)
                    {
                        laserCombos[currentCombo].incrRotation = -laserCombos[currentCombo].incrRotation;
                        mirrorBeat = 0;
                    }
                    else mirrorBeat++;
                }

                // regular rotation
                transform.parent.transform.Rotate(laserCombos[currentCombo].incrRotation, Space.Self);
            }
            currentBeat = 0;
        }
    }
}
