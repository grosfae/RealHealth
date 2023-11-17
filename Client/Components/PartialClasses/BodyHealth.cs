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
                if(HeadHp == 0)
                {
                    return "#FF131615";
                }
                if (HeadHp <= 15 && HeadHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (HeadHp <= 25 && HeadHp > 15)
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
                if (TorsoHp == 0)
                {
                    return "#FF131615";
                }
                if (TorsoHp <= 35 && TorsoHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (TorsoHp <= 60 && TorsoHp > 35)
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
                if (StomachHp == 0)
                {
                    return "#FF131615";
                }
                if (StomachHp <= 35 && StomachHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (StomachHp <= 55 && StomachHp > 35)
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
                if (LeftHandHp == 0)
                {
                    return "#FF131615";
                }
                if (LeftHandHp <= 20 && LeftHandHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (LeftHandHp <= 40 && LeftHandHp > 20)
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
                if (RightHandHp == 0)
                {
                    return "#FF131615";
                }
                if (RightHandHp <= 20 && RightHandHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (RightHandHp <= 40 && RightHandHp > 20)
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
                if (RightLegHp == 0)
                {
                    return "#FF131615";
                }
                if (RightLegHp <= 20 && RightLegHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (RightLegHp <= 40 && RightLegHp > 20)
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
                if (LeftLegHp == 0)
                {
                    return "#FF131615";
                }
                if (LeftLegHp <= 20 && LeftLegHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (LeftLegHp <= 40 && LeftLegHp > 20)
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
                return HeadHp + TorsoHp + StomachHp + RightHandHp + LeftHandHp + RightLegHp + LeftLegHp;
            }
        }
        public string GeneralColor
        {
            get
            {
                if (HeadHp == 0)
                {
                    return "#FF131615";
                }
                if (HeadHp <= 150 && HeadHp > 0)
                {
                    return "#FFFF0D0D";
                }
                if (HeadHp <= 300 && HeadHp > 150)
                {
                    return "#FFFFD200";
                }
                else
                {
                    return "#FF027902";
                }

            }
        }
    }
}
