namespace be_ipubers_kartan.Constants
{
    public static class ResponseCodeMapping
    {
        // Success
        public const int Success = 200;
        public const int SuccessDuplicate = 201;
        public const int SuccessReversalDuplicate = 202;

        // Client Errors
        public const int ErrorValidation = 400;
        public const int ErrorStock = 401;
        public const int ErrorNotaSyncFailed = 402;
        public const int ErrorRetailerEmployeeNotFound = 403;
        public const int ErrorRetailerActivationStatus = 404;
        public const int ErrorTimeout = 405;
        public const int ErrorInvalidCommodity = 406;
        public const int ErrorNotaAlreadyExists = 407;
        public const int ErrorNotaNotFound = 408;
        public const int ErrorDuplicateReferenceNumber = 409;
        public const int ErrorRetailerProductNotFound = 410;

        // Server Errors
        public const int ErrorServer = 500;
    }
}