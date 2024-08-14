using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eConnect_CSharp_ConsoleApplication.Model.ViewModel
{
    public class IV00100Vm
    {
        public string ITEMNMBR { get; set; }

        public string ITEMDESC { get; set; }

        public string ITMSHNAM { get; set; }

        public string ITMGEDSC { get; set; }

        public string ITMCLSCD { get; set; }

        public short ITEMTYPE { get; set; }

        public short TAXOPTNS { get; set; }

        public string ITMTSHID { get; set; }

        public string UOMSCHDL { get; set; }

        public decimal ITEMSHWT { get; set; }

        public short Purchase_Tax_Options { get; set; }

        public decimal STNDCOST { get; set; }

        public decimal CURRCOST { get; set; }
    }
}
