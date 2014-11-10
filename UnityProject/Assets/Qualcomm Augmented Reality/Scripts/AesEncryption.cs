using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Security.Cryptography;

public class AesEncryption {

	public static string encrypt(string password)
	{
		byte[] cipher;
		using (Aes aes = Aes.Create ())
		{
			cipher = EncryptStringToBytes_Aes(password, aes.Key, aes.IV);

			// For debug
			Debug.Log (DecryptStringFromBytes_Aes(cipher, aes.Key, aes.IV));
		}

		return cipher.ToString ();
	}

	static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
	{
		if (plainText == null || plainText.Length <= 0)
			throw new ArgumentNullException ("plaintext");
		if (Key == null || Key.Length <= 0)
			throw new ArgumentNullException ("key");
		if (IV == null || IV.Length <= 0)
			throw new ArgumentNullException ("IV");

		byte[] encrypted;
		using (Aes aes = Aes.Create ())
		{
			aes.Key = Key;
			aes.IV = IV;

			ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
			using (MemoryStream msEncrypt = new  MemoryStream())
			{
				using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
				{
					using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
					{
						swEncrypt.Write (plainText);
					}
					encrypted = msEncrypt.ToArray();
				}
			}
		}
		return encrypted;
	}

	static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
	{
		// Check arguments. 
		if (cipherText == null || cipherText.Length <= 0)
			throw new ArgumentNullException("cipherText");
		if (Key == null || Key.Length <= 0)
			throw new ArgumentNullException("Key");
		if (IV == null || IV.Length <= 0)
			throw new ArgumentNullException("Key");
		
		// Declare the string used to hold 
		// the decrypted text. 
		string plaintext = null;
		
		// Create an Aes object 
		// with the specified key and IV. 
		using (Aes aesAlg = Aes.Create())
		{
			aesAlg.Key = Key;
			aesAlg.IV = IV;
			
			// Create a decrytor to perform the stream transform.
			ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
			
			// Create the streams used for decryption. 
			using (MemoryStream msDecrypt = new MemoryStream(cipherText))
			{
				using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
				{
					using (StreamReader srDecrypt = new StreamReader(csDecrypt))
					{
						
						// Read the decrypted bytes from the decrypting stream
							// and place them in a string.
							plaintext = srDecrypt.ReadToEnd();
					}
				}
			}
			
		}
		
		return plaintext;
		
	}
}
