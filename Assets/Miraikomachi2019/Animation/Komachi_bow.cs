using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Komachi_bow : MonoBehaviour
{
  GameObject mirai, angleSlider;
  Animator miraiAnimator;
  HumanPose miraiPose;
  HumanPoseHandler handler;
  AngleControl angleControlScript;
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
    initZeroPose();
    initUpRightPose();
    musclesStatus();

    angleSlider = GameObject.Find("Slider");
    angleControlScript = angleSlider.GetComponent<AngleControl>();
  }

  // Update is called once per frame
  void Update()
  {
    // musclesStatus ();
    getSliderValue();
    handler.SetHumanPose(ref miraiPose);
  }

  private void initZeroPose()
  {
    for (int i = 0; i < HumanTrait.MuscleCount; i++)
    {
      miraiPose.muscles[i] = 0f;
    }
    handler.SetHumanPose(ref miraiPose);
  }

  // 直立のポーズに初期化
  private void initUpRightPose()
  {
    miraiPose.muscles[(int)Muscles.LeftArmDownUp] = -0.6f;
    miraiPose.muscles[(int)Muscles.LeftArmTwistInOut] = 0.15f;
    miraiPose.muscles[(int)Muscles.LeftForearmStretch] = 1f;
    miraiPose.muscles[(int)Muscles.LeftLowerLegStretch] = 0.88f;
    miraiPose.muscles[(int)Muscles.LeftUpperLegFrontBack] = 0.5f;
    miraiPose.muscles[(int)Muscles.RightArmDownUp] = -0.6f;
    miraiPose.muscles[(int)Muscles.RightArmTwistInOut] = 0.15f;
    miraiPose.muscles[(int)Muscles.RightForearmStretch] = 1f;
    miraiPose.muscles[(int)Muscles.RightLowerLegStretch] = 0.88f;
    miraiPose.muscles[(int)Muscles.RightUpperLegFrontBack] = 0.5f;
    miraiPose.muscles[(int)Muscles.SpineFrontBack] = 0f;
    // TODO: Root T および Root Q.x の初期化
    handler.SetHumanPose(ref miraiPose);
  }

  private void musclesStatus()
  {
    string[] muscleName = HumanTrait.MuscleName;
    int i = 0;
    while (i < HumanTrait.MuscleCount)
    {
      //   switch (i)
      //   {
      //     case (int)Muscles.LeftArmDownUp:
      //     case (int)Muscles.LeftArmTwistInOut:
      //     case (int)Muscles.LeftForearmStretch:
      //     case (int)Muscles.LeftLowerLegStretch:
      //     case (int)Muscles.LeftUpperLegFrontBack:
      //     case (int)Muscles.RightArmDownUp:
      //     case (int)Muscles.RightArmTwistInOut:
      //     case (int)Muscles.RightForearmStretch:
      //     case (int)Muscles.RightLowerLegStretch:
      //     case (int)Muscles.RightUpperLegFrontBack:
      //     case (int)Muscles.SpineFrontBack:
      //       Debug.Log((Muscles)System.Enum.ToObject(typeof(Muscles), i) + ":" + muscleName[i] + ":" + miraiPose.muscles[i]);
      //       break;
      //   }
      Debug.Log((Muscles)System.Enum.ToObject(typeof(Muscles), i) + ":" + muscleName[i] + ":" + miraiPose.muscles[i]);
      i++;
    }
  }

  private void getSliderValue()
  {
    float maxValue = angleControlScript.maxValue;
    float minValue = angleControlScript.minValue;
    float sliderValue = angleControlScript.getAngleSliderValue();
    float linearValue = (sliderValue - minValue) / (maxValue - minValue);

    // [parameters of bow_3]
    // 21 Left  Upper Leg Front-Back  :  [0.5 ~ 0.0]
    // 29 Right Upper Leg Front-Back  :  [0.5 ~ 0.0]
    // 0  Spine Front-Back            :  [0.0 ~ -0.5]
    // ?  Root Q.x                    :  [0.0 ~ 0.3]
    miraiPose.muscles[(int)Muscles.LeftUpperLegFrontBack] = 0.5f - 0.5f * linearValue;
    miraiPose.muscles[(int)Muscles.RightUpperLegFrontBack] = 0.5f - 0.5f * linearValue;
    miraiPose.muscles[(int)Muscles.SpineFrontBack] = 0.0f - 0.5f * linearValue;

    float rot = 130 * (0.0f + 0.3f * (sliderValue - minValue) / (maxValue - minValue));
    miraiAnimator.transform.RotateAround(new Vector3(0, 0.8f, 0), new Vector3(1, 0, 0), rot - miraiAnimator.transform.rotation.eulerAngles.x);
  }

}