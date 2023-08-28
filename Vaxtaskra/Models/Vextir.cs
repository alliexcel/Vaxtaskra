using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vaxtaskra.Models
{
    public class Vaxtafotur_extra
    {
        public Vaxtafotur vaxtafotur { get; set; }
        public string vextir { get; set; }
    }
    public class Vaxtaruna_interest_extra
    {
        public Vaxtaruna_interests vaxtaruna_int { get; set; }
        public string SpreadString { get; set; }
        public string Runuheiti { get; set; }
        public int Vaxtaruna_interestID { get; set; }

    }
    public class Vaxtaruna_all
    {
        public Vaxtaruna Vaxtaruna { get; set; }
        public string SpreadString { get; set; }
        public Vaxtaruna_interests VaxtarunaInterests { get; set; }
        public Vaxtafotur Vaxtafotur { get; set; }
        public Vaxtafotur_interests Vaxtafotur_interests { get; set; }

    }

    public class Product_indexation_extra
    {
        public Product_indexation product_indexation { get; set; }
        public string verðtryggt { get; set; }
        
    }

    public class Indexed
    {
        public string IndexedType { get; set; }

    }
    public class vaxtasagas_full
    {
        public int VaxtarunaID { get; set; }
        public int VaxtafoturID { get; set; }
        public string Vaxtafotur { get; set; }
        public string Vaxtaruna { get; set; }
        public decimal Vaxtafotur_interests { get; set; }
        public decimal Vaxtaruna_interests { get; set; }
        public DateTime DateChange { get; set; }
        public decimal Vextir_total { get; set; }
        public bool is_lending { get; set; }
        public bool is_indexed { get; set; }



    }

    public class Product_Create
    {
       public Product Product { get; set; }
       public bool Is_Indexed { get; set; }     
        public int Indexed_MaxNumberPayments { get; set; }
        public int Indexed_MinNumberPayments { get; set; }
        public bool IndexedEqualPayments { get; set; }
        public bool IndexedAnnuited { get; set; }
        public bool Is_None_Indexed { get; set; }
        public int NotIndexed_MaxNumberPayments { get; set; }
        public int NotIndexed_MinNumberPayments { get; set; }
        public bool NotIndexedEqualPayments { get; set; }
        public bool NotIndexedAnnuited { get; set; }

    }

    public class vaxtaf
    {
        public string Heiti { get; set; }
        public bool? is_indexed { get; set; }
        public decimal vextir { get; set; }
    }

    public class Vaxtarunur_list
    {
        public int Vaxtafotur_ID { get; set; }
        public int Vaxtaruna_ID { get; set; }
        public string Vaxtafotur_heiti { get; set; }
        public string Vaxtaruna_heiti { get; set; }
        public decimal Vaxtafotur_interest { get; set; }
        public int Vaxtaruna_interestsID { get; set; }
        public decimal Spread { get; set; }
        public decimal interests_total { get; set; }
        public DateTime effective_date { get; set; }
        public bool is_fixed { get; set; }
        public bool is_indexed { get; set; }
        public decimal amount_from { get; set; }
        public decimal amount_to { get; set; }
        public string vextir_greidast { get; set; }
        public bool is_deposit { get; set; }
        public int Months_Tied { get; set; }

        public bool selectLending { get; set; }
        public bool selectIndexed { get; set; }
        public bool selectNonIndexed { get; set; }
        public bool selectDeposit { get; set; }
        public bool selectFixed { get; set; }

    }


}