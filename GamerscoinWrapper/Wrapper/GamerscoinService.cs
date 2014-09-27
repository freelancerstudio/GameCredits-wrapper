using System;
using GamerscoinWrapper.Data;
using GamerscoinWrapper.Wrapper.Interfaces;

namespace GamerscoinWrapper.Wrapper
{
    /// <summary>
    /// This class is a helper class to get useful information
    /// </summary>
    public sealed class GamerscoinService : IGamerscoinService
    {
        private readonly IBaseGamerscoinConnector _baseGamerscoinConnector;

        public GamerscoinService(bool isPrimary)
        {
            _baseGamerscoinConnector = new BaseGamerscoinConnector(isPrimary);    
        }

        public Transaction GetTransaction(String txId)
        {
            String rawTransaction = _baseGamerscoinConnector.GetRawTransaction(txId);
            return _baseGamerscoinConnector.DecodeRawTransaction(rawTransaction);
        }
    }
}
