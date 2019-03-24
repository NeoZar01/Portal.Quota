using System;

namespace DoE.Quota.ShoppingCart.Norms.Validations.Exceptions
{

    [Serializable]
    public class LearnerGuideException : Exception
    {
        public LearnerGuideException() {}
        public LearnerGuideException(string error) : base(error){}
    }

}
