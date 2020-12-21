using System;

namespace BusinessRulesEngine
{
    public class PackingSlip : Item
    {
        public DateTime PurchaseDate { get; set; }

        public double TotalPrice { get; set; }

        public virtual bool Perform()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }


}