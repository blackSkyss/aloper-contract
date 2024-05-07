namespace MBKC.API.Constants
{
    public static class APIEndPointConstant
    {
        private const string ApiEndpoint = "/api";


        public static class ContractEndpoint
        {
            public const string InsertContractEndpoint = ApiEndpoint + "/Contracts/Insert";
            public const string GetContractEndpoint = ApiEndpoint + "/Contracts/GetContractByID/{id}";
            public const string UpdateContractEndpoint = ApiEndpoint + "/Contracts/UpdateContract/{id}";
            public const string CancelContractEndpoint = ApiEndpoint + "/Contracts/EndOfContractByIdRoom/{id}";
            public const string ExportPDFFile = ApiEndpoint + "/Contracts/ExportPDF";
        }
    }
}
