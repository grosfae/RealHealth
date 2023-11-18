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
                return leftLeg;
            }
        }

        public string HealthStatus
        {
            get
            {
                if (GeneralHealth == 0)
                {
                    return "Вызовите скорую";
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
