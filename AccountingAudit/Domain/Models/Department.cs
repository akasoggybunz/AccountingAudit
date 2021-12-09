namespace AccountingAudit.Domain.Models
{
    public class Department
    {
        /// <summary>
        ///  Dept name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public string remarks { get; set; }

        /// <summary>
        /// year
        /// </summary>
        public long FiscalYear { get; set; }


        /// <summary>
        /// fundAvb
        /// </summary>
        public long FundsAvailable { get; set; }

        /// <summary>
        /// FundsUsed
        /// </summary>
        public long FundsUsed { get; set; }
    }
}
