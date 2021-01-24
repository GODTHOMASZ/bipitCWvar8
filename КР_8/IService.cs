using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace КР_8
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [DataContract]
    public class DataProviders
    {
        [DataMember(Name = "Id", Order = 1)]
        public string provider_id { get; set; }
        [DataMember(Name = "Provider", Order = 2)]
        public string provider_name { get; set; }
    }
    [DataContract]
    public class DataInvoices
    {
        [DataMember(Name = "Id", Order = 1)]
        public string invoice_id { get; set; }
        [DataMember(Name = "Date", Order = 2)]
        public string date { get; set; }
        [DataMember(Name = "Provider_id", Order = 3)]
        public string provider_id { get; set; }
        [DataMember(Name = "Sum", Order = 4)]
        public string summary { get; set; }
    }
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        DataProviders[] GetProviders();
        [OperationContract]
        DataInvoices[] GetInvoices();
        [OperationContract]
        Dictionary<int, string> Providers();
        [OperationContract]
        void NewProvider(string provider_name);
        [OperationContract]
        void NewInvoice(DateTime date, int provider_id, int summary);
    }
}
