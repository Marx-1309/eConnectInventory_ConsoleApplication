using System;
using System.ServiceModel;
using ExceptionHandling.eConnectIntegrationService;
using Microsoft.Dynamics.GP.eConnect;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            eConnectClient client = null;
            try
            {
                // Instantiate an eConnectClient object
                client = new eConnectClient();

                // Get a requestor document for a specified customer
                string customer = client.GetEntity(ConnectionString("localhost", "TWO"), SpecifyCustomer("AARONFIT0001"));

                // Show customer XML document in the console window
                Console.WriteLine(customer);
                Console.WriteLine("\n\nTo continue, press any key");
                Console.ReadKey(false);
            }
            catch (FaultException<eConnectFault> eFault)
            {
                Console.WriteLine(eFault.ToString());
                Console.WriteLine("\n\nTo continue, press any key");
                Console.ReadKey(false);
            }
            catch (FaultException<eConnectSqlFault> sqlFault)
            {
                Console.WriteLine(sqlFault.ToString());
                Console.WriteLine("\n\nTo continue, press any key");
                Console.ReadKey(false);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                Console.WriteLine("\n\nTo continue, press any key");
                Console.ReadKey(false);
            }
            finally
            {
                if (client != null)
                {
                    client.Dispose();
                }
            }
        }

        // Return a string that represents a transaction requestor XML 
        // document for the specified customer
        static string SpecifyCustomer(string custID)
        {
            return String.Format(@"<?xml version=""1.0"" ?>
             <eConnect 
             xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
             xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
             <RQeConnectOutType><eConnectProcessInfo xsi:nil=""true"" />
             <taRequesterTrxDisabler_Items xsi:nil=""true"" />
             <eConnectOut><DOCTYPE>Customer</DOCTYPE>
             <OUTPUTTYPE>1</OUTPUTTYPE><INDEX1TO>{0}</INDEX1TO>
            <INDEX1FROM>{1}</INDEX1FROM><FORLIST>1</FORLIST>
             </eConnectOut></RQeConnectOutType></eConnect>",
                         custID, custID);
        }

        // Return a string that represents an eConnect connection string
        // to the specified server and database
        static string ConnectionString(string dataSource, string catalog)
        {
            return String.Format(@"data source={0}; initial catalog={1}; 
                                     integrated security=SSPI; persist security info=False; 
                                     packet size=4096", dataSource, catalog);
        }
    }
}
