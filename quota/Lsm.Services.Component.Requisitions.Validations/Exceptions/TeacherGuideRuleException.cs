using System;

namespace DoE.Quota.ShoppingCart.Norms.Validations.Exceptions
{
    [Serializable]
    public class TeacherGuideNormsException : Exception
    {
        public TeacherGuideNormsException() { }
        public TeacherGuideNormsException(string message) : base(message){}
    }
}
