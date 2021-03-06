﻿using System.Security.Cryptography;
using Crypto.Shim;

namespace CoinLib.Wallets
{
    public class RandomWalletAddressProvider : IWalletAddressProvider
    {
        private readonly ushort _buffer;

        public RandomWalletAddressProvider(ushort bitsOfEntropy = 256)
        {
            _buffer = (ushort) (bitsOfEntropy / 8);
        }
        
        public string GenerateAddress(Wallet wallet)
        {
            var randomBytes = new byte[_buffer];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(randomBytes);
            return randomBytes.ToHex();
        }
    }
}