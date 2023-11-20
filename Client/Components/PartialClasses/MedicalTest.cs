using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Components
{
    public partial class MedicalTest
    {
        public int QuestionCount
        {
            get
            {
                return MedicalQuestion.Count;
            }
        }
    }
}
