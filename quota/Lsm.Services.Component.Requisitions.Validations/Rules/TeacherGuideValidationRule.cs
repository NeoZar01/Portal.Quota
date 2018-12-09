using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoE.Lsm.ShoppingCart.Norms.Validations.Rules
{
    using Api;
    using Core.Constants;

    public sealed class TeacherGuideValidationRule
    {

        private readonly int teacher_guide_cd_option_x01;
        private readonly int teacher_guide_cd_option_x02;

        public TeacherGuideValidationRule(int teacher_guide_cd_option_x01, int teacher_guide_cd_option_x02)
        {
            this.teacher_guide_cd_option_x01 = teacher_guide_cd_option_x01;
            this.teacher_guide_cd_option_x02 = teacher_guide_cd_option_x02;
        }

        public VettingOutcome output;

        public delegate VettingOutcome TeacherGuidesValidationCallback(int quantity, ref int quota, int category, int teacherCount, int teacher_guide_cd_option_x01, int teacher_guide_cd_option_x02);

        public TeacherGuidesValidationCallback TeacherGuidesCallback;

        public void ActionTeacherGuideValidationWorker(IValidationCallbackContainer callback, int quantity, ref int quota, int category, int teacherCount)
        {
            TeacherGuidesCallback = callback.TeacherGuideQuotaCheckCallback;
            output = TeacherGuidesCallback(quantity, ref quota, category, teacherCount, teacher_guide_cd_option_x01, teacher_guide_cd_option_x02);
        }

    }
}
