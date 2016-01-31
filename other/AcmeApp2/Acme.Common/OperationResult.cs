namespace Acme.Common
{
    /// <summary>
    /// Provides a Result flag and message 
    /// useful as a method return type.
    /// </summary>
    /// 
    /// When using a generic type T on a property, we define T on the class signature.
    /// The <T> is a type parameter. By putting that there, the OperationResult class 
    /// becomes a generic class. 
    public class OperationResult<T>
    {
        public OperationResult()
        {
        }

        public OperationResult(T result, string message) : this()
        {
            this.Result = result;
            this.Message = message;
        }

        public T Result { get; set; }
        public string Message { get; set; }
    }

    //// The below class is no longer needed when the above OperationResult 
    //// is turned in to a generic class.
    //public class OperationResultDecimal
    //{
    //    public OperationResultDecimal()
    //    {
    //    }

    //    public OperationResultDecimal(decimal result, string message) : this()
    //    {
    //        this.Result = result;
    //        this.Message = message;
    //    }

    //    public decimal Result { get; set; }
    //    public string Message { get; set; }
    //}

}
