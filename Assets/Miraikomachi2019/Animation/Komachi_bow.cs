using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
 
public class Komachi_bow : MonoBehaviour
{
 
    GameObject mirai;
    Animator miraiAnimator;
    HumanPose miraiPose;
    HumanPoseHandler handler;
    enum Muscles : int
    {
        SpineFrontBack,
        SpineLeftRight,
        SpineTwistLeftRight,
        ChestFrontBack,
        ChestLeftRight,
        ChestTwistLeftRight,
        UpperChestFrontBack,
        UpperChestLeftRight,
        UpperChestTwistLeftRight,
        NeckNodDownUp,
        NeckTiltLeftRight,
        NeckTurnLeftRight,
        HeadNodDownUp,
        HeadTiltLeftRight,
        HeadTurnLeftRight,
        LeftEyeDownUp,
        LeftEyeInOut,
        RightEyeDownUp,
        RightEyeInOut,
        JawClose,
        JawLeftRight,
        LeftUpperLegFrontBack,
        LeftUpperLegInOut,
        LeftUpperLegTwistInOut,
        LeftLowerLegStretch,
        LeftLowerLegTwistInOut,
        LeftFootUpDown,
        LeftFootTwistInOut,
        LeftToesUpDown,
        RightUpperLegFrontBack,
        RightUpperLegInOut,
        RightUpperLegTwistInOut,
        RightLowerLegStretch,
        RightLowerLegTwistInOut,
        RightFootUpDown,
        RightFootTwistInOut,
        RightToesUpDown,
        LeftShoulderDownUp,
        LeftShoulderFrontBack,
        LeftArmDownUp,
        LeftArmFrontBack,
        LeftArmTwistInOut,
        LeftForearmStretch,
        LeftForearmTwistInOut,
        LeftHandDownUp,
        LeftHandInOut,
        RightShoulderDownUp,
        RightShoulderFrontBack,
        RightArmDownUp,
        RightArmFrontBack,
        RightArmTwistInOut,
        RightForearmStretch,
        RightForearmTwistInOut,
        RightHandDownUp,
        RightHandInOut,
        LeftThumb1Stretched,
        LeftThumbSpread,
        LeftThumb2Stretched,
        LeftThumb3Stretched,
        LeftIndex1Stretched,
        LeftIndexSpread,
        LeftIndex2Stretched,
        LeftIndex3Stretched,
        LeftMiddle1Stretched,
        LeftMiddleSpread,
        LeftMiddle2Stretched,
        LeftMiddle3Stretched,
        LeftRing1Stretched,
        LeftRingSpread,
        LeftRing2Stretched,
        LeftRing3Stretched,
        LeftLittle1Stretched,
        LeftLittleSpread,
        LeftLittle2Stretched,
        LeftLittle3Stretched,
        RightThumb1Stretched,
        RightThumbSpread,
        RightThumb2Stretched,
        RightThumb3Stretched,
        RightIndex1Stretched,
        RightIndexSpread,
        RightIndex2Stretched,
        RightIndex3Stretched,
        RightMiddle1Stretched,
        RightMiddleSpread,
        RightMiddle2Stretched,
        RightMiddle3Stretched,
        RightRing1Stretched,
        RightRingSpread,
        RightRing2Stretched,
        RightRing3Stretched,
        RightLittle1Stretched,
        RightLittleSpread,
        RightLittle2Stretched,
        RightLittle3Stretched
    }
 
    // Use this for initialization
    void Start()
    {

        mirai = GameObject.Find("mirai2019_dance");
        miraiAnimator = mirai.GetComponent<Animator>();
        handler = new HumanPoseHandler(miraiAnimator.avatar, miraiAnimator.transform);
        handler.GetHumanPose(ref miraiPose);
        miraiPose.muscles[9] = -20f;
        handler.SetHumanPose(ref miraiPose);
    }

    void musclesStatus() {
        handler.GetHumanPose(ref miraiPose);
		string[] muscleName = HumanTrait.MuscleName;
		int i = 0;
		while (i < HumanTrait.MuscleCount)
		{
            switch (i)
            {
                //case (int)Muscles.LeftArmDownUp:
                //case (int)Muscles.LeftArmTwistInOut:
                //case (int)Muscles.LeftForearmStretch:
                //case (int)Muscles.LeftLowerLegStretch:
                case (int)Muscles.LeftUpperLegFrontBack:
                //case (int)Muscles.RightArmDownUp:
                //case (int)Muscles.RightArmTwistInOut:
                //case (int)Muscles.RightForearmStretch:
                //case (int)Muscles.RightLowerLegStretch:
                //case (int)Muscles.RightUpperLegFrontBack:
                //case (int)Muscles.SpineFrontBack:
			        Debug.Log(i + ":" + muscleName[i] + ":" + miraiPose.muscles[i]);
                    break;
            }
            i++;
		}
	}

    // Update is called once per frame
    void Update()
    {
        musclesStatus();
        for (int i=0;i<miraiPose.muscles.Length;i++){
            miraiPose.muscles[i]=0;
        }
        handler.SetHumanPose(ref miraiPose);
    }

    public void MoveSlider(){
		Debug.Log("Moving");
	}
 
 
}