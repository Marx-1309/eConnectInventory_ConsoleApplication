using eConnect_CSharp_ConsoleApplication.Model.ViewModel;
using Microsoft.Dynamics.GP.eConnect;
using Microsoft.Dynamics.GP.eConnect.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace eConnect_CSharp_ConsoleApplication
{
    public class Inventory
    {
        [STAThread]
        static void Main()
        {
            string sInventoryItemDocument;
            string sXsdSchema;
            string sConnectionString;

            using (eConnectMethods eConnectDbContext = new eConnectMethods())
            {
                try
                {
                    IV00100Vm iV00100Vm = new IV00100Vm
                    {

                        ITEMNMBR = "AX100",
                        ITEMDESC = "Evenson Iipangelwa",
                        ITMSHNAM = "Sucre",
                        ITMGEDSC = "El-Chappo",
                        ITMCLSCD = "CABINETS   ",
                        ITEMTYPE = 1,
                        TAXOPTNS = 2,
                        ITMTSHID = "",
                        UOMSCHDL = "EACH       ",
                        ITEMSHWT = 10,
                        Purchase_Tax_Options = 1,
                        STNDCOST = 50,
                        CURRCOST = 100,
                    };

                    SerializeInventoryObject("InventoryItem.xml", iV00100Vm);

                    // Use an XML document to create a string representation of the customer
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load("InventoryItem.xml");
                    sInventoryItemDocument = xmldoc.OuterXml;

                    // Specify the Microsoft Dynamics GP server and database in the connection string
                    sConnectionString = @"data source=localhost;initial catalog=TWO;integrated security=SSPI;persist security info=False;packet size=4096";

                    // Create an XML Document object for the schema
                    XmlDocument XsdDoc = new XmlDocument();

                    // Create a string representing the eConnect schema
                    sXsdSchema = XsdDoc.OuterXml;

                    // Pass in xsdSchema to validate against.
                    eConnectDbContext.CreateTransactionEntity(sConnectionString, sInventoryItemDocument);

                }
                // The eConnectException class will catch eConnect business logic errors.
                // display the error message on the console
                catch (eConnectException exc)
                {
                    Console.Write(exc.ToString());
                }
                // Catch any system error that might occurr.
                // display the error message on the console
                catch (System.Exception ex)
                {
                    Console.Write(ex.ToString());
                }
                finally
                {
                    // Call the Dispose method to release the resources
                    // of the eConnectMethds object
                    eConnectDbContext.Dispose();
                }
            } // end of using statement
        }
        public static void SerializeInventoryObject(string filename,IV00100Vm vmData)
        {
            try
            {

                eConnectType eConnect = new eConnectType();
                // Instantiate a RMCustomerMasterType schema object

                IVCreateIVItemClassType  item = new IVCreateIVItemClassType();
                
                IVItemMasterType ivItemMasterType = new IVItemMasterType {  };

                XmlSerializer serializer = new XmlSerializer(eConnect.GetType());

                taUpdateCreateItemRcd itemIv = new taUpdateCreateItemRcd 
                {
                    ITEMNMBR = vmData.ITEMNMBR,
                    ITEMDESC = vmData.ITEMDESC,
                    ITMSHNAM = vmData.ITMSHNAM,
                    ITMGEDSC = vmData.ITMGEDSC,
                    ITMCLSCD = vmData.ITMCLSCD,
                    ITEMTYPE = vmData.ITEMTYPE, // Assuming 1 represents a specific item type, such as 'Product'
                    VCTNMTHD = 2, // Assuming 2 represents a specific method for validation or calculation
                    TAXOPTNS = vmData.TAXOPTNS, // Assuming 3 represents a certain tax option, such as 'Standard Tax'
                    ITMTSHID = vmData.ITMTSHID,
                    UOMSCHDL = vmData.UOMSCHDL,
                    ITEMSHWT = vmData.ITEMSHWT,
                    Purchase_Tax_Options = vmData.Purchase_Tax_Options,
                    STNDCOST = vmData.STNDCOST,
                    CURRCOST = vmData.CURRCOST,
                    //TCC = "TCC001",
                    //CNTRYORGN = "USA",
                    //DECPLQTY = 2, // Decimal places for quantity
                    //DECPLCUR = 2, // Decimal places for currency
                    ////PURCHASE_TAX_OPTIONS = 4, // Represents a specific tax option for purchase
                    ////PURCHASE_ITEM_TAX_SCHEDU = "StandardTaxSchedule",
                    //STNDCOST = 49.99m, // Standard cost in USD
                    //CURRCOST = 45.50m, // Current cost in USD
                    //LISTPRCE = 59.99m, // List price in USD
                    //NOTETEXT = "This widget is designed for durability and performance.",
                    //ALTITEM1 = "B789012",
                    //ALTITEM2 = "C345678",
                    //ITMTRKOP = 1, // Tracking option
                    //LOTTYPE = "Batch",
                    //LOTEXPWARN = 90, // Days until expiration warning
                    //LOTEXPWARNDAYS = 30, // Days before expiration to warn
                    //INCLUDEINDP = 1, // 1 might indicate inclusion in certain reports or processes
                    //MINSHELF1 = 6, // Minimum shelf life in months
                    //MINSHELF2 = 12, // Minimum shelf life in months for extended versions
                    //ALWBKORD = 100, // Allowed backorder quantity
                    //WRNTYDYS = 365, // Warranty period in days
                    //ABCCODE = 10, // Code representing a specific category or attribute
                    //USCATVLS_1 = "Electronics",
                    //USCATVLS_2 = "Widgets",
                    //USCATVLS_3 = "Premium",
                    //USCATVLS_4 = "2024",
                    //USCATVLS_5 = "NewArrival",
                    //USCATVLS_6 = "InStock",
                    //KPCALHST = 15, // Calibration history code
                    //KPERHIST = 20, // Performance history code
                    //KPTRXHST = 25, // Transaction history code
                    //KPDSTHST = 30, // Discount history code
                    //IVIVACTNUMST = "IVACT001",
                    //IVIVOFACTNUMST = "IVACT002",
                    //IVCOGSACTNUMST = "IVCOG001",
                    //IVSLSACTNUMST = "IVSLS001",
                    //IVSLDSACTNUMST = "IVSLDS001",
                    //IVSLRNACTNUMST = "IVSLRNACT001",
                    //IVINUSACTNUMST = "IVINUS001",
                    //IVINSVACTNUMST = "IVINSV001",
                    //IVDMGACTNUMST = "IVDMG001",
                    //IVVARACTNUMST = "IVVAR001",
                    //DPSHPACTNUMST = "DPSHP001",
                    //PURPVACTNUMST = "PURPV001",
                    //UPPVACTNUMST = "UPPV001",
                    //IVRETACTNUMST = "IVREACT001",
                    ////ASMVRCACTNUMST = "ASMVR001",
                    //KTACCTSR = 50, // Account type or serial code
                    //PRCHSUOM = "Each", // Purchase unit of measure
                    ////REVALUE_INVENTORY = 5, // Inventory revaluation code or method
                    ////TOLERANCE_PERCENTAGE = 0.05m, // Tolerance percentage for overage or shortage
                    //LOCNCODE = "LOC123",
                    //PRICMTHD = 2, // Pricing method code
                    ////PRICEGROUP = "Standard",
                    ////USEQTYOVERAGETOLERANCE = 1, // Flag for using quantity overage tolerance
                    ////USEQTYSHORTAGETOLERANCE = 0, // Flag for using quantity shortage tolerance
                    ////QTYOVERTOLERANCEPERCENT = 10, // Percentage for overage tolerance
                    ////QTYSHORTTOLERANCEPERCENT = 5, // Percentage for shortage tolerance
                    ////USEITEMCLASS = 1, // Flag for using item class
                    ////UPDATEIFEXISTS = 0, // Flag for updating if the item already exists
                    ////REQUESTERTRX = 1001, // Requester transaction ID
                    //USRDEFND1 = "UserDef1",
                    //USRDEFND2 = "UserDef2",
                    //USRDEFND3 = "UserDef3",
                    //USRDEFND4 = "UserDef4",
                    //USRDEFND5 = "UserDef5"
                };

                ivItemMasterType.taUpdateCreateItemRcd = itemIv;

                IVItemMasterType[] iVItemMasterTypes = { ivItemMasterType };

                eConnect.IVItemMasterType = iVItemMasterTypes;


                // Create objects to create file and write the customer XML to the file
                FileStream fs = new FileStream(filename, FileMode.Create);
                XmlTextWriter writer = new XmlTextWriter(fs, new UTF8Encoding());

                // Serialize the eConnectType object to a file using the XmlTextWriter.
                serializer.Serialize(writer, eConnect);
                writer.Close();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
