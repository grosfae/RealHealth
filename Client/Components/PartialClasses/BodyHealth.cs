using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Components
{
    public partial class BodyHealth
    {
        public string HeadColor
        {
            get
            {
                if(HeadEffectsHp == 0)
                {
                    return "#FF131615";
                }
                if (HeadEffectsHp <= 15 && HeadEffectsHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (HeadEffectsHp <= 25 && HeadEffectsHp > 15)
                {
                    return "#FFFFD200";
                }
                else
                {
                    return "#FF027902";
                }

            }
        }
        public string TorsoColor
        {
            get
            {
                if (TorsoEffectsHp == 0)
                {
                    return "#FF131615";
                }
                if (TorsoEffectsHp <= 35 && TorsoEffectsHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (TorsoEffectsHp <= 60 && TorsoEffectsHp > 35)
                {
                    return "#FFFFD200";
                }
                else
                {
                    return "#FF027902";
                }

            }
        }

        public string StomachColor
        {
            get
            {
                if (StomachEffectsHp == 0)
                {
                    return "#FF131615";
                }
                if (StomachEffectsHp <= 35 && StomachEffectsHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (StomachEffectsHp <= 55 && StomachEffectsHp > 35)
                {
                    return "#FFFFD200";
                }
                else
                {
                    return "#FF027902";
                }

            }
        }
        public string RightHandColor
        {
            get
            {
                if (RightHandEffectsHp == 0)
                {
                    return "#FF131615";
                }
                if (RightHandEffectsHp <= 20 && RightHandEffectsHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (RightHandEffectsHp <= 40 && RightHandEffectsHp > 20)
                {
                    return "#FFFFD200";
                }
                else
                {
                    return "#FF027902";
                }

            }
        }

        public string LeftHandColor
        {
            get
            {
                if (LeftHandEffectsHp == 0)
                {
                    return "#FF131615";
                }
                if (LeftHandEffectsHp <= 20 && LeftHandEffectsHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (LeftHandEffectsHp <= 40 && LeftHandEffectsHp > 20)
                {
                    return "#FFFFD200";
                }
                else
                {
                    return "#FF027902";
                }

            }
        }
        public string RightLegColor
        {
            get
            {
                if (RightLegEffectsHp == 0)
                {
                    return "#FF131615";
                }
                if (RightLegEffectsHp <= 20 && RightLegEffectsHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (RightLegEffectsHp <= 40 && RightLegEffectsHp > 20)
                {
                    return "#FFFFD200";
                }
                else
                {
                    return "#FF027902";
                }

            }
        }

        public string LeftLegColor
        {
            get
            {
                if (LeftLegEffectsHp == 0)
                {
                    return "#FF131615";
                }
                if (LeftLegEffectsHp <= 20 && LeftLegEffectsHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (LeftLegEffectsHp <= 40 && LeftLegEffectsHp > 20)
                {
                    return "#FFFFD200";
                }
                else
                {
                    return "#FF027902";
                }

            }
        }

        public int GeneralHealth
        {
            get
            {
                return HeadEffectsHp + TorsoEffectsHp + StomachEffectsHp + RightHandEffectsHp + LeftHandEffectsHp + RightLegEffectsHp + LeftLegEffectsHp;
            }
        }
        public string GeneralColor
        {
            get
            {
                if (GeneralHealth == 0)
                {
                    return "#FF131615";
                }
                if (GeneralHealth <= 150 && GeneralHealth > 0)
                {
                    return "#FFFF0D0D";
                }
                if (GeneralHealth <= 300 && GeneralHealth > 150)
                {
                    return "#FFFFD200";
                }
                else
                {
                    return "#FF30CA10";
                }

            }
        }

        public int HeadEffectsHp
        {
            get
            {
                int head = HeadHp;
                foreach (var effect in BodyHealthEffect)
                {
                    head -= effect.Effect.HeadHpDecrease;
                }
                if(head < 0)
                {
                    head = 0;
                }
                return head;
            }
        }
        public int TorsoEffectsHp
        {
            get
            {
                int torso = TorsoHp;
                foreach (var effect in BodyHealthEffect)
                {
                    torso -= effect.Effect.TorsoHpDecrease;
                }
                if (torso < 0)
                {
                    torso = 0;
                }
                return torso;
            }
        }
        public int StomachEffectsHp
        {
            get
            {
                int stomach = StomachHp;
                foreach (var effect in BodyHealthEffect)
                {
                    stomach -= effect.Effect.StomachHpDecrease;       
                }
                if (stomach < 0)
                {
                    stomach = 0;
                }
                return stomach;
            }
        }

        public int LeftHandEffectsHp
        {
            get
            {
                int leftHand = LeftHandHp;
                foreach (var effect in BodyHealthEffect)
                {
                    leftHand -= effect.Effect.LeftHandHpDecrease;
                }
                if (leftHand < 0)
                {
                    leftHand = 0;
                }
                return leftHand;
            }
        }

        public int RightHandEffectsHp
        {
            get
            {
                int rightHand = RightHandHp;
                foreach (var effect in BodyHealthEffect)
                {
                    rightHand -= effect.Effect.RightHandHpDecrease;
                }
                if (rightHand < 0)
                {
                    rightHand = 0;
                }
                return rightHand;
            }
        }

        public int RightLegEffectsHp
        {
            get
            {
                int rightLeg = RightLegHp;
                foreach (var effect in BodyHealthEffect)
                {
                    rightLeg -= effect.Effect.RightHandHpDecrease;
                }
                if (rightLeg < 0)
                {
                    rightLeg = 0;
                }
                return rightLeg;
            }
        }

        public int LeftLegEffectsHp
        {
            get
            {
                int leftLeg = LeftLegHp;
                foreach (var effect in BodyHealthEffect)
                {
                    leftLeg -= effect.Effect.LeftLegHpDecrease;
                }
                if (leftLeg < 0)
                {
                    leftLeg = 0;
                }
                return leftLeg;
            }
        }

        public string HealthStatus
        {
            get
            {
                if (GeneralHealth == 0)
                {
                    return "Вызывайте скорую";
                }
                if (GeneralHealth <= 150 && GeneralHealth > 0)
                {
                    return "Срочно обратитесь к доктору";
                }
                if (GeneralHealth <= 300 && GeneralHealth > 150)
                {
                    return "Примите рекомендации лечения";
                }
                else
                {
                    return "Нормально";
                }
            }
        }
    }
}
