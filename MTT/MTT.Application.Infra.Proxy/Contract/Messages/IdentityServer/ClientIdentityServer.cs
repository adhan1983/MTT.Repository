namespace MTT.Application.Infra.Proxy.Contract.Messages.IdentityServer
{
    public class ClientIdentityServer
    {
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string Scope { get; }        
        public ClientIdentityServer() 
        {
            ClientId = "MTTAPI";
            ClientSecret = "A3M3SL7WqnqyxBDX";
            Scope = "MTTAPI";            
        }
    }
}
