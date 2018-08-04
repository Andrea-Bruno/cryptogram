﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace cryptogram.Core
{
  static class Cryptography
  {
    public static byte[] Encrypt(byte[] Data, byte[] Password)
    {
      System.Security.Cryptography.HashAlgorithm hashType = new System.Security.Cryptography.SHA256Managed();
      byte[] Hash = hashType.ComputeHash(Password);
      var Result = new byte[Data.Length];
      int p = 0;
      for (int i = 0; i < Data.Length - 1; i++)
      {
        Result[i] = (byte)(Data[i] ^ Hash[p]);
        p += 1;
        if (p == Hash.Length)
        {
          p = 0;
          Hash = hashType.ComputeHash(Hash);
        }
      }
      return Result;
    }

    public static byte[] Decrypt(byte[] EncryptedData, byte[] Password)
    {
      return Encrypt(EncryptedData, Password);
    }    
  }
}
