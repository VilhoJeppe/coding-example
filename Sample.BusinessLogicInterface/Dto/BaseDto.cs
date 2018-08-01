namespace Sample.BusinessLogicInterface.Dto
{
    
    public class BaseDto
    {
        public virtual int? Id { get; set; }
      
        public byte[] RowVersion { get; set; }
    }
}
