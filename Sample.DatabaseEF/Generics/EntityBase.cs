using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.DatabaseEF.Generics
{
    public abstract class EntityBase
    {
        //Make sure that database has generated identity key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Handles concurrency inside EF
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
